# Skills - Automatic Intent Routing

This directory contains skill definitions that automatically detect user intent and route requests to the appropriate specialized agents. Skills act as "smart routers" that prevent manual implementation of complex workflows.

## What Are Skills?

**Skills** are intent detection patterns that:
1. **Listen** for specific trigger phrases in user requests
2. **Parse** the request to extract parameters
3. **Route** to the appropriate agent(s) via `runSubagent`
4. **Report** back the agent's output to the user

Skills **prevent** the AI from:
- ❌ Manually implementing complex multi-step workflows
- ❌ Creating files directly when agents should be used
- ❌ Duplicating agent logic in conversation responses

## Available Skills

### 🩺 cosd-transformation.skill.md

**Purpose**: Auto-detect and route COSD transformation requests to the agent pipeline

**Triggers**:
- "create cosd transformation"
- "generate cosd [cancer type]"
- "add cosd [domain] mapping"
- Mentions of cancer types + OMOP domains
- Requests for procedure/condition/measurement transformations

**Routing Target**: `cosd-transformation-pipeline.agent.md`

**How It Works**:
1. Detects COSD transformation intent in user message
2. Parses: Cancer Type, Version, Domain, Mapping Name
3. Invokes orchestrator agent with extracted parameters
4. Reports orchestrator's delivery summary

**Example Flow**:
```
User: "Create all 12 Sarcoma v9 procedure transformations"
    ↓
Skill detects: COSD transformation request (batch)
    ↓
Parses: Cancer=Sarcoma, Code=SA, Version=v9, Domain=ProcedureOccurrence, Count=12
    ↓
Invokes: cosd-transformation-pipeline.agent.md (12 times)
    ↓
Reports: Progress tracker + final delivery summary
```

---

## Skill Structure

Each skill file should contain:

### YAML Frontmatter
```yaml
---
description: 'Brief description of skill'
triggers:
  - 'trigger phrase 1'
  - 'trigger phrase 2'
agents:
  - 'agent-to-route-to.agent.md'
---
```

### Markdown Content
```markdown
## Purpose
What the skill does

## When This Skill Activates
Detailed trigger patterns and examples

## Automatic Routing Logic
Step-by-step routing process

## DO NOT Manually Implement
Forbidden patterns (manual file creation, etc.)

## Skill Output
Expected response format

## Error Handling
What to do if routing fails
```

## How Skills Work With Copilot Instructions

**Integration Flow**:
```
User Request
    ↓
[Copilot Instructions - General Guidance]
    ↓
[Skill Detection - Intent Pattern Matching]
    ↓
[Agent Invocation - runSubagent]
    ↓
[Agent Execution - Specialized Logic]
    ↓
[Skill Reporting - User-Facing Summary]
```

**Key Files**:
1. `.github/copilot-instructions.md` - Lists available agents/skills
2. `.github/skills/[skill].skill.md` - Intent detection + routing
3. `.github/agents/[agent].agent.md` - Execution logic

## Creating New Skills

### When to Create a Skill

Create a skill when:
- ✅ There's a multi-step workflow that shouldn't be done manually
- ✅ Multiple agents need orchestration
- ✅ Users frequently request the same complex task
- ✅ Manual implementation often leads to errors

**Examples**:
- ✅ COSD transformation pipeline (SQL + C# + registration)
- ✅ Bulk migration of transformations (v8 → v9)
- ✅ Creating new data source integration (full setup)

Do NOT create a skill for:
- ❌ Simple file edits
- ❌ One-off debugging tasks
- ❌ Read-only operations (file inspection, searching)

### Skill Creation Template

```yaml
---
description: 'What this skill does in one sentence'
triggers:
  - 'exact trigger phrase'
  - 'pattern with [variable]'
agents:
  - 'primary-agent.agent.md'
  - 'fallback-agent.agent.md'
---

# Skill Name

## Purpose
Detailed description of skill's responsibility

## When This Skill Activates
- Trigger pattern 1
- Trigger pattern 2
- Examples with context

## Automatic Routing Logic
### Step 1: Parse Request
Extract parameters...

### Step 2: Route to Agent
Invoke with parameters...

### Step 3: Report Results
Format and present...

## DO NOT Manually Implement
- ❌ Action 1 (use agent instead)
- ❌ Action 2 (use agent instead)

## Skill Output
Expected response format with examples

## Error Handling
What to do if agents fail

## Testing the Skill
How to verify skill works correctly
```

### Skill Best Practices

1. **Be Specific With Triggers**: Match exact phrases users will say
2. **Parse All Parameters**: Extract every detail needed by agent
3. **Validate Before Routing**: Check parameters are complete/valid
4. **Report Progress**: Keep user informed during execution
5. **Handle Failures**: Graceful error messages, don't retry manually

### Example: Adding a SUS Transformation Skill

```yaml
---
description: 'Route SUS (Secondary Uses Service) transformation requests'
triggers:
  - 'create sus transformation'
  - 'generate sus inpatient'
  - 'add sus outpatient'
agents:
  - 'sus-transformation-pipeline.agent.md'
---

# SUS Transformation Skill

## Purpose
Automatically route requests to create SUS (inpatient/outpatient) transformations
to the specialized agent pipeline.

## When This Skill Activates
- User mentions "SUS" + "transformation"
- Requests for SUS-OP or SUS-APC mappings
- Mentions HES (Hospital Episode Statistics) transformations

## Automatic Routing Logic
### Step 1: Parse Request
Extract:
- Dataset type (SUS-OP, SUS-APC, SUS-A&E)
- OMOP domain
- Mapping description

### Step 2: Route to Agent
Invoke sus-transformation-pipeline.agent.md with parameters

### Step 3: Report Results
Present agent's delivery summary

[... rest of skill definition ...]
```

## Skill Maintenance

### Updating Skills
When agent logic changes:
1. Update skill to pass new required parameters
2. Update trigger patterns if request phrasing changes
3. Update error handling for new failure modes

### Testing Skills
To test a skill:
1. Use exact trigger phrase from skill definition
2. Verify it routes to agent (not manual implementation)
3. Check agent receives correct parameters
4. Confirm final output matches expected format

### Debugging Skills
If skill doesn't activate:
- ✅ Check trigger patterns match user's exact phrasing
- ✅ Verify skill file is in `.github/skills/` directory
- ✅ Ensure copilot-instructions.md references the skill
- ✅ Look for typos in agent file paths

## Advanced: Multi-Agent Skills

Some skills may need to coordinate multiple agents in sequence:

```markdown
## Automatic Routing Logic
### Step 1: Invoke Data Extraction Agent
Extract raw data from source...

### Step 2: Invoke Validation Agent
Validate extracted data quality...

### Step 3: Invoke Transformation Agent
Generate OMOP mappings...

### Step 4: Consolidate Results
Combine outputs and report...
```

**Use Case**: Complex migrations requiring validation + transformation + registration

## Integration With Agents

**Skills complement agents**:
- **Skills**: DETECT intent, ROUTE to agents, REPORT results
- **Agents**: EXECUTE complex logic, GENERATE files, VERIFY output

**Do not duplicate logic**:
- ❌ Skill should NOT contain transformation logic (that's in agents)
- ❌ Agent should NOT worry about intent detection (that's in skills)
- ✅ Clean separation of concerns

## Summary

Skills make the AI assistant smarter by:
1. **Preventing manual work** - Routes to agents automatically
2. **Ensuring consistency** - Always uses validated agent logic
3. **Improving UX** - Users don't need to know agent names
4. **Reducing errors** - No manual file creation bypassing agents

**Think of skills as the "receptionist" that directs requests to the right specialist (agent).**
