# Agent System Architecture

## System Overview

```
┌─────────────────────────────────────────────────────────────────────┐
│                         USER REQUEST                                │
│  "Create COSD Sarcoma v9 primary procedure transformation"         │
└────────────────────────────┬────────────────────────────────────────┘
                             │
                             ▼
┌─────────────────────────────────────────────────────────────────────┐
│                   COPILOT INSTRUCTIONS                              │
│  .github/copilot-instructions.md                                    │
│  • Lists available agents & skills                                  │
│  • Defines when to use agents                                       │
│  • Provides routing guidance                                        │
└────────────────────────────┬────────────────────────────────────────┘
                             │
                             ▼
┌─────────────────────────────────────────────────────────────────────┐
│                   SKILL DETECTION                                   │
│  .github/skills/cosd-transformation.skill.md                        │
│  • Detects "COSD transformation" intent                             │
│  • Parses: Cancer Type, Version, Domain, Mapping                    │
│  • Routes to orchestrator agent                                     │
└────────────────────────────┬────────────────────────────────────────┘
                             │
                             ▼
┌─────────────────────────────────────────────────────────────────────┐
│               ORCHESTRATOR AGENT (runSubagent)                      │
│  .github/agents/cosd-transformation-pipeline.agent.md               │
│  • Validates inputs                                                 │
│  • Generates file naming conventions                                │
│  • Coordinates sub-agents                                           │
│  • Verifies outputs                                                 │
│  • Provides final delivery summary                                  │
└─────────────────┬──────────────────────────┬────────────────────────┘
                  │                          │
         ┌────────▼────────┐        ┌───────▼────────┐
         │  SQL Generator  │        │  C# Generator  │
         │   (runSubagent) │        │  (runSubagent) │
         └────────┬────────┘        └───────┬────────┘
                  │                          │
                  ▼                          ▼
         ┌────────────────┐        ┌────────────────┐
         │  Generate SQL  │        │ Generate C#    │
         │  Query XML     │        │ Record +       │
         │  File          │        │ Transformation │
         │                │        │ Classes        │
         └────────┬───────┘        └───────┬────────┘
                  │                         │
                  │                         ▼
                  │                ┌────────────────┐
                  │                │ Update Project │
                  │                │ Files:         │
                  │                │ • CosdTrans..  │
                  │                │ • .csproj      │
                  │                └───────┬────────┘
                  │                         │
                  └─────────┬───────────────┘
                            │
                            ▼
┌─────────────────────────────────────────────────────────────────────┐
│                   VERIFICATION & DELIVERY                           │
│  • All files created successfully                                   │
│  • Namespaces match folder structure                                │
│  • Cancer codes match SQL WHERE clauses                             │
│  • EmbeddedResource paths correct                                   │
│  • Build verification steps provided                                │
└────────────────────────────┬────────────────────────────────────────┘
                             │
                             ▼
┌─────────────────────────────────────────────────────────────────────┐
│                      USER RECEIVES                                  │
│  ✅ Complete transformation ready to build                          │
│  ✅ All files in correct locations                                  │
│  ✅ Project files updated                                           │
│  ✅ Verification checklist                                          │
└─────────────────────────────────────────────────────────────────────┘
```

## File Dependency Flow

```
Input: User Request
  ↓
.github/copilot-instructions.md ← Guidance layer
  ↓
.github/skills/cosd-transformation.skill.md ← Detection layer
  ↓
.github/agents/cosd-transformation-pipeline.agent.md ← Orchestration layer
  ↓
├─ .github/agents/cosd-procedure-query-generator.agent.md ← SQL generation
│  └─ Reads: cosdv81base.csv OR cosdv901base.csv
│     ↓
│     Creates: OmopTransformer/COSD/{Cancer}/{Domain}/{Name}/{Name}.xml
│
└─ .github/agents/cosd-csharp-transformer-generator.agent.md ← C# generation
   └─ Reads: Generated XML file
      ↓
      Creates:
      ├─ OmopTransformer/COSD/{Cancer}/{Domain}/{Name}/{Name}Record.cs
      ├─ OmopTransformer/COSD/{Cancer}/{Domain}/{Name}/{Name}.cs
      └─ Updates:
         ├─ OmopTransformer/COSD/CosdTransformer.cs
         └─ OmopTransformer/OmopTransformer.csproj
```

