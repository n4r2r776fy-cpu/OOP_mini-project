# Test Strategy - Iteration 3

## Critical scenarios
- Order creation and payment flow (status transitions, empty orders prevention).
- Product inventory invariants (stock reduction, no negative stock).
- Discount strategies (NoDiscount, BulkDiscount) and edge thresholds.
- Persistence: save/load aggregates and restore behavior after reload.
- Fault handling for file I/O (missing file, corrupted JSON, retry behavior).

## Hard-to-test areas
- File I/O and persistence due to external filesystem dependence.
- Any static or hidden dependencies in services (rare in this codebase) which need seams.

## Mocks vs Integration
- Use mocks for external dependencies in unit tests (e.g., external APIs if present).
- Use real persistence (file-based) for integration tests to verify end-to-end save/load.

## Negative scenarios to cover early
- Corrupted or empty persistence file during load.
- I/O exceptions (access denied, disk full) during save.
- Applying discounts on borderline totals (1000.00, 1000.01).
- Concurrent modification edge-cases when reducing stock (simulated).

## Test data and fixtures
- Use builders for `Product`, `Order`, `OrderItem` to create readable test data.
- Use temporary files (`Path.GetTempFileName()` / `TempFile` pattern) for integration file tests.

## Coverage targets
- Aim for >80% coverage for domain and services code.
- Ensure critical paths (order lifecycle, persistence) are fully covered.

## CI Quality Gate
- Run `dotnet test` with `coverlet` collecting OpenCover format.
- Fail pipeline if any test fails.

