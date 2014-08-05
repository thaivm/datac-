using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ConfigValueTest and is intended
    ///to contain all ConfigValueTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConfigValueTest
    {
        /// <summary>
        /// GetCCSHeader is expected to return properly value
        ///</summary>
        [TestMethod()]
        public void GetCCSHeaderTest_1()
        {
            List<string> expected = new List<string>();
            expected.Add(ConfigValue.CCSHeader.HEADER_LINE);
            expected.Add(ConfigValue.CCSHeader.HEADER_DATE);
            expected.Add(ConfigValue.CCSHeader.HEADER_TIME);
            expected.Add(ConfigValue.CCSHeader.HEADER_HOSTNAME);
            expected.Add(ConfigValue.CCSHeader.HEADER_THREADID);
            expected.Add(ConfigValue.CCSHeader.HEADER_TYPE);
            expected.Add(ConfigValue.CCSHeader.HEADER_ID);
            expected.Add(ConfigValue.CCSHeader.HEADER_CONTENT);
            expected.Add(ConfigValue.CCSHeader.HEADER_ADDITIONINFO);
            expected.Add(ConfigValue.CCSHeader.HEADER_PERSONALINFO);
            expected.Add(ConfigValue.CCSHeader.HEADER_CLASSNAME);
            expected.Add(ConfigValue.CCSHeader.HEADER_COMMENT);

            List<string> actual = ConfigValue.CCSHeader.AllLogField;
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// GetCXDIHeader is expected to return properly value
        ///</summary>
        [TestMethod()]
        public void GetCXDIHeaderTest_1()
        {
            List<string> cxdiHeader = new List<string>();
            cxdiHeader.Add(ConfigValue.CXDIHeader.HEADER_LINE);
            cxdiHeader.Add(ConfigValue.CXDIHeader.HEADER_DATE);
            cxdiHeader.Add(ConfigValue.CXDIHeader.HEADER_TIME);
            cxdiHeader.Add(ConfigValue.CXDIHeader.HEADER_MESSAGE);
            cxdiHeader.Add(ConfigValue.CXDIHeader.HEADER_MODULE);
            cxdiHeader.Add(ConfigValue.CXDIHeader.HEADER_COMMENT);
        }
    }
}
