using System.Reflection;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OmopTransformer.Annotations;
using OmopTransformer.Documentation.Charting;
using OmopTransformer.Omop;
using OmopTransformer.Transformation;

namespace OmopTransformer.Documentation;

internal class DocumentationRenderer
{
    private readonly IReadOnlyCollection<Type> _types;
    private readonly IQueryLocator _queryLocator;
    private readonly ILogger<DocumentationWriter> _logger;
    private readonly DataDictionaryUrlResolver _dataDictionaryUrlResolver;

    public DocumentationRenderer(IReadOnlyCollection<Type> types, IQueryLocator queryLocator, ILogger<DocumentationWriter> logger, DataDictionaryUrlResolver dataDictionaryUrlResolver)
    {
        _types = types;
        _queryLocator = queryLocator;
        _logger = logger;
        _dataDictionaryUrlResolver = dataDictionaryUrlResolver;
    }

    public IEnumerable<Document> Render()
    {
        var typesImplementingIOmopRecord =
            _types
            .Where(type => GetAllInterfaces(type).Any(i => i == typeof(IOmopTarget)) && type is { IsInterface: false, IsAbstract: false })
            .ToList();

        var mapperByOmopTarget =
            typesImplementingIOmopRecord
                .Select(
                    mapperType =>
                    new
                    {
                        MapperType = mapperType,
                        OmopTargetDescription = OmopDescription(mapperType)
                    })
                .GroupBy(target => target.OmopTargetDescription)
                .ToList();

        var indexStringBuilder = new StringBuilder();

        indexStringBuilder.AppendLine("---");
        indexStringBuilder.AppendLine("layout: default");
        indexStringBuilder.AppendLine("title: Transformation Documentation");
        indexStringBuilder.AppendLine("nav_order: 5");
        indexStringBuilder.AppendLine("has_children: true");
        indexStringBuilder.AppendLine("---");
        indexStringBuilder.AppendLine("{: .no_toc }");
        indexStringBuilder.AppendLine("");
        
        indexStringBuilder.AppendLine("`Automatically generated documentation`");
        indexStringBuilder.AppendLine();
        indexStringBuilder.AppendLine("# Transformation Documentation");
        indexStringBuilder.AppendLine("");
        indexStringBuilder.AppendLine("This section of the site covers the documentation for the mappings completed so far from various sources to OMOP v5.4.");
        indexStringBuilder.AppendLine("");
        indexStringBuilder.AppendLine("The page is structured based on the OMOP tables mapped. Underneath each table page you will find:");
        indexStringBuilder.AppendLine("");
        indexStringBuilder.AppendLine("* A contents list for the fields mapped");
        indexStringBuilder.AppendLine("* A summary diagram showing the high level field mappings at table level from the various sources, with one graph for each data source");
        indexStringBuilder.AppendLine("* A button to submit a comment or raise an issue for the table level mapping");
        indexStringBuilder.AppendLine("* When clicking through to the field level mappings you will find:");
        indexStringBuilder.AppendLine("    * Detail of the source column");
        indexStringBuilder.AppendLine("    * Any appropriate documentation notes");
        indexStringBuilder.AppendLine("    * Any appropriate SQL code");
        indexStringBuilder.AppendLine("    * A button to submit a comment or raise an issue for the field level mapping");
        indexStringBuilder.AppendLine("");
        indexStringBuilder.AppendLine("We encourage you to use the buttons to comment on or raise an issue with the mappings, to help us to continue to improve them.");

        var properties = new List<Property>();

        foreach (var omopTarget in mapperByOmopTarget)
        {
            StringBuilder omopTable = new StringBuilder();

            omopTable.AppendLine("---");
            omopTable.AppendLine("layout: default");
            omopTable.AppendLine($"title: {omopTarget.Key}");
            omopTable.AppendLine("has_children: true");
            omopTable.AppendLine("parent: Transformation Documentation");
            omopTable.AppendLine("has_toc: false");
            omopTable.AppendLine("---");

            omopTable.AppendLine("");
            omopTable.AppendLine($"# {omopTarget.Key}");

            var mapperByProperty =
                omopTarget
                    .SelectMany(
                        mapper =>
                            mapper
                                .MapperType
                                .GetProperties()
                                .Select(
                                    property =>
                                        new
                                        {
                                            Property = property,
                                            Mapper = mapper
                                        }))
                    .GroupBy(property => property.Property.Name)
                    .ToList();

            foreach (var propertyGroup in mapperByProperty)
            {
                if (!AnyPropertyHasDocumentationAttributes(propertyGroup.Select(m => m.Property)))
                    continue;

                var name = propertyGroup.First().Property.Name;

                var fileName = $"{omopTarget.Key}_{name}.md";

                omopTable.AppendLine($"* [{name}]({{% link docs/transformation-documentation/{fileName} %}})");

                var stringBuilder = new StringBuilder();

                stringBuilder.AppendLine("---");
                stringBuilder.AppendLine("layout: default");
                stringBuilder.AppendLine($"title: {name}");
                stringBuilder.AppendLine($"parent: {omopTarget.Key}");
                stringBuilder.AppendLine("grand_parent: Transformation Documentation");
                stringBuilder.AppendLine("has_toc: false");
                stringBuilder.AppendLine("---");

                stringBuilder.AppendLine($"# {name}");

                foreach (var property in propertyGroup)
                {
                    var p = GetProperty(property.Mapper.MapperType, property.Property, omopTarget.Key, name);

                    if (p != null)
                        properties.Add(p);

                    p?.WriteMarkdown(stringBuilder);
                }

                yield return new Document(fileName, stringBuilder.ToString());
            }

            omopTable.AppendLine();

            foreach (var target in omopTarget)
            {
                omopTable.AppendLine($"## {target.MapperType.Name}");
                omopTable.AppendLine($"<a href=\"{target.MapperType.Name}.svg\" target=\"_blank\"><img src=\"{target.MapperType.Name}.svg\" /></a>");
                omopTable.AppendLine();

                var notes = target.MapperType.GetCustomAttributes(typeof(NotesAttribute)).Cast<NotesAttribute>();

                foreach (var note in notes)
                {
                    omopTable.AppendLine("{: .important-title }");
                    omopTable.AppendLine($"> {note.Title}");
                    omopTable.AppendLine(">");
                    foreach (var line in note.TextLine)
                    {
                        omopTable.AppendLine($"> {line}");

                        if (line.StartsWith("*") == false)
                            omopTable.AppendLine(">");
                    }

                    omopTable.AppendLine("");
                }

                omopTable.AppendLine($"[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title={target.MapperType.Name}%20mapping){{: .btn }}");
            }

            yield return new Document($"{omopTarget.Key}.md", omopTable.ToString());
        }

        yield return new Document("transformation-documentation.md", indexStringBuilder.ToString());

        foreach (var document in GetSvgDocuments(properties))
        {
            yield return document;
        }

        foreach (var document in GetJsonDocuments(properties))
        {
            yield return document;
        }
    }

