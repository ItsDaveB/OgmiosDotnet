# Transaction Submission

Submit a signed transaction to the connected Cardano node (via Ogmios) for mempool inclusion and eventual confirmation.

## Key Operation

1. **SubmitTransactionAsync**
   - Purpose: Send a signed transaction to the node so it can be considered for inclusion in the mempool and later in a block.
   - Signature: SubmitTransactionAsync(InteractionContext context, CborSerializedSignedTransactionBase16 signedCborBase16, MirrorOptions? mirrorOptions = null, CancellationToken cancellationToken = default)

## Key Concepts

- Submission places the transaction into the node's mempool; inclusion in a block is not guaranteed.
- The request is sent over the InteractionContext's WebSocket using the project's IWebSocketService.
- The transaction is supplied as CBOR serialized then encoded as base16 (CborSerializedSignedTransactionBase16).
- MirrorOptions may be provided to include a mirror identifier in the request.
- For Ogmios API details see: https://ogmios.dev/api/#operation-publish-/?SubmitTransaction

## Error Handling

- Deserialisation errors reported by the node are surfaced as SubmitTransactionDeserialisationException.
- Other node rejections are surfaced as SubmitTransactionFailedException with details from the failure shape.
- JSON parse failures are surfaced as InvalidOperationException wrapping the raw response.

## Summary of Methods

| Method                   | Purpose                                    | Notes                                                   |
| ------------------------ | ------------------------------------------ | ------------------------------------------------------- |
| `SubmitTransactionAsync` | Submit a signed transaction to the mempool | Consider evaluating first with EvaluateTransactionAsync |

## Notes

- Submission is not finality: monitor mempool and chain state for confirmation.
- Consider calling EvaluateTransactionAsync before submitting to reduce the chance of obvious rejections.
- Nodes may rate limit or reject malformed/invalid transactions.
