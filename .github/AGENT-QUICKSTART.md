# Agent & Skill System - Quick Reference

## ✅ What Just Got Fixed

Your AI assistant was manually creating COSD transformation files instead of using your specialized agents. Now it will automatically detect COSD requests and route to your agent pipeline.

## 📁 Files Created

```
.github/
├── agents/
│   ├── README.md ✨ NEW - Agent documentation
│   ├── cosd-transformation-pipeline.agent.md (existing)
│   ├── cosd-procedure-query-generator.agent.md (existing)
│   └── cosd-csharp-transformer-generator.agent.md (existing)
├── skills/
│   ├── README.md ✨ NEW - Skills documentation
│   └── cosd-transformation.skill.md ✨ NEW - Auto-routing logic
└── copilot-instructions.md ✨ UPDATED - Added agent guidance
```

## 🚀 How It Works Now

### Before (Manual ❌)
```
You: "Create all 12 Sarcoma v9 procedures"
AI: "I'll create the files..." [manually creates SQL, C#, etc.]
Result: ❌ Inconsistent, error-prone, missing steps
```

### After (Automated ✅)
```
You: "Create all 12 Sarcoma v9 procedures"
AI: [Detects COSD intent via skill]
    [Routes to cosd-transformation-pipeline.agent.md]
    [Orchestrator invokes sub-agents for SQL + C#]
    [All files generated with verification]
Result: ✅ Consistent, complete, verified
```

## 💬 Example Commands That Trigger Auto-Routing

Try these phrases:
- "Create COSD Sarcoma v9 primary procedure transformation"
- "Generate all Lung v8 procedure transformations"
- "Add Breast tumour size measurement mapping"
- "Create COSD Liver v9 condition occurrence for primary diagnosis"

## 🎯 What Happens When You Request a COSD Transformation

### Detection Phase
1. **Skill activates** (`.github/skills/cosd-transformation.skill.md`)
2. **Parses your request**:
   - Cancer Type: Sarcoma
   - Cancer Code: SA
   - Version: v9
   - Domain: ProcedureOccurrence
   - Mapping: Primary Procedure OR "all possible"

### Routing Phase
3. **Invokes orchestrator** (`.github/agents/cosd-transformation-pipeline.agent.md`)
4. **Orchestrator validates** inputs and determines file paths

### Discovery Phase (Batch Requests Only)
If you said "all possible" or "all procedures":
5a. **Discovery agent invoked** → Fetches NHS Data Dictionary
5b. **Analyzes available fields** → Identifies procedure-related fields
5c. **Recommends transformations** → Prioritizes by clinical value
5d. **Returns field list** → Orchestrator creates each transformation

### Execution Phase
5. **SQL Generator invoked** → Creates XML query file (for each transformation)
6. **C# Generator invoked** → Creates Record + Transformation classes (for each)
7. **Project files updated** → CosdTransformer.cs + .csproj

### Delivery Phase
8. **Verification checklist** provided
9. **Build instructions** given
10. **Summary report** delivered

## 🔍 New Feature: Automatic Discovery

When you say "all possible [cancer] [version] [domain]", the system:

1. **Queries NHS Data Dictionary** - Fetches the official dataset specification
2. **Extracts relevant fields** - Finds all fields for your domain (procedures, conditions, etc.)
3. **Analyzes each field** - Determines OMOP mappability and clinical value
4. **Prioritizes transformations**:
   - **Priority 1 (Critical)**: Required for OMOP CDM (dates, codes, patient ID)
   - **Priority 2 (High)**: Significant clinical value (providers, locations)
   - **Priority 3 (Medium)**: Enrichment fields (clinical details)
   - **Priority 4 (Low)**: Nice-to-have (administrative fields)
5. **Creates all recommended transformations** automatically

**Example Discovery Output:**
```
🔍 NHS Data Dictionary Discovery Results

Sarcoma v9 Procedure Fields Found: 15
Recommended Transformations: 9

Priority 1 (Creating now):
 ✅ Primary Procedure (OPCS) - Required for procedure_concept_id
 ✅ Procedure Date - Required for procedure_date

Priority 2 (Creating now):
 ✅ Consultant Code - Provider linkage
 ✅ Organisation Site - Care site linkage
 ✅ Cancer Treatment Modality - Context

Priority 3 (Creating now):
 🔄 Surgical Access Type - Modifier
 🔄 Surgical Margins - Outcome
 🔄 ASA Score - Patient fitness

Not Creating:
 ⏭️ Internal Audit Fields (6) - Administrative only
```

## 🛡️ What the System Prevents

