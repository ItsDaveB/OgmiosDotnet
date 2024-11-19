# Software Test Report

**Project Name:** OgmiosDotnetClient  
**Report Title:** Software Test Report for MempoolMonitoringService  
**Date:** 19/11/2024  
**Author(s):** Dave B

---

1. [Introduction](#introduction)
2. [Test Objectives](#test-objectives)
3. [Test Environment](#test-environment)
4. [Test Scope](#test-scope)
5. [Test Approach](#test-approach)
6. [Test Cases Executed](#test-cases-executed)
7. [Test Results](#test-results)
8. [Conclusion](#conclusion)

---

## Introduction

**Purpose:**  
This report documents the testing process, findings, and outcomes for the `MempoolMonitoringService` in the OgmiosDotnetClient project. The objective is to ensure that the client can handle mempool-related operations, including acquiring snapshots, querying transactions, fetching mempool statistics, and handling errors related to missing snapshots.

**Scope:**  
The tests focus exclusively on the `MempoolMonitoringService` and its interactions with the WebSocket service, covering core functionalities such as acquiring mempool snapshots, querying transactions, retrieving statistics, and ensuring proper error handling.

**Audience:**  
This report is intended for reviewers and the community.

---

## Test Objectives

- Verify that the `MempoolMonitoringService` can acquire mempool snapshots correctly.
- Ensure that the client can query transactions and retrieve mempool statistics.
- Test proper error handling when operations are performed without a valid snapshot.
- Validate the client's behavior under scenarios like empty mempools or WebSocket connection failures.
- Confirm that the WebSocket is properly closed during shutdown.

---

## Test Environment

**Software:**

- .NET SDK 8.0
- Moq Library for mocking.
- xUnit Framework for testing.

**Test Data:**

- Mocked WebSocket responses simulating mempool data and errors.

---

## Test Scope

**In-Scope:**

- Methods in `MempoolMonitoringService` for acquiring snapshots, querying transactions, fetching mempool statistics, and handling errors.
- Interaction with WebSocket and mock services.

**Out-of-Scope:**

- Integration testing with a live Ogmios server.

---

## Test Approach

**Methodology:**  
Unit testing was performed to validate the functionality of the `MempoolMonitoringService`. Mocked WebSocket responses were used to simulate various scenarios, ensuring isolation and reproducibility of the tests.

**Test Levels:**

- Unit Testing

---

## Test Cases Executed

| **Test Case ID** | **Description**                                                              | **Status** | **Priority** | **Remarks**                                |
| ---------------- | ---------------------------------------------------------------------------- | ---------- | ------------ | ------------------------------------------ |
| TC001            | Verify `ShutdownAsync` properly closes the WebSocket.                        | Passed     | High         | WebSocket closed as expected.              |
| TC002            | Verify `CreateClient` throws an exception on failed WebSocket connection.    | Passed     | High         | Exception thrown for invalid host or port. |
| TC003            | Verify `AcquireMempoolAsync` successfully acquires the first snapshot.       | Passed     | High         | Snapshot acquired with the correct data.   |
| TC004            | Verify `HasTransactionAsync` returns false for missing transactions.         | Passed     | Medium       | Correctly identified missing transactions. |
| TC005            | Verify `HasTransactionAsync` throws when no snapshot is acquired.            | Passed     | High         | Exception thrown for missing snapshot.     |
| TC006            | Verify `NextTransactionAsync` returns null when no transactions are present. | Passed     | Medium       | Correctly handled an empty mempool.        |
| TC007            | Verify `NextTransactionAsync` throws when no snapshot is acquired.           | Passed     | High         | Exception thrown for missing snapshot.     |
| TC008            | Verify `SizeOfMempoolAsync` retrieves correct mempool statistics.            | Passed     | Medium       | Statistics match expected values.          |
| TC009            | Verify `SizeOfMempoolAsync` throws when no snapshot is acquired.             | Passed     | High         | Exception thrown for missing snapshot.     |

---

## Test Results

**Summary:**

- **Total Test Cases:** 9
- **Passed:** 9
- **Failed:** 0

All test cases passed successfully, demonstrating that the `MempoolMonitoringService` meets its functional requirements.

---

## Conclusion

The tests successfully verify the core functionality of the `MempoolMonitoringService`, including its ability to acquire mempool snapshots, query transactions, fetch statistics, and handle errors gracefully. The client interacts correctly with the WebSocket service and behaves as expected under various scenarios.

No issues or regressions were found during testing.
