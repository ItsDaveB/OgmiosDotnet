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
/// ogmios
/// </summary>
public readonly partial struct Ogmios
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    public readonly partial struct SubmitTransactionFailure
    {
        /// <summary>
        /// SubmitTransactionFailure<InvalidHardForkVersionBump>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The new proposed version for a hard-fork isn't a valid version bump. The version (major, minor, patch) follows strict rules which can be summarized as follow: (1) the new triplet must be greater than the current one in the usual order of priorities (i.e. 'major' -> 'minor' -> 'patch'), (2) 'minor' must be 0 if 'major' is bumped, (3) 'minor' can only be bumped in increments of 1 and only if 'major' isn't bumped and (4) 'major' can only be bumped in increments of 1. The field 'data.proposedVersion' indicates the (invalid) version in the submitted proposal whereas 'data.currentVersion' indicates the current protocol version.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureInvalidHardForkVersionBump
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct RequiredCurrentVersionAndProposedVersion
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
                        result = result.PushSchemaLocation("https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/63/properties/data");
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
                        in RequiredCurrentVersionAndProposedVersion value,
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

                        bool hasSeenCurrentVersion = false;
                        bool hasSeenProposedVersion = false;

                        int propertyCount = 0;
                        foreach (JsonObjectProperty property in value.EnumerateObject())
                        {
                            string? propertyNameAsString = null;

                            if (property.NameEquals(JsonPropertyNames.CurrentVersionUtf8, JsonPropertyNames.CurrentVersion))
                            {
                                hasSeenCurrentVersion = true;
                                result = result.WithLocalProperty(propertyCount);
                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/currentVersion/$ref"), JsonPropertyNames.CurrentVersion);
                                }

                                ValidationContext propertyResult = property.Value.As<Generated.ProtocolVersion>().Validate(result.CreateChildContext(), level);
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
                            else if (property.NameEquals(JsonPropertyNames.ProposedVersionUtf8, JsonPropertyNames.ProposedVersion))
                            {
                                hasSeenProposedVersion = true;
                                result = result.WithLocalProperty(propertyCount);
                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/proposedVersion/$ref"), JsonPropertyNames.ProposedVersion);
                                }

                                ValidationContext propertyResult = property.Value.As<Generated.ProtocolVersion>().Validate(result.CreateChildContext(), level);
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
                            result = result.PushValidationLocationReducedPathModifier(new("#/required/1"));
                        }

                        if (!hasSeenCurrentVersion)
                        {
                            if (level >= ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, "Validation properties - the required property 'currentVersion' was not present.");
                            }
                            else
                            {
                                return ValidationContext.InvalidContext;
                            }
                        }
                        else if (level == ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true, "Validation properties - the required property 'currentVersion' was present.");
                        }

                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PopLocation();
                        }

                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifier(new("#/required/0"));
                        }

                        if (!hasSeenProposedVersion)
                        {
                            if (level >= ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, "Validation properties - the required property 'proposedVersion' was not present.");
                            }
                            else
                            {
                                return ValidationContext.InvalidContext;
                            }
                        }
                        else if (level == ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true, "Validation properties - the required property 'proposedVersion' was present.");
                        }

                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PopLocation();
                        }

                        return result;
                    }
                }
            }
        }
    }
}
