# CI Validation Pipeline - Quick Start Guide

## Overview

The CI Validation Pipeline agent automates the entire process of validating code changes through Azure DevOps:
- Creates feature branch
- Commits and pushes changes
- Creates pull request
- Triggers Azure DevOps pipeline (omop-ci build)
- Monitors execution  
- Analyzes results
- Suggests fixes if build fails

## Basic Usage

### Scenario 1: Validate After Creating Transformation

After using the COSD transformation pipeline to generate new code:

```
User: "Validate the Sarcoma v9 Primary Procedure transformation I just created"
```

**What Happens**:
1. Agent detects uncommitted changes
2. Creates branch: `feature/cosd-sarcoma-v9-primary-procedure`
3. Commits: "feat: Add COSD Sarcoma v9 Primary Procedure transformation"
4. Pushes to remote
5. Creates PR with detailed description
6. Triggers omop-ci pipeline
7. Monitors build (progress updates every 1-2 minutes)
8. Reports: ✅ PASSED or ❌ FAILED with error details

### Scenario 2: Validate Multiple Changes

After manually editing several files:

```
User: "I've updated the Icd10Selector and added null checks. Can you validate these changes?"
```

**What Happens**:
1. Creates branch: `feature/fix-icd10-selector-null-handling`  
2. Commits all modified files
3. PR creation and pipeline trigger
4. Full validation cycle
5. Results report

### Scenario 3: Custom Branch Name

When you want to control the branch name:

```
User: "Validate my changes on branch feature/ticket-1234-fix-concepts"
```

**What Happens**:
1. Uses your specified branch name
2. Same workflow as above
3. PR references branch name

## Advanced Usage

### Automatic Fix Attempts

If the build fails, the agent can attempt fixes:

```
Pipeline Failed:
❌ CI Validation FAILED

Error: Missing using statement for 'Icdo3Selector'

Would you like me to attempt automatic fixes?
```

**User Response**: "Yes"

**What Happens**:
1. Agent analyzes error pattern
2. Identifies fix: Add `using OmopTransformer.ConceptResolution;`
3. Applies fix and commits
4. Pushes updated branch
5. Re-triggers pipeline
6. Monitors again
7. Up to 3 automatic retry attempts

### Custom Commit Message

For specific commit messages:

```
User: "Validate with commit message: 'fix: Resolve null reference in concept lookup (#1234)'"
```

**What Happens**:
- Uses your custom commit message instead of auto-generated one
- Normal validation workflow

### Specific Files Only

To commit only certain files:

```
User: "Validate just the changes to CosdSarcomaTransformer.cs and the XML query files"
```

**What Happens**:
1. Commits only specified files
2. Other modifications remain unstaged
3. Normal validation workflow

## Understanding Results

### Success Report

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
- ✅ All Stages: Completed

Files Changed:
- OmopTransformer/COSD/Sarcoma/ProcedureOccurrence/CosdV9SarcomaProcedureOccurrencePrimaryProcedure.cs
- OmopTransformer/COSD/Sarcoma/ProcedureOccurrence/CosdV9SarcomaProcedureOccurrencePrimaryProcedure.xml
- OmopTransformer/COSD/Sarcoma/ProcedureOccurrence/CosdV9SarcomaProcedureOccurrencePrimaryProcedureRecord.cs
- OmopTransformer/COSD/CosdTransformer.cs
- OmopTransformer/OmopTransformer.csproj

