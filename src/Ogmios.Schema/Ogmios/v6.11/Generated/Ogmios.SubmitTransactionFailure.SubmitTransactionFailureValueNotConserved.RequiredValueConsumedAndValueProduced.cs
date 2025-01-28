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
        /// SubmitTransactionFailure&lt;ValueNotConserved&gt;
        /// </summary>
        /// <remarks>
        /// <para>
        /// In and out value not conserved. The transaction must *exactly* balance: every input must be accounted for. There are various things counting as &#39;in balance&#39;: (a) the total value locked by inputs (or collateral inputs in case of a failing script), (b) rewards coming from withdrawals and (c) return deposits from stake credential or pool de-registration. In a similar fashion, various things count towards the &#39;out balance&#39;: (a) the total value assigned to each transaction output, (b) the fee and (c) any deposit for stake credential or pool registration. The field &#39;data.valueConsumed&#39; contains the total &#39;in balance&#39;, and &#39;data.valueProduced&#39; indicates the total amount counting as &#39;out balance&#39;.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureValueNotConserved
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            [System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<RequiredValueConsumedAndValueProduced>))]
            public readonly partial struct RequiredValueConsumedAndValueProduced

            {
                private readonly Backing backing;
                private readonly JsonElement jsonElementBacking;
                private readonly ImmutableList<JsonObjectProperty> objectBacking;

                /// <summary>
                /// Initializes a new instance of the <see cref="RequiredValueConsumedAndValueProduced"/> struct.
                /// </summary>
                public RequiredValueConsumedAndValueProduced()
                {
                    this.jsonElementBacking = default;
                    this.backing = Backing.JsonElement;
                    this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="RequiredValueConsumedAndValueProduced"/> struct.
                /// </summary>
                /// <param name="value">The value from which to construct the instance.</param>
                public RequiredValueConsumedAndValueProduced(in JsonElement value)
                {
                    this.jsonElementBacking = value;
                    this.backing = Backing.JsonElement;
                    this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="RequiredValueConsumedAndValueProduced"/> struct.
                /// </summary>
                /// <param name="value">The value from which to construct the instance.</param>
                public RequiredValueConsumedAndValueProduced(ImmutableList<JsonObjectProperty> value)
                {
                    this.backing = Backing.Object;
                    this.jsonElementBacking = default;
                    this.objectBacking = value;
                }

                /// <summary>
                /// Gets the schema location from which this type was generated.
                /// </summary>
                public static string SchemaLocation { get; } = "OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/24/properties/data";

                /// <summary>
                /// Gets a Null instance.
                /// </summary>
                public static RequiredValueConsumedAndValueProduced Null { get; } = new(JsonValueHelpers.NullElement);

                /// <summary>
                /// Gets an Undefined instance.
                /// </summary>
                public static RequiredValueConsumedAndValueProduced Undefined { get; }

                /// <summary>
                /// Gets the default instance.
                /// </summary>
                public static RequiredValueConsumedAndValueProduced DefaultInstance { get; }

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
                public static implicit operator RequiredValueConsumedAndValueProduced(JsonAny value)
                {
                    return value.As<RequiredValueConsumedAndValueProduced>();
                }

                /// <summary>
                /// Conversion to JsonAny.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator JsonAny(RequiredValueConsumedAndValueProduced value)
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
                public static bool operator ==(in RequiredValueConsumedAndValueProduced left, in RequiredValueConsumedAndValueProduced right)
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
                public static bool operator !=(in RequiredValueConsumedAndValueProduced left, in RequiredValueConsumedAndValueProduced right)
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
                public static RequiredValueConsumedAndValueProduced FromJson(in JsonElement value)
                {
                    return new(value);
                }

                /// <summary>
                /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
                /// </summary>
                /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
                /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static RequiredValueConsumedAndValueProduced FromAny(in JsonAny value)
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
                static RequiredValueConsumedAndValueProduced IJsonValue<RequiredValueConsumedAndValueProduced>.FromBoolean<TValue>(in TValue value)
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
                static RequiredValueConsumedAndValueProduced IJsonValue<RequiredValueConsumedAndValueProduced>.FromString<TValue>(in TValue value)
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
                static RequiredValueConsumedAndValueProduced IJsonValue<RequiredValueConsumedAndValueProduced>.FromNumber<TValue>(in TValue value)
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
                public static RequiredValueConsumedAndValueProduced FromObject<TValue>(in TValue value)
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
                static RequiredValueConsumedAndValueProduced IJsonValue<RequiredValueConsumedAndValueProduced>.FromArray<TValue>(in TValue value)
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return Undefined;
                }
#endif

                /// <summary>
                /// Parses the RequiredValueConsumedAndValueProduced.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredValueConsumedAndValueProduced Parse(string source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredValueConsumedAndValueProduced.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredValueConsumedAndValueProduced Parse(Stream source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredValueConsumedAndValueProduced.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredValueConsumedAndValueProduced Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredValueConsumedAndValueProduced.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredValueConsumedAndValueProduced Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredValueConsumedAndValueProduced.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static RequiredValueConsumedAndValueProduced Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the RequiredValueConsumedAndValueProduced.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static RequiredValueConsumedAndValueProduced ParseValue(string source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<RequiredValueConsumedAndValueProduced>.ParseValue(source);
#else
                    return JsonValueHelpers.ParseValue<RequiredValueConsumedAndValueProduced>(source.AsSpan());
#endif
                }

                /// <summary>
                /// Parses the RequiredValueConsumedAndValueProduced.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static RequiredValueConsumedAndValueProduced ParseValue(ReadOnlySpan<char> source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<RequiredValueConsumedAndValueProduced>.ParseValue(source);
#else
                    return JsonValueHelpers.ParseValue<RequiredValueConsumedAndValueProduced>(source);
#endif
                }

                /// <summary>
                /// Parses the RequiredValueConsumedAndValueProduced.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static RequiredValueConsumedAndValueProduced ParseValue(ReadOnlySpan<byte> source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<RequiredValueConsumedAndValueProduced>.ParseValue(source);
#else
                    return JsonValueHelpers.ParseValue<RequiredValueConsumedAndValueProduced>(source);
#endif
                }

                /// <summary>
                /// Parses the RequiredValueConsumedAndValueProduced.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static RequiredValueConsumedAndValueProduced ParseValue(ref Utf8JsonReader source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<RequiredValueConsumedAndValueProduced>.ParseValue(ref source);
#else
                    return JsonValueHelpers.ParseValue<RequiredValueConsumedAndValueProduced>(ref source);
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
                    return this.As<RequiredValueConsumedAndValueProduced, TTarget>();
#endif
                }

                /// <inheritdoc/>
                public override bool Equals(object? obj)
                {
                    return
                        (obj is IJsonValue jv && this.Equals(jv.As<RequiredValueConsumedAndValueProduced>())) ||
                        (obj is null && this.IsNull());
                }

                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, IJsonValue<T>
                {
                    return this.Equals(other.As<RequiredValueConsumedAndValueProduced>());
                }

                /// <summary>
                /// Equality comparison.
                /// </summary>
                /// <param name="other">The other item with which to compare.</param>
                /// <returns><see langword="true"/> if the values were equal.</returns>
                public bool Equals(in RequiredValueConsumedAndValueProduced other)
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
