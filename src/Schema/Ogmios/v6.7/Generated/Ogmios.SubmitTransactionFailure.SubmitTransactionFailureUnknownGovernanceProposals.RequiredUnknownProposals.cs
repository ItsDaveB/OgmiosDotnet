//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Buffers;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

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
        /// SubmitTransactionFailure<UnknownGovernanceProposals>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Reference(s) to unknown governance proposals found in transaction. This may be because you've indicated a wrong identifier or because the proposal hasn't yet been submitted on-chain. Note that the order in which transactions are submitted matters. The field 'data.unknownProposals' tells you about the unknown references.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureUnknownGovernanceProposals
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            [System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<RequiredUnknownProposals>))]
            public readonly partial struct RequiredUnknownProposals

            {
                private readonly Backing backing;
                private readonly JsonElement jsonElementBacking;
                private readonly ImmutableList<JsonObjectProperty> objectBacking;

                /// <summary>
                /// Initializes a new instance of the <see cref="RequiredUnknownProposals"/> struct.
                /// </summary>
                public RequiredUnknownProposals()
                {
                    this.jsonElementBacking = default;
                    this.backing = Backing.JsonElement;
                    this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="RequiredUnknownProposals"/> struct.
                /// </summary>
                /// <param name="value">The value from which to construct the instance.</param>
                public RequiredUnknownProposals(in JsonElement value)
                {
                    this.jsonElementBacking = value;
                    this.backing = Backing.JsonElement;
                    this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="RequiredUnknownProposals"/> struct.
                /// </summary>
                /// <param name="value">The value from which to construct the instance.</param>
                public RequiredUnknownProposals(ImmutableList<JsonObjectProperty> value)
                {
                    this.backing = Backing.Object;
                    this.jsonElementBacking = default;
                    this.objectBacking = value;
                }

                /// <summary>
                /// Gets the schema location from which this type was generated.
                /// </summary>
                public static string SchemaLocation { get; } = "https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/39/properties/data";

                /// <summary>
                /// Gets a Null instance.
                /// </summary>
                public static RequiredUnknownProposals Null { get; } = new(JsonValueHelpers.NullElement);

                /// <summary>
                /// Gets an Undefined instance.
                /// </summary>
                public static RequiredUnknownProposals Undefined { get; }

                /// <summary>
                /// Gets the default instance.
                /// </summary>
                public static RequiredUnknownProposals DefaultInstance { get; }

                /// <inheritdoc/>
                public JsonAny AsAny
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return new(this.jsonElementBacking);
                        }

                        if ((this.backing & Backing.Object) != 0)
                        {
                            return new(this.objectBacking);
                        }

                        if ((this.backing & Backing.Null) != 0)
                        {
                            return JsonAny.Null;
                        }

                        return JsonAny.Undefined;
                    }
                }

                /// <inheritdoc/>
                public JsonElement AsJsonElement
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return this.jsonElementBacking;
                        }

                        if ((this.backing & Backing.Object) != 0)
                        {
                            return JsonValueHelpers.ObjectToJsonElement(this.objectBacking);
                        }

                        if ((this.backing & Backing.Null) != 0)
                        {
                            return JsonValueHelpers.NullElement;
                        }

                        return default;
                    }
                }

                /// <inheritdoc/>
                JsonString IJsonValue.AsString
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return new(this.jsonElementBacking);
                        }

                        throw new InvalidOperationException();
                    }
                }

                /// <inheritdoc/>
                JsonBoolean IJsonValue.AsBoolean
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return new(this.jsonElementBacking);
                        }

                        throw new InvalidOperationException();
                    }
                }

                /// <inheritdoc/>
                JsonNumber IJsonValue.AsNumber
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return new(this.jsonElementBacking);
                        }

                        throw new InvalidOperationException();
                    }
                }

                /// <inheritdoc/>
                public JsonObject AsObject
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return new(this.jsonElementBacking);
                        }

                        if ((this.backing & Backing.Object) != 0)
                        {
                            return new(this.objectBacking);
                        }

                        throw new InvalidOperationException();
                    }
                }

                /// <inheritdoc/>
                JsonArray IJsonValue.AsArray
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return new(this.jsonElementBacking);
                        }

                        throw new InvalidOperationException();
                    }
                }

                /// <inheritdoc/>
                public bool HasJsonElementBacking
                {
                    get
                    {
                        return (this.backing & Backing.JsonElement) != 0;
                    }
                }

                /// <inheritdoc/>
                public bool HasDotnetBacking
                {
                    get
                    {
                        return (this.backing & Backing.Dotnet) != 0;
                    }
                }

                /// <inheritdoc/>
                public JsonValueKind ValueKind
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return this.jsonElementBacking.ValueKind;
                        }

                        if ((this.backing & Backing.Object) != 0)
                        {
                            return JsonValueKind.Object;
                        }

                        return JsonValueKind.Undefined;
                    }
                }

                /// <summary>
                /// Conversion from JsonAny.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator RequiredUnknownProposals(JsonAny value)
                {
                    return value.As<RequiredUnknownProposals>();
                }

                /// <summary>
                /// Conversion to JsonAny.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator JsonAny(RequiredUnknownProposals value)
                {
                    return value.AsAny;
                }

                /// <summary>
                /// Operator ==.
                /// </summary>
                /// <param name="left">The lhs of the operator.</param>
                /// <param name="right">The rhs of the operator.</param>
                /// <returns>
                /// <c>True</c> if the values are equal.
                /// </returns>
                public static bool operator ==(in RequiredUnknownProposals left, in RequiredUnknownProposals right)
                {
                    return left.Equals(right);
                }

                /// <summary>
                /// Operator !=.
                /// </summary>
                /// <param name="left">The lhs of the operator.</param>
                /// <param name="right">The rhs of the operator.</param>
                /// <returns>
                /// <c>True</c> if the values are not equal.
                /// </returns>
                public static bool operator !=(in RequiredUnknownProposals left, in RequiredUnknownProposals right)
                {
                    return !left.Equals(right);
                }

                /// <summary>
                /// Gets an instance of the JSON value from a <see cref="JsonElement"/> value.
                /// </summary>
                /// <param name="value">The <see cref="JsonElement"/> value from which to instantiate the instance.</param>
                /// <returns>An instance of this type, initialized from the <see cref="JsonElement"/>.</returns>
                /// <remarks>The returned value will have a <see cref = "IJsonValue.ValueKind"/> of <see cref = "JsonValueKind.Undefined"/> if the
                /// value cannot be constructed from the given instance (e.g. because they have an incompatible .NET backing type).
                /// </remarks>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static RequiredUnknownProposals FromJson(in JsonElement value)
                {
                    return new(value);
                }

                /// <summary>
                /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
                /// </summary>
                /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
                /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static RequiredUnknownProposals FromAny(in JsonAny value)
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return value.ValueKind switch
                    {
                        JsonValueKind.Object => new(value.AsObject.AsPropertyBacking()),
                        JsonValueKind.Null => Null,
                        _ => Undefined,
                    };
                }

