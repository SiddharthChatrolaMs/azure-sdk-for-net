﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisCache.Tests
{
    public class TestsFixtureWithCacheCreate : TestBase, IDisposable
    {
        public string ResourceGroupName { set; get; }
        public string RedisCacheName = "hydracache1";
        public string Location = "North Central US";
        private RedisCacheManagementHelper _redisCacheManagementHelper;
        private MockContext _context=null;
        
        public TestsFixtureWithCacheCreate()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            _context = new MockContext();
            MockContext.Start(this.GetType().FullName, ".ctor");
            try
            {
                _redisCacheManagementHelper = new RedisCacheManagementHelper(this, _context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();

                ResourceGroupName = TestUtilities.GenerateName("hydra1");
                _redisCacheManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);
                _redisCacheManagementHelper.TryCreatingCache(ResourceGroupName, RedisCacheName, Location);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
            finally
            {
                HttpMockServer.Flush();
            }
        }

        public void Dispose()
        {
            Cleanup();    
        }

        private void Cleanup()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
                HttpMockServer.Initialize(this.GetType().FullName, ".cleanup");
            }
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(AzureRedisCache.Tests.TestsFixtureWithCacheCreate).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}
