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
    public readonly partial struct QueryLedgerStateConstitutionResponseEntity
    {
        /// <summary>
        /// QueryLedgerStateConstitutionResponse
        /// </summary>
        public readonly partial struct QueryLedgerStateConstitutionResponse
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            [System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<JsonrpcEntity>))]
            public readonly partial struct JsonrpcEntity

            {
                private readonly Backing backing;
                private readonly JsonElement jsonElementBacking;
                private readonly string stringBacking;

                /// <summary>
                /// Initializes a new instance of the <see cref="JsonrpcEntity"/> struct.
                /// </summary>
                public JsonrpcEntity()
                {
                    this.jsonElementBacking = default;
                    this.backing = Backing.JsonElement;
                    this.stringBacking = string.Empty;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="JsonrpcEntity"/> struct.
                /// </summary>
                /// <param name="value">The value from which to construct the instance.</param>
                public JsonrpcEntity(in JsonElement value)
                {
                    this.jsonElementBacking = value;
                    this.backing = Backing.JsonElement;
                    this.stringBacking = string.Empty;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="JsonrpcEntity"/> struct.
                /// </summary>
                /// <param name="value">The value from which to construct the instance.</param>
                public JsonrpcEntity(string value)
                {
                    this.backing = Backing.String;
                    this.jsonElementBacking = default;
                    this.stringBacking = value;
                }

                /// <summary>
                /// Gets the schema location from which this type was generated.
                /// </summary>
                public static string SchemaLocation { get; } = "OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/ogmios.json#/properties/QueryLedgerStateConstitutionResponse/oneOf/0/properties/jsonrpc";

                /// <summary>
                /// Gets a Null instance.
                /// </summary>
                public static JsonrpcEntity Null { get; } = new(JsonValueHelpers.NullElement);

                /// <summary>
                /// Gets an Undefined instance.
                /// </summary>
                public static JsonrpcEntity Undefined { get; }

                /// <summary>
                /// Gets the default instance.
                /// </summary>
                public static JsonrpcEntity DefaultInstance { get; }

                /// <inheritdoc/>
                public JsonAny AsAny
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return new(this.jsonElementBacking);
                        }

                        if ((this.backing & Backing.String) != 0)
                        {
                            return new(this.stringBacking);
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

                        if ((this.backing & Backing.String) != 0)
                        {
                            return JsonValueHelpers.StringToJsonElement(this.stringBacking);
                        }

                        if ((this.backing & Backing.Null) != 0)
                        {
                            return JsonValueHelpers.NullElement;
                        }

                        return default;
                    }
                }

                /// <inheritdoc/>
                public JsonString AsString
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return new(this.jsonElementBacking);
                        }

                        if ((this.backing & Backing.String) != 0)
                        {
                            return new(this.stringBacking);
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
                JsonObject IJsonValue.AsObject
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

                        if ((this.backing & Backing.String) != 0)
                        {
                            return JsonValueKind.String;
                        }

                        return JsonValueKind.Undefined;
                    }
                }

                /// <summary>
                /// Conversion from JsonAny.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator JsonrpcEntity(JsonAny value)
                {
                    return value.As<JsonrpcEntity>();
                }

                /// <summary>
                /// Conversion to JsonAny.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator JsonAny(JsonrpcEntity value)
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
                public static bool operator ==(in JsonrpcEntity left, in JsonrpcEntity right)
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
                public static bool operator !=(in JsonrpcEntity left, in JsonrpcEntity right)
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
                public static JsonrpcEntity FromJson(in JsonElement value)
                {
                    return new(value);
                }

                /// <summary>
                /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
                /// </summary>
                /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
                /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static JsonrpcEntity FromAny(in JsonAny value)
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return value.ValueKind switch
                    {
                        JsonValueKind.String => new(value.AsString.GetString()!),
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
                static JsonrpcEntity IJsonValue<JsonrpcEntity>.FromBoolean<TValue>(in TValue value)
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
                public static JsonrpcEntity FromString<TValue>(in TValue value)
                    where TValue : struct, IJsonString<TValue>
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return value.ValueKind switch
                    {
                        JsonValueKind.String => new(value.GetString()!),
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
                static JsonrpcEntity IJsonValue<JsonrpcEntity>.FromNumber<TValue>(in TValue value)
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
                static JsonrpcEntity IJsonValue<JsonrpcEntity>.FromObject<TValue>(in TValue value)
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
                static JsonrpcEntity IJsonValue<JsonrpcEntity>.FromArray<TValue>(in TValue value)
                {
                    if (value.HasJsonElementBacking)
                    {
                        return new(value.AsJsonElement);
                    }

                    return Undefined;
                }
#endif

                /// <summary>
                /// Parses the JsonrpcEntity.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static JsonrpcEntity Parse(string source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the JsonrpcEntity.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static JsonrpcEntity Parse(Stream source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the JsonrpcEntity.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static JsonrpcEntity Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the JsonrpcEntity.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static JsonrpcEntity Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the JsonrpcEntity.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                /// <param name="options">The (optional) JsonDocumentOptions.</param>
                public static JsonrpcEntity Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
                {
                    using var jsonDocument = JsonDocument.Parse(source, options);
                    return new(jsonDocument.RootElement.Clone());
                }

                /// <summary>
                /// Parses the JsonrpcEntity.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static JsonrpcEntity ParseValue(string source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<JsonrpcEntity>.ParseValue(source);
#else
                    return JsonValueHelpers.ParseValue<JsonrpcEntity>(source.AsSpan());
#endif
                }

                /// <summary>
                /// Parses the JsonrpcEntity.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static JsonrpcEntity ParseValue(ReadOnlySpan<char> source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<JsonrpcEntity>.ParseValue(source);
#else
                    return JsonValueHelpers.ParseValue<JsonrpcEntity>(source);
#endif
                }

                /// <summary>
                /// Parses the JsonrpcEntity.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static JsonrpcEntity ParseValue(ReadOnlySpan<byte> source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<JsonrpcEntity>.ParseValue(source);
