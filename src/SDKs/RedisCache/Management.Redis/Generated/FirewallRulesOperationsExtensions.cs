// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Redis
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for FirewallRulesOperations.
    /// </summary>
    public static partial class FirewallRulesOperationsExtensions
    {
            /// <summary>
            /// Gets all firewall rules in the specified redis cache.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cacheName'>
            /// The name of the Redis cache.
            /// </param>
            public static IPage<RedisFirewallRule> ListByRedisResource(this IFirewallRulesOperations operations, string resourceGroupName, string cacheName)
            {
                return operations.ListByRedisResourceAsync(resourceGroupName, cacheName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all firewall rules in the specified redis cache.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cacheName'>
            /// The name of the Redis cache.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<RedisFirewallRule>> ListByRedisResourceAsync(this IFirewallRulesOperations operations, string resourceGroupName, string cacheName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByRedisResourceWithHttpMessagesAsync(resourceGroupName, cacheName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Create or update a redis cache firewall rule
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cacheName'>
            /// The name of the Redis cache.
            /// </param>
            /// <param name='ruleName'>
            /// The name of the firewall rule.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update redis firewall rule operation.
            /// </param>
            public static RedisFirewallRule CreateOrUpdate(this IFirewallRulesOperations operations, string resourceGroupName, string cacheName, string ruleName, RedisFirewallRule parameters)
            {
                return operations.CreateOrUpdateAsync(resourceGroupName, cacheName, ruleName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create or update a redis cache firewall rule
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cacheName'>
            /// The name of the Redis cache.
            /// </param>
            /// <param name='ruleName'>
            /// The name of the firewall rule.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update redis firewall rule operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RedisFirewallRule> CreateOrUpdateAsync(this IFirewallRulesOperations operations, string resourceGroupName, string cacheName, string ruleName, RedisFirewallRule parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, cacheName, ruleName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a single firewall rule in a specified redis cache.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cacheName'>
            /// The name of the Redis cache.
            /// </param>
            /// <param name='ruleName'>
            /// The name of the firewall rule.
            /// </param>
            public static RedisFirewallRule Get(this IFirewallRulesOperations operations, string resourceGroupName, string cacheName, string ruleName)
            {
                return operations.GetAsync(resourceGroupName, cacheName, ruleName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a single firewall rule in a specified redis cache.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cacheName'>
            /// The name of the Redis cache.
            /// </param>
            /// <param name='ruleName'>
            /// The name of the firewall rule.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RedisFirewallRule> GetAsync(this IFirewallRulesOperations operations, string resourceGroupName, string cacheName, string ruleName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, cacheName, ruleName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a single firewall rule in a specified redis cache.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cacheName'>
            /// The name of the Redis cache.
            /// </param>
            /// <param name='ruleName'>
            /// The name of the firewall rule.
            /// </param>
            public static void Delete(this IFirewallRulesOperations operations, string resourceGroupName, string cacheName, string ruleName)
            {
                operations.DeleteAsync(resourceGroupName, cacheName, ruleName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a single firewall rule in a specified redis cache.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cacheName'>
            /// The name of the Redis cache.
            /// </param>
            /// <param name='ruleName'>
            /// The name of the firewall rule.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IFirewallRulesOperations operations, string resourceGroupName, string cacheName, string ruleName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, cacheName, ruleName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets all firewall rules in the specified redis cache.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<RedisFirewallRule> ListByRedisResourceNext(this IFirewallRulesOperations operations, string nextPageLink)
            {
                return operations.ListByRedisResourceNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all firewall rules in the specified redis cache.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<RedisFirewallRule>> ListByRedisResourceNextAsync(this IFirewallRulesOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByRedisResourceNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}