Next Steps:
- Review PR: [View PR #42](link)
- Approve & Merge: Changes are ready for integration

Ready to merge! 🎉
```

**What to do**: Review the PR, request code review if needed, then merge.

### Failure Report with Recommendations

```
❌ CI Validation FAILED

Branch: feature/cosd-sarcoma-v9-primary-procedure
PR: #42
Pipeline: omop-ci (Run #123)
Duration: 3m 12s
Status: Failed

Error Summary (3 errors detected):

1. Compilation Error (Critical)
   error CS0246: The type or namespace name 'Icdo3Selector' could not be found
   File: CosdV9SarcomaProcedureOccurrencePrimaryProcedure.cs:45
   
   Root Cause: Missing using statement
   
   Recommended Fix:
   // Add to top of file:
   using OmopTransformer.ConceptResolution;

2. Compilation Error (Critical)  
   error CS1061: 'TumourLateralityLookup' does not contain a definition for 'Resolve'
   File: CosdV9SarcomaProcedureOccurrencePrimaryProcedure.cs:89
   
   Root Cause: Incorrect method name (should be 'Map')
   
   Recommended Fix:
   // Change line 89 from:
   var laterality = TumourLateralityLookup.Resolve(value);
   // To:
   var laterality = TumourLateralityLookup.Map(value);

3. Test Failure (High Priority)
   Failed: CosdSarcomaProcedureTests.TestPrimaryProcedureMapping
   Expected: 1234, Actual: null
   
   Root Cause: Null value returned from concept lookup
   
   Recommended Fix:
   - Check SQL query returns expected data
   - Verify concept mapper handles null values
   - Add defensive null checking:
     if (record?.ProcedureCode != null) { ... }

Required Actions:

1. ✏️ Fix compilation errors in:
   - [ ] CosdV9SarcomaProcedureOccurrencePrimaryProcedure.cs
   - [ ] Add missing using statement (line 1)
   - [ ] Fix method call (line 89)

2. 🔧 Fix test failure:
   - [ ] Review CosdSarcomaProcedureTests.cs
   - [ ] Update test expectations or fix transformation logic
   - [ ] Add null handling

Next Steps:

Option 1: I can attempt automatic fixes (Recommended)
- I can make the necessary code changes to fix these issues
- Then re-run this validation pipeline

Option 2: Manual fixes
- Review the errors above
- Make fixes manually  
- Run `dotnet build` locally to verify
- Request validation again

Option 3: Review in Azure DevOps
- [View full build logs](link-to-azure-devops)

Would you like me to attempt automatic fixes?
```

**What to do**: 
- Say "yes" for automatic fixes
- Say "no" to fix manually
- Review detailed error context

## Integration with COSD Pipeline

Perfect workflow combination:

```
Step 1: Create Transformation
User: "Create COSD Sarcoma v9 Primary Procedure transformation"
→ cosd-transformation-pipeline.agent.md generates files

Step 2: Validate Changes  
User: "Validate these changes"
→ ci-validation-pipeline.agent.md runs validation

Step 3: Merge (if passed)
Review PR and merge to main
```

## Troubleshooting

### "No uncommitted changes found"

**Problem**: Agent says no changes to validate

**Solution**: 
- Ensure files were actually modified
- Check git status: `git status`
- Stage changes if needed: `git add -A`

### "Pipeline not found: omop-ci"

**Problem**: Azure DevOps pipeline cannot be located

**Solutions**:
- Verify pipeline name in Azure DevOps portal
- Check project permissions
- Ensure MCP tools are properly configured
- Pipeline might be named differently (check with team)

### "Push failed: Remote branch has changes"

**Problem**: Someone else pushed to the branch

**Solutions**:
- Use different branch name
- Pull latest changes first
- Resolve any conflicts manually

### "Pipeline timeout (30 minutes)"

**Problem**: Build is taking longer than expected

**Solutions**:
- Continue monitoring in Azure DevOps portal
- Check for infrastructure issues
- Pipeline might be queued behind other builds
- Consider increasing timeout for large changes

### "Cannot create PR: Permissions denied"

**Problem**: Insufficient Azure DevOps permissions

**Solutions**:
- Verify you have "Contribute" permission on repository
- Verify you have "Create Pull Request" permission  
- Contact project administrator to grant access

## Best Practices

### ✅ DO
- Run validation after every significant code change
- Let agent attempt automatic fixes for simple errors
- Review PR description before final merge
- Use descriptive change descriptions
- Monitor first validation to understand the flow

### ❌ DON'T  
- Skip validation to save time (it will fail in main branch)
- Merge PRs without reviewing validation results
- Manually trigger pipeline in Azure DevOps (let agent do it)
- Create branch manually then run validation (agent handles it)
- Ignore warnings even if build passes

## Common Patterns

### Pattern 1: Generate and Validate (Full Cycle)

```
1. User: "Create COSD Lung v9 Primary Diagnosis"
   → COSD pipeline generates files
   
2. User: "Validate"  
   → CI pipeline validates
   
3. If ✅ Pass: "Merge the PR"
   If ❌ Fail: "Fix the errors" → Re-validate
```

### Pattern 2: Multi-Transformation Batch

```
1. User: "Create all COSD Sarcoma v9 procedure transformations"
   → COSD pipeline generates 5 transformations
   
2. User: "Validate all changes"
   → CI pipeline validates all at once
   
3. Review comprehensive results
```

### Pattern 3: Fix and Retry

```
1. User: "Validate my changes"
   → CI pipeline: ❌ FAILED (3 errors)
   
2. User: "Yes, attempt fixes"  
   → Agent fixes 2/3 errors automatically
   → Re-validates: ❌ FAILED (1 error)
   
3. User: "I'll fix the last error manually"
   → Make manual fix
   
4. User: "Validate again"
   → CI pipeline: ✅ PASSED
```

## Performance Expectations

- **Branch creation**: < 5 seconds
- **Commit and push**: < 10 seconds
- **PR creation**: < 5 seconds  
- **Pipeline trigger**: < 10 seconds
- **Pipeline execution**: 5-15 minutes (typical)
- **Log analysis**: < 30 seconds
- **Total time (success)**: ~8-10 minutes
- **Total time (failure)**: ~3-5 minutes (fails fast)

## What Gets Checked

The omop-ci pipeline validates:

1. **Build**:
   - C# compilation
   - Project references
   - NuGet package restoration
   - XML embedded resource loading

2. **Tests**:
   - Unit test execution
   - Test result analysis
   - Code coverage (optional)

3. **Code Quality**:
   - Code analysis rules
   - Static analysis
   - Warning detection

4. **Validation**:
   - Namespace consistency
   - File structure
   - Naming conventions

## Quick Reference Commands

| User Intent | Example Request |
|-------------|----------------|
| Basic validation | "Validate my changes" |
| With custom branch | "Validate on branch feature/my-feature" |
| After transformation | "Validate the Sarcoma transformation" |
| With auto-fix | "Validate and fix any errors" |
| Specific files | "Validate just the Transformer.cs file" |
| Custom commit message | "Validate with message 'fix: Issue #123'" |

## Getting Help

If the agent encounters issues:

1. **Check error message**: Agent provides detailed context
2. **Review Azure DevOps portal**: Direct link provided in reports
3. **Run local build**: `dotnet build` to reproduce locally
4. **Check agent logs**: Review detailed execution steps
5. **Contact support**: Provide PR number and run ID

---

**Remember**: The goal is to catch issues early, before they reach the main branch. Let the agent handle the tedious parts of CI validation while you focus on writing great code! 🚀