#if NET8_0_OR_GREATER
                /// <summary>
                /// Gets an instance of the JSON value from the provided value.
                /// </summary>
                /// <typeparam name="TValue">The type of the value.</typeparam>
                /// <param name="value">The value from which to instantiate the instance.</param>
                /// <returns>An instance of this type, initialized from the provided value.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                static RequiredUnknownProposals IJsonValue<RequiredUnknownProposals>.FromBoolean<TValue>(in TValue value)
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return Undefined;
                }
#endif

#if NET8_0_OR_GREATER
                /// <summary>
                /// Gets an instance of the JSON value from the provided value.
                /// </summary>
                /// <typeparam name="TValue">The type of the value.</typeparam>
                /// <param name="value">The value from which to instantiate the instance.</param>
                /// <returns>An instance of this type, initialized from the provided value.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                static RequiredUnknownProposals IJsonValue<RequiredUnknownProposals>.FromString<TValue>(in TValue value)
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return Undefined;
                }
#endif

#if NET8_0_OR_GREATER
                /// <summary>
                /// Gets an instance of the JSON value from the provided value.
                /// </summary>
                /// <typeparam name="TValue">The type of the value.</typeparam>
                /// <param name="value">The value from which to instantiate the instance.</param>
                /// <returns>An instance of this type, initialized from the provided value.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                static RequiredUnknownProposals IJsonValue<RequiredUnknownProposals>.FromNumber<TValue>(in TValue value)
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return Undefined;
                }
#endif

                /// <summary>
                /// Gets an instance of the JSON value from the provided value.
                /// </summary>
                /// <typeparam name="TValue">The type of the value.</typeparam>
                /// <param name="value">The value from which to instantiate the instance.</param>
                /// <returns>An instance of this type, initialized from the provided value.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static RequiredUnknownProposals FromObject<TValue>(in TValue value)
                    where TValue : struct, IJsonObject<TValue>
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return value.ValueKind switch
                    {
                        JsonValueKind.Object => new(value.AsPropertyBacking()),
                        JsonValueKind.Null => Null,
                        _ => Undefined,
                    };
                }

#if NET8_0_OR_GREATER
                /// <summary>
                /// Gets an instance of the JSON value from the provided value.
                /// </summary>
                /// <typeparam name="TValue">The type of the value.</typeparam>
                /// <param name="value">The value from which to instantiate the instance.</param>
                /// <returns>An instance of this type, initialized from the provided value.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                static RequiredUnknownProposals IJsonValue<RequiredUnknownProposals>.FromArray<TValue>(in TValue value)
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return Undefined;
                }
#endif

                /// <summary>
                /// Parses the RequiredUnknownProposals.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredUnknownProposals Parse(string source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredUnknownProposals.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredUnknownProposals Parse(Stream source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredUnknownProposals.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredUnknownProposals Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredUnknownProposals.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredUnknownProposals Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredUnknownProposals.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredUnknownProposals Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredUnknownProposals.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static RequiredUnknownProposals ParseValue(string source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<RequiredUnknownProposals>.ParseValue(source);
