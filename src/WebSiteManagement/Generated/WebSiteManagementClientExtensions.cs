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
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// The Windows Azure Web Sites management API provides a RESTful set of
    /// web services that interact with Windows Azure Web Sites service to
    /// manage your web sites. The API has entities that capture the
    /// relationship between an end user and the Windows Azure Web Sites
    /// service.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/dn166981.aspx for
    /// more information)
    /// </summary>
    public static partial class WebSiteManagementClientExtensions
    {
        /// <summary>
        /// The Get Operation Status operation returns the status of
        /// thespecified operation. After calling a long-running operation,
        /// you can call Get Operation Status to determine whether the
        /// operation has succeeded, failed, timed out, or is still in
        /// progress.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460783.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.WebSites.IWebSiteManagementClient.
        /// </param>
        /// <param name='webSpaceName'>
        /// Required. The name of the webspace for the website where the
        /// operation was targeted.
        /// </param>
        /// <param name='siteName'>
        /// Required. The name of the site where the operation was targeted.
        /// </param>
        /// <param name='operationId'>
        /// Required. The operation ID for the operation you wish to track. The
        /// operation ID is returned in the Id field in the body of the
        /// response for long-running operations.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified long-running
        /// operation, indicating whether it has succeeded, is inprogress, has
        /// time dout, or has failed. Note that this status is distinct from
        /// the HTTP status code returned for the Get Operation Status
        /// operation itself.  If the long-running operation failed, the
        /// response body includes error information regarding the failure.
        /// </returns>
        public static WebSiteOperationStatusResponse GetOperationStatus(this IWebSiteManagementClient operations, string webSpaceName, string siteName, string operationId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IWebSiteManagementClient)s).GetOperationStatusAsync(webSpaceName, siteName, operationId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// The Get Operation Status operation returns the status of
        /// thespecified operation. After calling a long-running operation,
        /// you can call Get Operation Status to determine whether the
        /// operation has succeeded, failed, timed out, or is still in
        /// progress.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460783.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.WebSites.IWebSiteManagementClient.
        /// </param>
        /// <param name='webSpaceName'>
        /// Required. The name of the webspace for the website where the
        /// operation was targeted.
        /// </param>
        /// <param name='siteName'>
        /// Required. The name of the site where the operation was targeted.
        /// </param>
        /// <param name='operationId'>
        /// Required. The operation ID for the operation you wish to track. The
        /// operation ID is returned in the Id field in the body of the
        /// response for long-running operations.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified long-running
        /// operation, indicating whether it has succeeded, is inprogress, has
        /// time dout, or has failed. Note that this status is distinct from
        /// the HTTP status code returned for the Get Operation Status
        /// operation itself.  If the long-running operation failed, the
        /// response body includes error information regarding the failure.
        /// </returns>
        public static Task<WebSiteOperationStatusResponse> GetOperationStatusAsync(this IWebSiteManagementClient operations, string webSpaceName, string siteName, string operationId)
        {
            return operations.GetOperationStatusAsync(webSpaceName, siteName, operationId, CancellationToken.None);
        }
        
        /// <summary>
        /// Register your subscription to use Windows Azure Web Sites.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.WebSites.IWebSiteManagementClient.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static OperationResponse RegisterSubscription(this IWebSiteManagementClient operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IWebSiteManagementClient)s).RegisterSubscriptionAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Register your subscription to use Windows Azure Web Sites.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.WebSites.IWebSiteManagementClient.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<OperationResponse> RegisterSubscriptionAsync(this IWebSiteManagementClient operations)
        {
            return operations.RegisterSubscriptionAsync(CancellationToken.None);
        }
        
        /// <summary>
        /// Unregister your subscription to use Windows Azure Web Sites.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.WebSites.IWebSiteManagementClient.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static OperationResponse UnregisterSubscription(this IWebSiteManagementClient operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IWebSiteManagementClient)s).UnregisterSubscriptionAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Unregister your subscription to use Windows Azure Web Sites.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.WebSites.IWebSiteManagementClient.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<OperationResponse> UnregisterSubscriptionAsync(this IWebSiteManagementClient operations)
        {
            return operations.UnregisterSubscriptionAsync(CancellationToken.None);
        }
    }
}
