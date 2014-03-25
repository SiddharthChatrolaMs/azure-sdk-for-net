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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management;

namespace Microsoft.WindowsAzure.Management
{
    /// <summary>
    /// The Service Management API provides programmatic access to much of the
    /// functionality available through the Management Portal. The Service
    /// Management API is a REST API. All API operations are performed over
    /// SSL and mutually authenticated using X.509 v3 certificates.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460799.aspx for
    /// more information)
    /// </summary>
    public partial class ManagementClient : ServiceClient<ManagementClient>, Microsoft.WindowsAzure.Management.IManagementClient
    {
        private Uri _baseUri;
        
        /// <summary>
        /// The URI used as the base for all Service Management requests.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
        }
        
        private SubscriptionCloudCredentials _credentials;
        
        /// <summary>
        /// When you create a Windows Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management
        /// API.  The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure.  No anonymous requests
        /// are allowed.
        /// </summary>
        public SubscriptionCloudCredentials Credentials
        {
            get { return this._credentials; }
        }
        
        private IAffinityGroupOperations _affinityGroups;
        
        /// <summary>
        /// Operations for managing affinity groups beneath your subscription.
        /// (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460798.aspx
        /// for more information)
        /// </summary>
        public virtual IAffinityGroupOperations AffinityGroups
        {
            get { return this._affinityGroups; }
        }
        
        private ILocationOperations _locations;
        
        /// <summary>
        /// The Service Management API includes operations for listing the
        /// available data center locations for a hosted service in your
        /// subscription.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/gg441299.aspx
        /// for more information)
        /// </summary>
        public virtual ILocationOperations Locations
        {
            get { return this._locations; }
        }
        
        private IManagementCertificateOperations _managementCertificates;
        
        /// <summary>
        /// You can use management certificates, which are also known as
        /// subscription certificates, to authenticate clients attempting to
        /// connect to resources associated with your Windows Azure
        /// subscription.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj154124.aspx
        /// for more information)
        /// </summary>
        public virtual IManagementCertificateOperations ManagementCertificates
        {
            get { return this._managementCertificates; }
        }
        
        private IRoleSizeOperations _roleSizes;
        
        /// <summary>
        /// The Service Management API includes operations for listing the
        /// available role sizes for VMs in your subscription.
        /// </summary>
        public virtual IRoleSizeOperations RoleSizes
        {
            get { return this._roleSizes; }
        }
        
        private ISubscriptionOperations _subscriptions;
        
        /// <summary>
        /// Operation for listing subscription operations and details.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/gg715315.aspx
        /// for more information)
        /// </summary>
        public virtual ISubscriptionOperations Subscriptions
        {
            get { return this._subscriptions; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ManagementClient class.
        /// </summary>
        private ManagementClient()
            : base()
        {
            this._affinityGroups = new AffinityGroupOperations(this);
            this._locations = new LocationOperations(this);
            this._managementCertificates = new ManagementCertificateOperations(this);
            this._roleSizes = new RoleSizeOperations(this);
            this._subscriptions = new SubscriptionOperations(this);
            this.HttpClient.Timeout = TimeSpan.FromSeconds(300);
        }
        
        /// <summary>
        /// Initializes a new instance of the ManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. When you create a Windows Azure subscription, it is
        /// uniquely identified by a subscription ID. The subscription ID
        /// forms part of the URI for every call that you make to the Service
        /// Management API.  The Windows Azure Service ManagementAPI use
        /// mutual authentication of management certificates over SSL to
        /// ensure that a request made to the service is secure.  No anonymous
        /// requests are allowed.
        /// </param>
        /// <param name='baseUri'>
        /// Required. The URI used as the base for all Service Management
        /// requests.
        /// </param>
        public ManagementClient(SubscriptionCloudCredentials credentials, Uri baseUri)
            : this()
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._credentials = credentials;
            this._baseUri = baseUri;
            
            this.Credentials.InitializeServiceClient(this);
        }
        
        /// <summary>
        /// Initializes a new instance of the ManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. When you create a Windows Azure subscription, it is
        /// uniquely identified by a subscription ID. The subscription ID
        /// forms part of the URI for every call that you make to the Service
        /// Management API.  The Windows Azure Service ManagementAPI use
        /// mutual authentication of management certificates over SSL to
        /// ensure that a request made to the service is secure.  No anonymous
        /// requests are allowed.
        /// </param>
        public ManagementClient(SubscriptionCloudCredentials credentials)
            : this()
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            this._baseUri = new Uri("https://management.core.windows.net");
            
            this.Credentials.InitializeServiceClient(this);
        }
        
