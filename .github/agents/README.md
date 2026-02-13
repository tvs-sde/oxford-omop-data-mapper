# Specialized Agents for Oxford OMOP Data Mapper

This directory contains specialized agents that handle complex, multi-step tasks in the OMOP transformation pipeline. These agents should be invoked via the `runSubagent` tool rather than implemented manually.

## ⛔ CRITICAL POLICY: Never Modify Existing Transformation Tools

**ALL agents enforce this rule: NEVER edit, modify, or adapt existing selectors, lookups, or resolvers.**

Existing transformation tools (e.g., `Icdo3Selector`, `Opcs4Selector`, `TumourLateralityLookup`, `DataDictionaryBasisOfDiagnosisCancerLookup`) are used by MANY transformations across the entire codebase. Modifying them will break existing functionality and cause production issues.

### ✅ If an existing tool doesn't match your needs:
- **CREATE a NEW selector/lookup/resolver class** with a descriptive name
- **Document why the new tool is needed** (different inputs, different logic, etc.)
- **Never modify existing tools** to accommodate new requirements

### 📋 Examples:
- Need `Icdo3Selector` with 1 input instead of 2? 
  - ❌ DO NOT modify `Icdo3Selector` to accept 1 input
  - ✅ CREATE `Icdo3MorphologyOnlySelector` that accepts 1 input
  
- Need `TCategoryLookup` with different value mappings?
  - ❌ DO NOT modify `TCategoryLookup` mappings
  - ✅ CREATE `TCategoryVariantLookup` with new mappings
  
- Need modified behavior from any existing tool?
  - ❌ DO NOT edit the existing class
  - ✅ CREATE a new tool with a specific name explaining the difference

### 🎯 Rationale:
Each transformation tool may be used by dozens of transformations across COSD, SUS, SACT, RTDS, and Oxford data sources. A single change breaks all of them. **Immutability of existing tools is non-negotiable.**

---

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

### 🔄 CI/CD Validation Pipeline

#### ci-validation-pipeline.agent.md
**Purpose**: Orchestrates end-to-end CI validation from code changes through Azure DevOps pipeline execution and result analysis

**When to Use**:
- After code changes are made (by you or another agent)
- Need to validate changes pass all quality checks
- Want automated branch creation, PR, and pipeline execution
- Require log analysis and error extraction for failed builds

**Inputs Required**:
- Change Description (what was changed)
- Branch Name (optional - auto-generated from description)

**Optional Inputs**:
- Specific files to commit
- Reviewer to assign
- Pipeline timeout (default: 30 minutes)

**Outputs Delivered**:
- New feature branch created
- Pull request with comprehensive description
- Azure DevOps pipeline run (omop-ci build)
- Build status monitoring with progress updates
- Pass/fail determination with log analysis
- Error extraction and fix recommendations (if failed)
- Automatic fix attempts (optional, with user approval)

**Pipeline Flow**:
1. **Create Branch**: Generate feature branch from description
2. **Commit Changes**: Stage and commit with proper message
3. **Push Branch**: Push to remote repository
4. **Create PR**: Generate PR with detailed description
5. **Trigger Pipeline**: Run omop-ci build with feature branch
6. **Monitor Execution**: Poll status every 30 seconds
7. **Retrieve Results**: Get build logs and status
8. **Analyze Logs**: Extract errors with context and patterns
9. **Report Findings**: Comprehensive pass/fail report
10. **Auto-Fix** (optional): Attempt fixes and retry (up to 3 attempts)

**Success Report Example**:
```
✅ CI Validation PASSED

Branch: feature/cosd-sarcoma-v9-primary-procedure
PR: #42 - feat: Add COSD Sarcoma v9 Primary Procedure transformation
Pipeline: omop-ci (Run #123)
Duration: 8m 34s

Build Summary:
- ✅ Compilation: Success
- ✅ Unit Tests: 127 passed
- ✅ Code Analysis: 0 warnings

Ready to merge! 🎉
```

**Failure Report Example**:
```
❌ CI Validation FAILED

Error Summary (3 errors detected):

1. Compilation Error (Critical)
   error CS0246: Type 'Icdo3Selector' not found
   File: CosdV9SarcomaProcedureOccurrencePrimaryProcedure.cs:45
   
   Recommended Fix:
   - Add: using OmopTransformer.ConceptResolution;

2. Test Failure (High Priority)
   Failed: CosdSarcomaProcedureTests.TestPrimaryProcedureMapping
   Expected: 1234, Actual: null
   
   Recommended Fix:
   - Check SQL query returns data
   - Verify concept mapper handles null values

Would you like me to attempt automatic fixes?
```

**Special Features**:
- **Automatic retries**: Up to 3 fix attempts with incremental improvements
- **Log parsing**: Extracts specific errors from build output
- **Context-aware fixes**: Understands common patterns (missing imports, null checks, typos)
- **Progress tracking**: Real-time status updates during pipeline execution
- **Azure DevOps integration**: Uses MCP tools for pipeline and PR management

**MCP Tools Used**:
- Git operations: `mcp_gitkraken_git_branch`, `mcp_gitkraken_git_add_or_commit`, `mcp_gitkraken_git_push`
- Pull requests: Activated via `activate_pull_request_and_issue_management_tools()`
- Pipelines: Activated via `activate_pipeline_run_tools()`, `activate_build_management_tools()`

**Example Invocation**:
```
Task: Validate COSD Sarcoma v9 Primary Procedure transformation

Input:
- Change Description: Added COSD Sarcoma v9 Primary Procedure transformation

Expected Actions:
1. Create feature branch
2. Commit and push changes
3. Create pull request
4. Trigger omop-ci pipeline
5. Monitor until completion
6. Report results with recommendations
```

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
            ↓
        [After transformation complete]
            ↓
    ci-validation-pipeline.agent.md (CI/CD VALIDATION)
        ↓
    [Monitors Azure DevOps pipeline]
        ↓
    ✅ Pass → Merge PR
    ❌ Fail → Fix and retry
```

## Usage Guidelines

### ✅ DO Use Agents When:
- Creating new COSD transformations from scratch
- Need complete pipeline with SQL + C# + registration
- Want automated verification and consistency
- User requests multiple transformations (batch processing)
- **Validating code changes through CI/CD pipeline**
- **Need automated branch creation, PR, and build monitoring**
- **Want error analysis and automatic fix attempts**

### ❌ DO NOT Use Agents For:
- Simple edits to existing files (use direct file editing)
- Non-COSD data sources (transformation agents are COSD-specific)
- Debugging existing transformations (use IDE/direct inspection)
- Quick one-off SQL query adjustments
- **Manual git operations when you want fine-grained control**
- **Simple local builds (just use `dotnet build` directly)**

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