#else
                    return JsonValueHelpers.ParseValue<RequiredUnknownProposals>(source.AsSpan());
#endif
                }

                /// <summary>
                /// Parses the RequiredUnknownProposals.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static RequiredUnknownProposals ParseValue(ReadOnlySpan<char> source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<RequiredUnknownProposals>.ParseValue(source);
#else
                    return JsonValueHelpers.ParseValue<RequiredUnknownProposals>(source);
#endif
                }

                /// <summary>
                /// Parses the RequiredUnknownProposals.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static RequiredUnknownProposals ParseValue(ReadOnlySpan<byte> source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<RequiredUnknownProposals>.ParseValue(source);
#else
                    return JsonValueHelpers.ParseValue<RequiredUnknownProposals>(source);
#endif
                }

                /// <summary>
                /// Parses the RequiredUnknownProposals.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static RequiredUnknownProposals ParseValue(ref Utf8JsonReader source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<RequiredUnknownProposals>.ParseValue(ref source);
#else
                    return JsonValueHelpers.ParseValue<RequiredUnknownProposals>(ref source);
#endif
                }

                /// <summary>
                /// Gets the value as an instance of the target value.
                /// </summary>
                /// <typeparam name="TTarget">The type of the target.</typeparam>
                /// <returns>An instance of the target type.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public TTarget As<TTarget>()
                    where TTarget : struct, IJsonValue<TTarget>
                {
#if NET8_0_OR_GREATER
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        return TTarget.FromJson(this.jsonElementBacking);
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        return TTarget.FromObject(this);
                    }

                    if ((this.backing & Backing.Null) != 0)
                    {
                        return TTarget.Null;
                    }

                    return TTarget.Undefined;
#else
                    return this.As<RequiredUnknownProposals, TTarget>();
#endif
                }

                /// <inheritdoc/>
                public override bool Equals(object? obj)
                {
                    return
                        (obj is IJsonValue jv && this.Equals(jv.As<RequiredUnknownProposals>())) ||
                        (obj is null && this.IsNull());
                }

                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, IJsonValue<T>
                {
                    return this.Equals(other.As<RequiredUnknownProposals>());
                }

                /// <summary>
                /// Equality comparison.
                /// </summary>
                /// <param name="other">The other item with which to compare.</param>
                /// <returns><see langword="true"/> if the values were equal.</returns>
                public bool Equals(in RequiredUnknownProposals other)
                {
                    JsonValueKind thisKind = this.ValueKind;
                    JsonValueKind otherKind = other.ValueKind;
                    if (thisKind != otherKind)
                    {
                        return false;
                    }

                    if (thisKind == JsonValueKind.Null || thisKind == JsonValueKind.Undefined)
                    {
                        return true;
                    }

                    if (thisKind == JsonValueKind.Object)
                    {
                        int count = 0;
                        foreach (JsonObjectProperty property in this.EnumerateObject())
                        {
                            if (!other.TryGetProperty(property.Name, out JsonAny value) || !property.Value.Equals(value))
                            {
                                return false;
                            }

                            count++;
                        }

                        int otherCount = 0;
                        foreach (JsonObjectProperty otherProperty in other.EnumerateObject())
                        {
                            otherCount++;
                            if (otherCount > count)
                            {
                                return false;
                            }
                        }

                        return count == otherCount;
                    }

                    return false;
                }

                /// <inheritdoc/>
                public void WriteTo(Utf8JsonWriter writer)
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Undefined)
                        {
                            this.jsonElementBacking.WriteTo(writer);
                        }

                        return;
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        JsonValueHelpers.WriteProperties(this.objectBacking, writer);

                        return;
                    }

                    if ((this.backing & Backing.Null) != 0)
                    {
                        writer.WriteNullValue();

                        return;
                    }
                }

                /// <inheritdoc/>
                public override int GetHashCode()
                {
                    return this.ValueKind switch
                    {
                        JsonValueKind.Array => JsonValueHelpers.GetArrayHashCode(((IJsonValue)this).AsArray),
                        JsonValueKind.Object => JsonValueHelpers.GetObjectHashCode(this),
                        JsonValueKind.Number => JsonValueHelpers.GetHashCodeForNumber(((IJsonValue)this).AsNumber),
                        JsonValueKind.String => JsonValueHelpers.GetHashCodeForString(((IJsonValue)this).AsString),
                        JsonValueKind.True => true.GetHashCode(),
                        JsonValueKind.False => false.GetHashCode(),
                        JsonValueKind.Null => JsonValueHelpers.NullHashCode,
                        _ => JsonValueHelpers.UndefinedHashCode,
                    };
                }

                /// <inheritdoc/>
                public override string ToString()
                {
                    return this.Serialize();
                }
            }
        }
    }
}