    private static IEnumerable<Document> GetSvgDocuments(IEnumerable<Property> properties)
    {
        Relationship CreateRelationship(string source, Property mapping)
        {
            return
                new Relationship(
                    source,
                    mapping.FieldName,
                    mapping.IsCopyOperation ? "Copy value" : mapping.Transform?.TransformDescription ?? mapping.OperationDescription ?? "");
        }

        var mapperProperties =
            properties
                .GroupBy(p => p.MapperType.Name)
                .Select(
                    dataSourceMappingGroup =>
                        new
                        {
                            dataSourceMappingGroup.Key,
                            dataSourceMappingGroup.First().MapperType,
                            DataOrigin = dataSourceMappingGroup.First().DataSourceName,
                            Relationships =
                                dataSourceMappingGroup
                                .Where(mapping => mapping.Query != null)
                                .SelectMany(
                                    mapping =>
                                        mapping
                                            .Query!
                                            .ColumnExplanations
                                            .SelectMany(
                                                columnExplanation =>
                                                    columnExplanation
                                                        .Origins
                                                        .Select(
                                                            mappingSource =>
                                                                CreateRelationship(
                                                                    mappingSource.Origin,
                                                                    mapping))
                                                        .Concat(
                                                            columnExplanation.Origins.Any()
                                                            ?
                                                            Enumerable.Empty<Relationship>()
                                                            :
                                                            new []
                                                            {
                                                                CreateRelationship(columnExplanation.ColumnName, mapping)
                                                            })))  
                                .ToList()
                        })
                .ToList();

        foreach (var mapper in mapperProperties)
        {
            var svgRenderer = new SvgRenderer(mapper.Relationships.ToList());
            
            yield return new Document($"{mapper.MapperType.Name}.svg", svgRenderer.Render());
        }
    }
    

