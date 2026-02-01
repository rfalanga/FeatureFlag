# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v10.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [LocalFeatureFlag\LocalFeatureFlag.csproj](#localfeatureflaglocalfeatureflagcsproj)


## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 1 | All require upgrade |
| Total NuGet Packages | 4 | 2 need upgrade |
| Total Code Files | 20 |  |
| Total Code Files with Incidents | 2 |  |
| Total Lines of Code | 350 |  |
| Total Number of Issues | 4 |  |
| Estimated LOC to modify | 1+ | at least 0.3% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :--- |
| [LocalFeatureFlag\LocalFeatureFlag.csproj](#localfeatureflaglocalfeatureflagcsproj) | net8.0 | 🟢 Low | 2 | 1 | 1+ | AspNetCore, Sdk Style = True |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 2 | 50.0% |
| ⚠️ Incompatible | 0 | 0.0% |
| 🔄 Upgrade Recommended | 2 | 50.0% |
| ***Total NuGet Packages*** | ***4*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 1 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 1169 |  |
| ***Total APIs Analyzed*** | ***1170*** |  |

## Aggregate NuGet packages details

| Package | Current Version | Suggested Version | Projects | Description |
| :--- | :---: | :---: | :--- | :--- |
| Microsoft.EntityFrameworkCore | 8.0.8 | 10.0.2 | [LocalFeatureFlag.csproj](#localfeatureflaglocalfeatureflagcsproj) | NuGet package upgrade is recommended |
| Microsoft.EntityFrameworkCore.Sqlite | 8.0.8 | 10.0.2 | [LocalFeatureFlag.csproj](#localfeatureflaglocalfeatureflagcsproj) | NuGet package upgrade is recommended |
| Microsoft.FeatureManagement | 3.5.0 |  | [LocalFeatureFlag.csproj](#localfeatureflaglocalfeatureflagcsproj) | ✅Compatible |
| Microsoft.FeatureManagement.AspNetCore | 3.5.0 |  | [LocalFeatureFlag.csproj](#localfeatureflaglocalfeatureflagcsproj) | ✅Compatible |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |
| M:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler(Microsoft.AspNetCore.Builder.IApplicationBuilder,System.String) | 1 | 100.0% | Behavioral Change |

## Projects Relationship Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>📦&nbsp;LocalFeatureFlag.csproj</b><br/><small>net8.0</small>"]
    click P1 "#localfeatureflaglocalfeatureflagcsproj"

```

## Project Details

<a id="localfeatureflaglocalfeatureflagcsproj"></a>
### LocalFeatureFlag\LocalFeatureFlag.csproj

#### Project Info

- **Current Target Framework:** net8.0
- **Proposed Target Framework:** net10.0
- **SDK-style**: True
- **Project Kind:** AspNetCore
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 25
- **Number of Files with Incidents**: 2
- **Lines of Code**: 350
- **Estimated LOC to modify**: 1+ (at least 0.3% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["LocalFeatureFlag.csproj"]
        MAIN["<b>📦&nbsp;LocalFeatureFlag.csproj</b><br/><small>net8.0</small>"]
        click MAIN "#localfeatureflaglocalfeatureflagcsproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 1 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 1169 |  |
| ***Total APIs Analyzed*** | ***1170*** |  |

