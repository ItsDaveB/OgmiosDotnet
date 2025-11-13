# Milestone 1 - Transaction Submission + Typed Ledger Schema & Service Definitions

## Proof of Achievement

OgmiosDotnet now offers production-ready transaction submission and evaluation capabilities, complete with fully typed schema support for Ogmios v6.13.

---

## 1. Typed Schema Update

**Output:** Complete .NET request and response models for Ogmios v6.13 ledger state queries, transaction submission, and transaction evaluation with serialization and validation support.

**Evidence:**

- Transaction submission: [`Ogmios.SubmitTransaction.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Schema/Ogmios/v6.13/Generated/Ogmios.SubmitTransaction.cs) | [`Response`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Schema/Ogmios/v6.13/Generated/Ogmios.SubmitTransactionResponseEntity.cs)
- Transaction evaluation: [`Ogmios.EvaluateTransaction.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Schema/Ogmios/v6.13/Generated/Ogmios.EvaluateTransaction.cs) | [`Response`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Schema/Ogmios/v6.13/Generated/Ogmios.EvaluateTransactionResponseEntity.cs)
- All v6.13 schemas: [`src/Ogmios.Schema/Ogmios/v6.13/Generated/`](https://github.com/ItsDaveB/OgmiosDotnet/tree/main/src/Ogmios.Schema/Ogmios/v6.13/Generated)

---

## 2. Service Contracts

**Output:** Interfaces defined for ledger query services, transaction submission service, and transaction evaluation service.

**Evidence:**

**Transaction Services:**

- [`ITransactionSubmissionService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionSubmission/ITransactionSubmissionService.cs)
- [`ITransactionEvaluationService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionEvaluation/ITransactionEvaluationService.cs)

**Ledger State Query Interfaces:**

- All 20+ ledger query interfaces: [`LedgerStateQueries/Contracts/`](https://github.com/ItsDaveB/OgmiosDotnet/tree/main/src/Ogmios.Services/LedgerStateQueries/Contracts)

---

## 3. Transaction Submission Implementation

**Output:** Working transaction submission service with typed error handling.

**Evidence:**

- Service: [`TransactionSubmissionService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionSubmission/TransactionSubmissionService.cs)
- Exceptions: [`SubmitTransactionExceptions.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionSubmission/SubmitTransactionExceptions.cs)
- Example: [`OgmiosWorker.cs#L85-L96`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/OgmiosWorker.cs#L85-L96)
- Documentation: [`TransactionSubmission/docs/README.md`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionSubmission/docs/README.md)

---

## 4. Transaction Evaluation Implementation

**Output:** Working transaction evaluation service with typed error handling.

**Evidence:**

- Service: [`TransactionEvaluationService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionEvaluation/TransactionEvaluationService.cs)
- Exceptions: [`TransactionEvaluationExceptions.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionEvaluation/TransactionEvaluationExceptions.cs)
- Example: [`OgmiosWorker.cs#L68-L83`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/OgmiosWorker.cs#L68-L83)
- Documentation: [`TransactionEvaluation/docs/README.md`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionEvaluation/docs/README.md)

---

## 5. Worker Example Update

**Output:** Demonstrates submission and evaluation services in action.

**Evidence:**

- Worker: [`OgmiosWorker.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/OgmiosWorker.cs)
- Documentation: [`Worker/docs/README.md`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/docs/README.md)

The worker demonstrates both services with CBOR-encoded transactions, showing budget extraction from evaluation and transaction ID retrieval from submission.

---

## 6. Ogmios Version Support

**Output:** OgmiosDotnet upgraded to support Ogmios version (v6.13.0).

**Evidence:**

- README: [`Current Version: Ogmios v6.13.0`](https://github.com/ItsDaveB/OgmiosDotnet#current-version)
- Schema: [`src/Ogmios.Schema/Ogmios/v6.13/`](https://github.com/ItsDaveB/OgmiosDotnet/tree/main/src/Ogmios.Schema/Ogmios/v6.13)

---

## 7. Unit Tests

**Output:** Tests covering model serialization/deserialization, request/response mapping, and submission success/failure paths.

**Evidence:**

- Transaction Submission Tests: [`TransactionSubmissionTests.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Tests/TransactionSubmission/TransactionSubmissionTests.cs)
- Transaction Evaluation Tests: [`TransactionEvaluationTests.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Tests/TransactionEvaluation/TransactionEvaluationTests.cs)

**Transaction Submission Test Coverage:**

| Test  | Validates                                        | Result |
| ----- | ------------------------------------------------ | ------ |
| TC001 | WebSocket connection failure handling            | Passed |
| TC002 | Invalid JSON response parsing                    | Passed |
| TC003 | Node transaction rejection with typed exceptions | Passed |
| TC004 | Successful submission with transaction ID return | Passed |

**Transaction Evaluation Test Coverage:**

| Test  | Validates                                          | Result |
| ----- | -------------------------------------------------- | ------ |
| TC005 | WebSocket connection failure handling              | Passed |
| TC006 | Invalid JSON response parsing                      | Passed |
| TC007 | Evaluation failure with typed exception handling   | Passed |
| TC008 | Successful evaluation with execution budget return | Passed |

**Summary:** 8/8 tests passing. Coverage includes connection failures, response parsing, typed error handling, and successful operation scenarios for both submission and evaluation services.

---

## 8. Published Package

**Output:** New published package released with supported outputs.

**Evidence:**

- **OgmiosDotnetClient.Schema**: https://www.nuget.org/packages/OgmiosDotnetClient.Schema
- **OgmiosDotnetClient.Services**: https://www.nuget.org/packages/OgmiosDotnetClient.Services

Both packages include v6.13 schema support, transaction submission, and transaction evaluation functionality.

---

## Summary

The OgmiosDotnet library now provides complete transaction submission and evaluation capabilities for the Cardano ecosystem, with comprehensive type safety, error handling, documentation, and testing. The functionality is production-ready and available via published NuGet packages.
