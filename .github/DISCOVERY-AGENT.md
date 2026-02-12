# NHS Data Dictionary Discovery Agent - Summary

## ✅ What Was Created

A new intelligent agent that automatically discovers what transformations should be created by analyzing the NHS Data Dictionary website.

### New File
**[.github/agents/nhs-data-dictionary-discovery.agent.md](.github/agents/nhs-data-dictionary-discovery.agent.md)**

### Updated Files
- **[.github/agents/cosd-transformation-pipeline.agent.md](.github/agents/cosd-transformation-pipeline.agent.md)** - Added Phase 0: Discovery
- **[.github/agents/README.md](.github/agents/README.md)** - Documented new agent
- **[.github/AGENT-QUICKSTART.md](.github/AGENT-QUICKSTART.md)** - Added discovery feature explanation

---

## 🎯 What It Does

When you say **"Create me all possible Sarcoma v9 procedures"**, the system now:

### Before (Without Discovery Agent)
```
❌ Had to manually check cosdv901base.csv
❌ Guessed which fields matter
❌ Might miss important fields
❌ Might map deprecated fields
❌ No clinical prioritization
```

### After (With Discovery Agent)
```
✅ Fetches NHS Data Dictionary automatically
✅ Finds ALL procedure-related fields
✅ Extracts permitted values/code systems
✅ Prioritizes by clinical importance
✅ Recommends specific transformations
✅ Provides NHS DD URLs for documentation
✅ Flags deprecated/unmappable fields
```

---

## 🚀 How To Use It

### Simple: Let It Happen Automatically

Just say:
```
Create me all possible Sarcoma v9 procedures
```

The orchestrator will automatically:
1. Detect "all possible" in your request
2. Invoke the discovery agent
3. Get comprehensive field analysis
4. Create all recommended transformations

### Advanced: Request Discovery Explicitly

You can also ask for discovery without creating transformations:
```
What procedure fields are available in COSD Sarcoma v9?
```

The discovery agent will return a report showing:
- All available fields
- Prioritized recommendations
- NHS Data Dictionary links
- Implementation notes

---

## 📊 What The Discovery Agent Provides

### Field Analysis
```markdown
### Primary Procedure (OPCS)
**NHS DD URL**: https://www.datadictionary.nhs.uk/...
**OMOP Domain**: ProcedureOccurrence
**Priority**: 1 (Critical)
**Rationale**: Required for procedure_concept_id mapping

**Mapping Details**:
- Source: PrimaryProcedureOpcs
- Target: procedure_concept_id (via Opcs4Selector)
- Value Set: OPCS-4 classification
- Example: "X123" → 4012345 "Excision of lesion"

**Implementation Notes**:
- Must be present for valid OMOP procedure record
- Lookup via OMOP vocabulary tables
```

### Prioritization
- **Priority 1 (Critical)**: MUST create (dates, codes, patient ID)
- **Priority 2 (High)**: SHOULD create (providers, locations, treatment context)
- **Priority 3 (Medium)**: NICE TO HAVE (clinical details, modifiers)
- **Priority 4 (Low)**: OPTIONAL (administrative, rare fields)

### Value Sets
For coded fields, extracts permitted values:
```markdown
Surgical Access Type:
- 01 - Open
- 02 - Laparoscopic
- 03 - Laparoscopic Converted
- 04 - Robotic
- 05 - Robotic Converted
- 99 - Not Known
```

---

## 🔗 Integration With Existing Agents

### Agent Flow (Batch Mode)

```
You: "Create all possible Sarcoma v9 procedures"
  ↓
Orchestrator: Detects "all possible"
  ↓
Discovery Agent: Fetches NHS Data Dictionary
  ↓
Discovery Agent: Returns 9 recommended transformations
  ↓
Orchestrator: Creates each transformation (1-9)
  ↓
  For each transformation:
    ├─ SQL Generator: Creates query
    └─ C# Generator: Creates classes
  ↓
Orchestrator: Delivers complete summary
```

### Agent Flow (Single Transformation)

