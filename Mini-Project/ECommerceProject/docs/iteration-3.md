(Iteration 3 changes and summary)

- Added test strategy and extensive tests (unit + integration).
- Fixed BulkDiscount rounding to match expected business rule used in tests.
- Added coverage collection instructions and TESTING.md.

Summary:
- Unit tests: 21
- Integration tests: 8
- Coverage: collected via coverlet (use `dotnet test /p:CollectCoverage=true`).

Remaining risks:
- Some persistence APIs lack full-create/update semantics; repository API is limited and may need enhancement for full CRUD operations in next iteration.
- No CI pipeline configured here to enforce quality gate automatically; recommend adding GitHub Actions or Azure DevOps pipeline to run tests and coverage.

