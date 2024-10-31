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
/// DelegateRepresentative
/// </summary>
[System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<DelegateRepresentative>))]
public readonly partial struct DelegateRepresentative
    : IJsonValue<Generated.DelegateRepresentative>
{
    private readonly Backing backing;
    private readonly JsonElement jsonElementBacking;
    private readonly ImmutableList<JsonObjectProperty> objectBacking;

    /// <summary>
    /// Initializes a new instance of the <see cref="DelegateRepresentative"/> struct.
    /// </summary>
    public DelegateRepresentative()
    {
        this.jsonElementBacking = default;
        this.backing = Backing.JsonElement;
        this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DelegateRepresentative"/> struct.
    /// </summary>
    /// <param name="value">The value from which to construct the instance.</param>
    public DelegateRepresentative(in JsonElement value)
    {
        this.jsonElementBacking = value;
        this.backing = Backing.JsonElement;
        this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DelegateRepresentative"/> struct.
    /// </summary>
    /// <param name="value">The value from which to construct the instance.</param>
    public DelegateRepresentative(ImmutableList<JsonObjectProperty> value)
    {
        this.backing = Backing.Object;
        this.jsonElementBacking = default;
        this.objectBacking = value;
    }

    /// <summary>
    /// Gets the schema location from which this type was generated.
    /// </summary>
    public static string SchemaLocation { get; } = "https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/cardano.json#/definitions/DelegateRepresentative";

    /// <summary>
    /// Gets a Null instance.
    /// </summary>
    public static DelegateRepresentative Null { get; } = new(JsonValueHelpers.NullElement);

    /// <summary>
    /// Gets an Undefined instance.
    /// </summary>
    public static DelegateRepresentative Undefined { get; }

    /// <summary>
    /// Gets the default instance.
    /// </summary>
    public static DelegateRepresentative DefaultInstance { get; }

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
    /// Gets the instance as a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeRegistered" />.
    /// </summary>
    public Generated.DelegateRepresentative.DelegateRepresentativeRegistered AsDelegateRepresentativeRegistered
    {
        get
        {
            return this.As<Generated.DelegateRepresentative.DelegateRepresentativeRegistered>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeRegistered" />.
    /// </summary>
    public bool IsDelegateRepresentativeRegistered
    {
        get
        {
            return this.As<Generated.DelegateRepresentative.DelegateRepresentativeRegistered>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence" />.
    /// </summary>
    public Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence AsDelegateRepresentativeNoConfidence
    {
        get
        {
            return this.As<Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence" />.
    /// </summary>
    public bool IsDelegateRepresentativeNoConfidence
    {
        get
        {
            return this.As<Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeAbstain" />.
    /// </summary>
    public Generated.DelegateRepresentative.DelegateRepresentativeAbstain AsDelegateRepresentativeAbstain
    {
        get
        {
            return this.As<Generated.DelegateRepresentative.DelegateRepresentativeAbstain>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeAbstain" />.
    /// </summary>
    public bool IsDelegateRepresentativeAbstain
    {
        get
        {
            return this.As<Generated.DelegateRepresentative.DelegateRepresentativeAbstain>().IsValid();
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
    public static implicit operator DelegateRepresentative(JsonAny value)
    {
        return value.As<DelegateRepresentative>();
    }

    /// <summary>
    /// Conversion to JsonAny.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator JsonAny(DelegateRepresentative value)
    {
        return value.AsAny;
    }

    /// <summary>
    /// Conversion to <see cref="Generated.DelegateRepresentative.DelegateRepresentativeRegistered"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.DelegateRepresentative.DelegateRepresentativeRegistered(DelegateRepresentative value)
    {
        return value.As<Generated.DelegateRepresentative.DelegateRepresentativeRegistered>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.DelegateRepresentative.DelegateRepresentativeRegistered"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator DelegateRepresentative(Generated.DelegateRepresentative.DelegateRepresentativeRegistered value)
    {
        return value.As<DelegateRepresentative>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence(DelegateRepresentative value)
    {
        return value.As<Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator DelegateRepresentative(Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence value)
    {
        return value.As<DelegateRepresentative>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.DelegateRepresentative.DelegateRepresentativeAbstain"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.DelegateRepresentative.DelegateRepresentativeAbstain(DelegateRepresentative value)
    {
        return value.As<Generated.DelegateRepresentative.DelegateRepresentativeAbstain>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.DelegateRepresentative.DelegateRepresentativeAbstain"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator DelegateRepresentative(Generated.DelegateRepresentative.DelegateRepresentativeAbstain value)
    {
        return value.As<DelegateRepresentative>();
    }

    /// <summary>
    /// Operator ==.
    /// </summary>
    /// <param name="left">The lhs of the operator.</param>
    /// <param name="right">The rhs of the operator.</param>
    /// <returns>
    /// <c>True</c> if the values are equal.
    /// </returns>
    public static bool operator ==(in DelegateRepresentative left, in DelegateRepresentative right)
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
    public static bool operator !=(in DelegateRepresentative left, in DelegateRepresentative right)
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
    public static DelegateRepresentative FromJson(in JsonElement value)
    {
        return new(value);
    }

    /// <summary>
    /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
    /// </summary>
    /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DelegateRepresentative FromAny(in JsonAny value)
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
    static DelegateRepresentative IJsonValue<DelegateRepresentative>.FromBoolean<TValue>(in TValue value)
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
    static DelegateRepresentative IJsonValue<DelegateRepresentative>.FromString<TValue>(in TValue value)
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
    static DelegateRepresentative IJsonValue<DelegateRepresentative>.FromNumber<TValue>(in TValue value)
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
    public static DelegateRepresentative FromObject<TValue>(in TValue value)
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
    static DelegateRepresentative IJsonValue<DelegateRepresentative>.FromArray<TValue>(in TValue value)
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }
#endif

    /// <summary>
    /// Parses the DelegateRepresentative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static DelegateRepresentative Parse(string source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the DelegateRepresentative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static DelegateRepresentative Parse(Stream source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the DelegateRepresentative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static DelegateRepresentative Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the DelegateRepresentative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static DelegateRepresentative Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the DelegateRepresentative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static DelegateRepresentative Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the DelegateRepresentative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static DelegateRepresentative ParseValue(string source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<DelegateRepresentative>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<DelegateRepresentative>(source.AsSpan());
#endif
    }

    /// <summary>
    /// Parses the DelegateRepresentative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static DelegateRepresentative ParseValue(ReadOnlySpan<char> source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<DelegateRepresentative>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<DelegateRepresentative>(source);
#endif
    }

    /// <summary>
    /// Parses the DelegateRepresentative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static DelegateRepresentative ParseValue(ReadOnlySpan<byte> source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<DelegateRepresentative>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<DelegateRepresentative>(source);
#endif
    }

    /// <summary>
    /// Parses the DelegateRepresentative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static DelegateRepresentative ParseValue(ref Utf8JsonReader source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<DelegateRepresentative>.ParseValue(ref source);
#else
        return JsonValueHelpers.ParseValue<DelegateRepresentative>(ref source);
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
        return this.As<DelegateRepresentative, TTarget>();
#endif
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return
            (obj is IJsonValue jv && this.Equals(jv.As<DelegateRepresentative>())) ||
            (obj is null && this.IsNull());
    }

    /// <inheritdoc/>
    public bool Equals<T>(in T other)
        where T : struct, IJsonValue<T>
    {
        return this.Equals(other.As<DelegateRepresentative>());
    }

    /// <summary>
    /// Equality comparison.
    /// </summary>
    /// <param name="other">The other item with which to compare.</param>
    /// <returns><see langword="true"/> if the values were equal.</returns>
    public bool Equals(in DelegateRepresentative other)
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
    /// <param name="matchDelegateRepresentativeRegistered">Match a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeRegistered"/>.</param>
    /// <param name="matchDelegateRepresentativeNoConfidence">Match a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence"/>.</param>
    /// <param name="matchDelegateRepresentativeAbstain">Match a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeAbstain"/>.</param>
    /// <param name="defaultMatch">Match any other value.</param>
    /// <returns>An instance of the value returned by the match function.</returns>
    public TOut Match<TIn, TOut>(
        in TIn context,
        Matcher<Generated.DelegateRepresentative.DelegateRepresentativeRegistered, TIn, TOut> matchDelegateRepresentativeRegistered,
        Matcher<Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence, TIn, TOut> matchDelegateRepresentativeNoConfidence,
        Matcher<Generated.DelegateRepresentative.DelegateRepresentativeAbstain, TIn, TOut> matchDelegateRepresentativeAbstain,
        Matcher<Generated.DelegateRepresentative, TIn, TOut> defaultMatch)
    {
        Generated.DelegateRepresentative.DelegateRepresentativeRegistered matchDelegateRepresentativeRegisteredValue = this.As<Generated.DelegateRepresentative.DelegateRepresentativeRegistered>();
        if (matchDelegateRepresentativeRegisteredValue.IsValid())
        {
            return matchDelegateRepresentativeRegistered(matchDelegateRepresentativeRegisteredValue, context);
        }

        Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence matchDelegateRepresentativeNoConfidenceValue = this.As<Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence>();
        if (matchDelegateRepresentativeNoConfidenceValue.IsValid())
        {
            return matchDelegateRepresentativeNoConfidence(matchDelegateRepresentativeNoConfidenceValue, context);
        }

        Generated.DelegateRepresentative.DelegateRepresentativeAbstain matchDelegateRepresentativeAbstainValue = this.As<Generated.DelegateRepresentative.DelegateRepresentativeAbstain>();
        if (matchDelegateRepresentativeAbstainValue.IsValid())
        {
            return matchDelegateRepresentativeAbstain(matchDelegateRepresentativeAbstainValue, context);
        }

        return defaultMatch(this, context);
    }

    /// <summary>
    /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
    /// </summary>
    /// <typeparam name="TOut">The result of calling the match function.</typeparam>
    /// <param name="matchDelegateRepresentativeRegistered">Match a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeRegistered"/>.</param>
    /// <param name="matchDelegateRepresentativeNoConfidence">Match a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence"/>.</param>
    /// <param name="matchDelegateRepresentativeAbstain">Match a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeAbstain"/>.</param>
    /// <param name="defaultMatch">Match any other value.</param>
    /// <returns>An instance of the value returned by the match function.</returns>
    public TOut Match<TOut>(
        Matcher<Generated.DelegateRepresentative.DelegateRepresentativeRegistered, TOut> matchDelegateRepresentativeRegistered,
        Matcher<Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence, TOut> matchDelegateRepresentativeNoConfidence,
        Matcher<Generated.DelegateRepresentative.DelegateRepresentativeAbstain, TOut> matchDelegateRepresentativeAbstain,
        Matcher<Generated.DelegateRepresentative, TOut> defaultMatch)
    {
        Generated.DelegateRepresentative.DelegateRepresentativeRegistered matchDelegateRepresentativeRegisteredValue = this.As<Generated.DelegateRepresentative.DelegateRepresentativeRegistered>();
        if (matchDelegateRepresentativeRegisteredValue.IsValid())
        {
            return matchDelegateRepresentativeRegistered(matchDelegateRepresentativeRegisteredValue);
        }

        Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence matchDelegateRepresentativeNoConfidenceValue = this.As<Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence>();
        if (matchDelegateRepresentativeNoConfidenceValue.IsValid())
        {
            return matchDelegateRepresentativeNoConfidence(matchDelegateRepresentativeNoConfidenceValue);
        }

        Generated.DelegateRepresentative.DelegateRepresentativeAbstain matchDelegateRepresentativeAbstainValue = this.As<Generated.DelegateRepresentative.DelegateRepresentativeAbstain>();
        if (matchDelegateRepresentativeAbstainValue.IsValid())
        {
            return matchDelegateRepresentativeAbstain(matchDelegateRepresentativeAbstainValue);
        }

        return defaultMatch(this);
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeRegistered" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsDelegateRepresentativeRegistered(out Generated.DelegateRepresentative.DelegateRepresentativeRegistered result)
    {
        result = this.As<Generated.DelegateRepresentative.DelegateRepresentativeRegistered>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsDelegateRepresentativeNoConfidence(out Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence result)
    {
        result = this.As<Generated.DelegateRepresentative.DelegateRepresentativeNoConfidence>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.DelegateRepresentative.DelegateRepresentativeAbstain" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsDelegateRepresentativeAbstain(out Generated.DelegateRepresentative.DelegateRepresentativeAbstain result)
    {
        result = this.As<Generated.DelegateRepresentative.DelegateRepresentativeAbstain>();
        return result.IsValid();
    }
}
