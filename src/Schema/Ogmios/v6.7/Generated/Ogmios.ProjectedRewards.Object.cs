//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
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
    /// <remarks>
    /// <para>
    /// Rewards that can be expected assuming a pool is fully saturated. Such rewards are said non-myopic, in opposition to short-sighted rewards looking at immediate benefits. Keys of the map can be either Lovelace amounts or account credentials depending on the query.
    /// </para>
    /// </remarks>
    public readonly partial struct ProjectedRewards
        : IJsonObject<Generated.Ogmios.ProjectedRewards>,
          IReadOnlyDictionary<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>
    {
        /// <summary>
        /// Conversion from <see cref="ImmutableList{JsonObjectProperty}"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator ProjectedRewards(ImmutableList<JsonObjectProperty> value)
        {
            return new(value);
        }

        /// <summary>
        /// Conversion to <see cref="ImmutableList{JsonObjectProperty}"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator ImmutableList<JsonObjectProperty>(ProjectedRewards value)
        {
            return
                __CorvusObjectHelpers.GetPropertyBacking(value);
        }

        /// <summary>
        /// Conversion from JsonObject.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator ProjectedRewards(JsonObject value)
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
        public static implicit operator JsonObject(ProjectedRewards value)
        {
            return
                value.AsObject;
        }

        /// <inheritdoc/>
        JsonAny IJsonObject<ProjectedRewards>.this[in JsonPropertyName name]
        {
            get
            {
                if (this.TryGetProperty(name, out Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity result))
                {
                    return result;
                }

                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets the property with the given name.
        /// </summary>
        /// <param name="name">The name of the property to retrieve.</param>
        /// <returns>The value of the property with the given name.</returns>
        /// <exception cref="IndexOutOfRangeException">The given property was not present on the object.</exception>
        /// <exception cref="InvalidOperationException">The value is not an object.</exception>
        public Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity this[in JsonPropertyName name]
        {
            get
            {
                if (this.TryGetProperty(name, out Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity result))
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

        /// <inheritdoc/>
        Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity IReadOnlyDictionary<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>.this[JsonPropertyName key] => this[key];

        /// <inheritdoc/>
        IEnumerable<JsonPropertyName> IReadOnlyDictionary<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>.Keys
        {
            get
            {
                foreach(var property in this.EnumerateObject())
                {
                    yield return property.Name;
                }
            }
        }

        /// <inheritdoc/>
        IEnumerable<Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity> IReadOnlyDictionary<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>.Values
        {
            get
            {
                foreach(var property in this.EnumerateObject())
                {
                    yield return property.Value;
                }
            }
        }

        /// <inheritdoc/>
        int IReadOnlyCollection<KeyValuePair<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>>.Count => this.Count;

#if NET8_0_OR_GREATER
        /// <inheritdoc/>
        static ProjectedRewards IJsonObject<ProjectedRewards>.FromProperties(IDictionary<JsonPropertyName, JsonAny> source)
        {
            return new(source.Select(kvp => new JsonObjectProperty(kvp.Key, kvp.Value)).ToImmutableList());
        }

        /// <inheritdoc/>
        static ProjectedRewards IJsonObject<ProjectedRewards>.FromProperties(params (JsonPropertyName Name, JsonAny Value)[] source)
        {
            return new(source.Select(s => new JsonObjectProperty(s.Name, s.Value)).ToImmutableList());
        }
#endif

        /// <summary>
        /// Creates an instance of the type from the given dictionary of properties.
        /// </summary>
        /// <param name="source">The dictionary of properties.</param>
        /// <returns>An instance of the type initialized from the dictionary of properties.</returns>
        public static ProjectedRewards FromProperties(IDictionary<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity> source)
        {
            return new(source.Select(kvp => new JsonObjectProperty(kvp.Key, kvp.Value.AsAny)).ToImmutableList());
        }

        /// <summary>
        /// Creates an instance of the type from the given name/value tuples.
        /// </summary>
        /// <param name="source">The name value tuples.</param>
        /// <returns>An instance of the type initialized from the properties.</returns>
        public static ProjectedRewards FromProperties(params (JsonPropertyName Name, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity Value)[] source)
        {
            return new(source.Select(s => new JsonObjectProperty(s.Name, s.Value.AsAny)).ToImmutableList());
        }

        /// <summary>
        /// Creates an instance of the type from the given immutable list of properties.
        /// </summary>
        /// <param name="source">The list of properties.</param>
        /// <returns>An instance of the type initialized from the list of properties.</returns>
        public static ProjectedRewards FromProperties(ImmutableList<JsonObjectProperty> source)
        {
            return new(source);
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
        JsonObjectEnumerator IJsonObject<ProjectedRewards>.EnumerateObject()
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

        /// <summary>
        /// Enumerate the object.
        /// </summary>
        /// <returns>An enumerator for the object.</returns>
        /// <exception cref="InvalidOperationException">The value is not an object.</exception>
        public JsonObjectEnumerator<Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity> EnumerateObject()
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
        IEnumerator<KeyValuePair<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>> IEnumerable<KeyValuePair<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>>.GetEnumerator()
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return new ReadOnlyDictionaryJsonObjectEnumerator<Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>(this.jsonElementBacking);
            }

            if ((this.backing & Backing.Object) != 0)
            {
                return new ReadOnlyDictionaryJsonObjectEnumerator<Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>(this.objectBacking);
            }

            throw new InvalidOperationException();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.EnumerateObject();

        bool IReadOnlyDictionary<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>.ContainsKey(JsonPropertyName key) => this.HasProperty(key);

        bool IReadOnlyDictionary<JsonPropertyName, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity>.TryGetValue(JsonPropertyName key, out Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity result) => this.TryGetProperty(key, out result);

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

        /// <inheritdoc />
        bool IJsonObject<ProjectedRewards>.TryGetProperty(in JsonPropertyName name, out JsonAny value)
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
        public bool TryGetProperty(in JsonPropertyName name, out Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity value)
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
                    value = Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity.FromAny(result);
                    return true;
                }

                value = default;
                return false;
            }

            throw new InvalidOperationException();
        }

        /// <inheritdoc />
        bool IJsonObject<ProjectedRewards>.TryGetProperty(string name, out JsonAny value)
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
        public bool TryGetProperty(string name, out Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity value)
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
                    value = Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity.FromAny(result);
                    return true;
                }

                value = default;
                return false;
            }

            throw new InvalidOperationException();
        }

        /// <inheritdoc />
        bool IJsonObject<ProjectedRewards>.TryGetProperty(ReadOnlySpan<char> name, out JsonAny value)
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
        public bool TryGetProperty(ReadOnlySpan<char> name, out Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity value)
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
                    value = Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity.FromAny(result);
                    return true;
                }

                value = default;
                return false;
            }

            throw new InvalidOperationException();
        }

        /// <inheritdoc />
        bool IJsonObject<ProjectedRewards>.TryGetProperty(ReadOnlySpan<byte> name, out JsonAny value)
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
        public bool TryGetProperty(ReadOnlySpan<byte> name, out Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity value)
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
                    value = Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity.FromAny(result);
                    return true;
                }

                value = default;
                return false;
            }

            throw new InvalidOperationException();
        }

        /// <inheritdoc />
        bool IJsonObject<ProjectedRewards>.TryGetProperty<TValue>(in JsonPropertyName name, out TValue value)
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
        bool IJsonObject<ProjectedRewards>.TryGetProperty<TValue>(string name, out TValue value)
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
        bool IJsonObject<ProjectedRewards>.TryGetProperty<TValue>(ReadOnlySpan<char> name, out TValue value)
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
        bool IJsonObject<ProjectedRewards>.TryGetProperty<TValue>(ReadOnlySpan<byte> name, out TValue value)
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
ProjectedRewards IJsonObject<ProjectedRewards>.SetProperty<TValue>(in JsonPropertyName name, TValue value)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWith(this, name, value.AsAny));
        }

        /// <summary>
        /// Sets the given property value.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        /// <returns>The instance with the property set.</returns>
        public ProjectedRewards SetProperty(in JsonPropertyName name, Generated.Ogmios.ProjectedRewards.AdditionalPropertiesEntity value)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWith(this, name, value.AsAny));
        }

        /// <inheritdoc />
        public ProjectedRewards RemoveProperty(in JsonPropertyName name)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
        }

        /// <inheritdoc />
        public ProjectedRewards RemoveProperty(string name)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
        }

        /// <inheritdoc />
        public ProjectedRewards RemoveProperty(ReadOnlySpan<char> name)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
        }

        /// <inheritdoc />
        public ProjectedRewards RemoveProperty(ReadOnlySpan<byte> name)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
        }

        private static class __CorvusObjectHelpers
        {
            /// <summary>
            /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object.
            /// </summary>
            /// <returns>An immutable list of <see cref="JsonAny"/> built from the object.</returns>
            /// <exception cref="InvalidOperationException">The value is not an object.</exception>
            public static ImmutableList<JsonObjectProperty> GetPropertyBacking(in ProjectedRewards that)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in ProjectedRewards that, in JsonPropertyName name)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in ProjectedRewards that, ReadOnlySpan<char> name)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in ProjectedRewards that, ReadOnlySpan<byte> name)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in ProjectedRewards that, string name)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWith(in ProjectedRewards that, in JsonPropertyName name, in JsonAny value)
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