        /// <summary>
        /// The Get Operation Status operation returns the status of
        /// thespecified operation. After calling an asynchronous operation,
        /// you can call Get Operation Status to determine whether the
        /// operation has succeeded, failed, or is still in progress.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460783.aspx
        /// for more information)
        /// </summary>
        /// <param name='requestId'>
        /// Required. The request ID for the request you wish to track. The
        /// request ID is returned in the x-ms-request-id response header for
        /// every request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationStatusResponse> GetOperationStatusAsync(string requestId, CancellationToken cancellationToken)
        {
            // Validate
            if (requestId == null)
            {
                throw new ArgumentNullException("requestId");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("requestId", requestId);
                Tracing.Enter(invocationId, this, "GetOperationStatusAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.BaseUri.AbsoluteUri;
            string url = "/" + this.Credentials.SubscriptionId + "/operations/" + requestId;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-03-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    OperationStatusResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new OperationStatusResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement operationElement = responseDoc.Element(XName.Get("Operation", "http://schemas.microsoft.com/windowsazure"));
                    if (operationElement != null && operationElement.IsEmpty == false)
                    {
                        XElement idElement = operationElement.Element(XName.Get("ID", "http://schemas.microsoft.com/windowsazure"));
                        if (idElement != null && idElement.IsEmpty == false)
                        {
                            string idInstance = idElement.Value;
                            result.Id = idInstance;
                        }
                        
                        XElement statusElement = operationElement.Element(XName.Get("Status", "http://schemas.microsoft.com/windowsazure"));
                        if (statusElement != null && statusElement.IsEmpty == false)
                        {
                            OperationStatus statusInstance = ((OperationStatus)Enum.Parse(typeof(OperationStatus), statusElement.Value, true));
                            result.Status = statusInstance;
                        }
                        
                        XElement httpStatusCodeElement = operationElement.Element(XName.Get("HttpStatusCode", "http://schemas.microsoft.com/windowsazure"));
                        if (httpStatusCodeElement != null && httpStatusCodeElement.IsEmpty == false)
                        {
                            HttpStatusCode httpStatusCodeInstance = ((HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), httpStatusCodeElement.Value, true));
                            result.HttpStatusCode = httpStatusCodeInstance;
                        }
                        
                        XElement errorElement = operationElement.Element(XName.Get("Error", "http://schemas.microsoft.com/windowsazure"));
                        if (errorElement != null && errorElement.IsEmpty == false)
                        {
                            OperationStatusResponse.ErrorDetails errorInstance = new OperationStatusResponse.ErrorDetails();
                            result.Error = errorInstance;
                            
                            XElement codeElement = errorElement.Element(XName.Get("Code", "http://schemas.microsoft.com/windowsazure"));
                            if (codeElement != null && codeElement.IsEmpty == false)
                            {
                                string codeInstance = codeElement.Value;
                                errorInstance.Code = codeInstance;
                            }
                            
                            XElement messageElement = errorElement.Element(XName.Get("Message", "http://schemas.microsoft.com/windowsazure"));
                            if (messageElement != null && messageElement.IsEmpty == false)
                            {
                                string messageInstance = messageElement.Value;
                                errorInstance.Message = messageInstance;
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