## Agent Invocation Chain

```
┌────────────────────────────────────────────────────────────────┐
│ Main AI Assistant                                              │
│ • Receives user message                                        │
│ • Loads copilot-instructions.md                                │
│ • Has access to all tools                                      │
└───────────────────────────┬────────────────────────────────────┘
                            │
                            │ Detects COSD intent
                            │
                            ▼
┌────────────────────────────────────────────────────────────────┐
│ runSubagent Tool Invoked                                       │
│ Target: cosd-transformation-pipeline.agent.md                  │
│ Params: {                                                      │
│   cancerType: "Sarcoma",                                       │
│   cancerCode: "SA",                                            │
│   version: "v9",                                               │
│   domain: "ProcedureOccurrence",                               │
│   mapping: "Primary Procedure"                                 │
│ }                                                              │
└───────────────────────────┬────────────────────────────────────┘
                            │
                            │ Creates subagent context
                            │
                            ▼
┌────────────────────────────────────────────────────────────────┐
│ Orchestrator Agent (Subagent 1)                                │
│ • Validates inputs                                             │
│ • Detects batch mode ("all possible")                          │
│ • Generates naming: CosdV9SarcomaProcedureOccurrence...        │
│ • Determines file paths                                        │
└───────────────────────────┬────────────────────────────────────┘
                            │
              ┌─────────────┴──────────────┐
              │ If "all possible" request  │
              ▼                            │
┌──────────────────────────┐               │
│ Discovery Agent          │               │
│ (Optional Subagent)      │               │
│                          │               │
│ • Fetches NHS Data Dict  │               │
│ • Finds available fields │               │
│ • Prioritizes mappings   │               │
│ • Returns recommendations│               │
└──────────┬───────────────┘               │
           │                               │
           │ Returns field list            │
           │                               │
           └──────────┬────────────────────┘
                      │
            ┌─────────┴──────────┐
            │                    │
            ▼                    ▼
┌──────────────────────────┐  ┌──────────────────────────┐
│ SQL Generator            │  │ C# Generator             │
│ (Subagent 2 or 3)        │  │ (Subagent 3 or 4)        │
│                          │  │                          │
│ runSubagent invoked by   │  │ runSubagent invoked by   │
│ orchestrator             │  │ orchestrator             │
│                          │  │                          │
│ Returns: SQL query XML   │  │ Returns: C# classes      │
└──────────────────────────┘  └──────────────────────────┘
                  │                    │
                  └─────────┬──────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────────────┐
│ Orchestrator Consolidates Results                              │
│ • Verifies SQL query valid                                     │
│ • Verifies C# classes valid                                    │
│ • Checks all files created                                     │
│ • Generates verification checklist                             │
└───────────────────────────┬────────────────────────────────────┘
                            │
                            │ Returns to main assistant
                            │
                            ▼
┌────────────────────────────────────────────────────────────────┐
│ Main AI Assistant                                              │
│ • Receives orchestrator's final report                         │
│ • Formats for user consumption                                 │
│ • Presents delivery summary                                    │
│ • Provides next steps (build, test)                            │
└────────────────────────────────────────────────────────────────┘
```

## Decision Tree

```
User mentions COSD?
  │
  ├─ NO → Normal conversation flow
  │
  └─ YES → Is it about creating transformations?
            │
            ├─ NO → Answer question directly
            │
            └─ YES → Can we extract Cancer/Version/Domain/Mapping?
                     │
                     ├─ NO → Ask user for clarification
                     │
                     └─ YES → Invoke runSubagent(orchestrator)
                              │
                              └─ Orchestrator invokes sub-agents
                                 │
                                 ├─ SQL Generator
                                 └─ C# Generator
                                    │
                                    └─ Return complete delivery
```

## Error Handling Flow