    private IEnumerable<Document> GetJsonDocuments(IEnumerable<Property> properties)
    {
        var mapperProperties =
            properties
                .GroupBy(p => p.MapperType.Name)
                .Select(
                    dataSourceMappingGroup =>
                        new
                        {
                            dataSourceMappingGroup.Key,
                            dataSourceMappingGroup.First().MapperType,
                            DataOrigin = dataSourceMappingGroup.First().DataSourceName,
                            Relationships = dataSourceMappingGroup
                        })
                .ToList();

        foreach (var mapper in mapperProperties)
        {
            if (mapper.DataOrigin == null)
            {
                _logger.LogError($"{mapper.MapperType.Name} has no origin attribute.");

                yield break;
            }

            var report =
                new
                {
                    omopTable = mapper.Relationships.First().TableName,
                    origin = mapper.DataOrigin,
                    omopColumns =
                        mapper
                            .Relationships
                            .Select(
                                relationship =>
                                    new
                                    {
                                        name = relationship.FieldName,
                                        operation_description = relationship.Transform?.TransformDescription ?? relationship.OperationDescription,
                                        dataSource =
                                            relationship
                                                .Query?
                                                .ColumnExplanations
                                                .Select(
                                                    explanation =>
                                                        new
                                                        {
                                                            name = explanation.ColumnName,
                                                            description = explanation.Description,
                                                            origins = explanation.Origins.Select(origin => new { origin = origin.Origin, url = origin.Url })
                                                        }),
                                        query = relationship.Query?.Query,
                                        lookup_table_markdown = relationship.Transform?.LookupTable?.GetMarkdown()
                                    })
                };

            var json = JsonConvert.SerializeObject(report, Formatting.Indented);

            yield return new Document($"{mapper.MapperType.Name}.json", json);
        }
    }

    private static string OmopDescription(Type type) => ((IOmopTarget)Activator.CreateInstance(type)!).OmopTargetTypeDescription;
    
    private static IReadOnlyCollection<object> GetDocumentableAttributes(PropertyInfo property)
    {
        return
            new[]
            {
                typeof(TransformAttribute),
                typeof(DescriptionAttribute),
                typeof(CopyValueAttribute),
                typeof(ConstantValueAttribute)
            }
            .SelectMany(type => property.GetCustomAttributes(type, false))
            .ToList();
    }

    private static bool PropertyHasDocumentationAttributes(PropertyInfo property) => GetDocumentableAttributes(property).Any();

    private static bool AnyPropertyHasDocumentationAttributes(IEnumerable<PropertyInfo> properties) =>
        properties
            .Any(PropertyHasDocumentationAttributes);

    private static bool IgnoreProperty(PropertyInfo property) => property.Name is "OmopTargetTypeDescription" or "Source";

    private Property? GetProperty(Type mapperType, PropertyInfo property, string omopTable, string omopField)
    {
        if (IgnoreProperty(property))
            return null;

        var attributes = GetDocumentableAttributes(property);

        if (attributes.Count == 0)
            return null;

        var sourceType = GetOmopSourceType(mapperType);

        var sourceDescription = sourceType.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault();

        if (sourceDescription == null)
        {
            _logger.LogError($"{sourceType.Name} has no DescriptionAttribute");
        }

        var dataOrigin = sourceType.GetCustomAttributes(typeof(DataOriginAttribute)).FirstOrDefault();

        if (dataOrigin == null)
        {
            _logger.LogError($"{sourceType} has no origin attribute.");
        }

        SqlQuery? query = null;
        string? operationDescription = null;
        bool isCopyOperation = false;

        var copyValueAttribute = attributes.OfType<CopyValueAttribute>().FirstOrDefault();

        if (copyValueAttribute != null)
        {
            operationDescription = $"Value copied from `{copyValueAttribute.Value}`";
            isCopyOperation = true;

            query = GetQuery(mapperType,  copyValueAttribute.Value);
        }

        var propertyDescription = attributes.OfType<DescriptionAttribute>().FirstOrDefault();

        var constantValueAttribute = attributes.OfType<ConstantValueAttribute>().FirstOrDefault();

        if (constantValueAttribute != null)
        {
            operationDescription = $"Constant value set to `{constantValueAttribute.Value}`. {constantValueAttribute.Description}";
        }

        Transform? transform = null;

        var transformAttribute = attributes.OfType<TransformAttribute>().FirstOrDefault();

        if (transformAttribute != null)
        {
            transform = GetTransform(transformAttribute, property.Name);

            if (transformAttribute.UseOmopTypeAsSource == false) // Don't try and render any query documentation if we are not using a query as a datasource.
            {
                query = GetQuery(mapperType,  transformAttribute.Value);
            }
        }

        return
            new Property(
                tableName: omopTable,
                fieldName: omopField,
                description: propertyDescription?.Value,
                dataSourceName: dataOrigin == null ? null : ((DataOriginAttribute)dataOrigin).Value,
                dataSourceDescription: sourceDescription == null ? null : ((DescriptionAttribute)sourceDescription).Value,
                operationDescription: operationDescription,
                transform: transform,
                query: query,
                mapperType: mapperType,
                isCopyOperation: isCopyOperation);
    }

