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

    public async Task ExecuteAsync(InteractionContext context, OgmiosConfiguration ogmiosConfiguration, CancellationToken cancellationToken)
    {
        Console.WriteLine("\u001b[33m--- Transaction Submission Demonstration ---\u001b[0m");

        // Note: Replace with a real CBOR-encoded signed transaction for actual submission
        var cborRawForSubmission = "CBORHex";

        Console.WriteLine($"\u001b[36m[TransactionSubmission] Submitting transaction...\u001b[0m");
        Console.WriteLine($"\u001b[33m[TransactionSubmission] Note: Using placeholder CBOR. Replace with real signed transaction for actual submission.\u001b[0m");

        try
        {
            var transactionToSubmit = Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.Create(
                Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.FromAny(cborRawForSubmission));

            var transactionSubmissionResult = await transactionSubmissionService.SubmitTransactionAsync(
                context,
                transactionToSubmit.Cbor,
                cancellationToken: cancellationToken);

            var transactionId = (string)transactionSubmissionResult.AsSubmitTransactionSuccess.Id.AsString;
            Console.WriteLine($"\u001b[32m[TransactionSubmission] Transaction submitted successfully!\u001b[0m");
            Console.WriteLine($"\u001b[32m[TransactionSubmission] Transaction Id: {transactionId}\u001b[0m");

            logger.LogInformation("Transaction submitted successfully. Transaction Id: {TransactionId}", transactionId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\u001b[33m[TransactionSubmission] Error: {ex.Message}\u001b[0m");
            Console.WriteLine($"\u001b[33m[TransactionSubmission] This is expected with placeholder CBOR.\u001b[0m");
        }

        Console.WriteLine("\u001b[33m--- Transaction Submission Demonstration Complete ---\u001b[0m");
    }
}
