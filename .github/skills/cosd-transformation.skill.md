---
description: 'Automatically route COSD transformation requests to the specialized agent pipeline'
triggers:
  - 'create cosd transformation'
  - 'generate cosd'
  - 'add cosd mapping'
  - 'new cosd procedure'
  - 'new cosd condition'
  - 'cosd measurement'
  - 'cosd observation'
agents:
  - 'cosd-transformation-pipeline.agent.md'
---

# COSD Transformation Skill

## Purpose
This skill automatically detects requests to create COSD transformations and routes them to the proper agent pipeline.

## When This Skill Activates

**Trigger Patterns:**
- User asks to create/generate COSD transformations
- User mentions cancer types (Colorectal, Lung, Sarcoma, Breast, Brain, Liver) with OMOP domains
- User requests procedure/condition/measurement/observation mappings from COSD
- User mentions "v8" or "v9" COSD versions

**Examples:**
- "Create COSD Sarcoma v9 primary procedure transformations"
- "Generate all Lung v8 condition occurrences"
- "Add Breast tumour size measurement mapping"
- "Create 12 Sarcoma procedure transformations"

## Automatic Routing Logic

When a COSD transformation request is detected:

### Step 1: Parse User Intent
Extract from the request:
- **Cancer Type**: Colorectal/Lung/Sarcoma/Breast/Brain/Liver
- **Cancer Code**: CT/LU/SA/BR/BA/LV (infer if not stated)
- **Version**: v8 or v9 (default to v9 if not specified)
- **Domain**: ProcedureOccurrence/ConditionOccurrence/Measurement/Observation/Death
- **Mapping Name**: Primary Procedure, Primary Diagnosis, Tumour Size, etc.
- **Quantity**: Single transformation or batch (e.g., "all 12")

### Step 2: Route to Pipeline Orchestrator
Invoke the `cosd-transformation-pipeline.agent.md` with:

```
Task: Create COSD transformation for {CancerType} {Version} {Domain}

Inputs:
- Cancer Type: {CancerType}
- Cancer Code: {CancerCode}
- COSD Version: {Version}
- OMOP Domain: {Domain}
- Mapping Description: {Description}
- Special Requirements: {any user-specified constraints}

Context:
{Provide any additional context from user request}

Expected Deliverables:
- SQL query XML file
- C# Record class
- C# Transformation class
- Project file updates
- Build verification steps
```

### Step 3: For Batch Requests
If user requests multiple transformations (e.g., "all 12 Sarcoma procedures"):

1. Break down into individual transformation requests
2. Invoke orchestrator for EACH transformation separately
3. Track progress across all transformations
4. Provide consolidated summary at the end

**Batch Example:**
```
User: "Create all 12 Sarcoma v9 procedure transformations"

Parse as:
- Primary Procedure
- Secondary Procedure
- Surgical Access Approach
- Surgical Margin Status
- etc. (12 total)

Execute:
for each mapping in list:
  invoke orchestrator(Sarcoma, SA, v9, ProcedureOccurrence, mapping)
  verify success before proceeding to next
```

## DO NOT Manually Implement

**NEVER do this:**
- ❌ Manually create SQL queries without invoking SQL generator agent
- ❌ Manually create C# classes without invoking C# generator agent
- ❌ Directly edit files without agent orchestration
- ❌ Skip the verification steps from the orchestrator

**ALWAYS do this:**
- ✅ Route ALL COSD transformation requests through the orchestrator
- ✅ Let sub-agents generate SQL and C# code
- ✅ Follow the orchestrator's verification checklist
- ✅ Report back the orchestrator's delivery summary

## Skill Output

After routing to orchestrator, report:

```
✅ COSD Transformation Pipeline Invoked

Request: {Summary of what was requested}
Routing: cosd-transformation-pipeline.agent.md
Status: {In Progress / Complete / Failed}

{Include orchestrator's final delivery summary here}
```

## Error Handling

If orchestrator or sub-agents fail:
- Report the specific failure point (SQL generation / C# generation / Build)
- DO NOT attempt to manually fix by creating files directly
- Ask user if they want to retry with different parameters

## Multi-Transformation Tracking

For batch requests, maintain a progress tracker:

```
COSD Batch Transformation Progress

Sarcoma v9 Procedures (12 transformations):
 ✅ 1/12 - Primary Procedure (Complete)
 ✅ 2/12 - Secondary Procedure (Complete)
 🔄 3/12 - Surgical Access (In Progress)
 ⏳ 4/12 - Surgical Margin (Pending)
 ⏳ 5/12 - ... (Pending)
 ...
```

## Integration with Existing Agents

This skill acts as the **router** that:
1. Detects COSD transformation intent
2. Routes to `cosd-transformation-pipeline.agent.md` (orchestrator)
3. Orchestrator invokes:
   - `cosd-procedure-query-generator.agent.md` (for SQL)
   - `cosd-csharp-transformer-generator.agent.md` (for C#)

**Chain of Command:**
```
User Request
    ↓
cosd-transformation.skill.md (THIS FILE - Router)
    ↓
cosd-transformation-pipeline.agent.md (Orchestrator)
    ↓
├── cosd-procedure-query-generator.agent.md (SQL Generator)
└── cosd-csharp-transformer-generator.agent.md (C# Generator)
```

## Testing the Skill

To verify this skill works, user should say:
- "Create Sarcoma v9 primary procedure transformation"
- Expect: Automatic routing to orchestrator, not manual file creation
- Result: Complete pipeline execution with SQL + C# files generated
