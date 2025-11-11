# Ogmios Example Worker

## Overview

The **Ogmios Example Worker** demonstrates the capabilities of the Ogmios Client package, including:

- Reading blocks from blockchain slots.
- Accessing and monitoring mempool transactions.
- Saving transaction data to a PostgreSQL database (in-memory in this example).

This application is open-source and designed for easy cloning, use, and extension.

---

## Features

- **Chain Synchronization**: Reads and processes blocks from the blockchain.
- **Mempool Monitoring**: Tracks mempool transactions and metadata.
- **Transaction Evaluation**: Demonstrates evaluating transactions to estimate execution units before submission.
- **Transaction Submission**: Demonstrates submitting signed transactions to the Cardano blockchain.
- **Data Persistence**: Saves transactions to an in-memory PostgreSQL database using Entity Framework.
- **Extendable Architecture**: Easily customize or replace components.
- **Unit Testing**: Includes tests for mocking data and validating database operations.

---

## Getting Started

### Prerequisites

- .NET SDK 9.0 or later.
- PostgreSQL database.
- Access to an Ogmios server or mock data.

### Installation

1. **Clone the repository**:

   ```bash
   git clone <repository-url>
   cd Ogmios.Example.Worker
   ```

2. **Configure the application**:
   Update `appsettings.json` with:

   - **Ogmios Server**:
     ```json
     "Ogmios": {
       "Host": "https://demeter-run-authenticated-url",
       "Port": 443,
       "Tls": true,
       "MaxBlocksPerSecond": "35"
     }
     ```
   - **Starting Points**:
     ```json
     "StartingPoints": [
       {
         "StartingPointIdOrOrigin": "4e58bb36837b32f894c8a57006e24b64c2d77bf4fc13b3b2c428fee8871e2491",
         "StartingPointSlot": "115545883"
       }
     ]
     ```

3. **Build and Run**:
   ```bash
   dotnet build
   dotnet run
   ```

---

## Usage

1. **Chain Synchronization**: Processes blocks from blockchain slots and saves transaction data.
2. **Mempool Monitoring**: Tracks live mempool transactions and metadata.
3. **Transaction Evaluation**: Evaluates transactions with CBOR-encoded data to estimate execution budgets and validator information.
4. **Transaction Submission**: Submits CBOR-encoded signed transactions to the Cardano blockchain and returns the transactionId.
5. **Database Integration**: Persists transaction data in a PostgreSQL database.

---

## Testing

Run unit tests to validate functionality:

```bash
dotnet test
```

Tests include:

- Mocking Ogmios data.
- Mapping transactions to the database.
- Validating data persistence.

---

## Extensibility

- **Database**: Replace or extend the PostgreSQL provider with any supported Entity Framework Provider.
- **Handlers**: Customize logic for blockchain and mempool events.

---

## Documentation and Demo

- **Demo Video**: Showcases blockchain and mempool processing.
- **Documentation**: Available in the repository for setup, usage, and testing.

---

## Contribution

Contributions are welcome! Fork the repo, create a branch, and submit a pull request to improve the example worker application.

---

## License

Licensed under the MIT License. See the `LICENSE` file for details.
