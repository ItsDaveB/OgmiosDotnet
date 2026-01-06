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

    public async Task ExecuteAsync(InteractionContext context, OgmiosConfiguration ogmiosConfiguration, CancellationToken cancellationToken)
    {
        Console.WriteLine("\u001b[33m--- Transaction Evaluation Demonstration ---\u001b[0m");

        // Note: Replace with a real CBOR-encoded transaction for actual evaluation
        var cborRawForEvaluation = "CBORHex";

        Console.WriteLine($"\u001b[36m[TransactionEvaluation] Evaluating transaction...\u001b[0m");
        Console.WriteLine($"\u001b[33m[TransactionEvaluation] Note: Using placeholder CBOR. Replace with real transaction for actual evaluation.\u001b[0m");

        try
        {
            var cborToEvaluate = Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.Create(
                Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.FromAny(cborRawForEvaluation));

            var evaluationResponse = await transactionEvaluationService.EvaluateTransactionAsync(
                context,
                cborToEvaluate.Cbor,
                cancellationToken: cancellationToken);

            var successResponse = evaluationResponse.AsEvaluateTransactionSuccess.Result;

            var budget = successResponse.FirstOrDefault().Budget;
            var validator = successResponse.FirstOrDefault().Validator;

            Console.WriteLine($"\u001b[32m[TransactionEvaluation] Budget: {budget}\u001b[0m");
            Console.WriteLine($"\u001b[32m[TransactionEvaluation] Validator: {validator}\u001b[0m");

            logger.LogInformation("Transaction evaluation completed. Budget: {Budget}, Validator: {Validator}", budget, validator);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\u001b[33m[TransactionEvaluation] Error: {ex.Message}\u001b[0m");
            Console.WriteLine($"\u001b[33m[TransactionEvaluation] This is expected with placeholder CBOR.\u001b[0m");
        }

        Console.WriteLine("\u001b[33m--- Transaction Evaluation Demonstration Complete ---\u001b[0m");
    }
}