```
┌────────────────────────────────────────────────────────────────┐
│ Orchestrator Agent                                             │
└───────────────────────────┬────────────────────────────────────┘
                            │
                            ▼
                   Invoke SQL Generator
                            │
              ┌─────────────┴─────────────┐
              │                           │
              ▼                           ▼
         ✅ SUCCESS                   ❌ FAILURE
              │                           │
              │                           ├─ Missing CSV file
              │                           ├─ Invalid cancer code
              │                           └─ Malformed JSON paths
              │                                    │
              │                                    ▼
              │                      Report error to orchestrator
              │                                    │
              │                                    ▼
              │                      Orchestrator reports to user
              │                      "SQL generation failed because..."
              │                      DO NOT attempt manual fix
              │
              ▼
         Invoke C# Generator
              │
   ┌──────────┴──────────┐
   │                     │
   ▼                     ▼
✅ SUCCESS           ❌ FAILURE
   │                     │
   │                     ├─ XML file not found
   │                     ├─ Invalid field mappings
   │                     └─ Namespace errors
   │                          │
   │                          ▼
   │              Report error to orchestrator
   │                          │
   │                          ▼
   │              Orchestrator reports to user
   │              "C# generation failed because..."
   │              DO NOT attempt manual fix
   │
   ▼
Complete Success
   │
   ▼
Return delivery summary
```

## Naming Convention Enforcement

```
Input: Cancer=Sarcoma, Version=v9, Domain=ProcedureOccurrence, Mapping=PrimaryProcedure
   ↓
┌─────────────────────────────────────────────────────────────┐
│ Orchestrator Generates Base Name                            │
│ Pattern: CosdV{version}{cancer}{domain}{mapping}            │
│ Result: CosdV9SarcomaProcedureOccurrencePrimaryProcedure    │
└──────────────────────────┬──────────────────────────────────┘
                           │
                           ▼
┌─────────────────────────────────────────────────────────────┐
│ File Paths Generated (ALL use same base name)               │
├─────────────────────────────────────────────────────────────┤
│ XML:    .../{Cancer}/{Domain}/{BaseName}/{BaseName}.xml     │
│ Record: .../{Cancer}/{Domain}/{BaseName}/{BaseName}Record.cs│
│ Class:  .../{Cancer}/{Domain}/{BaseName}/{BaseName}.cs      │
│ Using:  using {Alias} = OmopTransformer.COSD.{Cancer}...    │
│ Reg:    TransformDataSet<{Alias}.{BaseName}>(...)           │
└──────────────────────────┬──────────────────────────────────┘
                           │
                           ▼
┌─────────────────────────────────────────────────────────────┐
│ Namespace Generated (MUST match folder structure)           │
│ OmopTransformer.COSD.{Cancer}.{Domain}.{BaseName}           │
│ Example:                                                     │
│ OmopTransformer.COSD.Sarcoma.ProcedureOccurrence.CosdV9...  │
└─────────────────────────────────────────────────────────────┘
```

## Quality Verification Flow

```
C# Generator Completes
   ↓
┌─────────────────────────────────────────────────────────────┐
│ Orchestrator Runs Verification Checklist                    │
├─────────────────────────────────────────────────────────────┤
│ ✅ Record class exists                                       │
│ ✅ Transformation class exists                               │
│ ✅ Namespaces match folder structure                         │
│ ✅ Using statement added to CosdTransformer.cs               │
│ ✅ Registration added to Transform() method                  │
│ ✅ Cancer code matches SQL WHERE clause                      │
│ ✅ EmbeddedResource added to .csproj                         │
│ ✅ EmbeddedResource path uses backslashes                    │
│ ✅ All SQL fields present in Record class                    │
│ ✅ All properties nullable (string?)                         │
│ ✅ Correct transformation attributes used                    │
└──────────────────────────┬──────────────────────────────────┘
                           │
              ┌────────────┴────────────┐
              │                         │
              ▼                         ▼
         ALL PASS                   ANY FAIL
              │                         │
              │                         ▼
              │              Report specific failures
              │              Request corrections
              │              DO NOT deliver incomplete
              │
              ▼
      Deliver Complete Package
      ✅ SQL query
      ✅ C# classes
      ✅ Project updates
      ✅ Build instructions
```

---

## Summary

This agent system ensures:
1. **Automatic detection** - Skills catch COSD requests
2. **Proper routing** - Orchestrator coordinates workflow
3. **Specialized execution** - Sub-agents handle SQL/C# generation
4. **Quality verification** - Built-in checks prevent errors
5. **Complete delivery** - All files + instructions provided

**Result**: Consistent, high-quality COSD transformations generated automatically.
