# TESTING

How to run tests and generate coverage locally

1. Run unit + integration tests:

```powershell
cd "d:\OOP_mini project\Mini-Project\ECommerceProject"
dotnet test
```

2. Run tests with coverage (OpenCover format):

```powershell
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

3. (Optional) Generate HTML report (install reportgenerator):

```powershell
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:**/coverage.opencover.xml -targetdir:coverage-report
```

What is covered

- Unit tests: domain invariants, edge cases, discount strategies, order lifecycle.
- Integration tests: `JsonProductRepository` file-based persistence (save/load, corrupted files, roundtrip).

