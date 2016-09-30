using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyValueProvider;

namespace KeyValueProviderTests
{
    [TestClass]
    public class KeyValueProviderTests
    {
        private KeyValueProviderFactory factory;

        [TestInitialize]
        public void Initialize()
        {
            this.factory = new KeyValueProviderFactory();
        }

        [TestMethod]
        public void KeyValueProviderCreatesFactory()
        {
            IKeyValueProvider provider = factory.CreateKeyValueProvider(3);

            Assert.IsNotNull(provider);
        }

        [TestMethod]
        public void StoresElement()
        {
            IKeyValueProvider provider = factory.CreateKeyValueProvider(3);

            var res = provider.Put("key", "val");

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void GetsElement()
        {
            IKeyValueProvider provider = factory.CreateKeyValueProvider(3);

            provider.Put("key", "val");

            string val;
            var res = provider.Get("key", out val);

            Assert.IsTrue(res);
            Assert.AreEqual("val", val);
        }

        [TestMethod]
        public void RemovesLRU()
        {
            IKeyValueProvider provider = factory.CreateKeyValueProvider(3);

            provider.Put("key1", "val1");
            provider.Put("key2", "val2");
            provider.Put("key3", "val3");
            provider.Put("key4", "val4");

            string val;
            var res = provider.Get("key1", out val);

            Assert.IsFalse(res);
            Assert.IsTrue(string.IsNullOrEmpty(val));
        }

        [TestMethod]
        public void UpdatesLRU()
        {
            IKeyValueProvider provider = factory.CreateKeyValueProvider(3);
            string val;

            provider.Put("key1", "val1");
            provider.Put("key2", "val2");
            provider.Put("key3", "val3");
            provider.Get("key1", out val);
            provider.Put("key4", "val4");

            var res = provider.Get("key1", out val);

            Assert.IsTrue(res);
            Assert.AreEqual("val1", val);
        }
    }
}
