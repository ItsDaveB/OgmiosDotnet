# Software Test Report

**Project Name:** OgmiosDotnetClient  
**Report Title:** Software Test Report for Final Milestone (Worker Application)  
**Date:** 11-12-2024  
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
This report documents the testing process, findings, and outcomes for the Worker application in the OgmiosDotnetClient project. The objective is to validate the Worker’s ability to read transactions from blockchain slots, process mempool data, map the data, and save it to an in-memory PostgreSQL database. These tests ensure that the Worker meets the requirements of Milestone 3 and provides a final close-out for the project.

**Scope:**  
The tests validate the Worker’s functionality, including:

- Processing blockchain and mempool data.
- Handling mocked Ogmios responses.
- Mapping and saving transaction data to the database.
- Demonstrating compatibility with the core features outlined in Milestones 1 and 2.

**Audience:**  
This report is intended for reviewers and the community.

---

## Test Objectives

- Verify that the Worker reads transactions from specified blockchain slots and processes mempool data without errors.
- Ensure data is correctly mapped and saved to an in-memory PostgreSQL database.
- Validate the Worker’s ability to retrieve saved transactions with accurate mappings.
- Confirm proper error handling for invalid or null transactions.
- Demonstrate the Worker’s ability to use mocked Ogmios responses for unit testing.

---

## Test Environment

**Software:**

- .NET SDK 9.0
- Moq Library for mocking.
- xUnit Framework for testing.
- Entity Framework Core with Npgsql InMemoryDatabase provider for database operations.
- AutoMapper for mapping data entities.

**Test Data:**

- Mocked Ogmios responses for blockchain slots and mempool transactions.

---

## Test Scope

**In-Scope:**

- Reading and processing transactions from blockchain slots and mempool data.
- Mapping and saving transaction data to an in-memory PostgreSQL database.
- Validating mocked Ogmios responses for unit testing scenarios.

**Out-of-Scope:**

- Integration testing with a live Ogmios server.

---

## Test Approach

**Methodology:**  
Unit tests were created and executed using the xUnit framework. Mocked Ogmios responses simulated real-world scenarios, while an in-memory PostgreSQL database ensured isolated and repeatable testing. AutoMapper was used for entity mapping, and Moq facilitated the mocking of services.

**Test Levels:**

- Unit Testing

---

## Test Cases Executed

| **Test Case ID** | **Description**                                                                | **Status** | **Priority** | **Remarks**                                           |
| ---------------- | ------------------------------------------------------------------------------ | ---------- | ------------ | ----------------------------------------------------- |
| TC001            | Verify saving valid transactions from blockchain slots to the database.        | Passed     | High         | Transactions correctly saved and persisted.           |
| TC002            | Verify retrieving saved transactions from the database with correct mappings.  | Passed     | High         | Retrieved data matched expected structure and values. |
| TC003            | Verify processesing valid mempool transactions and saves them to the database. | Passed     | High         | Mempool transactions correctly processed and saved.   |
| TC004            | Verify retrieving saved mempool transactions with accurate mappings.           | Passed     | High         | Mapped mempool transactions retrieved successfully.   |

---

## Test Results

**Summary:**

- **Total Test Cases:** 4
- **Passed:** 4
- **Failed:** 0

All test cases passed successfully, confirming that the Worker application meets its functional requirements.

---

## Conclusion

The tests validate the Worker’s ability to process and save blockchain and mempool data accurately. It demonstrates proper data mapping, error handling, and compatibility with mocked Ogmios responses. These results confirm the Worker’s readiness for the final milestone, meeting all acceptance criteria for Milestone 3.

No issues or regressions were found during testing. The Worker application is ready for public release with supporting documentation and open-source availability.

---
