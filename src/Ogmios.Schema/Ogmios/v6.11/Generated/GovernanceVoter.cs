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
/// Generated from JSON Schema.
/// </summary>
[System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<GovernanceVoter>))]
public readonly partial struct GovernanceVoter
    : IJsonValue<Generated.GovernanceVoter>
{
    private readonly Backing backing;
    private readonly JsonElement jsonElementBacking;
    private readonly ImmutableList<JsonObjectProperty> objectBacking;

    /// <summary>
    /// Initializes a new instance of the <see cref="GovernanceVoter"/> struct.
    /// </summary>
    public GovernanceVoter()
    {
        this.jsonElementBacking = default;
        this.backing = Backing.JsonElement;
        this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GovernanceVoter"/> struct.
    /// </summary>
    /// <param name="value">The value from which to construct the instance.</param>
    public GovernanceVoter(in JsonElement value)
    {
        this.jsonElementBacking = value;
        this.backing = Backing.JsonElement;
        this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GovernanceVoter"/> struct.
    /// </summary>
    /// <param name="value">The value from which to construct the instance.</param>
    public GovernanceVoter(ImmutableList<JsonObjectProperty> value)
    {
        this.backing = Backing.Object;
        this.jsonElementBacking = default;
        this.objectBacking = value;
    }

    /// <summary>
    /// Gets the schema location from which this type was generated.
    /// </summary>
    public static string SchemaLocation { get; } = "OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/cardano.json#/definitions/GovernanceVoter";

    /// <summary>
    /// Gets a Null instance.
    /// </summary>
    public static GovernanceVoter Null { get; } = new(JsonValueHelpers.NullElement);

    /// <summary>
    /// Gets an Undefined instance.
    /// </summary>
    public static GovernanceVoter Undefined { get; }

    /// <summary>
    /// Gets the default instance.
    /// </summary>
    public static GovernanceVoter DefaultInstance { get; }

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
    /// Gets the instance as a <see cref="Generated.GovernanceVoter.VoterGenesisDelegate" />.
    /// </summary>
    public Generated.GovernanceVoter.VoterGenesisDelegate AsVoterGenesisDelegate
    {
        get
        {
            return this.As<Generated.GovernanceVoter.VoterGenesisDelegate>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.GovernanceVoter.VoterGenesisDelegate" />.
    /// </summary>
    public bool IsVoterGenesisDelegate
    {
        get
        {
            return this.As<Generated.GovernanceVoter.VoterGenesisDelegate>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.GovernanceVoter.VoterConstitutionalCommittee" />.
    /// </summary>
    public Generated.GovernanceVoter.VoterConstitutionalCommittee AsVoterConstitutionalCommittee
    {
        get
        {
            return this.As<Generated.GovernanceVoter.VoterConstitutionalCommittee>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.GovernanceVoter.VoterConstitutionalCommittee" />.
    /// </summary>
    public bool IsVoterConstitutionalCommittee
    {
        get
        {
            return this.As<Generated.GovernanceVoter.VoterConstitutionalCommittee>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.GovernanceVoter.VoterDelegateRepresentative" />.
    /// </summary>
    public Generated.GovernanceVoter.VoterDelegateRepresentative AsVoterDelegateRepresentative
    {
        get
        {
            return this.As<Generated.GovernanceVoter.VoterDelegateRepresentative>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.GovernanceVoter.VoterDelegateRepresentative" />.
    /// </summary>
    public bool IsVoterDelegateRepresentative
    {
        get
        {
            return this.As<Generated.GovernanceVoter.VoterDelegateRepresentative>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.GovernanceVoter.VoterStakePoolOperator" />.
    /// </summary>
    public Generated.GovernanceVoter.VoterStakePoolOperator AsVoterStakePoolOperator
    {
        get
        {
            return this.As<Generated.GovernanceVoter.VoterStakePoolOperator>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.GovernanceVoter.VoterStakePoolOperator" />.
    /// </summary>
    public bool IsVoterStakePoolOperator
    {
        get
        {
            return this.As<Generated.GovernanceVoter.VoterStakePoolOperator>().IsValid();
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
    public static implicit operator GovernanceVoter(JsonAny value)
    {
        return value.As<GovernanceVoter>();
    }

    /// <summary>
    /// Conversion to JsonAny.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator JsonAny(GovernanceVoter value)
    {
        return value.AsAny;
    }

    /// <summary>
    /// Conversion to <see cref="Generated.GovernanceVoter.VoterGenesisDelegate"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.GovernanceVoter.VoterGenesisDelegate(GovernanceVoter value)
    {
        return value.As<Generated.GovernanceVoter.VoterGenesisDelegate>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.GovernanceVoter.VoterGenesisDelegate"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator GovernanceVoter(Generated.GovernanceVoter.VoterGenesisDelegate value)
    {
        return value.As<GovernanceVoter>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.GovernanceVoter.VoterConstitutionalCommittee"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.GovernanceVoter.VoterConstitutionalCommittee(GovernanceVoter value)
    {
        return value.As<Generated.GovernanceVoter.VoterConstitutionalCommittee>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.GovernanceVoter.VoterConstitutionalCommittee"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator GovernanceVoter(Generated.GovernanceVoter.VoterConstitutionalCommittee value)
    {
        return value.As<GovernanceVoter>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.GovernanceVoter.VoterDelegateRepresentative"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.GovernanceVoter.VoterDelegateRepresentative(GovernanceVoter value)
    {
        return value.As<Generated.GovernanceVoter.VoterDelegateRepresentative>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.GovernanceVoter.VoterDelegateRepresentative"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator GovernanceVoter(Generated.GovernanceVoter.VoterDelegateRepresentative value)
    {
        return value.As<GovernanceVoter>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.GovernanceVoter.VoterStakePoolOperator"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.GovernanceVoter.VoterStakePoolOperator(GovernanceVoter value)
    {
        return value.As<Generated.GovernanceVoter.VoterStakePoolOperator>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.GovernanceVoter.VoterStakePoolOperator"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator GovernanceVoter(Generated.GovernanceVoter.VoterStakePoolOperator value)
    {
        return value.As<GovernanceVoter>();
    }

    /// <summary>
    /// Operator ==.
    /// </summary>
    /// <param name="left">The lhs of the operator.</param>
    /// <param name="right">The rhs of the operator.</param>
    /// <returns>
    /// <c>True</c> if the values are equal.
    /// </returns>
    public static bool operator ==(in GovernanceVoter left, in GovernanceVoter right)
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
    public static bool operator !=(in GovernanceVoter left, in GovernanceVoter right)
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
    public static GovernanceVoter FromJson(in JsonElement value)
    {
        return new(value);
    }

    /// <summary>
    /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
    /// </summary>
    /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GovernanceVoter FromAny(in JsonAny value)
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
    static GovernanceVoter IJsonValue<GovernanceVoter>.FromBoolean<TValue>(in TValue value)
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
    static GovernanceVoter IJsonValue<GovernanceVoter>.FromString<TValue>(in TValue value)
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
    static GovernanceVoter IJsonValue<GovernanceVoter>.FromNumber<TValue>(in TValue value)
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
    public static GovernanceVoter FromObject<TValue>(in TValue value)
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
    static GovernanceVoter IJsonValue<GovernanceVoter>.FromArray<TValue>(in TValue value)
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }
#endif

    /// <summary>
    /// Parses the GovernanceVoter.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static GovernanceVoter Parse(string source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the GovernanceVoter.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static GovernanceVoter Parse(Stream source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the GovernanceVoter.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static GovernanceVoter Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the GovernanceVoter.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static GovernanceVoter Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the GovernanceVoter.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static GovernanceVoter Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the GovernanceVoter.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static GovernanceVoter ParseValue(string source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<GovernanceVoter>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<GovernanceVoter>(source.AsSpan());
#endif
    }

    /// <summary>
    /// Parses the GovernanceVoter.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static GovernanceVoter ParseValue(ReadOnlySpan<char> source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<GovernanceVoter>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<GovernanceVoter>(source);
#endif
    }

    /// <summary>
    /// Parses the GovernanceVoter.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static GovernanceVoter ParseValue(ReadOnlySpan<byte> source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<GovernanceVoter>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<GovernanceVoter>(source);
#endif
    }

    /// <summary>
    /// Parses the GovernanceVoter.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static GovernanceVoter ParseValue(ref Utf8JsonReader source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<GovernanceVoter>.ParseValue(ref source);
#else
        return JsonValueHelpers.ParseValue<GovernanceVoter>(ref source);
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
        return this.As<GovernanceVoter, TTarget>();
#endif
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return
            (obj is IJsonValue jv && this.Equals(jv.As<GovernanceVoter>())) ||
            (obj is null && this.IsNull());
    }

    /// <inheritdoc/>
    public bool Equals<T>(in T other)
        where T : struct, IJsonValue<T>
    {
        return this.Equals(other.As<GovernanceVoter>());
    }

    /// <summary>
    /// Equality comparison.
    /// </summary>
    /// <param name="other">The other item with which to compare.</param>
    /// <returns><see langword="true"/> if the values were equal.</returns>
    public bool Equals(in GovernanceVoter other)
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
    /// <param name="matchVoterGenesisDelegate">Match a <see cref="Generated.GovernanceVoter.VoterGenesisDelegate"/>.</param>
    /// <param name="matchVoterConstitutionalCommittee">Match a <see cref="Generated.GovernanceVoter.VoterConstitutionalCommittee"/>.</param>
    /// <param name="matchVoterDelegateRepresentative">Match a <see cref="Generated.GovernanceVoter.VoterDelegateRepresentative"/>.</param>
    /// <param name="matchVoterStakePoolOperator">Match a <see cref="Generated.GovernanceVoter.VoterStakePoolOperator"/>.</param>
    /// <param name="defaultMatch">Match any other value.</param>
    /// <returns>An instance of the value returned by the match function.</returns>
    public TOut Match<TIn, TOut>(
        in TIn context,
        Matcher<Generated.GovernanceVoter.VoterGenesisDelegate, TIn, TOut> matchVoterGenesisDelegate,
        Matcher<Generated.GovernanceVoter.VoterConstitutionalCommittee, TIn, TOut> matchVoterConstitutionalCommittee,
        Matcher<Generated.GovernanceVoter.VoterDelegateRepresentative, TIn, TOut> matchVoterDelegateRepresentative,
        Matcher<Generated.GovernanceVoter.VoterStakePoolOperator, TIn, TOut> matchVoterStakePoolOperator,
        Matcher<Generated.GovernanceVoter, TIn, TOut> defaultMatch)
    {
        Generated.GovernanceVoter.VoterGenesisDelegate matchVoterGenesisDelegateValue = this.As<Generated.GovernanceVoter.VoterGenesisDelegate>();
        if (matchVoterGenesisDelegateValue.IsValid())
        {
            return matchVoterGenesisDelegate(matchVoterGenesisDelegateValue, context);
        }

        Generated.GovernanceVoter.VoterConstitutionalCommittee matchVoterConstitutionalCommitteeValue = this.As<Generated.GovernanceVoter.VoterConstitutionalCommittee>();
        if (matchVoterConstitutionalCommitteeValue.IsValid())
        {
            return matchVoterConstitutionalCommittee(matchVoterConstitutionalCommitteeValue, context);
        }

        Generated.GovernanceVoter.VoterDelegateRepresentative matchVoterDelegateRepresentativeValue = this.As<Generated.GovernanceVoter.VoterDelegateRepresentative>();
        if (matchVoterDelegateRepresentativeValue.IsValid())
        {
            return matchVoterDelegateRepresentative(matchVoterDelegateRepresentativeValue, context);
        }

        Generated.GovernanceVoter.VoterStakePoolOperator matchVoterStakePoolOperatorValue = this.As<Generated.GovernanceVoter.VoterStakePoolOperator>();
        if (matchVoterStakePoolOperatorValue.IsValid())
        {
            return matchVoterStakePoolOperator(matchVoterStakePoolOperatorValue, context);
        }

        return defaultMatch(this, context);
    }

    /// <summary>
    /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
    /// </summary>
    /// <typeparam name="TOut">The result of calling the match function.</typeparam>
    /// <param name="matchVoterGenesisDelegate">Match a <see cref="Generated.GovernanceVoter.VoterGenesisDelegate"/>.</param>
    /// <param name="matchVoterConstitutionalCommittee">Match a <see cref="Generated.GovernanceVoter.VoterConstitutionalCommittee"/>.</param>
    /// <param name="matchVoterDelegateRepresentative">Match a <see cref="Generated.GovernanceVoter.VoterDelegateRepresentative"/>.</param>
    /// <param name="matchVoterStakePoolOperator">Match a <see cref="Generated.GovernanceVoter.VoterStakePoolOperator"/>.</param>
    /// <param name="defaultMatch">Match any other value.</param>
    /// <returns>An instance of the value returned by the match function.</returns>
    public TOut Match<TOut>(
        Matcher<Generated.GovernanceVoter.VoterGenesisDelegate, TOut> matchVoterGenesisDelegate,
        Matcher<Generated.GovernanceVoter.VoterConstitutionalCommittee, TOut> matchVoterConstitutionalCommittee,
        Matcher<Generated.GovernanceVoter.VoterDelegateRepresentative, TOut> matchVoterDelegateRepresentative,
        Matcher<Generated.GovernanceVoter.VoterStakePoolOperator, TOut> matchVoterStakePoolOperator,
        Matcher<Generated.GovernanceVoter, TOut> defaultMatch)
    {
        Generated.GovernanceVoter.VoterGenesisDelegate matchVoterGenesisDelegateValue = this.As<Generated.GovernanceVoter.VoterGenesisDelegate>();
        if (matchVoterGenesisDelegateValue.IsValid())
        {
            return matchVoterGenesisDelegate(matchVoterGenesisDelegateValue);
        }

        Generated.GovernanceVoter.VoterConstitutionalCommittee matchVoterConstitutionalCommitteeValue = this.As<Generated.GovernanceVoter.VoterConstitutionalCommittee>();
        if (matchVoterConstitutionalCommitteeValue.IsValid())
        {
            return matchVoterConstitutionalCommittee(matchVoterConstitutionalCommitteeValue);
        }

        Generated.GovernanceVoter.VoterDelegateRepresentative matchVoterDelegateRepresentativeValue = this.As<Generated.GovernanceVoter.VoterDelegateRepresentative>();
        if (matchVoterDelegateRepresentativeValue.IsValid())
        {
            return matchVoterDelegateRepresentative(matchVoterDelegateRepresentativeValue);
        }

        Generated.GovernanceVoter.VoterStakePoolOperator matchVoterStakePoolOperatorValue = this.As<Generated.GovernanceVoter.VoterStakePoolOperator>();
        if (matchVoterStakePoolOperatorValue.IsValid())
        {
            return matchVoterStakePoolOperator(matchVoterStakePoolOperatorValue);
        }

        return defaultMatch(this);
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.GovernanceVoter.VoterGenesisDelegate" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsVoterGenesisDelegate(out Generated.GovernanceVoter.VoterGenesisDelegate result)
    {
        result = this.As<Generated.GovernanceVoter.VoterGenesisDelegate>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.GovernanceVoter.VoterConstitutionalCommittee" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsVoterConstitutionalCommittee(out Generated.GovernanceVoter.VoterConstitutionalCommittee result)
    {
        result = this.As<Generated.GovernanceVoter.VoterConstitutionalCommittee>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.GovernanceVoter.VoterDelegateRepresentative" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsVoterDelegateRepresentative(out Generated.GovernanceVoter.VoterDelegateRepresentative result)
    {
        result = this.As<Generated.GovernanceVoter.VoterDelegateRepresentative>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.GovernanceVoter.VoterStakePoolOperator" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsVoterStakePoolOperator(out Generated.GovernanceVoter.VoterStakePoolOperator result)
    {
        result = this.As<Generated.GovernanceVoter.VoterStakePoolOperator>();
        return result.IsValid();
    }
}