```
You: "Create COSD Sarcoma v9 primary procedure"
  ↓
Orchestrator: Detects specific transformation
  ↓
[SKIPS Discovery - not needed]
  ↓
SQL Generator: Creates query
  ↓
C# Generator: Creates classes
  ↓
Orchestrator: Delivers
```

---

## 💡 Benefits

### 1. Comprehensive Coverage
- Never miss important fields
- Discover fields you didn't know existed
- Understand complete dataset structure

### 2. Clinical Prioritization
- Focus on high-value transformations first
- Skip administrative/deprecated fields
- Understand clinical rationale for each mapping

### 3. Official Documentation
- NHS Data Dictionary URLs for every field
- Permitted values from authoritative source
- Code system references (OPCS-4, ICD-10, SNOMED CT)

### 4. Implementation Guidance
- Field dependencies identified
- Data quality expectations noted
- Example mappings provided

### 5. Gap Analysis
- Compare existing transformations to available fields
- Identify unmapped important fields
- Plan future transformation work

---

## 🧪 Try It Now!

Test with any of these commands:

### Batch Discovery + Creation
```
Create me all possible Sarcoma v9 procedures
Create all Lung v8 condition occurrences
Generate all Breast v9 measurements
```

### Discovery Only (Planning)
```
What procedure fields are in COSD Liver v9?
Show me available Colorectal v8 staging fields
What measurements can I extract from COSD Brain v9?
```

### Specific Transformation (Skips Discovery)
```
Create COSD Sarcoma v9 primary procedure transformation
Add Breast tumour size measurement
```

---

## 📚 Technical Details

### Tools Used
- **fetch_webpage**: Scrapes NHS Data Dictionary pages
- **grep_search**: Searches for field patterns in local files
- **semantic_search**: Finds related fields in workspace

### Data Sources
1. **NHS Data Dictionary** (primary): https://www.datadictionary.nhs.uk/
2. **Base Query CSV** (fallback): cosdv81base.csv, cosdv901base.csv
3. **Existing transformations** (context): Checks workspace for already-mapped fields

### Output Format
The agent returns a structured markdown report with:
- Executive summary (counts and priorities)
- Detailed field analysis (one section per field)
- Value set tables (permitted values)
- Implementation recommendations
- Known limitations
- Reference URLs

---

## 🎓 When To Use Discovery Agent

### ✅ USE IT FOR:
- "All possible" batch requests
- New cancer type/version exploration
- Gap analysis of unmapped fields
- Planning transformation work
- Understanding dataset structure

### ⏭️ SKIP IT FOR:
- Single transformation requests with known field names
- Quick edits to existing transformations
- When you already know exactly what you need
- Debugging/troubleshooting existing code

---

## 🔮 Future Enhancements

Potential improvements to the discovery agent:

1. **Data Quality Metrics**: Analyze staging data to show field population rates
2. **Cross-Dataset Discovery**: Compare COSD vs SUS fields for linkage opportunities
3. **Versioning Analysis**: Show field changes between COSD v8 and v9
4. **Concept Mapping Suggestions**: Recommend specific OMOP concepts based on field semantics
5. **Dependency Detection**: Identify required field combinations (e.g., date + code pairs)

---

## 📞 Support

**Agent not working?**
- Verify NHS Data Dictionary is accessible
- Check fetch_webpage tool is available
- Review agent logs for errors
- Fall back to manual field selection

**Wrong fields discovered?**
- Review NHS Data Dictionary URLs in output
- Check domain filter logic in agent
- Verify cancer type/version parameters

**Need custom discovery logic?**
- Edit `.github/agents/nhs-data-dictionary-discovery.agent.md`
- Update domain-to-field mapping patterns
- Adjust prioritization criteria

---

## ✨ Summary

You now have an **intelligent discovery system** that:
- Automatically finds what transformations to create
- Analyzes NHS Data Dictionary for authoritative field lists
- Prioritizes by clinical importance
- Provides implementation guidance
- Integrates seamlessly with your existing agent pipeline

**Just say "Create all possible [cancer] [version] [domain]" and let the agents do the work!** 🚀
