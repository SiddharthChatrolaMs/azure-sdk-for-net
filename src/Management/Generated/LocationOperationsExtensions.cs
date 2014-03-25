// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Models;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// The Service Management API provides programmatic access to much of the
    /// functionality available through the Management Portal. The Service
    /// Management API is a REST API. All API operations are performed over
    /// SSL and mutually authenticated using X.509 v3 certificates.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460799.aspx for
    /// more information)
    /// </summary>
    public static partial class LocationOperationsExtensions
    {
        /// <summary>
        /// The List Locations operation lists all of the data center locations
        /// that are valid for your subscription.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/gg441293.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ILocationOperations.
        /// </param>
        /// <returns>
        /// The List Locations operation response.
        /// </returns>
        public static LocationsListResponse List(this ILocationOperations operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ILocationOperations)s).ListAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// The List Locations operation lists all of the data center locations
        /// that are valid for your subscription.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/gg441293.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ILocationOperations.
        /// </param>
        /// <returns>
        /// The List Locations operation response.
        /// </returns>
        public static Task<LocationsListResponse> ListAsync(this ILocationOperations operations)
        {
            return operations.ListAsync(CancellationToken.None);
        }
    }
}
