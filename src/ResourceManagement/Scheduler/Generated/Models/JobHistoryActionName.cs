// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Scheduler.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Scheduler;
    using Microsoft.Azure.Management.Scheduler.Fluent;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for JobHistoryActionName.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobHistoryActionName
    {
        [EnumMember(Value = "MainAction")]
        MainAction,
        [EnumMember(Value = "ErrorAction")]
        ErrorAction
    }
    internal static class JobHistoryActionNameEnumExtension
    {
        internal static string ToSerializedValue(this JobHistoryActionName? value)  =>
            value == null ? null : ((JobHistoryActionName)value).ToSerializedValue();

        internal static string ToSerializedValue(this JobHistoryActionName value)
        {
            switch( value )
            {
                case JobHistoryActionName.MainAction:
                    return "MainAction";
                case JobHistoryActionName.ErrorAction:
                    return "ErrorAction";
            }
            return null;
        }

        internal static JobHistoryActionName? ParseJobHistoryActionName(this string value)
        {
            switch( value )
            {
                case "MainAction":
                    return JobHistoryActionName.MainAction;
                case "ErrorAction":
                    return JobHistoryActionName.ErrorAction;
            }
            return null;
        }
    }
}