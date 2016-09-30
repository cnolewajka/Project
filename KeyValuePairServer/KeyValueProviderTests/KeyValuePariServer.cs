using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyValueProvider;
using NMock;

namespace KeyValueProviderTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class KeyValuePairServerTests
    {
        MockFactory mockFactory = new MockFactory();
        Mock<IKeyValueProvider> providerMock;

        [TestInitialize]
        public void Initialize()
        {
            providerMock = this.mockFactory.CreateMock<IKeyValueProvider>();
        }

        [TestMethod]
        public void CreatesAndInitializesServer()
        {
            KeyValuePairServer server = new KeyValuePairServer();
            server.Initialize(4);

            Assert.IsNotNull(server);
        }

        [TestMethod]
        public void PutCallsProvider()
        {
            KeyValuePairServer server = new KeyValuePairServer();
            server.Initialize(providerMock.MockObject);

            providerMock.Expects.One.MethodWith(p => p.Put("key", "value")).WillReturn(true);

            var res = server.Execute("PUT\nkey\nvalue\n");

            Assert.AreEqual("OK\n", res);
            mockFactory.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void PutCallsProvider_WrongSyntax_ReturnsFail()
        {
            KeyValuePairServer server = new KeyValuePairServer();
            server.Initialize(providerMock.MockObject);

            var res = server.Execute("PUT\nkey");

            Assert.AreEqual("FAIL\n", res);
        }

        [TestMethod]
        public void GetCallsProvider()
        {
            KeyValuePairServer server = new KeyValuePairServer();
            server.Initialize(providerMock.MockObject);

            string val = "value";
            providerMock.Expects.One.Method(p => p.Get("key", out val)).With("key", Is.Out).Will(Return.OutValue("value", val), Return.Value(true));

            var res = server.Execute("GET\nkey\n");

            Assert.AreEqual("value\n", res);
            mockFactory.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void GetCallsProvider_KeyNotPresent_ReturnsEmpty()
        {
            KeyValuePairServer server = new KeyValuePairServer();
            server.Initialize(providerMock.MockObject);

            string val = "";
            providerMock.Expects.One.Method(p => p.Get("key", out val)).With("key", Is.Out).Will(Return.OutValue("value", val), Return.Value(false));

            var res = server.Execute("GET\nkey\n");

            Assert.AreEqual("\n", res);
            mockFactory.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void GetCallsProvider_WrongSyntax_ReturnsFail()
        {
            KeyValuePairServer server = new KeyValuePairServer();
            server.Initialize(providerMock.MockObject);

            var res = server.Execute("GET");

            Assert.AreEqual("FAIL\n", res);
        }
    }
}