### ❌ NO MORE:
- Manually creating SQL query files
- Manually creating C# Record classes
- Manually creating C# Transformation classes
- Forgetting to update CosdTransformer.cs
- **Guessing which fields to map** ← NEW!
- **Missing important fields** ← NEW!
- **Mapping deprecated fields** ← NEW!
- Forgetting to update OmopTransformer.csproj
- Namespace mismatches with folder structure
- Cancer code mismatches between SQL and registration
- Missing transformation attributes
- Incorrect EmbeddedResource paths

### ✅ NOW AUTOMATIC:
- All SQL query generation
- All C# class generation
- All project file updates
- All naming convention enforcement
- All verification steps

## 🧪 Testing the System

### Simple Test
```
You: "Create COSD Sarcoma v9 primary procedure transformation"

Expected Response:
"✅ COSD Transformation Pipeline Invoked

Request: Sarcoma v9 Primary Procedure
Routing: cosd-transformation-pipeline.agent.md
Status: In Progress

[Orchestrator executes...]
[SQL generated...]
[C# generated...]
[Files updated...]

✅ COMPLETE - Files created:
- OmopTransformer/COSD/Sarcoma/ProcedureOccurrence/CosdV9SarcomaProcedureOccurrencePrimaryProcedure/...
..."
```

### Batch Test
```
You: "Create all 12 Sarcoma v9 procedure transformations"

Expected Response:
"COSD Batch Transformation Progress

Sarcoma v9 Procedures (12 transformations):
 ✅ 1/12 - Primary Procedure (Complete)
 ✅ 2/12 - Secondary Procedure (Complete)
 🔄 3/12 - Surgical Access (In Progress)
 ⏳ 4/12 - ... (Pending)
..."
```

## 🔍 Verifying It's Working

**Signs it's working correctly**:
- ✅ AI says "Routing to orchestrator agent"
- ✅ AI invokes `runSubagent` tool
- ✅ You see phase-by-phase progress reports
- ✅ Final delivery includes verification checklist

**Signs it's NOT working** (old behavior):
- ❌ AI says "I'll create the files..."
- ❌ AI uses `create_file` tool directly
- ❌ No mention of agents or orchestrator
- ❌ Missing verification steps

## 📚 Documentation

- **Agent details**: [.github/agents/README.md](.github/agents/README.md)
- **Skills details**: [.github/skills/README.md](.github/skills/README.md)
- **Main instructions**: [.github/copilot-instructions.md](.github/copilot-instructions.md)

## 🔧 Customization

### Adding New Cancer Types
The system already supports:
- Colorectal (CT)
- Lung (LU)
- Sarcoma (SA)
- Breast (BR)
- Brain/CNS (BA)
- Liver (LV)

No changes needed - just request any cancer type!

### Adding New Domains
The system supports:
- ProcedureOccurrence
- ConditionOccurrence
- Measurement
- Observation
- Death

If you need a new domain, update the agents with the new base class patterns.

### Adding New COSD Versions
Currently supports v8 and v9. For new versions:
1. Add new base query CSV (e.g., `cosdv10base.csv`)
2. Update SQL generator agent to handle new JSON paths
3. Update C# generator for any new field patterns

## 🆘 Troubleshooting

### "AI is still creating files manually"
1. Check that copilot-instructions.md is loaded
2. Verify your request uses COSD trigger words
3. Try more explicit: "Use the agent pipeline to create..."

### "Agent produces errors"
1. Check base query CSV files exist (cosdv81base.csv, cosdv901base.csv)
2. Verify example files (Colorectal) are valid
3. Review agent logs for specific error message

### "Build fails after generation"
1. Run the verification checklist from orchestrator output
2. Check namespace matches folder structure
3. Verify EmbeddedResource paths use backslashes
4. Ensure cancer code matches SQL WHERE clause

## 🎓 How to Use This System

### For Single Transformations
```
You: "Create COSD {Cancer} {Version} {Domain} for {Description}"
```

### For Batch Transformations
```
You: "Create all {Cancer} {Version} {Domain} transformations"
```

### For Custom Requirements
```
You: "Create COSD Sarcoma v9 procedure including surgical margin status and access approach fields"
```

The orchestrator will pass special requirements to sub-agents.

## 🎉 Benefits

**Speed**: Generates complete transformations in seconds vs hours
**Consistency**: Every transformation follows exact same pattern
**Quality**: Built-in verification prevents common errors
**Documentation**: Automatic inline comments and field explanations
**Maintainability**: Changes to pattern update all future generations

---

**You're all set!** Try requesting a COSD transformation and watch the agent pipeline in action. 🚀
