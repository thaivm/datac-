using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows.Documents;
using LogViewer.Business;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business
{
    /// <summary>
    ///This is a test class for CXDILogsAnalyserTest and is intended
    ///to contain all CXDILogsAnalyserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CXDILogsAnalyserTest
    {
        #region SearchKeyword Test Cases

        /// <summary>
        /// SearchKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _searchedItem - searching all item which has header message "Message1"
        /// expected result: 
        ///     SearchKeywordBuffer has only one item is _record1
        ///</summary>
        [TestMethod()]
        public void SearchKeywordTest_1()
        {
            // prepare data for _allLogRecordsBuffer
            var _record1 = new CXDILogRecord();
            _record1.Module = "Module1";
            _record1.Message = "Message1";
            var _record2 = new CXDILogRecord();
            _record2.Module = "Module2";
            _record2.Message = " ";
            var _record3 = new CXDILogRecord();
            _record3.Module = "Module3";
            _record3.Message = "";
            var _record4 = new CXDILogRecord();
            _record4.Module = "Module4";
            _record4.Message = "Message4";

            // add data to _allLogRecords
            var _allLogRecords = new List<CXDILogRecord>();
            _allLogRecords.Add(_record1);
            _allLogRecords.Add(_record2);
            _allLogRecords.Add(_record3);
            _allLogRecords.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            var _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecords);

            // prepare to search item
            var _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _searchedItem.StringValue = "Message1";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreEqual(1, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record1);
        }


        /// <summary>
        /// SearchKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _searchedItem - searching all item which has header message "Message".
        /// expected result: 
        ///     SearchKeywordBuffer has only one item _record4.
        ///</summary>
        [TestMethod()]
        public void SearchKeywordTest_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module1";
            _record1.Message = "";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module2";
            _record2.Message = null;
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module3";
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module4";
            _record4.Message = "abc";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _searchedItem.StringValue = "abc";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreEqual(1, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record4);
        }
        [TestMethod()]
        public void SearchKeywordTest_2_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module1";
            _record1.Message = "";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module2";
            _record2.Message = null;
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module3";
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module4";
            _record4.Message = "abc";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _searchedItem.StringValue = "abc";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreNotEqual(0, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record4);
        }
        [TestMethod()]
        public void SearchKeywordTest_2_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module1";
            _record1.Message = "";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module2";
            _record2.Message = null;
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module3";
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module4";
            _record4.Message = "abc";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _searchedItem.StringValue = "abc";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreNotEqual(2, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record4);
        }

        /// <summary>
        /// SearchKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _searchedItem - searching all item which has header module "Module2"
        /// expected result: 
        ///     SearchKeywordBuffer has only one item is _record2
        ///</summary>
        [TestMethod()]
        public void SearchKeywordTest_3()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = "Message1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module2";
            _record2.Message = null;
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "";
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module4";
            _record4.Message = "Message4";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _searchedItem.StringValue = "Module2";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreEqual(1, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record2);
        }
        [TestMethod()]
        public void SearchKeywordTest_3_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = "Message1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module2";
            _record2.Message = null;
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "";
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module4";
            _record4.Message = "Message4";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _searchedItem.StringValue = "Module2";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreNotEqual(0, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record2);
        }
        [TestMethod()]
        public void SearchKeywordTest_3_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = "Message1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module2";
            _record2.Message = null;
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "";
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module4";
            _record4.Message = "Message4";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _searchedItem.StringValue = "Module2";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreNotEqual(2, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record2);
        }
        /// <summary>
        /// SearchKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _searchedItem - searching all item which has header module "Module"
        /// expected result: 
        ///     SearchKeywordBuffer has 4 item _record1, _record2, _record3, _record4
        ///</summary>
        [TestMethod()]
        public void SearchKeywordTest_4()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module";
            _record1.Message = "Message1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module";
            _record2.Message = "Message2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module";
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module123";
            _record4.Message = "Message4";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _searchedItem.StringValue = "Module";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreEqual(4, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record1);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record2);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record3);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record4);
        }
        [TestMethod()]
        public void SearchKeywordTest_4_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module";
            _record1.Message = "Message1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module";
            _record2.Message = "Message2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module";
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module123";
            _record4.Message = "Message4";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _searchedItem.StringValue = "Module";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreNotEqual(3, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record1);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record2);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record3);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record4);
        }
        [TestMethod()]
        public void SearchKeywordTest_4_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module";
            _record1.Message = "Message1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module";
            _record2.Message = "Message2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module";
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module123";
            _record4.Message = "Message4";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _searchedItem.StringValue = "Module";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreNotEqual(5, _logAnalyser.SearchKeywordBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record1);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record2);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record3);
            CollectionAssert.Contains(_logAnalyser.SearchKeywordBuffer, _record4);
        }
        /// <summary>
        /// SearchKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _searchedItem - searching all item which has header module "ModuleX"
        /// expected result: 
        ///     SearchKeywordBuffer has 0 item
        ///</summary>
        [TestMethod()]
        public void SearchKeywordTest_5()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "";
            _record1.Message = "Message1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module2";
            _record2.Message = "Message2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = null;
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = " ";
            _record4.Message = "Message4";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _searchedItem.StringValue = "ModuleX";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreEqual(0, _logAnalyser.SearchKeywordBuffer.Count);
        }

        public void SearchKeywordTest_5_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "";
            _record1.Message = "Message1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module2";
            _record2.Message = "Message2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = null;
            _record3.Message = "Message3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = " ";
            _record4.Message = "Message4";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare to search item
            SearchItem _searchedItem = new SearchItem();
            _searchedItem.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _searchedItem.StringValue = "ModuleX";

            // executes searching
            _logAnalyser.SearchKeyword(_searchedItem);

            // check returned value
            Assert.AreNotEqual(1, _logAnalyser.SearchKeywordBuffer.Count);
        }
        #endregion

        #region Filter Test Cases

        /// <summary>
        /// Filter is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _filter1 - (disable) - filter items which has header message "Message record3"
        ///     _filter2 - (enable) - filter items which has empty header message
        ///     _filter3 - (enable) - filter items which has header module "Module 4"
        ///     _filterItemSetting - A list of above filters
        /// expected result: 
        ///     FilteredLogRecordsBuffer has only one item is _record4
        ///</summary>
        [TestMethod()]
        public void FilterTest_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "asdf record2";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Mobil record 3";
            _record3.Message = "Message record3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module 4";
            _record4.Message = "Message record4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "Message ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = false;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record3";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "abc";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = true;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module 4";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(1, _logAnalyser.FilteredLogRecordsBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.FilteredLogRecordsBuffer, _record4);
        }
        [TestMethod()]
        public void FilterTest_1_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "asdf record2";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Mobil record 3";
            _record3.Message = "Message record3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module 4";
            _record4.Message = "Message record4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "Message ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = false;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record3";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "abc";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = true;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module 4";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreNotEqual(0, _logAnalyser.FilteredLogRecordsBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.FilteredLogRecordsBuffer, _record4);
        }
        [TestMethod()]
        public void FilterTest_1_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "asdf record2";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Mobil record 3";
            _record3.Message = "Message record3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module 4";
            _record4.Message = "Message record4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "Message ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = false;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record3";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "abc";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = true;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module 4";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreNotEqual(2, _logAnalyser.FilteredLogRecordsBuffer.Count);
            CollectionAssert.Contains(_logAnalyser.FilteredLogRecordsBuffer, _record4);
        }
        /// <summary>
        /// Filter is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _filter1 - (enable) - filter items which has header message "Message record X"
        ///     _filter2 - (enable) - filter items which has header message "Message record X"
        ///     _filter3 - (enable) - filter items which has header module "Module record X"
        ///     _filterItemSetting - A list of above filters
        /// expected result: 
        ///     FilteredLogRecordsBuffer has 5 items, triple _record3 and double _record4
        ///</summary>
        [TestMethod()]
        public void FilterTest_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record X";
            _record3.Message = "Message record X";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record X";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = true;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record X";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "Message record X";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = true;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module record X";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.FilteredLogRecordsBuffer.Count);
            int countR3 = 0;
            int countR4 = 0;
            foreach (CXDILogRecord record in _logAnalyser.FilteredLogRecordsBuffer)
            {
                if (_record3.Equals(record))
                {
                    ++countR3;
                }
                if (_record4.Equals(record))
                {
                    ++countR4;
                }
            }
            Assert.AreEqual(1, countR3);
            Assert.AreEqual(1, countR4);
        }
        [TestMethod()]
        public void FilterTest_2_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record X";
            _record3.Message = "Message record X";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record X";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = true;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record X";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "Message record X";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = true;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module record X";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.FilteredLogRecordsBuffer.Count);
            int countR3 = 0;
            int countR4 = 0;
            foreach (CXDILogRecord record in _logAnalyser.FilteredLogRecordsBuffer)
            {
                if (_record3.Equals(record))
                {
                    ++countR3;
                }
                if (_record4.Equals(record))
                {
                    ++countR4;
                }
            }
            Assert.AreNotEqual(0, countR3);
            Assert.AreEqual(1, countR4);
        }
        [TestMethod()]
        public void FilterTest_2_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record X";
            _record3.Message = "Message record X";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record X";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = true;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record X";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "Message record X";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = true;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module record X";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.FilteredLogRecordsBuffer.Count);
            int countR3 = 0;
            int countR4 = 0;
            foreach (CXDILogRecord record in _logAnalyser.FilteredLogRecordsBuffer)
            {
                if (_record3.Equals(record))
                {
                    ++countR3;
                }
                if (_record4.Equals(record))
                {
                    ++countR4;
                }
            }
            Assert.AreNotEqual(2, countR3);
            Assert.AreEqual(1, countR4);
        }
        [TestMethod()]
        public void FilterTest_2_3()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record X";
            _record3.Message = "Message record X";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record X";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = true;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record X";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "Message record X";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = true;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module record X";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.FilteredLogRecordsBuffer.Count);
            int countR3 = 0;
            int countR4 = 0;
            foreach (CXDILogRecord record in _logAnalyser.FilteredLogRecordsBuffer)
            {
                if (_record3.Equals(record))
                {
                    ++countR3;
                }
                if (_record4.Equals(record))
                {
                    ++countR4;
                }
            }
            Assert.AreEqual(1, countR3);
            Assert.AreNotEqual(0, countR4);
        }
        [TestMethod()]
        public void FilterTest_2_4()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record X";
            _record3.Message = "Message record X";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record X";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = true;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record X";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "Message record X";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = true;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module record X";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.FilteredLogRecordsBuffer.Count);
            int countR3 = 0;
            int countR4 = 0;
            foreach (CXDILogRecord record in _logAnalyser.FilteredLogRecordsBuffer)
            {
                if (_record3.Equals(record))
                {
                    ++countR3;
                }
                if (_record4.Equals(record))
                {
                    ++countR4;
                }
            }
            Assert.AreEqual(1, countR3);
            Assert.AreNotEqual(2, countR4);
        }

        /// <summary>
        /// Filter is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _filter1 - (disable) - filter items which has header message "Message record X"
        ///     _filter2 - (disable) - filter items which has header message "Message record X"
        ///     _filter3 - (disable) - filter items which has header module "Module record X"
        ///     _filterItemSetting - A list of above filters
        /// expected result: 
        ///     FilteredLogRecordsBuffer has no item.
        ///</summary>
        [TestMethod()]
        public void FilterTest_3()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record X";
            _record3.Message = "Message record X";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record X";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = false;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record X";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = false;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "Message record X";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = false;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module record X";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(5, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }
        [TestMethod()]
        public void FilterTest_3_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record X";
            _record3.Message = "Message record X";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record X";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = false;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record X";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = false;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "Message record X";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = false;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module record X";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreNotEqual(4, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }
        [TestMethod()]
        public void FilterTest_3_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record X";
            _record3.Message = "Message record X";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record X";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = false;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message record X";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = false;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter2.StringValue = "Message record X";
            FilterItemSetting _filter3 = new FilterItemSetting();
            _filter3.Enabled = false;
            _filter3.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter3.StringValue = "Module record X";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);
            _filterItemSetting.Add(_filter3);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreNotEqual(6, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }
        /// <summary>
        /// Filter is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _filter1 - (enable) - filter items which has header message "asdgdag"
        ///     _filter2 - (enable) - filter items which has header module "Modefdule"
        ///     _filterItemSetting - A list of above filters
        /// expected result: 
        ///     FilteredLogRecordsBuffer has no item.
        ///</summary>
        [TestMethod()]
        public void FilterTest_4()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message record 3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = true;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "asdgdag";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter2.StringValue = "Modefdule";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(0, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }
        [TestMethod()]
        public void FilterTest_4_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message record 3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = true;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "asdgdag";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter2.StringValue = "Modefdule";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreNotEqual(1, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }

        /// <summary>
        /// Filter is expected to return properly value
        /// precondition:
        ///     _allLogRecordsBuffer - An empty list.
        ///     _filter1 - (enable) - filter items which has header message "Message"
        ///     _filter2 - (enable) - filter items which has header module "Module"
        ///     _filterItemSetting - A list of above filters
        /// expected result: 
        ///     FilteredLogRecordsBuffer has no item.
        ///</summary>
        [TestMethod()]
        public void FilterTest_5()
        {
            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = true;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter2.StringValue = "Module";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(0, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }

        [TestMethod()]
        public void FilterTest_5_2()
        {
            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            _filter1.Enabled = true;
            _filter1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _filter1.StringValue = "Message";
            FilterItemSetting _filter2 = new FilterItemSetting();
            _filter2.Enabled = true;
            _filter2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _filter2.StringValue = "Module";

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreNotEqual(1, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }

        /// <summary>
        /// Filter is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _filter1 - filter is empty
        ///     _filter2 - filter is empty
        ///     _filterItemSetting - A list of above filters
        /// expected result: 
        ///     FilteredLogRecordsBuffer has 5 items.
        ///</summary>
        [TestMethod()]
        public void FilterTest_6()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message record 3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            FilterItemSetting _filter2 = new FilterItemSetting();

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreEqual(5, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }
        [TestMethod()]
        public void FilterTest_6_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message record 3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            FilterItemSetting _filter2 = new FilterItemSetting();

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreNotEqual(4, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }
        [TestMethod()]
        public void FilterTest_6_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = " ";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message record 3";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module record";
            _record4.Message = "Message record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_allLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _filterItemSetting
            FilterItemSetting _filter1 = new FilterItemSetting();
            FilterItemSetting _filter2 = new FilterItemSetting();

            // add data to _filterItemSetting
            List<FilterItemSetting> _filterItemSetting = new List<FilterItemSetting>();
            _filterItemSetting.Add(_filter1);
            _filterItemSetting.Add(_filter2);

            // executes filtering
            _logAnalyser.Filter(_filterItemSetting);

            // check returned value
            Assert.AreNotEqual(6, _logAnalyser.FilteredLogRecordsBuffer.Count);
        }
        #endregion

        #region CountKeyword Test Cases

        /// <summary>
        /// CountKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _keyword1 - (enable) - used for filtering all log record with header message is "Message".
        ///     _keyword2 - (disable) - used for filtering all log record with header module is "Module 4".
        ///     _keywords - A list of above keywords
        /// expected result: 
        ///     CountKeywordBuffer has only one item with 
        ///         item.name was equal with _keyword1.name 
        ///         and item.count is 2.
        ///</summary>
        [TestMethod()]
        public void CountKeywordTest_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module 4";
            _record4.Message = "record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = false;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module 4";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(1, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer[0].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_1_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module 4";
            _record4.Message = "record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = false;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module 4";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(0, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer[0].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_1_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module 4";
            _record4.Message = "record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = false;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module 4";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer[0].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_1_3()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module 4";
            _record4.Message = "record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = false;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module 4";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(1, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer[0].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_1_4()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = null;
            _record1.Message = null;
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = "Module record 3";
            _record3.Message = "Message";
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = "Module 4";
            _record4.Message = "record 4";
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = "";
            _record5.Message = "";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = false;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module 4";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(1, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreNotEqual(3, _logAnalyser.CountKeywordBuffer[0].Count);
        }
        /// <summary>
        /// CountKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _keyword1 - (enable) - used for filtering all log record with header message is "Message".
        ///     _keyword2 - (enable) - used for filtering all log record with header module is "Module X".
        ///     _keywords - A list of above keywords
        /// expected result: 
        ///     CountKeywordBuffer has 2 items with 
        ///         item1.name was equal with _keyword1.name and item1.count is 2.
        ///         item2.name was equal with _keyword2.name and item2.count is 1.
        ///</summary>
        [TestMethod()]
        public void CountKeywordTest_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module X";
            _record1.Message = "Message";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(1, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_2_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module X";
            _record1.Message = "Message";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(1, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_2_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module X";
            _record1.Message = "Message";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(3, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(1, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_2_3()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module X";
            _record1.Message = "Message";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(1, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_2_4()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module X";
            _record1.Message = "Message";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreNotEqual(3, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(1, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_2_5()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module X";
            _record1.Message = "Message";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreNotEqual(0, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_2_6()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module X";
            _record1.Message = "Message";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = " ";
            _record2.Message = "Message";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _filteredLogRecordsBuffer = new List<CXDILogRecord>();
            _filteredLogRecordsBuffer.Add(_record1);
            _filteredLogRecordsBuffer.Add(_record2);
            _filteredLogRecordsBuffer.Add(_record3);
            _filteredLogRecordsBuffer.Add(_record4);
            _filteredLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _filteredLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreNotEqual(2, _logAnalyser.CountKeywordBuffer[1].Count);
        }


        /// <summary>
        /// CountKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _keyword1 - (enable) - used for filtering all log record with header message is "Message".
        ///     _keyword2 - (enable) - used for filtering all log record with header module is "Module X".
        ///     _keywords - A list of above keywords
        /// expected result: 
        ///     CountKeywordBuffer has 2 items with 
        ///         item1.name was equal with _keyword1.name and item1.count is 0.
        ///         item2.name was equal with _keyword2.name and item2.count is 0.
        ///</summary>
        [TestMethod()]
        public void CountKeywordTest_3()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module 1";
            _record1.Message = "Message 1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module 2";
            _record2.Message = "Message 2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Messasaage";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_3_1()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module 1";
            _record1.Message = "Message 1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module 2";
            _record2.Message = "Message 2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Messasaage";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_3_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module 1";
            _record1.Message = "Message 1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module 2";
            _record2.Message = "Message 2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Messasaage";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(3, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]

        public void CountKeywordTest_3_4()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module 1";
            _record1.Message = "Message 1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module 2";
            _record2.Message = "Message 2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Messasaage";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[1].Count);
        }

        [TestMethod()]
        public void CountKeywordTest_3_6()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module 1";
            _record1.Message = "Message 1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module 2";
            _record2.Message = "Message 2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Messasaage";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        /// <summary>
        /// CountKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _keyword1 - (disable) - used for filtering all log record with header message is "Message".
        ///     _keyword2 - (disable) - used for filtering all log record with header module is "Module X".
        ///     _keywords - A list of above keywords
        /// expected result: 
        ///     CountKeywordBuffer has no items.
        ///</summary>
        [TestMethod()]
        public void CountKeywordTest_4()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module 1";
            _record1.Message = "Message 1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module 2";
            _record2.Message = "Message 2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = false;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = false;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer.Count);
        }

        [TestMethod()]
        public void CountKeywordTest_4_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module 1";
            _record1.Message = "Message 1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module 2";
            _record2.Message = "Message 2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = false;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = false;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer.Count);
        }
        /// <summary>
        /// CountKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - An empty list
        ///     _keyword1 - (enable) - used for filtering all log record with header message is "Message".
        ///     _keyword2 - (enable) - used for filtering all log record with header module is "Module X".
        ///     _keywords - A list of above keywords
        /// expected result: 
        ///     CountKeywordBuffer has 2 items with 
        ///         item1.name was equal with _keyword1.name and item1.count is 0.
        ///         item2.name was equal with _keyword2.name and item2.count is 0.
        ///</summary>
        [TestMethod()]
        public void CountKeywordTest_5()
        {
            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_5_1()
        {
            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_5_2()
        {
            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(3, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[1].Count);
        }
        [TestMethod()]
        public void CountKeywordTest_5_4()
        {
            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[1].Count);
        }


        [TestMethod()]
        public void CountKeywordTest_5_6()
        {
            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            _keyword1.Name = "keyword1";
            _keyword1.Enabled = true;
            _keyword1.LogItem = ConfigValue.CXDIHeader.HEADER_MESSAGE;
            _keyword1.StringValue = "Message";
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();
            _keyword2.Name = "keyword2";
            _keyword2.Enabled = true;
            _keyword2.LogItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            _keyword2.StringValue = "Module X";

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(2, _logAnalyser.CountKeywordBuffer.Count);
            Assert.AreEqual(_keyword1.Name, _logAnalyser.CountKeywordBuffer[0].Name);
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer[0].Count);
            Assert.AreEqual(_keyword2.Name, _logAnalyser.CountKeywordBuffer[1].Name);
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer[1].Count);
        }


        /// <summary>
        /// CountKeyword is expected to return properly value.
        /// precondition:
        ///     _allLogRecordsBuffer - A list of CXDI log record.
        ///     _keyword1 - This keyword is empty.
        ///     _keyword2 - This keyword is null.
        ///     _keywords - A list of above keywords
        /// expected result: 
        ///     CountKeywordBuffer has no item.
        ///</summary>
        [TestMethod()]
        public void CountKeywordTest_6()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module 1";
            _record1.Message = "Message 1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module 2";
            _record2.Message = "Message 2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreEqual(0, _logAnalyser.CountKeywordBuffer.Count);
        }

        [TestMethod()]
        public void CountKeywordTest_6_2()
        {
            // prepare data for _allLogRecordsBuffer
            CXDILogRecord _record1 = new CXDILogRecord();
            _record1.Module = "Module 1";
            _record1.Message = "Message 1";
            CXDILogRecord _record2 = new CXDILogRecord();
            _record2.Module = "Module 2";
            _record2.Message = "Message 2";
            CXDILogRecord _record3 = new CXDILogRecord();
            _record3.Module = String.Empty;
            _record3.Message = String.Empty;
            CXDILogRecord _record4 = new CXDILogRecord();
            _record4.Module = null;
            _record4.Message = null;
            CXDILogRecord _record5 = new CXDILogRecord();
            _record5.Module = " ";
            _record5.Message = " ";

            // add data to _allLogRecordsBuffer
            List<CXDILogRecord> _allLogRecordsBuffer = new List<CXDILogRecord>();
            _allLogRecordsBuffer.Add(_record1);
            _allLogRecordsBuffer.Add(_record2);
            _allLogRecordsBuffer.Add(_record3);
            _allLogRecordsBuffer.Add(_record4);
            _allLogRecordsBuffer.Add(_record5);

            // assign data to CXDILogsAnalyser._allLogRecordsBuffer
            CXDILogsAnalyser _logAnalyser = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(_logAnalyser);
            privateObject.SetField("_filteredLogRecordsBuffer", _allLogRecordsBuffer);

            // prepare data for _keywords
            KeywordCountItemSetting _keyword1 = new KeywordCountItemSetting();
            KeywordCountItemSetting _keyword2 = new KeywordCountItemSetting();

            // add data to _keywords
            List<KeywordCountItemSetting> _keywords = new List<KeywordCountItemSetting>();
            _keywords.Add(_keyword1);
            _keywords.Add(_keyword2);

            // executes count keyword
            _logAnalyser.CountKeyword(_keywords);

            // check returned value
            Assert.AreNotEqual(1, _logAnalyser.CountKeywordBuffer.Count);
        }



        #endregion

        [TestMethod]
        public void FirmwareTest()
        {
            CXDILogsAnalyser_Accessor cxdiLogsAnalyser = new CXDILogsAnalyser_Accessor();
            CXDIFirmware firmware = cxdiLogsAnalyser.Firmware;
            Assert.IsNotNull(firmware);
        }
        [TestMethod]
        public void FirmwareTest1()
        {
            CXDILogsAnalyser_Accessor cxdiLogsAnalyser = new CXDILogsAnalyser_Accessor();
            cxdiLogsAnalyser.Firmware = new LogViewer.Model.CXDIFirmware();
            CXDIFirmware firmware = cxdiLogsAnalyser.Firmware;
            Assert.IsNotNull(firmware);
        }
        [TestMethod]
        public void FirmwareTest3()
        {
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser);
            po.SetField("_firmWare", null);
            CXDIFirmware firmware = cxdiLogsAnalyser.Firmware;
            Assert.IsNotNull(firmware);
        }

        [TestMethod]
        public void LoadLogFileTest()
        {
            string textUser =
                         @"--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK";

            string filenameUser = string.Format("LoadLogFileTest{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser_Accessor cxdiLogsAnalyser = new CXDILogsAnalyser_Accessor();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            CXDIFirmware firmware = cxdiLogsAnalyser.Firmware;

            Assert.IsNotNull(firmware);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest1()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadLogFileTest1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser_Accessor cxdiLogsAnalyser = new CXDILogsAnalyser_Accessor();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            CXDIFirmware firmware = cxdiLogsAnalyser.Firmware;

            Assert.IsNotNull(firmware);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest2()
        {
            string textUser =
                         @"--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------";

            string filenameUser = string.Format("LoadLogFileTest2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 0;
            int actual = allLogRecorCollection.Count;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest2_1()
        {
            string textUser =
                         @"--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------";

            string filenameUser = string.Format("LoadLogFileTest2_1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 1;
            int actual = allLogRecorCollection.Count;
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest2_2()
        {
            string textUser =
                         @"--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------";

            string filenameUser = string.Format("LoadLogFileTest2_2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = -1;
            int actual = allLogRecorCollection.Count;
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }

        [TestMethod]
        public void LoadLogFileTest3()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>
--------[counter parametera--------startCount : 0
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parametera---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Loga-----------
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadLogFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 0;
            int actual = allLogRecorCollection.Count;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest3_1()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>
--------[counter parametera--------startCount : 0
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parametera---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Loga-----------
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadLogFileTest3_1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = -1;
            int actual = allLogRecorCollection.Count;
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest3_2()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>
--------[counter parametera--------startCount : 0
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parametera---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Loga-----------
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadLogFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 1;
            int actual = allLogRecorCollection.Count;
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }

        [TestMethod]
        public void LoadLogFileTest4()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>
--------[counter parametera--------startCount : 0
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parametera---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadLogFileTest4{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 8;
            int actual = allLogRecorCollection.Count;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest4_1()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>
--------[counter parametera--------startCount : 0
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parametera---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadLogFileTest4_1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 7;
            int actual = allLogRecorCollection.Count;
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest4_2()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>
--------[counter parametera--------startCount : 0
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parametera---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadLogFileTest4_2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 9;
            int actual = allLogRecorCollection.Count;
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }

        [TestMethod]
        public void LoadLogFileTest5()
        {
            string textUser =
                         @"--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK";

            string filenameUser = string.Format("LoadLogFileTest5{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 8;
            int actual = allLogRecorCollection.Count;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest_5_1()
        {
            string textUser =
                         @"--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK";

            string filenameUser = string.Format("LoadLogFileTest5_1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 7;
            int actual = allLogRecorCollection.Count;
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadLogFileTest5_2()
        {
            string textUser =
                         @"--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK";

            string filenameUser = string.Format("LoadLogFileTest5_2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 9;
            int actual = allLogRecorCollection.Count;
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LoadLogFileTest6()
        {
            string textUser =
                         @"--------[counter parameterfdasf--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameterfdas---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Logfdsa-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK";

            string filenameUser = string.Format("LoadLogFileTest6{0}.fdsa", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.LoadLogFile(fileFullPath, false);
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser, new PrivateType(typeof(BaseLogsAnalyser<CXDILogRecord>)));
            ReadOnlyCollection<CXDILogRecord> allLogRecorCollection = (ReadOnlyCollection<CXDILogRecord>)po.GetProperty("AllLogRecordsBuffer");
            int expected = 8;
            int actual = allLogRecorCollection.Count;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }

        [TestMethod]
        public void WriteMemoTest1()
        {


            string filenameUser = string.Format("WriteMemoTest1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.WriteMemo(fileFullPath);
            bool expected = false;
            bool actual = File.Exists(fileFullPath);
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void WriteMemoTest1_1()
        {


            string filenameUser = string.Format("WriteMemoTest1_1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();

            cxdiLogsAnalyser.WriteMemo(fileFullPath);
            bool expected = true;
            bool actual = File.Exists(fileFullPath);
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }

        [TestMethod]
        public void WriteMemoTest2()
        {


            string filenameUser = string.Format("WriteMemoTest2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();
            cxdiLogsAnalyser.Firmware = new CXDIFirmware();
            var r1  = new CXDILogRecord{DateTime= DateTime.Parse("2013/09/11 09:54:05.434"),Line = 1, Message = "exit status S_ExpReady"};
            var r2  = new CXDILogRecord{DateTime= DateTime.Parse("2013/09/11 09:54:05.434"),Line = 2, Message = "Led Ready:ON,Priority:-1[msec]"};
            var r3  = new CXDILogRecord{DateTime= DateTime.Parse("2013/09/11 09:54:05.434"),Line = 3, Message = "StateNotifySet. systemState:0xb0"};
            var r4  = new CXDILogRecord{DateTime= DateTime.Parse("2013/09/11 09:54:05.434"),Line = 4, Message = "Status = S_EXPOSING"};
           var r5  = new CXDILogRecord{DateTime= DateTime.Parse("2013/09/11 09:54:05.434"),Line = 5, Message = "entry status S_Exposing"};
            var r6  = new CXDILogRecord{DateTime= DateTime.Parse("2013/09/11 09:54:05.434"),Line = 6, Message = "BatteryMgr:Stop."};
            var r7  = new CXDILogRecord{DateTime= DateTime.Parse("2013/09/11 09:54:05.434"),Line = 7, Message = "TempMgr:Stop."};
            var r8  = new CXDILogRecord{DateTime= DateTime.Parse("2013/09/11 09:54:05.434"),Line = 8, Message = "XIF:Resp Data:GRANT_OK\";"};
            var ls = new List<CXDILogRecord>{r1,r2,r3,r4,r5,r6,r7,r8};
            PrivateObject po =new PrivateObject(cxdiLogsAnalyser);
            po.SetFieldOrProperty("_allLogRecordsBuffer",ls);
            cxdiLogsAnalyser.AddBookmark(r1);
            cxdiLogsAnalyser.AddBookmark(r3);
            cxdiLogsAnalyser.WriteMemo(fileFullPath);
            bool expected = true;
            bool actual = File.Exists(fileFullPath);
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void WriteMemoTest2_1()
        {


            string filenameUser = string.Format("WriteMemoTest2_1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();
            cxdiLogsAnalyser.Firmware = new CXDIFirmware();
            var r1 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 1, Message = "exit status S_ExpReady" };
            var r2 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 2, Message = "Led Ready:ON,Priority:-1[msec]" };
            var r3 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 3, Message = "StateNotifySet. systemState:0xb0" };
            var r4 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 4, Message = "Status = S_EXPOSING" };
            var r5 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 5, Message = "entry status S_Exposing" };
            var r6 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 6, Message = "BatteryMgr:Stop." };
            var r7 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 7, Message = "TempMgr:Stop." };
            var r8 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 8, Message = "XIF:Resp Data:GRANT_OK\";" };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5, r6, r7, r8 };
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser);
            po.SetFieldOrProperty("_allLogRecordsBuffer", ls);
            cxdiLogsAnalyser.AddBookmark(r1);
            cxdiLogsAnalyser.AddBookmark(r3);
            cxdiLogsAnalyser.WriteMemo(fileFullPath);
            bool expected = false;
            bool actual = File.Exists(fileFullPath);
            Assert.AreNotEqual(expected, actual);

            File.Delete(fileFullPath);

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void WriteMemoTest3()
        {


            string filenameUser = string.Format("WriteMemoTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();
            cxdiLogsAnalyser.Firmware = new CXDIFirmware();
            var r1 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 1, Message = "exit status S_ExpReady" };
            var r2 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 2, Message = "Led Ready:ON,Priority:-1[msec]" };
            var r3 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 3, Message = "StateNotifySet. systemState:0xb0" };
            var r4 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 4, Message = "Status = S_EXPOSING" };
            var r5 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 5, Message = "entry status S_Exposing" };
            var r6 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 6, Message = "BatteryMgr:Stop." };
            var r7 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 7, Message = "TempMgr:Stop." };
            var r8 = new CXDILogRecord { DateTime= DateTime.Parse("2013/09/11 09:54:05.434"), Line = 8, Message = "XIF:Resp Data:GRANT_OK\";" };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5, r6, r7, r8 };
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser);
            po.SetFieldOrProperty("_allLogRecordsBuffer", null);
            cxdiLogsAnalyser.AddBookmark(r1);
            cxdiLogsAnalyser.AddBookmark(r3);
            cxdiLogsAnalyser.WriteMemo(fileFullPath);
            bool expected = true;
            bool actual = File.Exists(fileFullPath);
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }

        [TestMethod]
        public void LoadMemoLogFileTest()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadMemoLogFileTest{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDILogsAnalyser();


            target.LoadMemoLogFile(fileFullPath);
            var expected = 8;
            var actual = target.AllLogRecordsBuffer.Count;
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void LoadMemoLogFileTest_1()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadMemoLogFileTest_1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDILogsAnalyser();


            target.LoadMemoLogFile(fileFullPath);
            var expected = 7;
            var actual = target.AllLogRecordsBuffer.Count;
            Assert.AreNotEqual(expected, actual);
            File.Delete(fileFullPath);

        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void LoadMemoLogFileTest1()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadMemoLogFileTest1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            FileStream fs = File.OpenWrite(fileFullPath);
            var target = new CXDILogsAnalyser();


            target.LoadMemoLogFile(fileFullPath);
            fs.Close();
            var expected = 8;
            var actual = target.AllLogRecordsBuffer.Count;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }


        [TestMethod]
        public void GetColumnContentValueTest1()
        {
            var record = new CXDILogRecord { Message = "abc" };
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnContentValue", record);
            string expected = "abc";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnContentValueTest1_1()
        {
            var record = new CXDILogRecord { Message = "abc" };
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnContentValue", record);
            string expected = "a";
            Assert.AreNotEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnContentValueTest2()
        {
            var record = new CXDILogRecord { Message = "abc" };
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnContentValue", new object[] { null });
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnContentValueTest2_1()
        {
            var record = new CXDILogRecord { Message = "abc" };
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnContentValue", new object[] { null });
            string expected = "abc";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest1()
        {
            var record = new CXDILogRecord { Message = "abc" };
            string logItem = "Message";
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { null, null });
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest1_1()
        {
            var record = new CXDILogRecord { Message = "abc" };
            string logItem = "Message";
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { null, null });
            string expected = "abc";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest2()
        {
            var record = new CXDILogRecord { Message = "abc" };
            string logItem = "Message";
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { null, logItem });
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest2_1()
        {
            var record = new CXDILogRecord { Message = "abc" };
            string logItem = "Message";
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { null, logItem });
            string expected = "abc";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest3()
        {
            var record = new CXDILogRecord { Message = "abc" };
            string logItem = "Message";
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "abc";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest3_1()
        {
            var record = new CXDILogRecord { Message = "abc" };
            string logItem = "Message";
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "a";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest4()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1 };
            string logItem = ConfigValue.CXDIHeader.HEADER_LINE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "1";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest4_1()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1 };
            string logItem = ConfigValue.CXDIHeader.HEADER_LINE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "0";
            Assert.AreNotEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest4_2()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1 };
            string logItem = ConfigValue.CXDIHeader.HEADER_LINE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "2";
            Assert.AreNotEqual(expected, actual);

        }


        [TestMethod]
        public void GetColumnValueTest5()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1,DateTime= DateTime.Parse("2014/10/10")};
            string logItem = ConfigValue.CXDIHeader.HEADER_DATE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "2014/10/10";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest5_1()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10") };
            string logItem = ConfigValue.CXDIHeader.HEADER_DATE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "2014";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest6()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100")};
            string logItem = ConfigValue.CXDIHeader.HEADER_TIME;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "10:10:10.100";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest6_1()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            string logItem = ConfigValue.CXDIHeader.HEADER_TIME;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "10";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest7()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100"), Module = "[M001]"};
            string logItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "[M001]";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest7_1()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100"), Module = "[M001]"};
            string logItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "M001";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest8()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" )};
            string logItem = ConfigValue.CXDIHeader.HEADER_COMMENT;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest8_1()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" )};
            string logItem = ConfigValue.CXDIHeader.HEADER_COMMENT;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "abc";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest9()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" )};
            string logItem = ConfigValue.CXDIHeader.HEADER_COMMENT;

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            target.Comments.Add(record,"abc");
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "abc";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest9_1()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" )};
            string logItem = ConfigValue.CXDIHeader.HEADER_COMMENT;

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            target.Comments.Add(record, "abc");
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "a";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest10()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100")};
            string logItem = "xxx";

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            target.Comments.Add(record, "abc");
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest10_1()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" )};
            string logItem = "xxx";

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            target.Comments.Add(record, "abc");
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "abc";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void BuildSearchPatternTest()
        {
            //var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" };
            //string logItem = "xxx";

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            //target.Comments.Add(record, "abc");
            IList<GraphParamSetting> paramList = new GraphParamSetting[] { };

            PrivateObject po = new PrivateObject(target);
            List<string> actual = (List<string>)po.Invoke("BuildSearchPattern", paramList);
            //List<string> expected = ;
            Assert.IsNotNull(actual);

        }
        [TestMethod]
        public void BuildSearchPatternTest1()
        {
            //var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" };
            //string logItem = "xxx";

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            //target.Comments.Add(record, "abc");
            IList<GraphParamSetting> paramList = new GraphParamSetting[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
            };

            PrivateObject po = new PrivateObject(target);
            List<string> actual = (List<string>)po.Invoke("BuildSearchPattern", paramList);
            List<string> expected = new List<string> { "(\\r?abc)" };
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void BuildSearchPatternTest1_1()
        {
            //var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" };
            //string logItem = "xxx";

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            //target.Comments.Add(record, "abc");
            IList<GraphParamSetting> paramList = new GraphParamSetting[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
            };

            PrivateObject po = new PrivateObject(target);
            var actual = (List<string>)po.Invoke("BuildSearchPattern", paramList);
            var expected = new List<string> { "" };
            CollectionAssert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void BuildSearchPatternTest2()
        {
            //var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" };
            //string logItem = "xxx";

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            //target.Comments.Add(record, "abc");
            IList<GraphParamSetting> paramList = new GraphParamSetting[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
            };

            PrivateObject po = new PrivateObject(target);
            List<string> actual = (List<string>)po.Invoke("BuildSearchPattern", paramList);
            List<string> expected = new List<string> { "(\\r?(abc)(\\s*:\\s*)(-?[0-9]\\d*(.\\d+)?))" };
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void BuildSearchPatternTest2_1()
        {
            //var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" };
            //string logItem = "xxx";

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            //target.Comments.Add(record, "abc");
            IList<GraphParamSetting> paramList = new GraphParamSetting[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
            };

            PrivateObject po = new PrivateObject(target);
            var actual = (List<string>)po.Invoke("BuildSearchPattern", paramList);
            var expected = new List<string> { "" };
            CollectionAssert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void BuildSearchPatternTest3()
        {
            //var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" };
            //string logItem = "xxx";

            var target = new CXDILogsAnalyser();
            //target.Comments.Add(record, "abc");
            var paramList = new List<GraphParamSetting>
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}
            };

            var po = new PrivateObject(target);
            var actual = (List<string>)po.Invoke("BuildSearchPattern", paramList);
            var expected = new List<string> { "(\\r?abc)", "(\\r?(abc)(\\s*:\\s*)(-?[0-9]\\d*(.\\d+)?))" };
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void BuildSearchPatternTest3_1()
        {
            //var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime= DateTime.Parse("2014/10/10 10:10:10.100" };
            //string logItem = "xxx";

            var target = new CXDILogsAnalyser();
            //target.Comments.Add(record, "abc");
            var paramList = new List<GraphParamSetting>
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}
            };

            var po = new PrivateObject(target);
            var actual = (List<string>)po.Invoke("BuildSearchPattern", paramList);
            var expected = new List<string> { };
            CollectionAssert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void InitGraphLineDataTest1()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new GraphParamSetting[] { };
            var graphLineData1 = new GraphResult();
            var graphLineData2 = new GraphResult();
            var eventResults = new GraphResult[] { };

            //IList<GraphParamSetting> paramList = new GraphParamSetting[]
            //{
            //    new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
            //    new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}
            //};

            var po = new PrivateObject(target);
            var actual = (int)po.Invoke("InitGraphLineData", new object[]
            {
                paramList,graphLineData1,graphLineData2,eventResults
            });
            var expected = 0;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void InitGraphLineDataTest1_1()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new GraphParamSetting[] { };
            var graphLineData1 = new GraphResult();
            var graphLineData2 = new GraphResult();
            var eventResults = new GraphResult[] { };

            //IList<GraphParamSetting> paramList = new GraphParamSetting[]
            //{
            //    new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
            //    new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}
            //};

            var po = new PrivateObject(target);
            var actual = (int)po.Invoke("InitGraphLineData", new object[]
            {
                paramList,graphLineData1,graphLineData2,eventResults
            });
            var expected = 1;
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void InitGraphLineDataTest2()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new List<GraphParamSetting>
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}
            };
            var graphLineData1 = new GraphResult();
            var graphLineData2 = new GraphResult();
            var eventResults = new List<GraphResult>();

            var po = new PrivateObject(target);
            var actual = (int)po.Invoke("InitGraphLineData", new object[]
            {
                paramList,graphLineData1,graphLineData2,eventResults
            });
            var expected = 1;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void InitGraphLineDataTest2_1()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new List<GraphParamSetting>
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}
            };
            var graphLineData1 = new GraphResult();
            var graphLineData2 = new GraphResult();
            var eventResults = new List<GraphResult>();

            var po = new PrivateObject(target);
            var actual = (int)po.Invoke("InitGraphLineData", new object[]
            {
                paramList,graphLineData1,graphLineData2,eventResults
            });
            var expected = 0;
            Assert.AreNotEqual(expected, actual);

        }
        [TestMethod]
        public void InitGraphLineDataTest2_2()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new List<GraphParamSetting>
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}
            };
            var graphLineData1 = new GraphResult();
            var graphLineData2 = new GraphResult();
            var eventResults = new List<GraphResult>();

            var po = new PrivateObject(target);
            var actual = (int)po.Invoke("InitGraphLineData", new object[]
            {
                paramList,graphLineData1,graphLineData2,eventResults
            });
            var expected = 2;
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void InitGraphLineDataTest3()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new List<GraphParamSetting>
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "2",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}
            };
            var graphLineData1 = new GraphResult();
            var graphLineData2 = new GraphResult();
            var eventResults = new List<GraphResult>();

            var po = new PrivateObject(target);
            var actual = (int)po.Invoke("InitGraphLineData", new object[]
            {
                paramList,graphLineData1,graphLineData2,eventResults
            });
            var expected = 2;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void InitGraphLineDataTest3_1()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new List<GraphParamSetting>
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "2",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}
            };
            var graphLineData1 = new GraphResult();
            var graphLineData2 = new GraphResult();
            var eventResults = new List<GraphResult>();

            var po = new PrivateObject(target);
            var actual = (int)po.Invoke("InitGraphLineData", new object[]
            {
                paramList,graphLineData1,graphLineData2,eventResults
            });
            var expected = 1;
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void BuildGraphParamResultTest1()
        {
            var target = new CXDILogsAnalyser();
            List<string> valueMatchedlist = new List<string>();
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            int numOfGraphLine = 0;
            DateTime recordDateTime = new DateTime();
            IList<GraphResult> eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuildGraphParamResultTest1_1()
        {
            var target = new CXDILogsAnalyser();
            List<string> valueMatchedlist = new List<string>();
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            int numOfGraphLine = 0;
            DateTime recordDateTime = new DateTime();
            IList<GraphResult> eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = true;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void BuildGraphParamResultTest2()
        {
            var target = new CXDILogsAnalyser();
            List<string> valueMatchedlist = new List<string> { "abc", "efg" };
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            int numOfGraphLine = 0;
            DateTime recordDateTime = new DateTime();
            IList<GraphResult> eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuildGraphParamResultTest2_1()
        {
            var target = new CXDILogsAnalyser();
            List<string> valueMatchedlist = new List<string> { "abc", "efg" };
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            int numOfGraphLine = 0;
            DateTime recordDateTime = new DateTime();
            IList<GraphResult> eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = true;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void BuildGraphParamResultTest3()
        {
            var target = new CXDILogsAnalyser();
            List<string> valueMatchedlist = new List<string> { "BatteryMgr:Stop.", "TempMgr:Stop." };
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            int numOfGraphLine = 0;
            DateTime recordDateTime = new DateTime();
            IList<GraphResult> eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuildGraphParamResultTest3_1()
        {
            var target = new CXDILogsAnalyser();
            List<string> valueMatchedlist = new List<string> { "BatteryMgr:Stop.", "TempMgr:Stop." };
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            int numOfGraphLine = 0;
            DateTime recordDateTime = new DateTime();
            IList<GraphResult> eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = true;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void BuildGraphParamResultTest4()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:Stop.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = string.Empty } };
            var graphLineData2 = new GraphResult();
            var numOfGraphLine = 1;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuildGraphParamResultTest4_1()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:Stop.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = string.Empty } };
            var graphLineData2 = new GraphResult();
            var numOfGraphLine = 1;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = true;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void BuildGraphParamResultTest5()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:Stop.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult();
            var numOfGraphLine = 1;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuildGraphParamResultTest5_1()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:Stop.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult();
            var numOfGraphLine = 1;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var actual = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var expected = true;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void BuildGraphParamResultTest6()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult();
            var numOfGraphLine = 1;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var actual = graphLineData1.ResultList.Count;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuildGraphParamResultTest6_1()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult();
            var numOfGraphLine = 1;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var actual = graphLineData1.ResultList.Count;
            var expected = 0;
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void BuildGraphParamResultTest6_2()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult();
            var numOfGraphLine = 1;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var actual = graphLineData1.ResultList.Count;
            var expected = 2;
            Assert.AreNotEqual(expected, actual);
        }


        [TestMethod]
        public void BuildGraphParamResultTest7()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = string.Empty } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var actual = graphLineData1.ResultList.Count;
            var expected = 1;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest7_1()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = string.Empty } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var actual = graphLineData1.ResultList.Count;
            var expected = 0;
            Assert.AreNotEqual(expected, actual);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest7_2()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = string.Empty } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var actual = graphLineData1.ResultList.Count;
            var expected = 2;
            Assert.AreNotEqual(expected, actual);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest7_3()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = string.Empty } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            var actual = graphLineData1.ResultList.Count;
            var expected = 1;
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(1, graphLineData2.ResultList.Count);
        }

        [TestMethod]
        public void BuildGraphParamResultTest8()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest8_1()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreNotEqual(0, graphLineData1.ResultList.Count);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest8_2()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreNotEqual(2, graphLineData1.ResultList.Count);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest8_3()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:Stop." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreNotEqual(1, graphLineData2.ResultList.Count);
        }

        [TestMethod]
        public void BuildGraphParamResultTest9()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreEqual(1, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest9_1()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreNotEqual(0, graphLineData1.ResultList.Count);
            Assert.AreEqual(1, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest9_2()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreNotEqual(2, graphLineData1.ResultList.Count);
            Assert.AreEqual(1, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest9_3()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreNotEqual(0, graphLineData2.ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest9_4()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423." };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult>();
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreNotEqual(2, graphLineData2.ResultList.Count);
        }

        [TestMethod]
        public void BuildGraphParamResultTest10()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreEqual(1, graphLineData2.ResultList.Count);
            Assert.AreEqual(0, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest10_1()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreNotEqual(0, graphLineData1.ResultList.Count);
            Assert.AreEqual(1, graphLineData2.ResultList.Count);
            Assert.AreEqual(0, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest10_2()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreNotEqual(2, graphLineData1.ResultList.Count);
            Assert.AreEqual(1, graphLineData2.ResultList.Count);
            Assert.AreEqual(0, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest10_3()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreNotEqual(0, graphLineData2.ResultList.Count);
            Assert.AreEqual(0, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest10_4()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreNotEqual(2, graphLineData2.ResultList.Count);
            Assert.AreEqual(0, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest10_5()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreEqual(1, graphLineData2.ResultList.Count);
            Assert.AreNotEqual(1, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest10_6()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1445.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreEqual(1, graphLineData2.ResultList.Count);
            Assert.AreNotEqual(2, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest11()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:xx.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(0, graphLineData1.ResultList.Count);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
            Assert.AreEqual(0, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest11_1()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:xx.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreNotEqual(1, graphLineData1.ResultList.Count);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
            Assert.AreEqual(0, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest11_2()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:xx.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(0, graphLineData1.ResultList.Count);
            Assert.AreNotEqual(1, graphLineData2.ResultList.Count);
            Assert.AreEqual(0, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest11_3()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:xx.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(0, graphLineData1.ResultList.Count);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
            Assert.AreNotEqual(1, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void BuildGraphParamResultTest11_4()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:xx.", "TempMgr:1423.", "Index:EVENT_GOTO_SLEEP2READY" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr" } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "TempMgr" } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "Index" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreNotEqual(1, graphLineData1.ResultList.Count);
            Assert.AreNotEqual(1, graphLineData2.ResultList.Count);
            Assert.AreNotEqual(1, eventResults[0].ResultList.Count);
        }

        [TestMethod]
        public void BuildGraphParamResultTest11_5()
        {
            var target = new CXDILogsAnalyser();
            var valueMatchedlist = new List<string> { "BatteryMgr:1423.", "TempMgr:1423.", "Sleep2 ready for 3sec time:30000[msec]", "image trans time 2335[msec]" };
            var graphLineData1 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "BatteryMgr", Enabled = true, GraphTypeValue = GraphType.Value } };
            var graphLineData2 = new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "image", Enabled = true, GraphTypeValue = GraphType.Event } };
            var numOfGraphLine = 2;
            var recordDateTime = new DateTime();
            var eventResults = new List<GraphResult> { new GraphResult { ParamSetting = new GraphParamSetting { StringValue = "image" } } };
            var po = new PrivateObject(target);
            var result = (bool)po.Invoke("BuildGraphParamResult", new object[]
            {
                valueMatchedlist,graphLineData1,graphLineData2,numOfGraphLine,recordDateTime,eventResults,""
            });
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
            Assert.AreEqual(0, graphLineData2.ResultList.Count);
            Assert.AreEqual(0, eventResults[0].ResultList.Count);
        }
        [TestMethod]
        public void AnalyGraphParamTest1()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new GraphParamSetting[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}

            };
            GraphResult graphLineData1;
            GraphResult graphLineData2;
            IList<GraphResult> eventResults;
            target.AnalyGraphParam(null, out graphLineData1, out graphLineData2, out eventResults);
            Assert.IsNotNull(graphLineData1);
            Assert.IsNotNull(graphLineData2);
            Assert.IsNotNull(eventResults);
        }
        [TestMethod]
        public void AnalyGraphParamTest2()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new GraphParamSetting[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}

            };
            GraphResult graphLineData1;
            GraphResult graphLineData2;
            IList<GraphResult> eventResults;
            target.AnalyGraphParam(paramList, out graphLineData1, out graphLineData2, out eventResults);
            Assert.AreEqual(0, graphLineData1.ResultList.Count);
        }
        [TestMethod]
        public void AnalyGraphParamTest2_1()
        {
            var target = new CXDILogsAnalyser();
            IList<GraphParamSetting> paramList = new GraphParamSetting[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Event,PrototypeValue = 0},
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "abc",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}

            };
            GraphResult graphLineData1;
            GraphResult graphLineData2;
            IList<GraphResult> eventResults;
            target.AnalyGraphParam(paramList, out graphLineData1, out graphLineData2, out eventResults);
            Assert.AreNotEqual(1, graphLineData1.ResultList.Count);
        }

        [TestMethod]
        public void AnalyGraphParamTest3()
        {

                   // prepare data for _allLogRecordsBuffer
            var record1 = new CXDILogRecord { Module = "", Message = "fsmEvent Index:EVENT_GOTO_SLEEP2READY ", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record2 = new CXDILogRecord { Module = " ", Message = "EVENT_GOTO_SLEEP2READY(fsmProc NULL)", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record3 = new CXDILogRecord { Module = "Module record 3", Message = "TempMgr:144.", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record4 = new CXDILogRecord { Module = "Module 4", Message = "entry status Sleep2Ready", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record5 = new CXDILogRecord { Module = "", Message = "jfds BatteryMgr:200 sdfsa", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };

            // add data to _allLogRecordsBuffer
            
            var alLogRecords = new List<CXDILogRecord> {record1, record2, record3, record4, record5};

            var target = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", alLogRecords);

            IList<GraphParamSetting> paramList = new[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "BatteryMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "2",Name = "abc",StringValue = "TempMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "3",Name = "abc",StringValue = "Index",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}

            };
            GraphResult graphLineData1;
            GraphResult graphLineData2;
            IList<GraphResult> eventResults;
            target.AnalyGraphParam(paramList, out graphLineData1, out graphLineData2, out eventResults);
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
        }
        [TestMethod]
        public void AnalyGraphParamTest3_1()
        {

            // prepare data for _allLogRecordsBuffer
            var record1 = new CXDILogRecord { Module = "", Message = "fsmEvent Index:EVENT_GOTO_SLEEP2READY ", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record2 = new CXDILogRecord { Module = " ", Message = "EVENT_GOTO_SLEEP2READY(fsmProc NULL)", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record3 = new CXDILogRecord { Module = "Module record 3", Message = "TempMgr:144.", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record4 = new CXDILogRecord { Module = "Module 4", Message = "entry status Sleep2Ready", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record5 = new CXDILogRecord { Module = "", Message = "jfds BatteryMgr:200 sdfsa", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };

            // add data to _allLogRecordsBuffer

            var alLogRecords = new List<CXDILogRecord> { record1, record2, record3, record4, record5 };

            var target = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", alLogRecords);

            IList<GraphParamSetting> paramList = new[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "BatteryMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "2",Name = "abc",StringValue = "TempMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "3",Name = "abc",StringValue = "Index",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}

            };
            GraphResult graphLineData1;
            GraphResult graphLineData2;
            IList<GraphResult> eventResults;
            target.AnalyGraphParam(paramList, out graphLineData1, out graphLineData2, out eventResults);
            Assert.AreNotEqual(0, graphLineData1.ResultList.Count);
        }
        [TestMethod]
        public void AnalyGraphParamTest3_2()
        {

            // prepare data for _allLogRecordsBuffer
            var record1 = new CXDILogRecord { Module = "", Message = "fsmEvent Index:EVENT_GOTO_SLEEP2READY ", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record2 = new CXDILogRecord { Module = " ", Message = "EVENT_GOTO_SLEEP2READY(fsmProc NULL)", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record3 = new CXDILogRecord { Module = "Module record 3", Message = "TempMgr:144.", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record4 = new CXDILogRecord { Module = "Module 4", Message = "entry status Sleep2Ready", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record5 = new CXDILogRecord { Module = "", Message = "jfds BatteryMgr:200 sdfsa", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };

            // add data to _allLogRecordsBuffer

            var alLogRecords = new List<CXDILogRecord> { record1, record2, record3, record4, record5 };

            var target = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", alLogRecords);

            IList<GraphParamSetting> paramList = new[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "BatteryMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "2",Name = "abc",StringValue = "TempMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "3",Name = "abc",StringValue = "Index",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}

            };
            GraphResult graphLineData1;
            GraphResult graphLineData2;
            IList<GraphResult> eventResults;
            target.AnalyGraphParam(paramList, out graphLineData1, out graphLineData2, out eventResults);
            Assert.AreNotEqual(2, graphLineData1.ResultList.Count);
        }
        [TestMethod]
        public void AnalyGraphParamTest4()
        {

            // prepare data for _allLogRecordsBuffer
            var record1 = new CXDILogRecord { Module = "", Message = "fsmEvent Index:EVENT_GOTO_SLEEP2READY ", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record2 = new CXDILogRecord { Module = " ", Message = "TempMgr:444", DateTime = DateTime.Parse("2014/10/10 10:10:10.400") };
            var record3 = new CXDILogRecord { Module = "Module record 3", Message = "TempMgr:144.", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record4 = new CXDILogRecord { Module = "Module 4", Message = "entry status Sleep2Ready", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record5 = new CXDILogRecord { Module = "", Message = "jfds BatteryMgr:200 sdfsa", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };

            // add data to _allLogRecordsBuffer

            var alLogRecords = new List<CXDILogRecord> { record1, record2, record3, record4, record5 };

            var target = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", alLogRecords);

            IList<GraphParamSetting> paramList = new[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "BatteryMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "2",Name = "abc",StringValue = "TempMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "3",Name = "abc",StringValue = "Index",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}

            };
            GraphResult graphLineData1;
            GraphResult graphLineData2;
            IList<GraphResult> eventResults;
            target.AnalyGraphParam(paramList, out graphLineData1, out graphLineData2, out eventResults);
            Assert.AreEqual(1, graphLineData1.ResultList.Count);
        }
        [TestMethod]
        public void AnalyGraphParamTest4_1()
        {

            // prepare data for _allLogRecordsBuffer
            var record1 = new CXDILogRecord { Module = "", Message = "fsmEvent Index:EVENT_GOTO_SLEEP2READY ", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record2 = new CXDILogRecord { Module = " ", Message = "TempMgr:444", DateTime = DateTime.Parse("2014/10/10 10:10:10.400") };
            var record3 = new CXDILogRecord { Module = "Module record 3", Message = "TempMgr:144.", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record4 = new CXDILogRecord { Module = "Module 4", Message = "entry status Sleep2Ready", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record5 = new CXDILogRecord { Module = "", Message = "jfds BatteryMgr:200 sdfsa", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };

            // add data to _allLogRecordsBuffer

            var alLogRecords = new List<CXDILogRecord> { record1, record2, record3, record4, record5 };

            var target = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", alLogRecords);

            IList<GraphParamSetting> paramList = new[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "BatteryMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "2",Name = "abc",StringValue = "TempMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "3",Name = "abc",StringValue = "Index",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}

            };
            GraphResult graphLineData1;
            GraphResult graphLineData2;
            IList<GraphResult> eventResults;
            target.AnalyGraphParam(paramList, out graphLineData1, out graphLineData2, out eventResults);
            Assert.AreNotEqual(0, graphLineData1.ResultList.Count);
        }
        [TestMethod]
        public void AnalyGraphParamTest4_2()
        {

            // prepare data for _allLogRecordsBuffer
            var record1 = new CXDILogRecord { Module = "", Message = "fsmEvent Index:EVENT_GOTO_SLEEP2READY ", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record2 = new CXDILogRecord { Module = " ", Message = "TempMgr:444", DateTime = DateTime.Parse("2014/10/10 10:10:10.400") };
            var record3 = new CXDILogRecord { Module = "Module record 3", Message = "TempMgr:144.", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record4 = new CXDILogRecord { Module = "Module 4", Message = "entry status Sleep2Ready", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };
            var record5 = new CXDILogRecord { Module = "", Message = "jfds BatteryMgr:200 sdfsa", DateTime= DateTime.Parse("2014/10/10 10:10:10.400") };

            // add data to _allLogRecordsBuffer

            var alLogRecords = new List<CXDILogRecord> { record1, record2, record3, record4, record5 };

            var target = new CXDILogsAnalyser();
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", alLogRecords);

            IList<GraphParamSetting> paramList = new[]
            {
                new GraphParamSetting{Id = "1",Name = "abc",StringValue = "BatteryMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "2",Name = "abc",StringValue = "TempMgr",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0},
                new GraphParamSetting{Id = "3",Name = "abc",StringValue = "Index",Enabled = true,GraphTypeValue = GraphType.Value,PrototypeValue = 0}

            };
            GraphResult graphLineData1;
            GraphResult graphLineData2;
            IList<GraphResult> eventResults;
            target.AnalyGraphParam(paramList, out graphLineData1, out graphLineData2, out eventResults);
            Assert.AreNotEqual(2, graphLineData1.ResultList.Count);
        }

    }
}
