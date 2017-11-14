// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Redis.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Response to put/get patch schedules for Redis cache.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class RedisPatchSchedule
    {
        /// <summary>
        /// Initializes a new instance of the RedisPatchSchedule class.
        /// </summary>
        public RedisPatchSchedule()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RedisPatchSchedule class.
        /// </summary>
        /// <param name="scheduleEntries">List of patch schedules for a Redis
        /// cache.</param>
        /// <param name="id">Resource ID.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="location">Resource location.</param>
        public RedisPatchSchedule(IList<ScheduleEntry> scheduleEntries, string id = default(string), string name = default(string), string type = default(string), string location = default(string))
        {
            Id = id;
            Name = name;
            Type = type;
            Location = location;
            ScheduleEntries = scheduleEntries;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets resource ID.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets resource name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets resource type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets resource location.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; private set; }

        /// <summary>
        /// Gets or sets list of patch schedules for a Redis cache.
        /// </summary>
        [JsonProperty(PropertyName = "properties.scheduleEntries")]
        public IList<ScheduleEntry> ScheduleEntries { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ScheduleEntries == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ScheduleEntries");
            }
            if (ScheduleEntries != null)
            {
                foreach (var element in ScheduleEntries)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
