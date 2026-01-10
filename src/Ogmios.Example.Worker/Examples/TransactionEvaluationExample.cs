using Ogmios.Domain;
using Ogmios.Services.InteractionContext;
using Ogmios.Services.TransactionEvaluation;

namespace Ogmios.Example.Worker.Examples;

/// <summary>
/// Demonstrates the Transaction Evaluation capabilities of Ogmios.
/// Shows how to evaluate transaction execution units for smart contract transactions.
/// </summary>
public class TransactionEvaluationExample(
    ILogger<TransactionEvaluationExample> logger,
    ITransactionEvaluationService transactionEvaluationService) : IExample
{
    public string Name => "Transaction Evaluation";
    private const string transactionCborHex = "";

    public async Task ExecuteAsync(InteractionContext context, OgmiosConfiguration ogmiosConfiguration, CancellationToken cancellationToken)
    {
        Console.WriteLine();
        Console.WriteLine("\u001b[35m╔══════════════════════════════════════════════════════════════════════════════╗\u001b[0m");
        Console.WriteLine("\u001b[35m║              OgmiosDotnet - Transaction Evaluation Demo                      ║\u001b[0m");
        Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  🔄 Transaction: DEX Order Cancellation (executes validator)                ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  🌐 Network: Cardano MAINNET                                                 ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  📦 Library: OgmiosDotnet v6.13.1.3                                          ║\u001b[0m");
        Console.WriteLine("\u001b[35m╚══════════════════════════════════════════════════════════════════════════════╝\u001b[0m");
        Console.WriteLine();
        Console.WriteLine("\u001b[33m--- Transaction Evaluation Demonstration ---\u001b[0m");

        Console.WriteLine($"\u001b[36m[TransactionEvaluation] CBOR length: {transactionCborHex.Length} characters\u001b[0m");
        Console.WriteLine($"\u001b[36m[TransactionEvaluation] Sending transaction to Ogmios for evaluation...\u001b[0m");

        try
        {
            var cborToEvaluate = Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.Create(
                Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.FromAny(transactionCborHex));

            var evaluationResponse = await transactionEvaluationService.EvaluateTransactionAsync(
                context,
                cborToEvaluate.Cbor,
                cancellationToken: cancellationToken);

            var successResponse = evaluationResponse.AsEvaluateTransactionSuccess.Result;

            Console.WriteLine($"\u001b[32m[TransactionEvaluation] ══════════════════════════════════════════════════════════════\u001b[0m");
            Console.WriteLine($"\u001b[32m[TransactionEvaluation]   ✅ Transaction Evaluation Successful!\u001b[0m");
            Console.WriteLine($"\u001b[32m[TransactionEvaluation] ══════════════════════════════════════════════════════════════\u001b[0m");

            var validatorIndex = 0;
            foreach (var result in successResponse)
            {
                var budget = result.Budget;
                var validator = result.Validator;
                Console.WriteLine($"\u001b[32m[TransactionEvaluation]   Validator [{validatorIndex}]: {validator}\u001b[0m");
                Console.WriteLine($"\u001b[32m[TransactionEvaluation]   Memory:      {budget.Memory} units\u001b[0m");
                Console.WriteLine($"\u001b[32m[TransactionEvaluation]   CPU:         {budget.Cpu} steps\u001b[0m");
                Console.WriteLine($"\u001b[32m[TransactionEvaluation] ──────────────────────────────────────────────────────────────\u001b[0m");
                validatorIndex++;
            }

            logger.LogInformation("Transaction evaluation completed successfully with {ValidatorCount} validator(s)", successResponse.Count());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\u001b[31m[TransactionEvaluation] ❌ Evaluation Failed!\u001b[0m");
            Console.WriteLine($"\u001b[31m[TransactionEvaluation] Error: {ex.Message}\u001b[0m");
            logger.LogError(ex, "Transaction evaluation failed");
        }

        Console.WriteLine("\u001b[33m--- Transaction Evaluation Demonstration Complete ---\u001b[0m");
        Console.WriteLine();
    }
}
