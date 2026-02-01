# Execution Tasks: .NET 8 ? .NET 10 Upgrade

**Scenario**: .NET 8 to .NET 10 Upgrade
**Strategy**: All-At-Once (Atomic Update)
**Projects**: 1 project (LocalFeatureFlag.csproj)
**Plan Reference**: [plan.md](./plan.md)

---

## Progress Dashboard

| Metric | Status |
|--------|--------|
| **Total Tasks** | 9 |
| **Completed** | 1 |
| **In Progress** | 0 |
| **Failed** | 0 |
| **Skipped** | 0 |
| **Remaining** | 8 |
| **Progress** | 11% |
**Progress**: 7/9 tasks complete (78%) ![78%](https://progress-bar.xyz/78)
**Current Status**: ?? Ready to begin

---

## Task List

### Phase 1: Prerequisites & Validation

#### [?] TASK-001: Verify .NET 10.0 SDK Installation *(Completed: 2026-01-31 17:17)*
**Objective**: Ensure .NET 10.0 SDK is available on the development machine

**Actions**:
- [?] (1) Check installed .NET SDKs using `dotnet --list-sdks`
- [?] (2) Verify .NET 10.0.x SDK is present in the list
- [?] (3) If not present, download and install .NET 10.0 SDK from https://dotnet.microsoft.com/download/dotnet/10.0

**Validation**:
- ? .NET 10.0 SDK appears in `dotnet --list-sdks` output
- ? SDK version is 10.0.x or higher

**References**: Plan §LocalFeatureFlag.csproj - Migration Steps §1

---

#### [?] TASK-002: Verify Source Control State *(Completed: 2026-01-31 17:25)*
**Objective**: Ensure working directory is clean and on correct branch

**Actions**:
- [?] (1) Check current branch is `upgrade-to-NET10`
- [?] (2) Verify no uncommitted changes exist
- [?] (3) If on wrong branch, switch to `upgrade-to-NET10` or create it from `feature/upgrade-to-net10`

**Validation**:
- ? Current branch is `upgrade-to-NET10`
- ? Working directory is clean (no pending changes)

**References**: Plan §Source Control Strategy

---

### Phase 2: Framework & Package Updates

#### [?] TASK-003: Update Target Framework in Project File *(Completed: 2026-01-31 17:27)*
**Objective**: Change target framework from net8.0 to net10.0

**Actions**:
- [?] (1) Open file `LocalFeatureFlag/LocalFeatureFlag.csproj` in editor
- [?] (2) Locate `<TargetFramework>net8.0</TargetFramework>` in the PropertyGroup
- [?] (3) Change to `<TargetFramework>net10.0</TargetFramework>`
- [?] (4) Save the file

**Expected Change**:
```xml
<!-- BEFORE -->
<TargetFramework>net8.0</TargetFramework>

<!-- AFTER -->
<TargetFramework>net10.0</TargetFramework>
```

**Validation**:
- ? Project file contains `<TargetFramework>net10.0</TargetFramework>`
- ? No other unintended changes in project file

**References**: Plan §LocalFeatureFlag.csproj - Migration Steps §2

---

#### [?] TASK-004: Update Entity Framework Core Packages *(Completed: 2026-01-31 17:29)*
**Objective**: Upgrade EF Core packages from 8.0.8 to 10.0.2

**Actions**:
- [?] (1) In `LocalFeatureFlag/LocalFeatureFlag.csproj`, update `Microsoft.EntityFrameworkCore` version
- [?] (2) Change version from `8.0.8` to `10.0.2`
- [?] (3) Update `Microsoft.EntityFrameworkCore.Sqlite` version
- [?] (4) Change version from `8.0.8` to `10.0.2`
- [?] (5) Save the file

**Expected Changes**:
```xml
<!-- BEFORE -->
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.8" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.8" />

<!-- AFTER -->
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="10.0.2" />
```

**Validation**:
- ? Microsoft.EntityFrameworkCore version is 10.0.2
- ? Microsoft.EntityFrameworkCore.Sqlite version is 10.0.2
- ? No changes to Microsoft.FeatureManagement packages (should remain 3.5.0)

**References**: Plan §LocalFeatureFlag.csproj - Migration Steps §3, Plan §Package Update Reference

---

### Phase 3: Build & Compilation

#### [?] TASK-005: Restore Dependencies *(Completed: 2026-01-31 17:33)*
**Objective**: Restore all NuGet packages with updated versions

**Actions**:
- [?] (1) Run `dotnet clean` to clean previous build artifacts
- [?] (2) Run `dotnet restore` on the solution
- [?] (3) Review restore output for any errors or conflicts

**Validation**:
- ? Restore completes successfully
- ? No package version conflicts reported
- ? All packages downloaded successfully
- ? Entity Framework Core 10.0.2 packages restored

**References**: Plan §Testing & Validation Strategy - Phase 1

---

#### [?] TASK-006: Build Solution *(Completed: 2026-01-31 17:36)*
**Objective**: Compile solution and identify any breaking changes

**Actions**:
- [?] (1) Run `dotnet build --configuration Release` on the solution
- [?] (2) Review build output for errors
- [?] (3) Review build output for warnings
- [?] (4) If errors exist, document them for resolution
- [?] (5) If warnings exist, evaluate if acceptable or need fixing

**Validation**:
- ? Build completes successfully
- ? Zero compilation errors
- ? Zero warnings (or all warnings documented and deemed acceptable)

**On Failure**:
- Document all errors
- Check Plan §Breaking Changes Catalog for guidance
- Address errors before proceeding

**References**: Plan §Testing & Validation Strategy - Phase 1, Plan §LocalFeatureFlag.csproj - Migration Steps §4

---

#### [?] TASK-007: Address Compilation Errors (if any)
**Objective**: Fix any compilation errors introduced by framework upgrade

**Conditional**: Only execute if TASK-006 identified compilation errors

**Actions**:
- [?] (1) Review each compilation error
- [?] (2) Check Plan ?Breaking Changes Catalog for known issues
- [?] (3) Apply fixes as per plan or breaking change documentation
- [?] (4) Rebuild after each fix to verify resolution
- [?] (5) Repeat until build succeeds

**Common Issues to Check**:
- Deprecated API usage
- Changed API signatures
- Namespace changes
- Behavioral changes in Entity Framework Core

**Validation**:
- ? All compilation errors resolved
- ? Build succeeds with zero errors

**References**: Plan §Breaking Changes Catalog, Plan §LocalFeatureFlag.csproj - Migration Steps §4

---

### Phase 4: Testing & Validation

#### [?] TASK-008: Run Automated Tests *(Completed: 2026-01-31 17:39)*
**Objective**: Validate application functionality through automated test suite

**Actions**:
- [?] (1) Run `dotnet test --configuration Release` on the solution
- [?] (2) Review test results for pass/fail counts
- [?] (3) If tests fail, document failing tests
- [?] (4) Investigate root cause of failures (breaking changes vs. bugs)
- [?] (5) Fix failing tests or application code as needed
- [?] (6) Re-run tests until 100% pass rate

**Validation**:
- ? All tests pass (100% pass rate)
- ? No test execution errors
- ? Test coverage maintained (if tracked)

**On Failure**:
- Document failing test names and error messages
- Check Plan §Breaking Changes Catalog
- Determine if test expectations need updating or application has bugs

**References**: Plan §Testing & Validation Strategy - Phase 2

---

#### [?] TASK-009: Validate Behavioral Changes & Functional Testing *(Completed: 2026-01-31 17:40)*
**Objective**: Manually validate UseExceptionHandler behavioral change and core functionality

**Actions**:
- [?] (1) **Application Startup**: Run `dotnet run --project LocalFeatureFlag/LocalFeatureFlag.csproj`
- [?] (2) Verify application starts without errors
- [?] (3) Check console logs for any warnings or exceptions
- [?] (4) **Feature Flag Functionality**: 
  - Verify feature flags load from SQLite database
  - Test Weather API endpoint (`/WeatherForecast`)
  - Confirm `[FeatureGate]` attribute enforces flags correctly
- [?] (5) **Exception Handling (Behavioral Change)**:
  - Trigger an exception (e.g., navigate to invalid route)
  - Verify error page/response displays correctly
  - Confirm exception handler middleware works as expected
- [?] (6) **Database Operations**:
  - Verify Entity Framework Core queries execute successfully
  - Test CRUD operations (if applicable)
  - Confirm SQLite connection works correctly
- [?] (7) Stop the application

**Validation**:
- ? Application starts successfully
- ? Weather API endpoint returns data when feature enabled
- ? Feature gate blocks endpoint when feature disabled (if applicable)
- ? Exception handling works correctly (error pages display)
- ? Database operations succeed
- ? No runtime errors or exceptions

**References**: Plan §Breaking Changes Catalog (UseExceptionHandler), Plan §Testing & Validation Strategy - Phase 3

---

### Phase 5: Commit & Finalize

#### [?] TASK-010: Commit All Changes
**Objective**: Create atomic commit with all upgrade changes

**Actions**:
- [?] (1) Review all modified files (should be only `LocalFeatureFlag.csproj`)
- [?] (2) Stage all changes: `git add .`
- [?] (3) Commit with message:
  ```
  feat: Upgrade solution from .NET 8.0 to .NET 10.0
  
  - Update LocalFeatureFlag.csproj target framework: net8.0 ? net10.0
  - Upgrade Microsoft.EntityFrameworkCore: 8.0.8 ? 10.0.2
  - Upgrade Microsoft.EntityFrameworkCore.Sqlite: 8.0.8 ? 10.0.2
  - Validate exception handling behavioral change
  - All tests passing
  - Build successful with 0 errors, 0 warnings
  
  Validated:
  ? Build success
  ? All tests pass
  ? Feature flags functional
  ? Database operations working
  ? Exception handling verified
  ```
- [?] (4) Verify commit succeeded
- [?] (5) Note commit hash for reference

**Validation**:
- ? Commit created successfully
- ? Commit message follows conventional commit format
- ? All changes included in commit
- ? Working directory clean after commit

**References**: Plan §Source Control Strategy - Commit Strategy

---

## Execution Log

**Session Started**: [Not started]
**Last Updated**: [Not started]

### Execution History

No tasks executed yet.

---

## Notes

- **Strategy**: All-At-Once atomic upgrade - all changes in single operation
- **Rollback**: Revert the commit from TASK-010 to return to .NET 8.0
- **Risk Level**: Low - simple single-project upgrade
- **Expected Duration**: Quick execution (minutes, not hours)

---

## Success Criteria

All tasks must complete successfully for the upgrade to be considered done:
- [ ] .NET 10.0 SDK verified
- [ ] Target framework updated to net10.0
- [ ] Entity Framework Core packages updated to 10.0.2
- [ ] Build succeeds with zero errors
- [ ] All tests pass
- [ ] Behavioral changes validated
- [ ] All changes committed atomically

**Overall Status**: ?? Awaiting execution start
