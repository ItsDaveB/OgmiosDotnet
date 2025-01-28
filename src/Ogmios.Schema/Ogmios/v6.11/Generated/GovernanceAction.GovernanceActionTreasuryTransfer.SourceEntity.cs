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
/// Generated from JSON Schema.
/// </summary>
public readonly partial struct GovernanceAction
{
    /// <summary>
    /// GovernanceAction&lt;TreasuryTransfer&gt;
    /// </summary>
    /// <remarks>
    /// <para>
    /// A transfer from or to the treasury / reserves authored by genesis delegates.
    /// </para>
    /// </remarks>
    public readonly partial struct GovernanceActionTreasuryTransfer
    {
        /// <summary>
        /// Generated from JSON Schema.
        /// </summary>
        [System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<SourceEntity>))]
        public readonly partial struct SourceEntity

        {
            private readonly Backing backing;
            private readonly JsonElement jsonElementBacking;
            private readonly string stringBacking;

            /// <summary>
            /// Initializes a new instance of the <see cref="SourceEntity"/> struct.
            /// </summary>
            public SourceEntity()
            {
                this.jsonElementBacking = default;
                this.backing = Backing.JsonElement;
                this.stringBacking = string.Empty;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SourceEntity"/> struct.
            /// </summary>
            /// <param name="value">The value from which to construct the instance.</param>
            public SourceEntity(in JsonElement value)
            {
                this.jsonElementBacking = value;
                this.backing = Backing.JsonElement;
                this.stringBacking = string.Empty;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SourceEntity"/> struct.
            /// </summary>
            /// <param name="value">The value from which to construct the instance.</param>
            public SourceEntity(string value)
            {
                this.backing = Backing.String;
                this.jsonElementBacking = default;
                this.stringBacking = value;
            }

            /// <summary>
            /// Gets the schema location from which this type was generated.
            /// </summary>
            public static string SchemaLocation { get; } = "OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/cardano.json#/definitions/GovernanceAction/oneOf/2/properties/source";

            /// <summary>
            /// Gets a Null instance.
            /// </summary>
            public static SourceEntity Null { get; } = new(JsonValueHelpers.NullElement);

            /// <summary>
            /// Gets an Undefined instance.
            /// </summary>
            public static SourceEntity Undefined { get; }

            /// <summary>
            /// Gets the default instance.
            /// </summary>
            public static SourceEntity DefaultInstance { get; }

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
            public static implicit operator SourceEntity(JsonAny value)
            {
                return value.As<SourceEntity>();
            }

            /// <summary>
            /// Conversion to JsonAny.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator JsonAny(SourceEntity value)
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
            public static bool operator ==(in SourceEntity left, in SourceEntity right)
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
            public static bool operator !=(in SourceEntity left, in SourceEntity right)
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
            public static SourceEntity FromJson(in JsonElement value)
            {
                return new(value);
            }

            /// <summary>
            /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
            /// </summary>
            /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
            /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static SourceEntity FromAny(in JsonAny value)
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
            static SourceEntity IJsonValue<SourceEntity>.FromBoolean<TValue>(in TValue value)
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
            public static SourceEntity FromString<TValue>(in TValue value)
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
            static SourceEntity IJsonValue<SourceEntity>.FromNumber<TValue>(in TValue value)
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
            static SourceEntity IJsonValue<SourceEntity>.FromObject<TValue>(in TValue value)
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
            static SourceEntity IJsonValue<SourceEntity>.FromArray<TValue>(in TValue value)
            {
                if (value.HasJsonElementBacking)
                {
                    return new(value.AsJsonElement);
                }

                return Undefined;
            }
#endif

            /// <summary>
            /// Parses the SourceEntity.
            /// </summary>
            /// <param name="source">The source of the JSON string to parse.</param>
            /// <param name="options">The (optional) JsonDocumentOptions.</param>
            public static SourceEntity Parse(string source, JsonDocumentOptions options = default)
            {
                using var jsonDocument = JsonDocument.Parse(source, options);
                return new(jsonDocument.RootElement.Clone());
            }

            /// <summary>
            /// Parses the SourceEntity.
            /// </summary>
            /// <param name="source">The source of the JSON string to parse.</param>
            /// <param name="options">The (optional) JsonDocumentOptions.</param>
            public static SourceEntity Parse(Stream source, JsonDocumentOptions options = default)
            {
                using var jsonDocument = JsonDocument.Parse(source, options);
                return new(jsonDocument.RootElement.Clone());
            }

            /// <summary>
            /// Parses the SourceEntity.
            /// </summary>
            /// <param name="source">The source of the JSON string to parse.</param>
            /// <param name="options">The (optional) JsonDocumentOptions.</param>
            public static SourceEntity Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
            {
                using var jsonDocument = JsonDocument.Parse(source, options);
                return new(jsonDocument.RootElement.Clone());
            }

            /// <summary>
            /// Parses the SourceEntity.
            /// </summary>
            /// <param name="source">The source of the JSON string to parse.</param>
            /// <param name="options">The (optional) JsonDocumentOptions.</param>
            public static SourceEntity Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
            {
                using var jsonDocument = JsonDocument.Parse(source, options);
                return new(jsonDocument.RootElement.Clone());
            }

            /// <summary>
            /// Parses the SourceEntity.
            /// </summary>
            /// <param name="source">The source of the JSON string to parse.</param>
            /// <param name="options">The (optional) JsonDocumentOptions.</param>
            public static SourceEntity Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
            {
                using var jsonDocument = JsonDocument.Parse(source, options);
                return new(jsonDocument.RootElement.Clone());
            }

            /// <summary>
            /// Parses the SourceEntity.
            /// </summary>
            /// <param name="source">The source of the JSON string to parse.</param>
            public static SourceEntity ParseValue(string source)
            {
#if NET8_0_OR_GREATER
                return IJsonValue<SourceEntity>.ParseValue(source);
#else
                return JsonValueHelpers.ParseValue<SourceEntity>(source.AsSpan());
#endif
            }

            /// <summary>
            /// Parses the SourceEntity.
            /// </summary>
            /// <param name="source">The source of the JSON string to parse.</param>
            public static SourceEntity ParseValue(ReadOnlySpan<char> source)
            {
#if NET8_0_OR_GREATER
                return IJsonValue<SourceEntity>.ParseValue(source);
#else
                return JsonValueHelpers.ParseValue<SourceEntity>(source);
#endif
            }

            /// <summary>
            /// Parses the SourceEntity.
            /// </summary>
            /// <param name="source">The source of the JSON string to parse.</param>
            public static SourceEntity ParseValue(ReadOnlySpan<byte> source)
            {
#if NET8_0_OR_GREATER
                return IJsonValue<SourceEntity>.ParseValue(source);
#else
                return JsonValueHelpers.ParseValue<SourceEntity>(source);
#endif
            }

            /// <summary>
            /// Parses the SourceEntity.
            /// </summary>
            /// <param name="source">The source of the JSON string to parse.</param>
            public static SourceEntity ParseValue(ref Utf8JsonReader source)
            {
#if NET8_0_OR_GREATER
                return IJsonValue<SourceEntity>.ParseValue(ref source);
#else
                return JsonValueHelpers.ParseValue<SourceEntity>(ref source);
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
                return this.As<SourceEntity, TTarget>();
#endif
            }

            /// <inheritdoc/>
            public override bool Equals(object? obj)
            {
                return
                    (obj is IJsonValue jv && this.Equals(jv.As<SourceEntity>())) ||
                    (obj is null && this.IsNull());
            }

            /// <inheritdoc/>
            public bool Equals<T>(in T other)
                where T : struct, IJsonValue<T>
            {
                return this.Equals(other.As<SourceEntity>());
            }

            /// <summary>
            /// Equality comparison.
            /// </summary>
            /// <param name="other">The other item with which to compare.</param>
            /// <returns><see langword="true"/> if the values were equal.</returns>
            public bool Equals(in SourceEntity other)
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

            /// <summary>
            /// Matches the value against the constant values, and returns the result of calling the provided match function for the first match found.
            /// </summary>
            /// <typeparam name="TIn">The immutable context to pass in to the match function.</typeparam>
            /// <typeparam name="TOut">The result of calling the match function.</typeparam>
            /// <param name="context">The context to pass to the match function.</param>
            /// <param name="matchReserves">Match 1st item.</param>
            /// <param name="matchTreasury">Match 2nd item.</param>
            /// <param name="defaultMatch">Match any other value.</param>
            /// <returns>An instance of the value returned by the match function.</returns>
            public TOut Match<TIn, TOut>(
                in TIn context,
                Func<TIn, TOut> matchReserves,
                Func<TIn, TOut> matchTreasury,
                Func<TIn, TOut> defaultMatch)
            {
                if (this.Equals(CorvusValidation.Enum1))
                {
                    return matchReserves(context);
                }

                if (this.Equals(CorvusValidation.Enum2))
                {
                    return matchTreasury(context);
                }

                return defaultMatch(context);
            }

            /// <summary>
            /// Matches the value against the constant values, and returns the result of calling the provided match function for the first match found.
            /// </summary>
            /// <typeparam name="TOut">The result of calling the match function.</typeparam>
            /// <param name="matchReserves">Match 1st item.</param>
            /// <param name="matchTreasury">Match 2nd item.</param>
            /// <param name="defaultMatch">Match any other value.</param>
            /// <returns>An instance of the value returned by the match function.</returns>
            public TOut Match<TOut>(
                Func<TOut> matchReserves,
                Func<TOut> matchTreasury,
                Func<TOut> defaultMatch)
            {
                if (this.Equals(CorvusValidation.Enum1))
                {
                    return matchReserves();
                }

                if (this.Equals(CorvusValidation.Enum2))
                {
                    return matchTreasury();
                }

                return defaultMatch();
            }
        }
    }
}
