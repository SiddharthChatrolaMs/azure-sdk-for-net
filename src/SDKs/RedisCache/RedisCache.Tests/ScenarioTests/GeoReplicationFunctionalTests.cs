// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;
using System.Collections.Generic;

namespace AzureRedisCache.Tests
{
    public class GeoReplicationFunctionalTests : TestBase
    {
        [Fact]
        public void GeoReplicationFunctionalTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourceGroupName = TestUtilities.GenerateName("RedisGeo");
                var redisCacheName1 = TestUtilities.GenerateName("RedisGeo1");
                var redisCacheName2 = TestUtilities.GenerateName("RedisGeo2");

                var _redisCacheManagementHelper = new RedisCacheManagementHelper(this, context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();
                _redisCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, RedisCacheManagementHelper.Location);

                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                // Create cache in ncus
                RedisResource ncResponse = _client.Redis.BeginCreate(resourceGroupName, redisCacheName1,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = RedisCacheManagementHelper.Location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            }
                                        });

                Assert.Contains(redisCacheName1, ncResponse.Id);
                Assert.Equal(redisCacheName1, ncResponse.Name);
                Assert.Equal("creating", ncResponse.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Premium, ncResponse.Sku.Name);
                Assert.Equal(SkuFamily.P, ncResponse.Sku.Family);

                // Create cache in scus
                RedisResource scResponse = _client.Redis.BeginCreate(resourceGroupName, redisCacheName2,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = RedisCacheManagementHelper.SecondaryLocation,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            }
                                        });

                Assert.Contains(redisCacheName2, scResponse.Id);
                Assert.Equal(redisCacheName2, scResponse.Name);
                Assert.Equal("creating", scResponse.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Premium, scResponse.Sku.Name);
                Assert.Equal(SkuFamily.P, scResponse.Sku.Family);

                // Wait for both cache creation to comeplete
                for (int i = 0; i < 60; i++)
                {
                    ncResponse = _client.Redis.Get(resourceGroupName, redisCacheName1);
                    scResponse = _client.Redis.Get(resourceGroupName, redisCacheName2);
                    if ("succeeded".Equals(ncResponse.ProvisioningState, StringComparison.OrdinalIgnoreCase) &&
                        "succeeded".Equals(scResponse.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                }

                // Fail if any of 2 cache is not created successfully
                Assert.Equal("succeeded", ncResponse.ProvisioningState, ignoreCase: true);
                Assert.Equal("succeeded", scResponse.ProvisioningState, ignoreCase: true);

                string linkName = "nctosclink";
                // Set up replication link
                RedisLinkedServerWithProperties linkServerWithProperties = _client.RedisLinkedServer.Create(resourceGroupName, redisCacheName1, linkName, new RedisLinkedServerCreateParameters
                                                    {
                                                        LinkedRedisCacheId = scResponse.Id,
                                                        LinkedRedisCacheLocation = RedisCacheManagementHelper.SecondaryLocation,
                                                        ServerRole = ReplicationRole.Secondary
                                                    });

                Assert.Equal(linkName, linkServerWithProperties.Name);
                Assert.Equal(scResponse.Id, linkServerWithProperties.LinkedRedisCacheId);
                Assert.Equal(RedisCacheManagementHelper.SecondaryLocation, linkServerWithProperties.LinkedRedisCacheLocation);
                Assert.Equal(ReplicationRole.Secondary, linkServerWithProperties.ServerRole);
                Assert.Equal("succeeded", linkServerWithProperties.ProvisioningState, ignoreCase: true);

                // test get response from primary
                RedisLinkedServerWithProperties primaryLinkProperties = _client.RedisLinkedServer.Get(resourceGroupName, redisCacheName1, linkName);
                Assert.Equal(scResponse.Id, primaryLinkProperties.LinkedRedisCacheId);
                Assert.Equal(RedisCacheManagementHelper.SecondaryLocation, primaryLinkProperties.LinkedRedisCacheLocation);
                Assert.Equal(ReplicationRole.Secondary, primaryLinkProperties.ServerRole);

                // test list response from primary
                IList<RedisLinkedServerWithProperties> allPrimaryLinkProperties = _client.RedisLinkedServer.List(resourceGroupName, redisCacheName1);
                Assert.Equal(1, allPrimaryLinkProperties.Count);
                
                // test get response from secondary
                RedisLinkedServerWithProperties secondaryLinkProperties = _client.RedisLinkedServer.Get(resourceGroupName, redisCacheName2, linkName);
                Assert.Equal(ncResponse.Id, secondaryLinkProperties.LinkedRedisCacheId);
                Assert.Equal(RedisCacheManagementHelper.Location, secondaryLinkProperties.LinkedRedisCacheLocation);
                Assert.Equal(ReplicationRole.Primary, secondaryLinkProperties.ServerRole);

                // test list response from secondary
                IList<RedisLinkedServerWithProperties> allSecondaryLinkProperties = _client.RedisLinkedServer.List(resourceGroupName, redisCacheName2);
                Assert.Equal(1, allSecondaryLinkProperties.Count);

                // Delete link on primary
                _client.RedisLinkedServer.Delete(resourceGroupName, redisCacheName1, linkName);

                // Clean up both caches and delete resource group
                _client.Redis.Delete(resourceGroupName: resourceGroupName, name: redisCacheName1);
                _client.Redis.Delete(resourceGroupName: resourceGroupName, name: redisCacheName2);
                _redisCacheManagementHelper.DeleteResourceGroup(resourceGroupName);
            }
        }
    }
}
