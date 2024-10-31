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
        /// SubmitTransactionFailure<ExecutionUnitsTooLarge>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The transaction execution budget for scripts execution is above the allowed limit. The protocol limits the amount of execution that a single transaction can do. This limit is set by a protocol parameter. The field 'data.maximumExecutionUnits' indicates the current limit and the field 'data.providedExecutionUnits' indicates how much the transaction requires.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureExecutionUnitsTooLarge
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct RequiredMaximumExecutionUnitsAndProvidedExecutionUnits
                : IJsonObject<Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureExecutionUnitsTooLarge.RequiredMaximumExecutionUnitsAndProvidedExecutionUnits>
            {
                /// <summary>
                /// Conversion from <see cref="ImmutableList{JsonObjectProperty}"/>.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator RequiredMaximumExecutionUnitsAndProvidedExecutionUnits(ImmutableList<JsonObjectProperty> value)
                {
                    return new(value);
                }

                /// <summary>
                /// Conversion to <see cref="ImmutableList{JsonObjectProperty}"/>.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator ImmutableList<JsonObjectProperty>(RequiredMaximumExecutionUnitsAndProvidedExecutionUnits value)
                {
                    return
                        __CorvusObjectHelpers.GetPropertyBacking(value);
                }

                /// <summary>
                /// Conversion from JsonObject.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator RequiredMaximumExecutionUnitsAndProvidedExecutionUnits(JsonObject value)
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
                public static implicit operator JsonObject(RequiredMaximumExecutionUnitsAndProvidedExecutionUnits value)
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
                /// Gets the <c>maximumExecutionUnits</c> property.
                /// </summary>
                /// <remarks>
                /// <para>
                /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
                /// </para>
                /// </remarks>
                public Generated.ExecutionUnits MaximumExecutionUnits
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                            {
                                return default;
                            }

                            if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.MaximumExecutionUnitsUtf8, out JsonElement result))
                            {
                                return new(result);
                            }
                        }

                        if ((this.backing & Backing.Object) != 0)
                        {
                            if (this.objectBacking.TryGetValue(JsonPropertyNames.MaximumExecutionUnits, out JsonAny result))
                            {
                                return result.As<Generated.ExecutionUnits>();
                            }
                        }

                        return default;
                    }
                }

                /// <summary>
                /// Gets the <c>providedExecutionUnits</c> property.
                /// </summary>
                /// <remarks>
                /// <para>
                /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
                /// </para>
                /// </remarks>
                public Generated.ExecutionUnits ProvidedExecutionUnits
                {
                    get
                    {
                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                            {
                                return default;
                            }

                            if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.ProvidedExecutionUnitsUtf8, out JsonElement result))
                            {
                                return new(result);
                            }
                        }

                        if ((this.backing & Backing.Object) != 0)
                        {
                            if (this.objectBacking.TryGetValue(JsonPropertyNames.ProvidedExecutionUnits, out JsonAny result))
                            {
                                return result.As<Generated.ExecutionUnits>();
                            }
                        }

                        return default;
                    }
                }

                /// <inheritdoc/>
                public static RequiredMaximumExecutionUnitsAndProvidedExecutionUnits FromProperties(IDictionary<JsonPropertyName, JsonAny> source)
                {
                    return new(source.Select(kvp => new JsonObjectProperty(kvp.Key, kvp.Value)).ToImmutableList());
                }

                /// <inheritdoc/>
                public static RequiredMaximumExecutionUnitsAndProvidedExecutionUnits FromProperties(params (JsonPropertyName Name, JsonAny Value)[] source)
                {
                    return new(source.Select(s => new JsonObjectProperty(s.Name, s.Value.AsAny)).ToImmutableList());
                }

                /// <summary>
                /// Creates an instance of the type from the given immutable list of properties.
                /// </summary>
                /// <param name="source">The list of properties.</param>
                /// <returns>An instance of the type initialized from the list of properties.</returns>
                public static RequiredMaximumExecutionUnitsAndProvidedExecutionUnits FromProperties(ImmutableList<JsonObjectProperty> source)
                {
                    return new(source);
                }

                /// <summary>
                /// Creates an instance of a <see cref="RequiredMaximumExecutionUnitsAndProvidedExecutionUnits"/>.
                /// </summary>
                public static RequiredMaximumExecutionUnitsAndProvidedExecutionUnits Create(in Generated.ExecutionUnits maximumExecutionUnits, in Generated.ExecutionUnits providedExecutionUnits)
                {
                    var builder = ImmutableList.CreateBuilder<JsonObjectProperty>();
                    builder.Add(JsonPropertyNames.MaximumExecutionUnits, maximumExecutionUnits.AsAny);
                    builder.Add(JsonPropertyNames.ProvidedExecutionUnits, providedExecutionUnits.AsAny);

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
                public RequiredMaximumExecutionUnitsAndProvidedExecutionUnits SetProperty<TValue>(in JsonPropertyName name, TValue value)
                    where TValue : struct, IJsonValue
                {
                    return new(__CorvusObjectHelpers.GetPropertyBackingWith(this, name, value.AsAny));
                }

                /// <inheritdoc />
                public RequiredMaximumExecutionUnitsAndProvidedExecutionUnits RemoveProperty(in JsonPropertyName name)
                {
                    return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
                }

                /// <inheritdoc />
                public RequiredMaximumExecutionUnitsAndProvidedExecutionUnits RemoveProperty(string name)
                {
                    return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
                }

                /// <inheritdoc />
                public RequiredMaximumExecutionUnitsAndProvidedExecutionUnits RemoveProperty(ReadOnlySpan<char> name)
                {
                    return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
                }

                /// <inheritdoc />
                public RequiredMaximumExecutionUnitsAndProvidedExecutionUnits RemoveProperty(ReadOnlySpan<byte> name)
                {
                    return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
                }

                /// <summary>
                /// Provides UTF8 and string versions of the JSON property names on the object.
                /// </summary>
                public static class JsonPropertyNames
                {
                    /// <summary>
                    /// Gets the JSON property name for <see cref="MaximumExecutionUnits"/>.
                    /// </summary>
                    public const string MaximumExecutionUnits = "maximumExecutionUnits";

                    /// <summary>
                    /// Gets the JSON property name for <see cref="ProvidedExecutionUnits"/>.
                    /// </summary>
                    public const string ProvidedExecutionUnits = "providedExecutionUnits";

                    /// <summary>
                    /// Gets the JSON property name for <see cref="MaximumExecutionUnits"/>.
                    /// </summary>
                    public static ReadOnlySpan<byte> MaximumExecutionUnitsUtf8 => "maximumExecutionUnits"u8;

                    /// <summary>
                    /// Gets the JSON property name for <see cref="ProvidedExecutionUnits"/>.
                    /// </summary>
                    public static ReadOnlySpan<byte> ProvidedExecutionUnitsUtf8 => "providedExecutionUnits"u8;
                }

                private static class __CorvusObjectHelpers
                {
                    /// <summary>
                    /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object.
                    /// </summary>
                    /// <returns>An immutable list of <see cref="JsonAny"/> built from the object.</returns>
                    /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                    public static ImmutableList<JsonObjectProperty> GetPropertyBacking(in RequiredMaximumExecutionUnitsAndProvidedExecutionUnits that)
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
                    public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredMaximumExecutionUnitsAndProvidedExecutionUnits that, in JsonPropertyName name)
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
                    public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredMaximumExecutionUnitsAndProvidedExecutionUnits that, ReadOnlySpan<char> name)
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
                    public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredMaximumExecutionUnitsAndProvidedExecutionUnits that, ReadOnlySpan<byte> name)
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
                    public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredMaximumExecutionUnitsAndProvidedExecutionUnits that, string name)
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
                    public static ImmutableList<JsonObjectProperty> GetPropertyBackingWith(in RequiredMaximumExecutionUnitsAndProvidedExecutionUnits that, in JsonPropertyName name, in JsonAny value)
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
}
