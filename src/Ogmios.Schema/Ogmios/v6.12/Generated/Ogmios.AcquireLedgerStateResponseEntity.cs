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
    [System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<AcquireLedgerStateResponseEntity>))]
    public readonly partial struct AcquireLedgerStateResponseEntity
        : IJsonValue<Generated.Ogmios.AcquireLedgerStateResponseEntity>
    {
        private readonly Backing backing;
        private readonly JsonElement jsonElementBacking;
        private readonly ImmutableList<JsonObjectProperty> objectBacking;

        /// <summary>
        /// Initializes a new instance of the <see cref="AcquireLedgerStateResponseEntity"/> struct.
        /// </summary>
        public AcquireLedgerStateResponseEntity()
        {
            this.jsonElementBacking = default;
            this.backing = Backing.JsonElement;
            this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AcquireLedgerStateResponseEntity"/> struct.
        /// </summary>
        /// <param name="value">The value from which to construct the instance.</param>
        public AcquireLedgerStateResponseEntity(in JsonElement value)
        {
            this.jsonElementBacking = value;
            this.backing = Backing.JsonElement;
            this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AcquireLedgerStateResponseEntity"/> struct.
        /// </summary>
        /// <param name="value">The value from which to construct the instance.</param>
        public AcquireLedgerStateResponseEntity(ImmutableList<JsonObjectProperty> value)
        {
            this.backing = Backing.Object;
            this.jsonElementBacking = default;
            this.objectBacking = value;
        }

        /// <summary>
        /// Gets the schema location from which this type was generated.
        /// </summary>
        public static string SchemaLocation { get; } = "OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.12/Source/ogmios.json#/properties/AcquireLedgerStateResponse";

        /// <summary>
        /// Gets a Null instance.
        /// </summary>
        public static AcquireLedgerStateResponseEntity Null { get; } = new(JsonValueHelpers.NullElement);

        /// <summary>
        /// Gets an Undefined instance.
        /// </summary>
        public static AcquireLedgerStateResponseEntity Undefined { get; }

        /// <summary>
        /// Gets the default instance.
        /// </summary>
        public static AcquireLedgerStateResponseEntity DefaultInstance { get; }

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

        /// <summary>
        /// Gets the instance as a <see cref="Generated.Ogmios.AcquireLedgerStateFailure" />.
        /// </summary>
        public Generated.Ogmios.AcquireLedgerStateFailure AsAcquireLedgerStateFailure
        {
            get
            {
                return this.As<Generated.Ogmios.AcquireLedgerStateFailure>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the instance is a <see cref="Generated.Ogmios.AcquireLedgerStateFailure" />.
        /// </summary>
        public bool IsAcquireLedgerStateFailure
        {
            get
            {
                return this.As<Generated.Ogmios.AcquireLedgerStateFailure>().IsValid();
            }
        }

        /// <summary>
        /// Gets the instance as a <see cref="Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess" />.
        /// </summary>
        public Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess AsAcquireLedgerStateSuccess
        {
            get
            {
                return this.As<Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the instance is a <see cref="Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess" />.
        /// </summary>
        public bool IsAcquireLedgerStateSuccess
        {
            get
            {
                return this.As<Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess>().IsValid();
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
        public static implicit operator AcquireLedgerStateResponseEntity(JsonAny value)
        {
            return value.As<AcquireLedgerStateResponseEntity>();
        }

        /// <summary>
        /// Conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(AcquireLedgerStateResponseEntity value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Conversion to <see cref="Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static explicit operator Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess(AcquireLedgerStateResponseEntity value)
        {
            return value.As<Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess>();
        }

        /// <summary>
        /// Conversion from <see cref="Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator AcquireLedgerStateResponseEntity(Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess value)
        {
            return value.As<AcquireLedgerStateResponseEntity>();
        }

        /// <summary>
        /// Conversion to <see cref="Generated.Ogmios.AcquireLedgerStateFailure"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static explicit operator Generated.Ogmios.AcquireLedgerStateFailure(AcquireLedgerStateResponseEntity value)
        {
            return value.As<Generated.Ogmios.AcquireLedgerStateFailure>();
        }

        /// <summary>
        /// Conversion from <see cref="Generated.Ogmios.AcquireLedgerStateFailure"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator AcquireLedgerStateResponseEntity(Generated.Ogmios.AcquireLedgerStateFailure value)
        {
            return value.As<AcquireLedgerStateResponseEntity>();
        }

        /// <summary>
        /// Operator ==.
        /// </summary>
        /// <param name="left">The lhs of the operator.</param>
        /// <param name="right">The rhs of the operator.</param>
        /// <returns>
        /// <c>True</c> if the values are equal.
        /// </returns>
        public static bool operator ==(in AcquireLedgerStateResponseEntity left, in AcquireLedgerStateResponseEntity right)
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
        public static bool operator !=(in AcquireLedgerStateResponseEntity left, in AcquireLedgerStateResponseEntity right)
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
        public static AcquireLedgerStateResponseEntity FromJson(in JsonElement value)
        {
            return new(value);
        }

        /// <summary>
        /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
        /// </summary>
        /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AcquireLedgerStateResponseEntity FromAny(in JsonAny value)
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
        static AcquireLedgerStateResponseEntity IJsonValue<AcquireLedgerStateResponseEntity>.FromBoolean<TValue>(in TValue value)
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
        static AcquireLedgerStateResponseEntity IJsonValue<AcquireLedgerStateResponseEntity>.FromString<TValue>(in TValue value)
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
        static AcquireLedgerStateResponseEntity IJsonValue<AcquireLedgerStateResponseEntity>.FromNumber<TValue>(in TValue value)
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
        public static AcquireLedgerStateResponseEntity FromObject<TValue>(in TValue value)
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
        static AcquireLedgerStateResponseEntity IJsonValue<AcquireLedgerStateResponseEntity>.FromArray<TValue>(in TValue value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return Undefined;
        }
#endif

        /// <summary>
        /// Parses the AcquireLedgerStateResponseEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static AcquireLedgerStateResponseEntity Parse(string source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the AcquireLedgerStateResponseEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static AcquireLedgerStateResponseEntity Parse(Stream source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the AcquireLedgerStateResponseEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static AcquireLedgerStateResponseEntity Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the AcquireLedgerStateResponseEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static AcquireLedgerStateResponseEntity Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the AcquireLedgerStateResponseEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static AcquireLedgerStateResponseEntity Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the AcquireLedgerStateResponseEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static AcquireLedgerStateResponseEntity ParseValue(string source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<AcquireLedgerStateResponseEntity>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<AcquireLedgerStateResponseEntity>(source.AsSpan());
#endif
        }

        /// <summary>
        /// Parses the AcquireLedgerStateResponseEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static AcquireLedgerStateResponseEntity ParseValue(ReadOnlySpan<char> source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<AcquireLedgerStateResponseEntity>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<AcquireLedgerStateResponseEntity>(source);
#endif
        }

        /// <summary>
        /// Parses the AcquireLedgerStateResponseEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static AcquireLedgerStateResponseEntity ParseValue(ReadOnlySpan<byte> source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<AcquireLedgerStateResponseEntity>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<AcquireLedgerStateResponseEntity>(source);
#endif
        }

        /// <summary>
        /// Parses the AcquireLedgerStateResponseEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static AcquireLedgerStateResponseEntity ParseValue(ref Utf8JsonReader source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<AcquireLedgerStateResponseEntity>.ParseValue(ref source);
#else
            return JsonValueHelpers.ParseValue<AcquireLedgerStateResponseEntity>(ref source);
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
                return TTarget.FromObject(this.AsObject);
            }

            if ((this.backing & Backing.Null) != 0)
            {
                return TTarget.Null;
            }

            return TTarget.Undefined;
#else
            return this.As<AcquireLedgerStateResponseEntity, TTarget>();
#endif
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return
                (obj is IJsonValue jv && this.Equals(jv.As<AcquireLedgerStateResponseEntity>())) ||
                (obj is null && this.IsNull());
        }

        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, IJsonValue<T>
        {
            return this.Equals(other.As<AcquireLedgerStateResponseEntity>());
        }

        /// <summary>
        /// Equality comparison.
        /// </summary>
        /// <param name="other">The other item with which to compare.</param>
        /// <returns><see langword="true"/> if the values were equal.</returns>
        public bool Equals(in AcquireLedgerStateResponseEntity other)
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
                JsonObject thisObject = this.AsObject;
                JsonObject otherObject = other.AsObject;
                int count = 0;
                foreach (JsonObjectProperty property in thisObject.EnumerateObject())
                {
                    if (!otherObject.TryGetProperty(property.Name, out JsonAny value) || !property.Value.Equals(value))
                    {
                        return false;
                    }

                    count++;
                }

                int otherCount = 0;
                foreach (JsonObjectProperty otherProperty in otherObject.EnumerateObject())
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

        /// <summary>
        /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
        /// </summary>
        /// <typeparam name="TIn">The immutable context to pass in to the match function.</typeparam>
        /// <typeparam name="TOut">The result of calling the match function.</typeparam>
        /// <param name="context">The context to pass to the match function.</param>
        /// <param name="matchAcquireLedgerStateSuccess">Match a <see cref="Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess"/>.</param>
        /// <param name="matchAcquireLedgerStateFailure">Match a <see cref="Generated.Ogmios.AcquireLedgerStateFailure"/>.</param>
        /// <param name="defaultMatch">Match any other value.</param>
        /// <returns>An instance of the value returned by the match function.</returns>
        public TOut Match<TIn, TOut>(
            in TIn context,
            Matcher<Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess, TIn, TOut> matchAcquireLedgerStateSuccess,
            Matcher<Generated.Ogmios.AcquireLedgerStateFailure, TIn, TOut> matchAcquireLedgerStateFailure,
            Matcher<Generated.Ogmios.AcquireLedgerStateResponseEntity, TIn, TOut> defaultMatch)
        {
            Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess matchAcquireLedgerStateSuccessValue = this.As<Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess>();
            if (matchAcquireLedgerStateSuccessValue.IsValid())
            {
                return matchAcquireLedgerStateSuccess(matchAcquireLedgerStateSuccessValue, context);
            }

            Generated.Ogmios.AcquireLedgerStateFailure matchAcquireLedgerStateFailureValue = this.As<Generated.Ogmios.AcquireLedgerStateFailure>();
            if (matchAcquireLedgerStateFailureValue.IsValid())
            {
                return matchAcquireLedgerStateFailure(matchAcquireLedgerStateFailureValue, context);
            }

            return defaultMatch(this, context);
        }

        /// <summary>
        /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
        /// </summary>
        /// <typeparam name="TOut">The result of calling the match function.</typeparam>
        /// <param name="matchAcquireLedgerStateSuccess">Match a <see cref="Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess"/>.</param>
        /// <param name="matchAcquireLedgerStateFailure">Match a <see cref="Generated.Ogmios.AcquireLedgerStateFailure"/>.</param>
        /// <param name="defaultMatch">Match any other value.</param>
        /// <returns>An instance of the value returned by the match function.</returns>
        public TOut Match<TOut>(
            Matcher<Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess, TOut> matchAcquireLedgerStateSuccess,
            Matcher<Generated.Ogmios.AcquireLedgerStateFailure, TOut> matchAcquireLedgerStateFailure,
            Matcher<Generated.Ogmios.AcquireLedgerStateResponseEntity, TOut> defaultMatch)
        {
            Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess matchAcquireLedgerStateSuccessValue = this.As<Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess>();
            if (matchAcquireLedgerStateSuccessValue.IsValid())
            {
                return matchAcquireLedgerStateSuccess(matchAcquireLedgerStateSuccessValue);
            }

            Generated.Ogmios.AcquireLedgerStateFailure matchAcquireLedgerStateFailureValue = this.As<Generated.Ogmios.AcquireLedgerStateFailure>();
            if (matchAcquireLedgerStateFailureValue.IsValid())
            {
                return matchAcquireLedgerStateFailure(matchAcquireLedgerStateFailureValue);
            }

            return defaultMatch(this);
        }

        /// <summary>
        /// Gets the value as a <see cref="Generated.Ogmios.AcquireLedgerStateFailure" />.
        /// </summary>
        /// <param name="result">The result of the conversions.</param>
        /// <returns><see langword="true" /> if the conversion was valid.</returns>
        public bool TryGetAsAcquireLedgerStateFailure(out Generated.Ogmios.AcquireLedgerStateFailure result)
        {
            result = this.As<Generated.Ogmios.AcquireLedgerStateFailure>();
            return result.IsValid();
        }

        /// <summary>
        /// Gets the value as a <see cref="Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess" />.
        /// </summary>
        /// <param name="result">The result of the conversions.</param>
        /// <returns><see langword="true" /> if the conversion was valid.</returns>
        public bool TryGetAsAcquireLedgerStateSuccess(out Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess result)
        {
            result = this.As<Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess>();
            return result.IsValid();
        }
    }
}
