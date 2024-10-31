//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Collections.Immutable;
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
        /// SubmitTransactionFailure<InvalidOrMissingPreviousProposals>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The transaction contains invalid or missing reference to previous (ratified) governance proposals. Indeed, some governance proposals such as protocol parameters update or consitutional committee change must point to last action of the same purpose that was ratified. The field 'data.invalidOrMissingPreviousProposals' contains a list of submitted actions that are missing details. For each item, we provide the anchor of the corresponding proposal, the type of previous proposal that is expected and the invalid proposal reference if relevant.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureInvalidOrMissingPreviousProposals
            : IJsonObject<Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureInvalidOrMissingPreviousProposals>
        {
            /// <summary>
            /// Conversion from <see cref="ImmutableList{JsonObjectProperty}"/>.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator SubmitTransactionFailureInvalidOrMissingPreviousProposals(ImmutableList<JsonObjectProperty> value)
            {
                return new(value);
            }

            /// <summary>
            /// Conversion to <see cref="ImmutableList{JsonObjectProperty}"/>.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator ImmutableList<JsonObjectProperty>(SubmitTransactionFailureInvalidOrMissingPreviousProposals value)
            {
                return
                    __CorvusObjectHelpers.GetPropertyBacking(value);
            }

            /// <summary>
            /// Conversion from JsonObject.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator SubmitTransactionFailureInvalidOrMissingPreviousProposals(JsonObject value)
            {
                if (value.HasDotnetBacking && value.ValueKind == JsonValueKind.Object)
                {
                    return new(
                        __CorvusObjectHelpers.GetPropertyBacking(value));
                }

                return new(value.AsJsonElement);
            }

            /// <summary>
            /// Conversion to JsonObject.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator JsonObject(SubmitTransactionFailureInvalidOrMissingPreviousProposals value)
            {
                return
                    value.AsObject;
            }

            /// <inheritdoc/>
            public Corvus.Json.JsonAny this[in JsonPropertyName name]
            {
                get
                {
                    if (this.TryGetProperty(name, out Corvus.Json.JsonAny result))
                    {
                        return result;
                    }

                    throw new InvalidOperationException();
                }
            }

            /// <summary>
            /// Gets the number of properties in the object.
            /// </summary>
            public int Count
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        return this.jsonElementBacking.GetPropertyCount();
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        return this.objectBacking.Count;
                    }

                    throw new InvalidOperationException();
                }
            }

            /// <summary>
            /// Gets the <c>code</c> property.
            /// </summary>
            /// <remarks>
            /// <para>
            /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
            /// </para>
            /// </remarks>
            public Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureInvalidOrMissingPreviousProposals.CodeEntity Code
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.CodeUtf8, out JsonElement result))
                        {
                            return new(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(JsonPropertyNames.Code, out JsonAny result))
                        {
                            return result.As<Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureInvalidOrMissingPreviousProposals.CodeEntity>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Gets the <c>data</c> property.
            /// </summary>
            /// <remarks>
            /// <para>
            /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
            /// </para>
            /// </remarks>
            public Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureInvalidOrMissingPreviousProposals.RequiredInvalidOrMissingPreviousProposals Data
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.DataUtf8, out JsonElement result))
                        {
                            return new(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(JsonPropertyNames.Data, out JsonAny result))
                        {
                            return result.As<Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureInvalidOrMissingPreviousProposals.RequiredInvalidOrMissingPreviousProposals>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Gets the <c>message</c> property.
            /// </summary>
            /// <remarks>
            /// <para>
            /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
            /// </para>
            /// </remarks>
            public Corvus.Json.JsonString Message
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.MessageUtf8, out JsonElement result))
                        {
                            return new(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(JsonPropertyNames.Message, out JsonAny result))
                        {
                            return result.As<Corvus.Json.JsonString>();
                        }
                    }

                    return default;
                }
            }

            /// <inheritdoc/>
            public static SubmitTransactionFailureInvalidOrMissingPreviousProposals FromProperties(IDictionary<JsonPropertyName, JsonAny> source)
            {
                return new(source.Select(kvp => new JsonObjectProperty(kvp.Key, kvp.Value)).ToImmutableList());
            }

            /// <inheritdoc/>
            public static SubmitTransactionFailureInvalidOrMissingPreviousProposals FromProperties(params (JsonPropertyName Name, JsonAny Value)[] source)
            {
                return new(source.Select(s => new JsonObjectProperty(s.Name, s.Value.AsAny)).ToImmutableList());
            }

            /// <summary>
            /// Creates an instance of the type from the given immutable list of properties.
            /// </summary>
            /// <param name="source">The list of properties.</param>
            /// <returns>An instance of the type initialized from the list of properties.</returns>
            public static SubmitTransactionFailureInvalidOrMissingPreviousProposals FromProperties(ImmutableList<JsonObjectProperty> source)
            {
                return new(source);
            }

            /// <summary>
            /// Creates an instance of a <see cref="SubmitTransactionFailureInvalidOrMissingPreviousProposals"/>.
            /// </summary>
            public static SubmitTransactionFailureInvalidOrMissingPreviousProposals Create(
                in Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureInvalidOrMissingPreviousProposals.CodeEntity code,
                in Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureInvalidOrMissingPreviousProposals.RequiredInvalidOrMissingPreviousProposals data,
                in Corvus.Json.JsonString message)
            {
                var builder = ImmutableList.CreateBuilder<JsonObjectProperty>();
                builder.Add(JsonPropertyNames.Code, code.AsAny);
                builder.Add(JsonPropertyNames.Data, data.AsAny);
                builder.Add(JsonPropertyNames.Message, message.AsAny);

                return new(builder.ToImmutable());
            }

            /// <inheritdoc/>
            public ImmutableList<JsonObjectProperty> AsPropertyBacking()
            {
                return __CorvusObjectHelpers.GetPropertyBacking(this);
            }
            /// <inheritdoc/>
            public ImmutableList<JsonObjectProperty>.Builder AsPropertyBackingBuilder()
            {
                return __CorvusObjectHelpers.GetPropertyBacking(this).ToBuilder();
            }

            /// <inheritdoc/>
            public JsonObjectEnumerator EnumerateObject()
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

            /// <inheritdoc/>
            public bool HasProperties()
            {
                if ((this.backing & Backing.Object) != 0)
                {
                    return this.objectBacking.Count > 0;
                }

                if ((this.backing & Backing.JsonElement) != 0)
                {
                    using JsonElement.ObjectEnumerator enumerator = this.jsonElementBacking.EnumerateObject();
                    return enumerator.MoveNext();
                }

                throw new InvalidOperationException();
            }

            /// <inheritdoc />
            public bool HasProperty(in JsonPropertyName name)
            {
                if ((this.backing & Backing.Object) != 0)
                {
                    return this.objectBacking.ContainsKey(name);
                }

                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return name.TryGetProperty(this.jsonElementBacking, out JsonElement _);
                }

                throw new InvalidOperationException();
            }

            /// <inheritdoc />
            public bool HasProperty(string name)
            {
                if ((this.backing & Backing.Object) != 0)
                {
                    return this.objectBacking.ContainsKey(name);
                }

                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return this.jsonElementBacking.TryGetProperty(name, out _);
                }

                throw new InvalidOperationException();
            }

            /// <inheritdoc />
            public bool HasProperty(ReadOnlySpan<char> name)
            {
                if ((this.backing & Backing.Object) != 0)
                {
                    return this.objectBacking.ContainsKey(name);
                }

                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return this.jsonElementBacking.TryGetProperty(name, out _);
                }

                throw new InvalidOperationException();
            }

            /// <inheritdoc />
            public bool HasProperty(ReadOnlySpan<byte> name)
            {
                if ((this.backing & Backing.Object) != 0)
                {
                    return this.objectBacking.ContainsKey(name);
                }

                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return this.jsonElementBacking.TryGetProperty(name, out _);
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Get a property.
            /// </summary>
            /// <param name="name">The name of the property.</param>
            /// <param name="value">The value of the property.</param>
            /// <returns><c>True</c> if the property was present.</returns>
            /// <exception cref="InvalidOperationException">The value is not an object.</exception>
            public bool TryGetProperty(in JsonPropertyName name, out JsonAny value)
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        value = default;
                        return false;
                    }

                    if (name.TryGetProperty(this.jsonElementBacking, out JsonElement element))
                    {
                        value = new(element);
                        return true;
                    }

                    value = default;
                    return false;
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(name, out JsonAny result))
                    {
                        value = result;
                        return true;
                    }

                    value = default;
                    return false;
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Get a property.
            /// </summary>
            /// <param name="name">The name of the property.</param>
            /// <param name="value">The value of the property.</param>
            /// <returns><c>True</c> if the property was present.</returns>
            /// <exception cref="InvalidOperationException">The value is not an object.</exception>
            public bool TryGetProperty(string name, out JsonAny value)
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        value = default;
                        return false;
                    }

                    if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
                    {
                        value = new(element);
                        return true;
                    }

                    value = default;
                    return false;
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(name, out JsonAny result))
                    {
                        value = result;
                        return true;
                    }

                    value = default;
                    return false;
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Get a property.
            /// </summary>
            /// <param name="name">The name of the property.</param>
            /// <param name="value">The value of the property.</param>
            /// <returns><c>True</c> if the property was present.</returns>
            /// <exception cref="InvalidOperationException">The value is not an object.</exception>
            public bool TryGetProperty(ReadOnlySpan<char> name, out JsonAny value)
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        value = default;
                        return false;
                    }

                    if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
                    {
                        value = new(element);
                        return true;
                    }

                    value = default;
                    return false;
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(name, out JsonAny result))
                    {
                        value = result;
                        return true;
                    }

                    value = default;
                    return false;
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Get a property.
            /// </summary>
            /// <param name="name">The name of the property.</param>
            /// <param name="value">The value of the property.</param>
            /// <returns><c>True</c> if the property was present.</returns>
            /// <exception cref="InvalidOperationException">The value is not an object.</exception>
            public bool TryGetProperty(ReadOnlySpan<byte> name, out JsonAny value)
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        value = default;
                        return false;
                    }

                    if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
                    {
                        value = new(element);
                        return true;
                    }

                    value = default;
                    return false;
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(name, out JsonAny result))
                    {
                        value = result;
                        return true;
                    }

                    value = default;
                    return false;
                }

                throw new InvalidOperationException();
            }

            /// <inheritdoc />
            public bool TryGetProperty<TValue>(in JsonPropertyName name, out TValue value)
                where TValue : struct, IJsonValue<TValue>
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        value = default;
                        return false;
                    }

                    if (name.TryGetProperty(this.jsonElementBacking, out JsonElement element))
                    {
#if NET8_0_OR_GREATER
                        value = TValue.FromJson(element);
#else
                        value = JsonValueNetStandard20Extensions.FromJsonElement<TValue>(element);
#endif

                        return true;
                    }

                    value = default;
                    return false;
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(name, out JsonAny result))
                    {
#if NET8_0_OR_GREATER
                        value = TValue.FromAny(result);
#else
                        value = result.As<TValue>();
#endif
                        return true;
                    }

                    value = default;
                    return false;
                }

                throw new InvalidOperationException();
            }

            /// <inheritdoc />
            public bool TryGetProperty<TValue>(string name, out TValue value)
                where TValue : struct, IJsonValue<TValue>
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        value = default;
                        return false;
                    }

                    if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
                    {
#if NET8_0_OR_GREATER
                        value = TValue.FromJson(element);
#else
                        value = JsonValueNetStandard20Extensions.FromJsonElement<TValue>(element);
#endif

                        return true;
                    }

                    value = default;
                    return false;
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(name, out JsonAny result))
                    {
#if NET8_0_OR_GREATER
                        value = TValue.FromAny(result);
#else
                        value = result.As<TValue>();
#endif
                        return true;
                    }

                    value = default;
                    return false;
                }

                throw new InvalidOperationException();
            }

            /// <inheritdoc />
            public bool TryGetProperty<TValue>(ReadOnlySpan<char> name, out TValue value)
                where TValue : struct, IJsonValue<TValue>
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        value = default;
                        return false;
                    }

                    if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
                    {
#if NET8_0_OR_GREATER
                        value = TValue.FromJson(element);
#else
                        value = JsonValueNetStandard20Extensions.FromJsonElement<TValue>(element);
#endif

                        return true;
                    }

                    value = default;
                    return false;
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(name, out JsonAny result))
                    {
#if NET8_0_OR_GREATER
                        value = TValue.FromAny(result);
#else
                        value = result.As<TValue>();
#endif
                        return true;
                    }

                    value = default;
                    return false;
                }

                throw new InvalidOperationException();
            }

            /// <inheritdoc />
            public bool TryGetProperty<TValue>(ReadOnlySpan<byte> name, out TValue value)
                where TValue : struct, IJsonValue<TValue>
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        value = default;
                        return false;
                    }

                    if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
                    {
#if NET8_0_OR_GREATER
                        value = TValue.FromJson(element);
#else
                        value = JsonValueNetStandard20Extensions.FromJsonElement<TValue>(element);
#endif

                        return true;
                    }

                    value = default;
                    return false;
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(name, out JsonAny result))
                    {
#if NET8_0_OR_GREATER
                        value = TValue.FromAny(result);
#else
                        value = result.As<TValue>();
#endif
                        return true;
                    }

                    value = default;
                    return false;
                }

                throw new InvalidOperationException();
            }

            /// <inheritdoc />
            public SubmitTransactionFailureInvalidOrMissingPreviousProposals SetProperty<TValue>(in JsonPropertyName name, TValue value)
                where TValue : struct, IJsonValue
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWith(this, name, value.AsAny));
            }

            /// <inheritdoc />
            public SubmitTransactionFailureInvalidOrMissingPreviousProposals RemoveProperty(in JsonPropertyName name)
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
            }

            /// <inheritdoc />
            public SubmitTransactionFailureInvalidOrMissingPreviousProposals RemoveProperty(string name)
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
            }

            /// <inheritdoc />
            public SubmitTransactionFailureInvalidOrMissingPreviousProposals RemoveProperty(ReadOnlySpan<char> name)
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
            }

            /// <inheritdoc />
            public SubmitTransactionFailureInvalidOrMissingPreviousProposals RemoveProperty(ReadOnlySpan<byte> name)
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
            }

            /// <summary>
            /// Provides UTF8 and string versions of the JSON property names on the object.
            /// </summary>
            public static class JsonPropertyNames
            {
                /// <summary>
                /// Gets the JSON property name for <see cref="Code"/>.
                /// </summary>
                public const string Code = "code";

                /// <summary>
                /// Gets the JSON property name for <see cref="Data"/>.
                /// </summary>
                public const string Data = "data";

                /// <summary>
                /// Gets the JSON property name for <see cref="Message"/>.
                /// </summary>
                public const string Message = "message";

                /// <summary>
                /// Gets the JSON property name for <see cref="Code"/>.
                /// </summary>
                public static ReadOnlySpan<byte> CodeUtf8 => "code"u8;

                /// <summary>
                /// Gets the JSON property name for <see cref="Data"/>.
                /// </summary>
                public static ReadOnlySpan<byte> DataUtf8 => "data"u8;

                /// <summary>
                /// Gets the JSON property name for <see cref="Message"/>.
                /// </summary>
                public static ReadOnlySpan<byte> MessageUtf8 => "message"u8;
            }

            private static class __CorvusObjectHelpers
            {
                /// <summary>
                /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object.
                /// </summary>
                /// <returns>An immutable list of <see cref="JsonAny"/> built from the object.</returns>
                /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                public static ImmutableList<JsonObjectProperty> GetPropertyBacking(in SubmitTransactionFailureInvalidOrMissingPreviousProposals that)
                {
                    if ((that.backing & Backing.Object) != 0)
                    {
                        return that.objectBacking;
                    }

                    if ((that.backing & Backing.JsonElement) != 0)
                    {
                        return PropertyBackingBuilders.GetPropertyBackingBuilder(that.jsonElementBacking).ToImmutable();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
                /// </summary>
                /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, without the given property.</returns>
                /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in SubmitTransactionFailureInvalidOrMissingPreviousProposals that, in JsonPropertyName name)
                {
                    if ((that.backing & Backing.Object) != 0)
                    {
                        return that.objectBacking.Remove(name);
                    }

                    if ((that.backing & Backing.JsonElement) != 0)
                    {
                        return PropertyBackingBuilders.GetPropertyBackingBuilderWithout(that.jsonElementBacking, name).ToImmutable();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
                /// </summary>
                /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, without the given property.</returns>
                /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in SubmitTransactionFailureInvalidOrMissingPreviousProposals that, ReadOnlySpan<char> name)
                {
                    if ((that.backing & Backing.Object) != 0)
                    {
                        return that.objectBacking.Remove(name);
                    }

                    if ((that.backing & Backing.JsonElement) != 0)
                    {
                        return PropertyBackingBuilders.GetPropertyBackingBuilderWithout(that.jsonElementBacking, name).ToImmutable();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
                /// </summary>
                /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, without the given property.</returns>
                /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in SubmitTransactionFailureInvalidOrMissingPreviousProposals that, ReadOnlySpan<byte> name)
                {
                    if ((that.backing & Backing.Object) != 0)
                    {
                        return that.objectBacking.Remove(name);
                    }

                    if ((that.backing & Backing.JsonElement) != 0)
                    {
                        return PropertyBackingBuilders.GetPropertyBackingBuilderWithout(that.jsonElementBacking, name).ToImmutable();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
                /// </summary>
                /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, without the given property.</returns>
                /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in SubmitTransactionFailureInvalidOrMissingPreviousProposals that, string name)
                {
                    if ((that.backing & Backing.Object) != 0)
                    {
                        return that.objectBacking.Remove(name);
                    }

                    if ((that.backing & Backing.JsonElement) != 0)
                    {
                        return PropertyBackingBuilders.GetPropertyBackingBuilderWithout(that.jsonElementBacking, name).ToImmutable();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
                /// </summary>
                /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, with the given property.</returns>
                /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWith(in SubmitTransactionFailureInvalidOrMissingPreviousProposals that, in JsonPropertyName name, in JsonAny value)
                {
                    if ((that.backing & Backing.Object) != 0)
                    {
                        return that.objectBacking.SetItem(name, value);
                    }

                    if ((that.backing & Backing.JsonElement) != 0)
                    {
                        return PropertyBackingBuilders.GetPropertyBackingBuilderReplacing(that.jsonElementBacking, name, value).ToImmutable();
                    }

                    throw new InvalidOperationException();
                }
            }
        }
    }
}