#else
                    return JsonValueHelpers.ParseValue<JsonrpcEntity>(source);
#endif
                }

                /// <summary>
                /// Parses the JsonrpcEntity.
                /// </summary>
                /// <param name="source">The source of the JSON string to parse.</param>
                public static JsonrpcEntity ParseValue(ref Utf8JsonReader source)
                {
#if NET8_0_OR_GREATER
                    return IJsonValue<JsonrpcEntity>.ParseValue(ref source);
#else
                    return JsonValueHelpers.ParseValue<JsonrpcEntity>(ref source);
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

                    if ((this.backing & Backing.String) != 0)
                    {
                        return TTarget.FromString(this);
                    }

                    if ((this.backing & Backing.Null) != 0)
                    {
                        return TTarget.Null;
                    }

                    return TTarget.Undefined;
#else
                    return this.As<JsonrpcEntity, TTarget>();
#endif
                }

                /// <inheritdoc/>
                public override bool Equals(object? obj)
                {
                    return
                        (obj is IJsonValue jv && this.Equals(jv.As<JsonrpcEntity>())) ||
                        (obj is null && this.IsNull());
                }

                /// <inheritdoc/>
                public bool Equals<T>(in T other)
                    where T : struct, IJsonValue<T>
                {
                    return this.Equals(other.As<JsonrpcEntity>());
                }

                /// <summary>
                /// Equality comparison.
                /// </summary>
                /// <param name="other">The other item with which to compare.</param>
                /// <returns><see langword="true"/> if the values were equal.</returns>
                public bool Equals(in JsonrpcEntity other)
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

                    if (thisKind == JsonValueKind.String)
                    {
                        if (this.backing == Backing.JsonElement)
                        {
                            if (other.backing == Backing.String)
                            {
                                return this.jsonElementBacking.ValueEquals(other.stringBacking);
                            }
                            else
                            {
                                other.jsonElementBacking.TryGetValue(CompareValues, this.jsonElementBacking, out bool areEqual);
                                return areEqual;
                            }

                        }

                        if (other.backing == Backing.JsonElement)
                        {
                            return other.jsonElementBacking.ValueEquals(this.stringBacking);
                        }

                        return this.stringBacking.Equals(other.stringBacking);

                        static bool CompareValues(ReadOnlySpan<byte> span, in JsonElement firstItem, out bool value)
                        {
                            value = firstItem.ValueEquals(span);
                            return true;
                        }
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

                    if ((this.backing & Backing.String) != 0)
                    {
                        writer.WriteStringValue(this.stringBacking);

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
                        JsonValueKind.Object => JsonValueHelpers.GetObjectHashCode(((IJsonValue)this).AsObject),
                        JsonValueKind.Number => JsonValueHelpers.GetHashCodeForNumber(((IJsonValue)this).AsNumber),
                        JsonValueKind.String => JsonValueHelpers.GetHashCodeForString(this),
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
