# Transaction Evaluation

Evaluate a signed transaction against the connected Cardano node (via Ogmios) to estimate execution units and detect obvious rejections before submission.

## Key Operation

1. **EvaluateTransactionAsync**
   - Purpose: Request the node to evaluate a signed transaction and return execution unit estimates and evaluation details without submitting the transaction to the mempool.
   - Signature: EvaluateTransactionAsync(InteractionContext context, CborSerializedSignedTransactionBase16 signedCborBase16, MirrorOptions? mirrorOptions = null, CancellationToken cancellationToken = default)

## Key Concepts

- Use this operation to validate cost and detect rejections early (eg. budget exceed, script failures) prior to broadcasting.
- The request is sent over the InteractionContext's WebSocket using the project's IWebSocketService.
- The transaction is supplied as CBOR serialized then encoded as base16 (CborSerializedSignedTransactionBase16).
- MirrorOptions may be supplied to include a mirror identifier in the request.

## Error Handling

- Deserialisation errors reported by the node are surfaced as EvaluateTransactionDeserialisationException.
- Other node rejections are surfaced as EvaluateTransactionFailedException with details from the failure shape.
- JSON parse failures are surfaced as InvalidOperationException wrapping the raw response.

## Summary of Methods

| Method                     | Purpose                                           | Notes                                        |
| -------------------------- | ------------------------------------------------- | -------------------------------------------- |
| `EvaluateTransactionAsync` | Estimate execution units and validate transaction | Non-submitting: does not place tx in mempool |

## Notes

- Evaluation is advisory: a successful evaluation does not guarantee acceptance when submitted (state may change).
- Use evaluation as a pre-submit check to size execution units and fail fast on obvious problems.
