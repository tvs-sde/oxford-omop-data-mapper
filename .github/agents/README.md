# Specialized Agents for Oxford OMOP Data Mapper

This directory contains specialized agents that handle complex, multi-step tasks in the OMOP transformation pipeline. These agents should be invoked via the `runSubagent` tool rather than implemented manually.

## Available Agents

### 🏥 COSD Transformation Pipeline

#### cosd-transformation-pipeline.agent.md
**Purpose**: Orchestrates the complete COSD-to-OMOP transformation creation process

**When to Use**:
- User requests to create new COSD transformations
- Need both SQL query generation AND C# class generation
- Want automated project file updates and verification

**Inputs Required**:
- Cancer Type (Colorectal, Lung, Sarcoma, Breast, Brain/CNS, Liver)
- Cancer Code (CT, LU, SA, BR, BA, LV)
- COSD Version (v8 or v9)
- OMOP Domain (ProcedureOccurrence, ConditionOccurrence, Measurement, Observation, Death)
- Mapping Description (e.g., "Primary Procedure", "Tumour Laterality")

**Outputs Delivered**:
- SQL query XML file
- C# Record class
- C# Transformation class
- Updated CosdTransformer.cs
- Updated OmopTransformer.csproj
- Build verification checklist

**Example Invocation**:
```
Task: Create COSD transformation for Sarcoma v9 Primary Procedure

Inputs:
- Cancer Type: Sarcoma
- Cancer Code: SA
- COSD Version: v9
- OMOP Domain: ProcedureOccurrence
- Mapping Description: Primary Procedure

Expected Deliverables:
- Complete SQL query, C# classes, and project updates
```

---

#### cosd-procedure-query-generator.agent.md
**Purpose**: Generates DuckDB SQL queries to extract procedure data from COSD staging tables

**When to Use**:
- Creating new COSD procedure extraction queries
- Need to map COSD JSON structure to OMOP procedure_occurrence
- Want comprehensive field extraction with proper documentation

**Inputs Required**:
- Cancer Type Code (CT, LU, SA, BR, BA, LV)
- COSD Version (v8 or v9)
- Domain (ProcedureOccurrence)
- Mapping Description

**Outputs Delivered**:
- Complete SQL query with unnest() for arrays
- Inline documentation for each field
- Field-to-OMOP mapping notes
- XML file ready for embedding

**Special Considerations**:
- Automatically handles v8 vs v9 JSON path differences
- Includes NHS Number extraction
- Applies NOT NULL filters on required fields
- Uses DISTINCT to prevent duplicates from array unnesting

---

#### nhs-data-dictionary-discovery.agent.md
**Purpose**: Discovers dataset schemas, field definitions, and value sets from NHS Data Dictionary to inform what transformations should be created

**When to Use**:
- User requests "all possible" transformations (batch mode)
- Need to discover what fields exist in a dataset
- Want to understand permitted values and code systems
- Performing gap analysis of unmapped fields

**Inputs Required**:
- Dataset Type (COSD, SUS, SACT, RTDS, etc.)
- Dataset Version (e.g., v9.01, v8.1)
- OMOP Domain (ProcedureOccurrence, ConditionOccurrence, etc.)
- Cancer Type (if COSD)

**Outputs Delivered**:
- Comprehensive field list from NHS Data Dictionary
- Prioritized transformation recommendations (Priority 1-4)
- Field definitions and permitted value sets
- NHS Data Dictionary URLs for documentation
- Implementation notes and dependencies

**How It Works**:
1. Fetches NHS Data Dictionary pages for the dataset
2. Extracts all fields relevant to the specified domain
3. Retrieves permitted values and code systems
4. Analyzes clinical value and OMOP mappability
5. Recommends which transformations to create and why

**Example Output**:
```
Discovered 15 procedure fields in COSD Sarcoma v9
Recommended Transformations (9 total):
- Priority 1 (Critical): 2 fields
- Priority 2 (High): 3 fields
- Priority 3 (Medium): 3 fields
- Priority 4 (Low): 1 field

Not Recommended: 6 fields (administrative/deprecated)
```

**Integration**:
- Invoked by orchestrator when user says "all possible [domain]"
- Output guides which transformations to create
- Can be run standalone for planning/gap analysis

