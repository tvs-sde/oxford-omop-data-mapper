---
layout: default
title: Configuration
parent: User Guide
---

# Configuration

This application can be configured by altering the `appsettings.json` file.

The tool uses [DuckDB](https://duckdb.org/) for storage, so the `ConnectionString` uses DuckDB's [DuckDB.NET](https://duckdb.net/docs/connection-string.html) connection string format.

An example configuration

```
{
    "ConnectionString": "DataSource=/data/omop.db;memory_limit=4GB",
    "VocabularyDirectory": "/vocabulary",
    "BatchSize": 200000
}
```

| Property            | Remarks                                                                                                                                                                                                                         |
|---------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ConnectionString    | [DuckDB.NET](https://duckdb.net/docs/connection-string.html) connection string specifying the DuckDB file that holds the OMOP data. A `.db` file is created at this location by the [`init`]({% link docs/user-guide/commands.md %}#init-command) command. |
| VocabularyDirectory | Path to the directory containing the unpacked Athena vocabulary CSVs. Used by the [`init`]({% link docs/user-guide/commands.md %}#init-command) command. Defaults to `/vocabulary`.                                              |
| BatchSize           | The maximum number of rows that can be inserted by any operation. Increasing this value can increase the speed of the transform operation.                                                                                      |

Any of these settings can also be provided on the Docker command line as `-e` environment variables (for example `-e ConnectionString=...`), which overrides the value in `appsettings.json`.