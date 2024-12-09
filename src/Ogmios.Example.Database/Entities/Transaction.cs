using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Corvus.Json;

namespace Ogmios.Example.Database.Entities;

/// <summary>
/// Represents the Transaction entity in the database.
/// </summary>
public class Transaction
{
    /// <summary>
    /// Unique ID of the transaction.
    /// </summary>
    [Key]
    [Required]
    [MaxLength(64)]
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Raw serialized CBOR transaction.
    /// </summary>
    [JsonPropertyName("cbor")]
    [Column(TypeName = "jsonb")]
    public string? Cbor { get; set; } = string.Empty;

    /// <summary>
    /// Array of certificates.
    /// </summary>
    [JsonPropertyName("certificates")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.CertificateArray? Certificates
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Collateral return information.
    /// </summary>
    [JsonPropertyName("collateralreturn")]
    [Column(TypeName = "jsonb")]
    public Generated.TransactionOutput? CollateralReturn
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Array of collaterals.
    /// </summary>
    [JsonPropertyName("collaterals")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.TransactionOutputReferenceArray? Collaterals
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Data related to transaction outputs.
    /// </summary>
    [JsonPropertyName("datums")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.DatumsEntity? Datums
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Transaction fee.
    /// </summary>
    [JsonPropertyName("fee")]
    [Column(TypeName = "jsonb")]
    public Generated.ValueAdaOnly? Fee
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Inputs for the transaction.
    /// </summary>
    [JsonPropertyName("inputs")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.InputsTransactionOutputRefArray Inputs
    {
        get;
        set => field = value.IsNullOrUndefined() ? [] : value;
    }

    /// <summary>
    /// Metadata associated with the transaction.
    /// </summary>
    [JsonPropertyName("metadata")]
    [Column(TypeName = "jsonb")]
    public Generated.Metadata? Metadata
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Minting details.
    /// </summary>
    [JsonPropertyName("mint")]
    [Column(TypeName = "jsonb")]
    public Generated.Assets? Mint
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Network details.
    /// </summary>
    [JsonPropertyName("network")]
    [Column(TypeName = "jsonb")]
    public Generated.Network? Network
    {
        get;
        set => field = value.GetValueOrDefault() == default ? null : value;
    }

    /// <summary>
    /// Outputs for the transaction.
    /// </summary>
    [JsonPropertyName("outputs")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.TransactionOutputArray? Outputs
    {
        get;
        set => field = value?.HasDotnetBacking == false || value?.ValueKind == JsonValueKind.Undefined ? null : value;
    }

    /// <summary>
    /// Governance proposals.
    /// </summary>
    [JsonPropertyName("proposals")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.GovernanceProposalArray? Proposals
    {
        get;
        set => field = value?.HasDotnetBacking == false || value?.ValueKind == JsonValueKind.Undefined ? null : value;
    }

    /// <summary>
    /// Redeemer details.
    /// </summary>
    [JsonPropertyName("redeemers")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.RedeemerArray? Redeemers
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// References in the transaction.
    /// </summary>
    [JsonPropertyName("references")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.ReferencesTransactionOutpuArray? References
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Required extra scripts.
    /// </summary>
    [JsonPropertyName("requiredextrascripts")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.DigestBlake2b224Array? RequiredExtraScripts
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Required extra signatories.
    /// </summary>
    [JsonPropertyName("requiredextrasignatories")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.RequiredExtraSigArray? RequiredExtraSignatories
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Script integrity hash.
    /// </summary>
    [JsonPropertyName("scriptintegrityhash")]
    [Column(TypeName = "jsonb")]
    public Generated.DigestBlake2b256? ScriptIntegrityHash
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Total collateral information.
    /// </summary>
    [JsonPropertyName("totalcollateral")]
    [Column(TypeName = "jsonb")]
    public Generated.ValueAdaOnly? TotalCollateral
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Treasury details.
    /// </summary>
    [JsonPropertyName("treasury")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.TreasuryEntity? Treasury
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Validity interval.
    /// </summary>
    [JsonPropertyName("validityinterval")]
    [Column(TypeName = "jsonb")]
    public Generated.ValidityInterval? ValidityInterval
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Governance votes.
    /// </summary>
    [JsonPropertyName("votes")]
    [Column(TypeName = "jsonb")]
    public Generated.Transaction.GovernanceVoteArray? Votes
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }

    /// <summary>
    /// Withdrawals information.
    /// </summary>
    [JsonPropertyName("withdrawals")]
    [Column(TypeName = "jsonb")]
    public Generated.Withdrawals? Withdrawals
    {
        get;
        set => field = value?.IsNullOrUndefined() == true ? null : value;
    }
}
