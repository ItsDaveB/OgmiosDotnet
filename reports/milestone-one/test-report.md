# Software Test Report

## 1. Title Page

**Project Name:** OgmiosDotnetClient  
**Report Title:** Software Test Report for OgmiosDotnetClient  
**Date:** 11/11/2024
**Author(s):** Dave B

---

## 2. Table of Contents

1. [Introduction](#introduction)
2. [Test Objectives](#test-objectives)
3. [Test Environment](#test-environment)
4. [Test Scope](#test-scope)
5. [Test Approach](#test-approach)
6. [Test Cases Executed](#test-cases-executed)
7. [Test Results](#test-results)
8. [Conclusion](#conclusion)

---

## 3. Introduction

**Purpose:**  
This report documents the testing process, findings, and outcomes for the OgmiosDotnetClient project. The objective is to ensure that the ChainSynchronizationClient and its core functionality for reading blockchain data from a specific point or origin meet the required standards to avoid regressions.

**Scope:**  
The tests cover the ChainSynchronizationClient and the functionality related to reading blockchain data from a specified point or origin.

**Audience:**  
This report is intended for reviewers.

---

## 4. Test Objectives

- Verify the ChainSynchronizationClient's ability to resume listening for WebSocket messages.
- Ensure queued WebSocket response messages are processed correctly.
- Validate the selection of the correct intersection point.
- Confirm error handling for specific scenarios, such as no intersection found.
- Verify the RollForward / RollBackward handlers are called correctly.

---

## 5. Test Environment

**Software:**

- .NET SDK 8.0
- Moq Library for mocking.
- xUnit Framework for testing.

**Test Data:**

- Mocked data representing blockchain interaction points and messages.

---

## 6. Test Scope

**In-Scope:**

- ChainSynchronizationClient's methods for resuming, queuing, and processing blockchain messages.
- Interaction with WebSocket and mock services.

**Out-of-Scope:**

- Integration testing with a live Ogmios server.

---

## 7. Test Approach

**Methodology:**  
The following testing methodologies were used:

- Unit Testing

**Test Levels:**

- Unit Testing

---

## 8. Test Cases Executed

| **Test Case ID** | **Description**                                                                         | **Status** | **Priority** | **Remarks**                                      |
| ---------------- | --------------------------------------------------------------------------------------- | ---------- | ------------ | ------------------------------------------------ |
| TC001            | Verify `ResumeListeningAsync` closes WebSocket on receiving a close message.            | Passed     | High         | WebSocket closed as expected.                    |
| TC002            | Verify WebSocket response messages are queued correctly.                                | Passed     | High         | Message correctly added to the queue.            |
| TC003            | Verify `ResumeListeningAsync` selects the tip as the intersection point.                | Passed     | Medium       | Tip successfully selected as intersection point. |
| TC004            | Verify `ResumeListeningAsync` throws exception when no intersection is found.           | Passed     | Medium       | Exception thrown as expected.                    |
| TC005            | Verify `ResumeListeningAsync` intersects at genesis when origin is provided as a point. | Passed     | Medium       | Correctly intersects at genesis.                 |
| TC006            | Verify `ProcessMessagesAsync` processes queued messages from WebSocket response.        | Passed     | Medium       | Correctly processes all queued messages.         |
| TC007            | Verify `ResumeListeningAsync` processes messages in correct order.                      | Passed     | High         | Messages processed in the correct sequence.      |
| TC008            | Verify `HandleNextBlockAsync` calls RollBackwardHandler when direction is backward.     | Passed     | Medium       | Correct handler called for backward direction.   |
| TC09             | Verify `HandleNextBlockAsync` calls RollForwardHandler when direction is forward.       | Passed     | Medium       | Correct handler called for forward direction.    |

---

## 9. Test Results

**Summary:**

- Total Test Cases: 9
- Passed: 9
- Failed: 0

---

## 10. Conclusion

The tests successfully verify the core functionality of the ChainSynchronizationClient, including its ability to process messages, select the appropriate intersection point, and handle errors appropriately. These tests cover the ChainSynchronizationClient and the core functionality of reading blockchain data from a specific point or origin.