---

#### cosd-csharp-transformer-generator.agent.md
**Purpose**: Generates C# Record and Transformation classes from SQL query XML files

**When to Use**:
- Have an XML query file and need corresponding C# classes
- Need to register transformation in CosdTransformer.cs
- Want attribute-based OMOP mapping classes

**Inputs Required**:
- Path to XML query file
- Cancer type and code
- COSD version
- OMOP domain
- Mapping name/description

**Outputs Delivered**:
- Record class with [DataOrigin] and [SourceQuery] attributes
- Transformation class with property mapping attributes
- Using statement for CosdTransformer.cs
- Registration line for Transform() method
- EmbeddedResource entry for .csproj

**Key Features**:
- Namespace matches folder structure exactly
- Nullable string properties for all source fields
- Correct transformation attributes (CopyValue, Transform, ConstantValue)
- Proper concept lookup selectors (Opcs4Selector, Icd10Selector, etc.)

---

## Agent Hierarchy

```
User Request
    ↓
[AUTO-ROUTING via cosd-transformation.skill.md]
    ↓
cosd-transformation-pipeline.agent.md (ORCHESTRATOR)
    ↓
    ├── nhs-data-dictionary-discovery.agent.md (DISCOVERY - batch mode only)
    ├── cosd-procedure-query-generator.agent.md (SQL)
    └── cosd-csharp-transformer-generator.agent.md (C#)
```

## Usage Guidelines

### ✅ DO Use Agents When:
- Creating new COSD transformations from scratch
- Need complete pipeline with SQL + C# + registration
- Want automated verification and consistency
- User requests multiple transformations (batch processing)

### ❌ DO NOT Use Agents For:
- Simple edits to existing files (use direct file editing)
- Non-COSD data sources (these agents are COSD-specific)
- Debugging existing transformations (use IDE/direct inspection)
- Quick one-off SQL query adjustments

### 🔄 Agent Invocation Pattern

**ALWAYS use this pattern**:
```
1. Detect user intent (via copilot-instructions.md guidance)
2. Invoke runSubagent with the orchestrator
3. Let orchestrator invoke sub-agents as needed
4. Report orchestrator's final delivery summary
5. Guide user through verification steps
```

**NEVER do this**:
```
❌ Read agent instructions and manually implement them yourself
❌ Create files directly without agent invocation
❌ Skip agent verification steps
❌ Mix agent-generated code with manual edits
```

## Quality Assurance

Agents enforce:
- ✅ Naming convention consistency (CosdV9SarcomaProcedureOccurrencePrimaryProcedure)
- ✅ Namespace alignment with folder structure
- ✅ Cancer code matching between SQL and registration
- ✅ Correct transformation attributes for each field type
- ✅ EmbeddedResource paths with backslashes
- ✅ Build verification before delivery

## Adding New Agents

If you need to create a new agent:

1. **Create agent file**: `.github/agents/[name].agent.md`
2. **Add YAML frontmatter**:
   ```yaml
   ---
   description: 'Brief description'
   tools: ['list', 'of', 'required', 'tools']
   ---
   ```
3. **Follow structure**:
   - Your Identity (who the agent is)
   - Your Mission (what it does)
   - Input Parameters (what it needs)
   - Phase-by-phase instructions
   - Quality assurance checklist
4. **Register in orchestrator** (if it's a sub-agent)
5. **Update this README** with usage guidelines

## Troubleshooting

**Agent not being invoked automatically?**
- Check `.github/copilot-instructions.md` has agent guidance
- Verify `.github/skills/cosd-transformation.skill.md` triggers match request
- Ensure user request is clear and specific

**Agent produces incorrect output?**
- Review agent instructions for errors
- Check base query CSV files are up-to-date
- Verify example files (Colorectal) match expected patterns

**Build errors after agent generation?**
- Run agent's quality checklist manually
- Verify namespace matches folder structure
- Check EmbeddedResource paths use backslashes
- Ensure cancer code in registration matches SQL WHERE clause

## Support

For agent issues or improvements:
1. Review agent source file for detailed instructions
2. Check existing examples (Colorectal transformations)
3. Test with simple case before batch processing
4. Report any systematic failures to update agent logic