    private class Property (
        string tableName,
        string fieldName,
        string? description, 
        string? dataSourceDescription, 
        string? dataSourceName, 
        string? operationDescription,
        Transform? transform, 
        SqlQuery? query,
        Type mapperType,
        bool isCopyOperation)
    {
        public string TableName => tableName;
        public string FieldName => fieldName;
        public string? Description => description;
        public string? DataSourceDescription => dataSourceDescription;
        public string? DataSourceName => dataSourceName;
        public string? OperationDescription => operationDescription;
        public Transform? Transform => transform;
        public SqlQuery? Query => query;
        public Type MapperType => mapperType;
        public bool IsCopyOperation => isCopyOperation;

        public void WriteMarkdown(StringBuilder stringBuilder)
        {
            if (dataSourceDescription != null)
            {
                stringBuilder.AppendLine($"### {dataSourceDescription}");
            }

            if (operationDescription != null)
            {
                stringBuilder.AppendLine($"* {operationDescription}");
            }

            transform?.WriteMarkdown(stringBuilder);

            if (description != null)
            {
                stringBuilder.AppendLine($"* {description}");
            }

            query?.WriteMarkdown(stringBuilder);

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20{TableName}%20table%20{FieldName}%20field%20{(dataSourceDescription ?? "").Replace(" ", "%20")}%20mapping){{: .btn }}");
        }
    }

    private static Type GetOmopSourceType(Type type)
    {
        var sourceTypeInterface = GetAllInterfaces(type).Single(i => i.Name == typeof(IOmopRecord<>).Name);

        return sourceTypeInterface.GetGenericArguments().Single();
    }

    private SqlQuery? GetQuery(Type mapperType, params string[] sourceColumns)
    {
        var sourceType = GetOmopSourceType(mapperType);

        var queryTransform = sourceType.GetCustomAttributes(typeof(SourceQueryAttribute), inherit: false).FirstOrDefault();

        if (queryTransform == null)
        {
            _logger.LogError($"{mapperType.Name} has no SourceQueryAttribute.");
            return null;
        }

        var query = _queryLocator.GetQuery(((SourceQueryAttribute)queryTransform).QueryFileName);

        var explanations = GetColumnCollectionExplanations(query, sourceColumns, sourceType.Name);

        return new SqlQuery(explanations.ToList(), query!.Sql!.Value ?? "");
    }

    private class SqlQuery(IReadOnlyCollection<ColumnDataDictionaryExplanation> columnExplanations, string sqlQuery)
    {
        public IReadOnlyCollection<ColumnDataDictionaryExplanation> ColumnExplanations => columnExplanations;
        public string Query => sqlQuery;
        public void WriteMarkdown(StringBuilder stringBuilder)
        {
            foreach (var explanation in ColumnExplanations)
            {
                explanation.WriteMarkdown(stringBuilder);
            }

            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("```sql");
            var whitespace = new[] { ' ', '\r', '\n' };
            stringBuilder.AppendLine(sqlQuery.TrimStart(whitespace).TrimEnd(whitespace));
            stringBuilder.AppendLine("```");
            stringBuilder.AppendLine();
        }
    }

    private IEnumerable<ColumnDataDictionaryExplanation> GetColumnCollectionExplanations(Query query, IEnumerable<string> columns, string sourceType)
    {
        foreach (var column in columns)
        {
            var explanation = GetColumnExplanations(query, column, sourceType);

            if (explanation != null)
                yield return explanation;
        }
    }

    private ColumnDataDictionaryExplanation? GetColumnExplanations(Query query, string columnName, string sourceType)
    {
        var explanation = query.Explanation!.Explanations!.FirstOrDefault(explanation => explanation.ColumnName!.Equals(columnName, StringComparison.OrdinalIgnoreCase));

        if (explanation == null)
        {
            _logger.LogError($"Explanation for column {columnName} on {sourceType} was not found.");
            return null;
        }

        return
            new ColumnDataDictionaryExplanation(
                columnName,
                explanation!.Description ?? "",
                explanation!.Origin == null ? [] : explanation!.Origin.Select(origin => new DataDictionaryOrigin(origin, _dataDictionaryUrlResolver.GetUrl(origin))));
    }

    private static Transform GetTransform(TransformAttribute transformAttribute, string targetField)
    { 
        var transformDescription = transformAttribute.Type.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault();

        return
            new Transform(
                transformAttribute.Value,
                transformDescription == null ? null : ((DescriptionAttribute)transformDescription).Value,
                typeof(ILookup).IsAssignableFrom(transformAttribute.Type) ? GetLookupTransform(transformAttribute, targetField) : null);
    }

    private class Transform(
        IReadOnlyCollection<string> sourceColumns,
        string? transformDescription,
        LookupTable? lookupTable)
    {
        public IReadOnlyCollection<string> SourceColumns => sourceColumns;
        public string? TransformDescription => transformDescription;
        public LookupTable? LookupTable => lookupTable;

        public void WriteMarkdown(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine(FormatColumns(sourceColumns));

            if (transformDescription != null)
            {
                stringBuilder.AppendLine(transformDescription);
            }

            if (lookupTable != null)
            {
                stringBuilder.Append(lookupTable.GetMarkdown());
            }
        }
    }

    private static LookupTable GetLookupTransform(TransformAttribute transformAttribute, string targetField) =>
        new (
            sourceProperty: transformAttribute.Value.First(),
            targetField: targetField,
            lookup: (ILookup)Activator.CreateInstance(transformAttribute.Type)!);

    private class LookupTable(string sourceProperty, string targetField, ILookup lookup)
    {
        public string GetMarkdown()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"|{sourceProperty}|{targetField}|notes|");
            stringBuilder.AppendLine("|------|-----|-----|");

            foreach (var mapping in lookup.Mappings)
            {
                stringBuilder.AppendLine($"|{mapping.Key}|{mapping.Value.Value}|{mapping.Value.Notes}|");
            }

            stringBuilder.AppendLine();

            if (lookup.ColumnNotes.Length > 0)
            {
                stringBuilder.AppendLine("Notes");

                foreach (string note in lookup.ColumnNotes)
                {
                    stringBuilder.AppendLine($"* {note}");
                }
            }

            return stringBuilder.ToString();
        }
    }

    private class DataDictionaryOrigin(string origin, string? url)
    {
        public string Origin => origin;
        public string? Url => url;
        public string GetMarkdown() => $"[{origin}]({url})";
    }

    private class ColumnDataDictionaryExplanation(
        string columnName,
        string description,
        IEnumerable<DataDictionaryOrigin> origins)
    {
        public string ColumnName => columnName;
        public string Description => description;
        public IEnumerable<DataDictionaryOrigin> Origins => origins;

        public void WriteMarkdown (StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("");
            stringBuilder.Append($"* `{columnName}` {description} ");

            var dataDictionaryOrigins = origins.Select(origin => origin.GetMarkdown());

            if (description!.Contains("\r\n")) // If the description is multi line, add the links on a new line.
            {
                stringBuilder.AppendLine();
            }

            stringBuilder.Append($"{string.Join(", ", dataDictionaryOrigins)}");
            
            stringBuilder.AppendLine();
        }
    }

    private static string FormatColumns(IReadOnlyCollection<string> columns)
    {
        string plural = columns.Count == 1 ? "Source column " : "Source columns ";

        string joinedColumns = string.Join(", ", columns.Select(c => $"`{c}`"));

        return $"{plural} {joinedColumns}.";
    }

    private static IEnumerable<Type> GetAllInterfaces(Type type)
    {
        HashSet<Type> interfaces = new HashSet<Type>(type.GetInterfaces());

        // Get interfaces of the base type
        Type? baseType = type.BaseType;
        while (baseType != null)
        {
            interfaces.UnionWith(baseType.GetInterfaces());
            baseType = baseType.BaseType;
        }

        return interfaces;
    }
}