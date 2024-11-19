//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;

namespace Generated;
/// <summary>
/// Block<BFT>
/// </summary>
public readonly partial struct BlockBft
{
    /// <inheritdoc/>
    public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
    {
        ValidationContext result = validationContext;
        if (level > ValidationLevel.Flag)
        {
            result = result.UsingResults();
        }

        if (level > ValidationLevel.Basic)
        {
            result = result.UsingStack();
            result = result.PushSchemaLocation("Ogmios/Generated/cardano.json#/definitions/Block<BFT>");
        }

        JsonValueKind valueKind = this.ValueKind;
        result = result.UsingEvaluatedProperties();

        result = CorvusValidation.TypeValidationHandler(valueKind, result, level);

        if (level == ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }

        result = CorvusValidation.ObjectValidationHandler(this, valueKind, result, level);

        if (level == ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }

        if (level > ValidationLevel.Basic)
        {
            result = result.PopLocation();
        }

        return result;
    }

    /// <summary>
    /// Validation constants for the type.
    /// </summary>
    public static partial class CorvusValidation
    {
        /// <summary>
        /// Core type validation.
        /// </summary>
        /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
        /// <param name="validationContext">The current validation context.</param>
        /// <param name="level">The current validation level.</param>
        /// <returns>The resulting validation context after validation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValidationContext TypeValidationHandler(
            JsonValueKind valueKind,
            in ValidationContext validationContext,
            ValidationLevel level = ValidationLevel.Flag)
        {
            return Corvus.Json.ValidateWithoutCoreType.TypeObject(valueKind, validationContext, level, "type");
        }

        /// <summary>
        /// Object validation.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
        /// <param name="validationContext">The current validation context.</param>
        /// <param name="level">The current validation level.</param>
        /// <returns>The resulting validation context after validation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValidationContext ObjectValidationHandler(
            in BlockBft value,
            JsonValueKind valueKind,
            in ValidationContext validationContext,
            ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext;
            if (valueKind != JsonValueKind.Object)
            {
                if (level == ValidationLevel.Verbose)
                {
                    ValidationContext ignoredResult = validationContext;
                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation additionalProperties - ignored because the value is not an object", "additionalProperties");
                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation properties - ignored because the value is not an object", "properties");
                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation required - ignored because the value is not an object", "required");

                    return ignoredResult;
                }

                return validationContext;
            }

            bool hasSeenAncestor = false;
            bool hasSeenDelegate = false;
            bool hasSeenEra = false;
            bool hasSeenHeight = false;
            bool hasSeenId = false;
            bool hasSeenIssuer = false;
            bool hasSeenProtocol = false;
            bool hasSeenSize = false;
            bool hasSeenSlot = false;
            bool hasSeenType = false;

            int propertyCount = 0;
            foreach (JsonObjectProperty property in value.EnumerateObject())
            {
                string? propertyNameAsString = null;

                if (property.NameEquals(JsonPropertyNames.AncestorUtf8, JsonPropertyNames.Ancestor))
                {
                    hasSeenAncestor = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/ancestor/$ref"), JsonPropertyNames.Ancestor);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.DigestBlake2b256>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.DelegateUtf8, JsonPropertyNames.Delegate))
                {
                    hasSeenDelegate = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/delegate"), JsonPropertyNames.Delegate);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.BlockBft.RequiredVerificationKey>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.EraUtf8, JsonPropertyNames.Era))
                {
                    hasSeenEra = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/era"), JsonPropertyNames.Era);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.BlockBft.EraEntity>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.HeightUtf8, JsonPropertyNames.Height))
                {
                    hasSeenHeight = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/height/$ref"), JsonPropertyNames.Height);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.BlockHeight>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.IdUtf8, JsonPropertyNames.Id))
                {
                    hasSeenId = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/id/$ref"), JsonPropertyNames.Id);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.DigestBlake2b256>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.IssuerUtf8, JsonPropertyNames.Issuer))
                {
                    hasSeenIssuer = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/issuer"), JsonPropertyNames.Issuer);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.BlockBft.BlockBftRequiredVerificationKey>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.OperationalCertificatesUtf8, JsonPropertyNames.OperationalCertificates))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/operationalCertificates"), JsonPropertyNames.OperationalCertificates);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.BlockBft.BootstrapOperationalCertificateArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.ProtocolUtf8, JsonPropertyNames.Protocol))
                {
                    hasSeenProtocol = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/protocol"), JsonPropertyNames.Protocol);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.BlockBft.RequiredIdAndSoftwareAndVersion>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.SizeUtf8, JsonPropertyNames.Size))
                {
                    hasSeenSize = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/size/$ref"), JsonPropertyNames.Size);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.NumberOfBytes>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.SlotUtf8, JsonPropertyNames.Slot))
                {
                    hasSeenSlot = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/slot/$ref"), JsonPropertyNames.Slot);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Slot>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.TransactionsUtf8, JsonPropertyNames.Transactions))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/transactions"), JsonPropertyNames.Transactions);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.BlockBft.TransactionArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.TypeUtf8, JsonPropertyNames.Type))
                {
                    hasSeenType = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/type"), JsonPropertyNames.Type);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.BlockBft.TypeEntity>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                if (!result.HasEvaluatedLocalProperty(propertyCount))
                {
                    if (level > ValidationLevel.Basic)
                    {
                        string localEvaluatedPropertyName = (propertyNameAsString ??= property.Name.GetString());
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new JsonReference("#/additionalProperties").AppendUnencodedPropertyNameToFragment(localEvaluatedPropertyName), localEvaluatedPropertyName);
                    }

                    result = property.Value.As<Corvus.Json.JsonNotAny>().Validate(result, level);
                    if (level == ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }

                    result = result.WithLocalProperty(propertyCount);
                }

                propertyCount++;
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/3"));
            }

            if (!hasSeenAncestor)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'ancestor' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'ancestor' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/9"));
            }

            if (!hasSeenDelegate)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'delegate' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'delegate' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/1"));
            }

            if (!hasSeenEra)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'era' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'era' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/4"));
            }

            if (!hasSeenHeight)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'height' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'height' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/0"));
            }

            if (!hasSeenId)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'id' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'id' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/8"));
            }

            if (!hasSeenIssuer)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'issuer' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'issuer' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/7"));
            }

            if (!hasSeenProtocol)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'protocol' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'protocol' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/5"));
            }

            if (!hasSeenSize)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'size' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'size' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/6"));
            }

            if (!hasSeenSlot)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'slot' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'slot' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/2"));
            }

            if (!hasSeenType)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'type' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'type' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            return result;
        }
    }
}