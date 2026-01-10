using Ogmios.Domain;
using Ogmios.Services.TransactionSubmission;

namespace Ogmios.Example.Worker.Examples;

/// <summary>
/// Demonstrates the Transaction Submission capabilities of Ogmios.
/// Shows how to submit signed transactions to the Cardano network.
/// </summary>
public class TransactionSubmissionExample(
    ILogger<TransactionSubmissionExample> logger,
    ITransactionSubmissionService transactionSubmissionService) : IExample
{
    public string Name => "Transaction Submission";
    private const string transactionCborHex = "";

    public async Task ExecuteAsync(InteractionContext context, OgmiosConfiguration ogmiosConfiguration, CancellationToken cancellationToken)
    {
        Console.WriteLine();
        Console.WriteLine("\u001b[35m╔══════════════════════════════════════════════════════════════════════════════╗\u001b[0m");
        Console.WriteLine("\u001b[35m║              OgmiosDotnet - Transaction Submission Demo                      ║\u001b[0m");
        Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  🔄 Transaction: DEX Order Placement (5 ADA → HOSKY)                         ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  🌐 Network: Cardano MAINNET                                                 ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  📦 Library: OgmiosDotnet v6.13.1.3                                          ║\u001b[0m");
        Console.WriteLine("\u001b[35m╚══════════════════════════════════════════════════════════════════════════════╝\u001b[0m");
        Console.WriteLine();
        Console.WriteLine("\u001b[33m--- Transaction Submission Demonstration ---\u001b[0m");


        Console.WriteLine($"\u001b[36m[TransactionSubmission] CBOR length: {transactionCborHex.Length} characters\u001b[0m");
        Console.WriteLine($"\u001b[36m[TransactionSubmission] Submitting signed transaction to Cardano network...\u001b[0m");

        try
        {
            var transactionToSubmit = Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.Create(
                Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.FromAny(transactionCborHex));

            var transactionSubmissionResult = await transactionSubmissionService.SubmitTransactionAsync(
                context,
                transactionToSubmit.Cbor,
                cancellationToken: cancellationToken);

            Console.WriteLine($"\u001b[33m[TransactionSubmission] Raw response: {transactionSubmissionResult}\u001b[0m");

            var successResult = transactionSubmissionResult.AsSubmitTransactionSuccess;

            Console.WriteLine($"\u001b[33m[TransactionSubmission] Id property: {successResult.Id}\u001b[0m");

            var transactionId = successResult.Id.ToString().Trim('"');
            if (string.IsNullOrEmpty(transactionId))
            {
                transactionId = successResult.Result.ToString().Trim('"');
            }

            Console.WriteLine($"\u001b[32m[TransactionSubmission] ══════════════════════════════════════════════════════════════\u001b[0m");
            Console.WriteLine($"\u001b[32m[TransactionSubmission]   ✅ Transaction Submitted Successfully!\u001b[0m");
            Console.WriteLine($"\u001b[32m[TransactionSubmission] ══════════════════════════════════════════════════════════════\u001b[0m");
            Console.WriteLine($"\u001b[32m[TransactionSubmission]   Transaction ID: {transactionId}\u001b[0m");
            Console.WriteLine($"\u001b[32m[TransactionSubmission] ══════════════════════════════════════════════════════════════\u001b[0m");

            logger.LogInformation("Transaction submitted successfully. Transaction Id: {TransactionId}", transactionId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\u001b[31m[TransactionSubmission] ❌ Submission Failed!\u001b[0m");
            Console.WriteLine($"\u001b[31m[TransactionSubmission] Error: {ex.Message}\u001b[0m");
            logger.LogError(ex, "Transaction submission failed");
        }

        Console.WriteLine("\u001b[33m--- Transaction Submission Demonstration Complete ---\u001b[0m");
        Console.WriteLine();
    }
}
