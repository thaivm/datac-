using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using LogViewer.Business;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business
{
    
    
    [TestClass()]
    public class CCSLogsAnalyserTest
    {


        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void FilterTest_1()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "world";
            item_4.ThreadId = "4";
            item_4.Type = "I";
            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);   
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);
            //add FilterItemSetting List
            FilterItemSetting filter1 = new FilterItemSetting();
            filter1.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;
            filter1.StringValue = "local";
            filter1.Id = "1";
            filter1.Enabled = true;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>(); 
            filterItemSetting.Add(filter1);
            //add expected List
            List<CCSLogRecord> expected = new List<CCSLogRecord>();
            expected.Add(item_1);
            expected.Add(item_2);
            expected.Add(item_3);
            //action
            target.Filter(filterItemSetting);
            List<CCSLogRecord> actual = new List<CCSLogRecord>();
            CollectionAssert.AreEqual(expected, target.FilteredLogRecordsBuffer);
        }

        /// <summary>
        ///A test for Filter
        ///case : one Filter.Enable is true one Filter.Enable is false
        ///Expected : return expected list
        ///</summary>
        [TestMethod()]
        public void FilterTest_2()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "world";
            item_4.ThreadId = "4";
            item_4.Type = "I";
            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);
            //add FilterItemSetting List
            FilterItemSetting filter1 = new FilterItemSetting();
            filter1.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;
            filter1.StringValue = "local";
            filter1.Id = "1";
            filter1.Enabled = true;

            FilterItemSetting filter2 = new FilterItemSetting();
            filter2.LogItem = ConfigValue.CCSHeader.HEADER_TYPE;
            filter2.StringValue = "N";
            filter2.Id = "2";
            filter2.Enabled = false;
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>(); 
            filterItemSetting.Add(filter1);
            filterItemSetting.Add(filter2);
            //add expected List
            List<CCSLogRecord> expected = new List<CCSLogRecord>();
            expected.Add(item_1);
            expected.Add(item_2);
            expected.Add(item_3);
            //action
            target.Filter(filterItemSetting);
            List<CCSLogRecord> actual = new List<CCSLogRecord>();
            CollectionAssert.AreEqual(expected, target.FilteredLogRecordsBuffer);
        }

        ///A test for Filter
        ///case :there is no object in input FilterItemSetting List 
        ///precondition:
        ///         filterItemSetting has no object
        ///expected: return a list same as AllLogRecordsBuffer
        ///</summary>
        [TestMethod()]
        public void FilterTest_3()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "world";
            item_4.ThreadId = "4";
            item_4.Type = "I";
            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);
            //add FilterItemSetting List         
            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>();     
            //add expected List
            List<CCSLogRecord> expected = new List<CCSLogRecord>();
            expected.Add(item_1);
            expected.Add(item_2);
            expected.Add(item_3);
            expected.Add(item_4);
            //action
            target.Filter(filterItemSetting);
            List<CCSLogRecord> actual = new List<CCSLogRecord>();
            CollectionAssert.AreEqual(expected, target.FilteredLogRecordsBuffer);
        }


        /// <summary>
        ///A test for Filter
        ///Case All Filter.Enable is False
        ///expected: return a list same as AllLogRecordsBuffer
        ///</summary>
        [TestMethod()]
        public void FilterTest_4()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            //target.baseLogRecord = new List<CCSLogRecord>();
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "world";
            item_4.ThreadId = "4";
            item_4.Type = "I";
            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);
            //add FilterItemSetting List
            FilterItemSetting filter1 = new FilterItemSetting();
            filter1.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;
            filter1.StringValue = "local";
            filter1.Id = "1";
            filter1.Enabled = false;
            FilterItemSetting filter2 = new FilterItemSetting();
            filter2.LogItem = ConfigValue.CCSHeader.HEADER_TYPE;
            filter2.StringValue = "I";
            filter2.Id = "2";
            filter2.Enabled = false;

            List<FilterItemSetting> filterItemSetting = new List<FilterItemSetting>(); 
            filterItemSetting.Add(filter1);
            filterItemSetting.Add(filter2);
            //add expected List
            List<BaseLogRecord> expected = new List<BaseLogRecord>();
            expected.Add(item_1);
            expected.Add(item_2);
            expected.Add(item_3);
            expected.Add(item_4);

            //action
            target.Filter(filterItemSetting);
            CollectionAssert.AreEqual(expected, target.FilteredLogRecordsBuffer);
        }


        /// <summary>
        ///A test for Filter
        ///Case FilterItemSetting list is null
        ///expected: return a list same as AllLogRecordsBuffer
        ///</summary>
        [TestMethod()]
        public void FilterTest_5()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            //target.baseLogRecord = new List<CCSLogRecord>();
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "world";
            item_4.ThreadId = "4";
            item_4.Type = "I";
            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);
            //add FilterItemSetting List

            List<FilterItemSetting> filterItemSetting = null; 
            //add expected List
            List<BaseLogRecord> expected = new List<BaseLogRecord>();
            expected.Add(item_1);
            expected.Add(item_2);
            expected.Add(item_3);
            expected.Add(item_4);

            //action
            target.Filter(filterItemSetting);
            CollectionAssert.AreEqual(expected, target.FilteredLogRecordsBuffer);
        }
        [TestMethod()]
        public void SearchKeyWord_1()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "world";
            item_4.ThreadId = "4";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //define SearchItem object
            SearchItem key = new SearchItem();
            key.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;
            key.StringValue = "local";
            //add expected List
            List<BaseLogRecord> expected = new List<BaseLogRecord>();
            expected.Add(item_1);
            expected.Add(item_2);
            expected.Add(item_3);
            //action
            target.SearchKeyword(key);

            CollectionAssert.AreEqual(expected, target.SearchKeywordBuffer);
        }


        /// <summary>
        ///A test for SearchKeyWord
        /// SerchItem Stringvalue is wrong value
        /// Expected :return a list have no object
        ///</summary>
        [TestMethod()]
        public void SearchKeyWord_2()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "world";
            item_4.ThreadId = "4";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);

            //define SearchItem object
            SearchItem key = new SearchItem();
            key.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;
            key.StringValue = "aaaaa";
            //add expected List
            List<BaseLogRecord> expected = new List<BaseLogRecord>();
            //action
            target.SearchKeyword(key);
            CollectionAssert.AreEqual(expected, target.SearchKeywordBuffer);
            
        }

        [TestMethod()]
        public void SearchKeyWord_3()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.ThreadId = "4";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);

            //define SearchItem object
            SearchItem key = new SearchItem();
            key.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;
            key.StringValue = null;
            //add expected List
            List<BaseLogRecord> expected = new List<BaseLogRecord>();
            //action
            target.SearchKeyword(key);
            CollectionAssert.AreEqual(expected, target.SearchKeywordBuffer);    
        }

        [TestMethod()]
        public void SearchKeyWord_4()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "  ";
            item_1.ThreadId = " ";
            item_1.Type = "   ";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.ThreadId = "4";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);

            //define SearchItem object
            SearchItem key = new SearchItem();
            key.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;
            key.StringValue = "  ";
            //add expected List
            List<BaseLogRecord> expected = new List<BaseLogRecord>();
            //action
            target.SearchKeyword(key);
            CollectionAssert.AreEqual(expected, target.SearchKeywordBuffer);
        }
        [TestMethod()]
        public void CountKeyWord_1()
        {
            //arrange
            CCSLogsAnalyser target = new CCSLogsAnalyser();

            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "bbbbb";
            item_1.ThreadId = "1";
            item_1.Type = "local";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "aaaa";
            item_4.ThreadId = "local";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //add KeywordCountItemSetting List

            KeywordCountItemSetting keyword_1 = new KeywordCountItemSetting();
            keyword_1.Enabled = true;
            keyword_1.Id = "1";
            keyword_1.StringValue = "local";
            keyword_1.Name = "Host_Local";
            keyword_1.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;

            List<KeywordCountItemSetting> lsKeywordCountItemSetting = new List<KeywordCountItemSetting>();
            lsKeywordCountItemSetting.Add(keyword_1);

            //add expected 
            AnalyzedCountKeywordItem analyzedCountItem_1 = new AnalyzedCountKeywordItem();
            analyzedCountItem_1.Name = "Host_Local";
            analyzedCountItem_1.Count = 2;

            List<AnalyzedCountKeywordItem> expected = new List<AnalyzedCountKeywordItem>();
            expected.Add(analyzedCountItem_1);

            target.CountKeyword(lsKeywordCountItemSetting);

            //Assert
            int i = 0;
            Assert.AreEqual(expected.Count, target.CountKeywordBuffer.Count);
            while (i < expected.Count)
            {
                Assert.AreEqual(expected[i].Count, target.CountKeywordBuffer[i].Count);
                Assert.AreEqual(expected[i].Name, target.CountKeywordBuffer[i].Name); 
                i++;
            }
        }
        [TestMethod()]
        public void CountKeyWord()
        {
            //arrange
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            target.KeywordCountWorker = new System.ComponentModel.BackgroundWorker();
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "bbbbb";
            item_1.ThreadId = "1";
            item_1.Type = "local";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "aaaa";
            item_4.ThreadId = "local";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //add KeywordCountItemSetting List

            KeywordCountItemSetting keyword_1 = new KeywordCountItemSetting();
            keyword_1.Enabled = true;
            keyword_1.Id = "1";
            keyword_1.StringValue = "local";
            keyword_1.Name = "Host_Local";
            keyword_1.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;

            List<KeywordCountItemSetting> lsKeywordCountItemSetting = new List<KeywordCountItemSetting>();
            lsKeywordCountItemSetting.Add(keyword_1);

            //add expected 
            AnalyzedCountKeywordItem analyzedCountItem_1 = new AnalyzedCountKeywordItem();
            analyzedCountItem_1.Name = "Host_Local";
            analyzedCountItem_1.Count = 2;

            List<AnalyzedCountKeywordItem> expected = new List<AnalyzedCountKeywordItem>();
            expected.Add(analyzedCountItem_1);

            target.CountKeyword(lsKeywordCountItemSetting);

            //Assert
            int i = 0;
            Assert.AreEqual(expected.Count, target.CountKeywordBuffer.Count);
            while (i < expected.Count)
            {
                Assert.AreEqual(expected[i].Count, target.CountKeywordBuffer[i].Count);
                Assert.AreEqual(expected[i].Name, target.CountKeywordBuffer[i].Name);
                i++;
            }
        }

        [TestMethod()]
        public void CountKeyWord_5()
        {
            //arrange
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            BackgroundWorker KeywordCountWorker = new BackgroundWorker();
            target.KeywordCountWorker = new System.ComponentModel.BackgroundWorker();
            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "bbbbb";
            item_1.ThreadId = "1";
            item_1.Type = "local";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "aaaa";
            item_4.ThreadId = "local";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //add KeywordCountItemSetting List

            KeywordCountItemSetting keyword_1 = new KeywordCountItemSetting();
            keyword_1.Enabled = true;
            keyword_1.Id = "1";
            keyword_1.StringValue = "local";
            keyword_1.Name = "Host_Local";
            keyword_1.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;

            List<KeywordCountItemSetting> lsKeywordCountItemSetting = new List<KeywordCountItemSetting>();
            lsKeywordCountItemSetting.Add(keyword_1);

            //add expected 
            AnalyzedCountKeywordItem analyzedCountItem_1 = new AnalyzedCountKeywordItem();
            analyzedCountItem_1.Name = "Host_Local";
            analyzedCountItem_1.Count = 2;

            List<AnalyzedCountKeywordItem> expected = new List<AnalyzedCountKeywordItem>();
            expected.Add(analyzedCountItem_1);

            target.CountKeyword(lsKeywordCountItemSetting);

            //Assert
            int i = 0;
            Assert.AreEqual(expected.Count, target.CountKeywordBuffer.Count);
            while (i < expected.Count)
            {
                Assert.AreEqual(expected[i].Count, target.CountKeywordBuffer[i].Count);
                Assert.AreEqual(expected[i].Name, target.CountKeywordBuffer[i].Name);
                i++;
            }
        }
        [TestMethod()]
        public void CountKeyWord_2()
        {
            //arrange
            CCSLogsAnalyser target = new CCSLogsAnalyser();

            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "local";
            item_4.ThreadId = "4";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);

            //add KeywordCountItemSetting List

            KeywordCountItemSetting keyword_1 = new KeywordCountItemSetting();
            keyword_1.Id = "1";
            keyword_1.Name = "Host_Local";
            keyword_1.StringValue = "local";
            keyword_1.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;

            List<KeywordCountItemSetting> lsKeywordCountItemSetting = new List<KeywordCountItemSetting>();
            lsKeywordCountItemSetting.Add(keyword_1);

            //add expected 
            List<AnalyzedCountKeywordItem> expected = new List<AnalyzedCountKeywordItem>();
            target.CountKeyword(lsKeywordCountItemSetting);
            //Assert
            int i = 0;
            Assert.AreEqual(expected.Count, target.CountKeywordBuffer.Count);
            while (i < expected.Count)
            {
                Assert.AreEqual(expected[i].Count, target.CountKeywordBuffer[i].Count);
                Assert.AreEqual(expected[i].Name, target.CountKeywordBuffer[i].Name);
                i++;
            }
        }

        [TestMethod()]
        public void CountKeyWord_3()
        {
            //arrange
            CCSLogsAnalyser target = new CCSLogsAnalyser();

            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "aaaaa";
            item_4.ThreadId = "4";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //add KeywordCountItemSetting List

            KeywordCountItemSetting keyword_1 = new KeywordCountItemSetting();
            keyword_1.Enabled = true;
            keyword_1.Id = "1";
            keyword_1.Name = "Host_Local";
            keyword_1.StringValue = "local";
            keyword_1.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;

            KeywordCountItemSetting keyword_2 = new KeywordCountItemSetting();
            keyword_2.Enabled = true;
            keyword_2.Id = "2";
            keyword_2.Name = "Type_I";
            keyword_2.StringValue = "I";
            keyword_2.LogItem = ConfigValue.CCSHeader.HEADER_TYPE;

            List<KeywordCountItemSetting> lsKeywordCountItemSetting = new List<KeywordCountItemSetting>();
            lsKeywordCountItemSetting.Add(keyword_1);
            lsKeywordCountItemSetting.Add(keyword_2);

            //add expected 
            List<AnalyzedCountKeywordItem> expected = new List<AnalyzedCountKeywordItem>();
            AnalyzedCountKeywordItem analyzeCountKeyWord_1 = new AnalyzedCountKeywordItem();
            analyzeCountKeyWord_1.Name = "Host_Local";
            analyzeCountKeyWord_1.Count = 3;

            AnalyzedCountKeywordItem analyzeCountKeyWord_2 = new AnalyzedCountKeywordItem();
            analyzeCountKeyWord_2.Name = "Type_I";
            analyzeCountKeyWord_2.Count = 3;
            expected.Add(analyzeCountKeyWord_1);
            expected.Add(analyzeCountKeyWord_2);
            //action
            target.CountKeyword(lsKeywordCountItemSetting);
            //Assert
            int i = 0;
            Assert.AreEqual(expected.Count, target.CountKeywordBuffer.Count);
            while (i < expected.Count)
            {
                Assert.AreEqual(expected[i].Count, target.CountKeywordBuffer[i].Count);
                Assert.AreEqual(expected[i].Name, target.CountKeywordBuffer[i].Name);
                i++;
            }
        }
        [TestMethod()]
        public void CountKeyWord_4()
        {
            //arrange
            CCSLogsAnalyser target = new CCSLogsAnalyser();

            CCSLogRecord item_1 = new CCSLogRecord();
            item_1.HostName = "local";
            item_1.ThreadId = "1";
            item_1.Type = "I";
            CCSLogRecord item_2 = new CCSLogRecord();
            item_2.HostName = "local";
            item_2.ThreadId = "2";
            item_2.Type = "I";
            CCSLogRecord item_3 = new CCSLogRecord();
            item_3.HostName = "local";
            item_3.ThreadId = "3";
            item_3.Type = "N";
            CCSLogRecord item_4 = new CCSLogRecord();
            item_4.HostName = "local";
            item_4.ThreadId = "4";
            item_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(item_1);
            lsCCSLogRecord.Add(item_2);
            lsCCSLogRecord.Add(item_3);
            lsCCSLogRecord.Add(item_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);

            //add KeywordCountItemSetting List

            List<KeywordCountItemSetting> lsKeywordCountItemSetting = new List<KeywordCountItemSetting>();

            //add expected 
            List<AnalyzedCountKeywordItem> expected = new List<AnalyzedCountKeywordItem>();

            //action
            target.CountKeyword(lsKeywordCountItemSetting);
            //Assert
            int i = 0;
            Assert.AreEqual(expected.Count, target.CountKeywordBuffer.Count);
            while (i < expected.Count)
            {
                Assert.AreEqual(expected[i].Count, target.CountKeywordBuffer[i].Count);
                Assert.AreEqual(expected[i].Name, target.CountKeywordBuffer[i].Name);
                i++;
            }
        }

        [TestMethod()]
        public void AnalyzeErrorAction_1()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "E";
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            lsCCSLogRecord.Add(record_3);
            lsCCSLogRecord.Add(record_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //Add ErrorActionItem List
            ErrorActionItem error_1 = new ErrorActionItem();
            error_1.ErrorCode = "30101001";
            error_1.ErrorLv = "E";
            List<ErrorActionItem> lsErrorActionItem = new List<ErrorActionItem>();
            lsErrorActionItem.Add(error_1);
            //Add expected List
            AnalyzedErrorActionItem analyzeErrorAction = new AnalyzedErrorActionItem(error_1,record_4);
            List<AnalyzedErrorActionItem> expected = new List<AnalyzedErrorActionItem>();
            expected.Add(analyzeErrorAction);
            ////Action
            target.AnalyzeErrorAction(lsErrorActionItem);
            ////Assert

            Assert.AreEqual(0,target.AnalyzedErrorActionBuffer.Count);
        }

        [TestMethod()]
        public void AnalyzeErrorAction_2()
        {
            //arrange
            //add CssLogRecord List
            var target = new CCSLogsAnalyser();
            var record1 = new CCSLogRecord {Id = "30101001", ThreadId = "1", Type = "E"};
            var record2 = new CCSLogRecord {Id = "123123123", ThreadId = "2", Type = "E"};
            var record3 = new CCSLogRecord {Id = "22301010012222", ThreadId = "3", Type = "N"};
            var record4 = new CCSLogRecord {Id = "10030101001", ThreadId = "4", Type = "I"};
            var record5 = new CCSLogRecord {Id = "30101001", ThreadId = "5", Type = "E"};

            //Set value to _allLogRecordsBuffer
            var lsCcsLogRecord = new List<CCSLogRecord> {record1,record2, record3, record4, record5};
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCcsLogRecord);

            //Add ErrorActionItem List
            var error1 = new ErrorActionItem {ErrorCode = "30101001", ErrorLv = "E"};
            var lsErrorActionItem = new List<ErrorActionItem> {error1};
            var expected = 2;
            ////Action
            target.AnalyzeErrorAction(lsErrorActionItem);
            var actual = target.AnalyzedErrorActionBuffer.Count;
            //Assert
            Assert.AreEqual(expected,actual);
        }
        [TestMethod()]
        public void AnalyzeErrorAction_3()
        {
            //arrange
            //add CssLogRecord List
            var target = new CCSLogsAnalyser();
            var record1 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E" };
            var record2 = new CCSLogRecord { Id = "123123123", ThreadId = "2", Type = "E" };
            var record3 = new CCSLogRecord { Id = "22301010012222", ThreadId = "3", Type = "N" };
            var record4 = new CCSLogRecord { Id = "10030101001", ThreadId = "4", Type = "I" };
            var record5 = new CCSLogRecord { Id = "30101001", ThreadId = "5", Type = "E" };

            //Set value to _allLogRecordsBuffer
            var lsCcsLogRecord = new List<CCSLogRecord> { record1, record2, record3, record4, record5 };
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCcsLogRecord);

            var expected = 0;
            ////Action
            target.AnalyzeErrorAction(null);
            var actual = target.AnalyzedErrorActionBuffer.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void AnalyzeErrorAction_4()
        {
            //arrange
            //add CssLogRecord List
            var target = new CCSLogsAnalyser();
            target.ErrorActionWorker = new BackgroundWorker();
            target.ErrorActionWorker.WorkerSupportsCancellation = true;
            var record1 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E" };
            var record2 = new CCSLogRecord { Id = "123123123", ThreadId = "2", Type = "E" };
            var record3 = new CCSLogRecord { Id = "22301010012222", ThreadId = "3", Type = "N" };
            var record4 = new CCSLogRecord { Id = "10030101001", ThreadId = "4", Type = "I" };
            var record5 = new CCSLogRecord { Id = "30101001", ThreadId = "5", Type = "E" };

            //Set value to _allLogRecordsBuffer
            var lsCcsLogRecord = new List<CCSLogRecord> { record1, record2, record3, record4, record5 };
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCcsLogRecord);

            //Add ErrorActionItem List
            var error1 = new ErrorActionItem { ErrorCode = "30101001", ErrorLv = "E" };
            var lsErrorActionItem = new List<ErrorActionItem> { error1 };
            var expected = 2;
            ////Action
            target.AnalyzeErrorAction(lsErrorActionItem);
            var actual = target.AnalyzedErrorActionBuffer.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void AnalyzeErrorAction_5()
        {
            //arrange
            //add CssLogRecord List
            var target = new CCSLogsAnalyser();
            target.ErrorActionWorker = new BackgroundWorker();
            target.ErrorActionWorker.WorkerSupportsCancellation = true;
            target.ErrorActionWorker.CancelAsync();
            var record1 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E" };
            var record2 = new CCSLogRecord { Id = "123123123", ThreadId = "2", Type = "E" };
            var record3 = new CCSLogRecord { Id = "22301010012222", ThreadId = "3", Type = "N" };
            var record4 = new CCSLogRecord { Id = "10030101001", ThreadId = "4", Type = "I" };
            var record5 = new CCSLogRecord { Id = "30101001", ThreadId = "5", Type = "E" };

            //Set value to _allLogRecordsBuffer
            var lsCcsLogRecord = new List<CCSLogRecord> { record1, record2, record3, record4, record5 };
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCcsLogRecord);

            //Add ErrorActionItem List
            var error1 = new ErrorActionItem { ErrorCode = "30101001", ErrorLv = "E" };
            var lsErrorActionItem = new List<ErrorActionItem> { error1 };
            var expected = 0;
            ////Action
            target.AnalyzeErrorAction(lsErrorActionItem);
            var actual = target.AnalyzedErrorActionBuffer.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        ///// <summary>
        /////A test for AnalyzeErrorAction
        /////Case:one  Record and more than one Error is match
        /////</summary>
        //[TestMethod()]
        //public void AnalyzeErrorAction_3()
        //{
        //    //arrange
        //    //add CssLogRecord List
        //    CCSLogsAnalyser target = new CCSLogsAnalyser(); 
        //    CCSLogRecord record_1 = new CCSLogRecord();
        //    record_1.Id = "12123123";
        //    record_1.ThreadId = "1";
        //    record_1.Type = "I";
        //    CCSLogRecord record_2 = new CCSLogRecord();
        //    record_2.Id = "123123123";
        //    record_2.ThreadId = "2";
        //    record_2.Type = "I";
        //    CCSLogRecord record_3 = new CCSLogRecord();
        //    record_3.Id = "123123123";
        //    record_3.ThreadId = "3";
        //    record_3.Type = "N";
        //    CCSLogRecord record_4 = new CCSLogRecord();
        //    record_4.Id = "10030101001";
        //    record_4.ThreadId = "4";
        //    record_4.Type = "I";

        //    //Set value to _allLogRecordsBuffer
        //    List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
        //    lsCCSLogRecord.Add(record_1);
        //    lsCCSLogRecord.Add(record_2);
        //    lsCCSLogRecord.Add(record_3);
        //    lsCCSLogRecord.Add(record_4);
        //    var privateObject = new PrivateObject(target);
        //    privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

        //    //Add ErrorActionItem List
        //    ErrorActionItem error_1 = new ErrorActionItem();
        //    error_1.ErrorCode = "1003";
        //    ErrorActionItem error_2 = new ErrorActionItem();
        //    error_2.ErrorCode = "0301";
        //    List<ErrorActionItem> lsErrorActionItem = new List<ErrorActionItem>();
        //    lsErrorActionItem.Add(error_1);
        //    lsErrorActionItem.Add(error_2);
        //    //Add expected List
        //    AnalyzedErrorActionItem analyzeErrorAction_1 = new AnalyzedErrorActionItem(error_1,record_4);
        //    AnalyzedErrorActionItem analyzeErrorAction_2 = new AnalyzedErrorActionItem(error_2,record_4);
        //    List<AnalyzedErrorActionItem> expected = new List<AnalyzedErrorActionItem>();
        //    expected.Add(analyzeErrorAction_1);
        //    expected.Add(analyzeErrorAction_2);
        //    ////Action
        //    target.AnalyzeErrorAction(lsErrorActionItem);
        //    ////Assert
        //    int i = 0;
        //    Assert.AreEqual(expected.Count, target.AnalyzedErrorActionBuffer.Count);
        //    while (i < expected.Count)
        //    {
        //        Assert.AreEqual(expected[i].ErrorCode, target.AnalyzedErrorActionBuffer[i].ErrorCode);
        //        Assert.AreEqual(expected[i].Date, target.AnalyzedErrorActionBuffer[i].Date);
        //        Assert.AreEqual(expected[i].Line, target.AnalyzedErrorActionBuffer[i].Line);
        //        Assert.AreEqual(expected[i].Message, target.AnalyzedErrorActionBuffer[i].Message);
        //        Assert.AreEqual(expected[i].Recipe, target.AnalyzedErrorActionBuffer[i].Recipe);
        //        Assert.AreEqual(expected[i].Time, target.AnalyzedErrorActionBuffer[i].Time);
        //        i++;
        //    }
        //}

        ///// <summary>
        /////A test for AnalyzeErrorAction
        /////Case:more than one  Record and more than one Error is match
        /////</summary>
        //[TestMethod()]
        //public void AnalyzeErrorAction_4()
        //{
        //    //arrange
        //    //add CssLogRecord List
        //    CCSLogsAnalyser target = new CCSLogsAnalyser(); 
        //    CCSLogRecord record_1 = new CCSLogRecord();
        //    record_1.Id = "121212";
        //    record_1.ThreadId = "1";
        //    record_1.Type = "F";
        //    CCSLogRecord record_2 = new CCSLogRecord();
        //    record_2.Id = "1003";
        //    record_2.ThreadId = "1003";
        //    record_2.Type = "E";
        //    CCSLogRecord record_3 = new CCSLogRecord();
        //    record_3.Id = "10030301";
        //    record_3.ThreadId = "3";
        //    record_3.Type = "W";
        //    CCSLogRecord record_4 = new CCSLogRecord();
        //    record_4.Id = "10030101001";
        //    record_4.ThreadId = "4";
        //    record_4.Type = "W";

        //    //Set value to _allLogRecordsBuffer
        //    List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
        //    lsCCSLogRecord.Add(record_1);
        //    lsCCSLogRecord.Add(record_2);
        //    lsCCSLogRecord.Add(record_3);
        //    lsCCSLogRecord.Add(record_4);
        //    var privateObject = new PrivateObject(target);
        //    privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

        //    //Add ErrorActionItem List
        //    ErrorActionItem error_1 = new ErrorActionItem();
        //    error_1.ErrorCode = "1003";
        //    error_1.ErrorLv = "E";
        //    ErrorActionItem error_2 = new ErrorActionItem();
        //    error_2.ErrorCode = "0301";
        //    error_2.ErrorLv = "W";
        //    List<ErrorActionItem> lsErrorActionItem = new List<ErrorActionItem>();
        //    lsErrorActionItem.Add(error_1);
        //    lsErrorActionItem.Add(error_2);
        //    //Add expected List
        //    AnalyzedErrorActionItem analyzeErrorAction_1 = new AnalyzedErrorActionItem(error_1,record_2);
        //    List<AnalyzedErrorActionItem> expected = new List<AnalyzedErrorActionItem>();
        //    expected.Add(analyzeErrorAction_1);
        //    //Action
        //    target.AnalyzeErrorAction(lsErrorActionItem);
        //    ////Assert

        //    int i = 0;
        //    Assert.AreEqual(expected.Count, target.AnalyzedErrorActionBuffer.Count);
        //    while (i < expected.Count)
        //    {
        //        Assert.AreEqual(expected[i].ErrorCode, target.AnalyzedErrorActionBuffer[i].ErrorCode);
        //        Assert.AreEqual(expected[i].Date, target.AnalyzedErrorActionBuffer[i].Date);
        //        Assert.AreEqual(expected[i].Line, target.AnalyzedErrorActionBuffer[i].Line);
        //        Assert.AreEqual(expected[i].Message, target.AnalyzedErrorActionBuffer[i].Message);
        //        Assert.AreEqual(expected[i].Recipe, target.AnalyzedErrorActionBuffer[i].Recipe);
        //        Assert.AreEqual(expected[i].Time, target.AnalyzedErrorActionBuffer[i].Time);
        //        i++;
        //    }
        //}


        [TestMethod()]
        public void AnalyzeUserAction_1()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser(); 
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "I";
            record_1.Content = "Workflow :  login_Loginasdasdasdasd";
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            record_2.Content = "a";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            record_3.Content = "b";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";
            record_4.Content = "csa";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            lsCCSLogRecord.Add(record_3);
            lsCCSLogRecord.Add(record_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //Add ErrorActionItem List
            UserActionItem userActionItem_1 = new UserActionItem();
            userActionItem_1.RefSystemLog = "Workflow :  login_Login";
            List<UserActionItem> lsUserActionItem = new List<UserActionItem>();
            lsUserActionItem.Add(userActionItem_1);
            //Add expected List
            AnalyzedUserActionItem analyzeUserAction = new AnalyzedUserActionItem(userActionItem_1,record_1);
            List<AnalyzedUserActionItem> expected = new List<AnalyzedUserActionItem>();
            expected.Add(analyzeUserAction);
            ////Action
            target.AnalyzeUserAction(lsUserActionItem);
            ////Assert

            int i = 0;
            Assert.AreEqual(expected.Count, target.AnalyzedUserActionBuffer.Count);
            while (i < expected.Count)
            {
                Assert.AreEqual(expected[i].UserAction, target.AnalyzedUserActionBuffer[i].UserAction);
                Assert.AreEqual(expected[i].Date, target.AnalyzedUserActionBuffer[i].Date);
                Assert.AreEqual(expected[i].Line, target.AnalyzedUserActionBuffer[i].Line);
                Assert.AreEqual(expected[i].Time, target.AnalyzedUserActionBuffer[i].Time);
                i++;
            }
        }
        [TestMethod()]
        public void AnalyzeUserAction_5()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            target.AnalyzeUserActionWorker = new BackgroundWorker();
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "I";
            record_1.Content = "Workflow :  login_Loginasdasdasdasd";
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            record_2.Content = "a";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            record_3.Content = "b";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";
            record_4.Content = "csa";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            lsCCSLogRecord.Add(record_3);
            lsCCSLogRecord.Add(record_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //Add ErrorActionItem List
            UserActionItem userActionItem_1 = new UserActionItem();
            userActionItem_1.RefSystemLog = "Workflow :  login_Login";
            List<UserActionItem> lsUserActionItem = new List<UserActionItem>();
            lsUserActionItem.Add(userActionItem_1);
            //Add expected List
            AnalyzedUserActionItem analyzeUserAction = new AnalyzedUserActionItem(userActionItem_1,record_1);
            List<AnalyzedUserActionItem> expected = new List<AnalyzedUserActionItem>();
            expected.Add(analyzeUserAction);
            ////Action
            target.AnalyzeUserAction(lsUserActionItem);
            ////Assert

            int i = 0;
            Assert.AreEqual(expected.Count, target.AnalyzedUserActionBuffer.Count);
            while (i < expected.Count)
            {
                Assert.AreEqual(expected[i].UserAction, target.AnalyzedUserActionBuffer[i].UserAction);
                Assert.AreEqual(expected[i].Date, target.AnalyzedUserActionBuffer[i].Date);
                Assert.AreEqual(expected[i].Line, target.AnalyzedUserActionBuffer[i].Line);
                Assert.AreEqual(expected[i].Time, target.AnalyzedUserActionBuffer[i].Time);
                i++;
            }
        }
        [TestMethod()]
        public void AnalyzeUserAction_6()
        {
            //arrange
            //add CssLogRecord List
            var target = new CCSLogsAnalyser();
            target.AnalyzeUserActionWorker = new BackgroundWorker();
            var record1 = new CCSLogRecord
            {
                Id = "12123123",
                ThreadId = "5",
                Type = "I",
                Content = "Workflow :  login_Loginasdasdasdasd",
                DateTime = DateTime.Parse("2014/10/11 10:10:10.500")
            };
            var record2 = new CCSLogRecord {Id = "123123123", ThreadId = "2", Type = "I", Content = "a"};
            var record3 = new CCSLogRecord();
            record3.Id = "123123";
            record3.ThreadId = "3";
            record3.Type = "N";
            record3.Content = "b";
            var record4 = new CCSLogRecord {Id = "10030101001", ThreadId = "4", Type = "I", Content = "csa"};
            var record5 = new CCSLogRecord{Id = "12123123",
            ThreadId = "5",
            Type = "I",
            Content = "Workflow :  login_Loginasdasdasdasd",
            DateTime = DateTime.Parse("2014/10/10 10:10:10.400")};
            

            //Set value to _allLogRecordsBuffer
            var lsCcsLogRecord = new List<CCSLogRecord> {record1, record2, record3, record4, record5};
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCcsLogRecord);

            //Add ErrorActionItem List
            var userActionItem1 = new UserActionItem {RefSystemLog = "Workflow :  login_Login"};
            var lsUserActionItem = new List<UserActionItem> {userActionItem1};
            //Add expected List
            var analyzeUserAction = new AnalyzedUserActionItem(userActionItem1, record1);
            var expected = new List<AnalyzedUserActionItem> {analyzeUserAction};
            ////Action
            target.AnalyzeUserAction(lsUserActionItem);

            Assert.AreEqual(2,target.AnalyzedUserActionBuffer.Count);
        }
        [TestMethod()]
        public void AnalyzeUserAction_2()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            target.AnalyzeUserActionWorker = new BackgroundWorker();
            ////Action
            target.AnalyzeUserAction(null);
            ////Assert

            Assert.AreEqual(0, target.AnalyzedUserActionBuffer.Count);
        }
        [TestMethod()]
        public void AnalyzeUserAction_3()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            target.AnalyzeUserActionWorker = new BackgroundWorker();
            target.AnalyzeUserActionWorker.WorkerSupportsCancellation=true;
            target.AnalyzeUserActionWorker.CancelAsync();
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "I";
            record_1.Content = "Workflow :  login_Loginasdasdasdasd";
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            record_2.Content = "a";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            record_3.Content = "b";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";
            record_4.Content = "csa";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            lsCCSLogRecord.Add(record_3);
            lsCCSLogRecord.Add(record_4);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //Add ErrorActionItem List
            UserActionItem userActionItem_1 = new UserActionItem();
            userActionItem_1.RefSystemLog = "Workflow :  login_Login";
            List<UserActionItem> lsUserActionItem = new List<UserActionItem>();
            lsUserActionItem.Add(userActionItem_1);
            //Add expected List
            AnalyzedUserActionItem analyzeUserAction = new AnalyzedUserActionItem(userActionItem_1, record_1);
            List<AnalyzedUserActionItem> expected = new List<AnalyzedUserActionItem>();
            expected.Add(analyzeUserAction);
            ////Action
            target.AnalyzeUserAction(lsUserActionItem);
            ////Assert

            int i = 0;
            Assert.AreEqual(0, target.AnalyzedUserActionBuffer.Count);
        }




        #region GetRecordFileName Test case
        /// <summary>
        ///A test for GetRecordFileName
        ///Case:one FileName and one Record is match
        ///</summary>
        [TestMethod()]
        public void GetRecordFileName_1()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "I";
            record_1.Content = "Workflow :  login_Loginasdasdasdasd";
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            record_2.Content = "a";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            record_3.Content = "b";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";
            record_4.Content = "csa";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            
            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            lsCCSLogRecord.Add(record_3);
            lsCCSLogRecord.Add(record_4);
            Dictionary<string, List<CCSLogRecord>> dicFileName = new Dictionary<string, List<CCSLogRecord>>();
            dicFileName.Add("aaa", lsCCSLogRecord);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);
            privateObject.SetField("_allLogRecordsBufferWithFileName", dicFileName);
            //Add ErrorActionItem List
            Assert.AreEqual("aaa", target.GetRecordFileName(record_1));
        }

        /// <summary>
        ///A test for GetRecordFileName
        ///Case: Record is null will return file name empty
        ///</summary>
        [TestMethod()]
        public void GetRecordFileName_2()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();
            Dictionary<string, List<CCSLogRecord>> dicFileName = new Dictionary<string, List<CCSLogRecord>>();
            dicFileName.Add("aaa", lsCCSLogRecord);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);
            privateObject.SetField("_allLogRecordsBufferWithFileName", dicFileName);
            //Add ErrorActionItem List
            Assert.AreEqual(String.Empty, target.GetRecordFileName(null));
        }

        /// <summary>
        ///A test for GetRecordFileName
        ///Case:one return more file name
        ///</summary>
        [TestMethod()]
        public void GetRecordFileName_3()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "I";
            record_1.Content = "Workflow :  login_Loginasdasdasdasd";
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            record_2.Content = "a";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            record_3.Content = "b";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";
            record_4.Content = "csa";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();

            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            List<CCSLogRecord> lsCCSLogRecord1 = new List<CCSLogRecord>();

            lsCCSLogRecord1.Add(record_3);
            lsCCSLogRecord1.Add(record_4);
            Dictionary<string, List<CCSLogRecord>> dicFileName = new Dictionary<string, List<CCSLogRecord>>();
            dicFileName.Add("aaa", lsCCSLogRecord);
            dicFileName.Add("bbb", lsCCSLogRecord1);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);
            privateObject.SetField("_allLogRecordsBufferWithFileName", dicFileName);
            //Add ErrorActionItem List
            Assert.AreEqual("aaa, bbb", target.GetRecordFileName(record_1));
        }
        #endregion

        #region CanMerge Test case
        /// <summary>
        ///A test for CanMerge
        ///Case: not merge file memo
        ///</summary>
        [TestMethod()]
        public void CanMerge_1()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_isMemoLoaded", true);
            //Add ErrorActionItem List
            Assert.AreEqual(false, target.CanMerge(""));
        }
        /// <summary>
        ///A test for CanMerge
        ///Case: not memo file, file not valid
        ///</summary>
        [TestMethod()]
        public void CanMerge_2()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_isMemoLoaded", false);
            //Add ErrorActionItem List
            Assert.AreEqual(false, target.CanMerge("aaaa.xml"));
        }

        /// <summary>
        ///A test for CanMerge
        ///Case: can load file,not memo file, file extencion valid
        ///</summary>
        [TestMethod()]
        public void CanMerge_3()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_isMemoLoaded", false);
            //Add ErrorActionItem List
            Assert.AreEqual(true, target.CanMerge("aaaa.txt"));
        }
        #endregion

        #region AllLogRecordsFilePaths Test case
        /// <summary>
        ///A test for AllLogRecordsFilePaths
        ///Case:get all FileName
        ///</summary>
        [TestMethod()]
        public void AllLogRecordsFilePaths_1()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "I";
            record_1.Content = "Workflow :  login_Loginasdasdasdasd";
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            record_2.Content = "a";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            record_3.Content = "b";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";
            record_4.Content = "csa";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();

            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            lsCCSLogRecord.Add(record_3);
            lsCCSLogRecord.Add(record_4);

            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBuffer", lsCCSLogRecord);
            //Add ErrorActionItem List
            Assert.AreEqual(lsCCSLogRecord[0], target.AllLogRecordsBuffer[0]);
        }

        #endregion

        #region AllLogRecordsBuffer Test case
        /// <summary>
        ///A test for AllLogRecordsBuffer
        ///Case:get all FileName
        ///</summary>
        [TestMethod()]
        public void AllLogRecordsBuffer_1()
        {
            //arrange
            //add CssLogRecord List
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "I";
            record_1.Content = "Workflow :  login_Loginasdasdasdasd";
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            record_2.Content = "a";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            record_3.Content = "b";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";
            record_4.Content = "csa";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();

            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            lsCCSLogRecord.Add(record_3);
            lsCCSLogRecord.Add(record_4);
            Dictionary<string, List<CCSLogRecord>> dicFileName = new Dictionary<string, List<CCSLogRecord>>();
            dicFileName.Add("aaa", lsCCSLogRecord);
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_allLogRecordsBufferWithFileName", dicFileName);
            //Add ErrorActionItem List
            Assert.AreEqual("aaa", target.AllLogRecordsFilePaths[0]);
        }

   
        #endregion

        #region ClearOldValue
        /// <summary>
        ///A test for ClearOldValue
        ///Case:
        ///</summary>
        [TestMethod()]
        public void ClearOldValue_1()
        {

            CCSLogsAnalyser target = new CCSLogsAnalyser();
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "I";
            record_1.Content = "Workflow :  login_Loginasdasdasdasd";
            record_1.DateTime = DateTime.Parse("2013/10/02 13:36:47.049");
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            record_2.Content = "aaaa :  login_Loginasdasdasdasd";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            record_3.Content = "Workflow :  login_Loginasdasdasdasd";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";
            record_4.Content = "Workflow :  login_Loginasdasdasdasd";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();

            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            List<CCSLogRecord> lsCCSLogRecord1 = new List<CCSLogRecord>();

            lsCCSLogRecord1.Add(record_3);
            lsCCSLogRecord1.Add(record_4);
            BackgroundWorker AnalyzePatternWorker = new BackgroundWorker();
            target.AnalyzePatternWorker = AnalyzePatternWorker;
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);
            target.ClearOldValue(true);
            Assert.AreEqual(0, target.FilteredLogRecordsBuffer.Count);
        }
        /// <summary>
        ///A test for ClearOldValue
        ///Case:
        ///</summary>
        [TestMethod()]
        public void ClearOldValue_2()
        {

            CCSLogsAnalyser target = new CCSLogsAnalyser();
            CCSLogRecord record_1 = new CCSLogRecord();
            record_1.Id = "12123123";
            record_1.ThreadId = "1";
            record_1.Type = "I";
            record_1.Content = "Workflow :  login_Loginasdasdasdasd";
            record_1.DateTime = DateTime.Parse("2013/10/02 13:36:47.049");
            CCSLogRecord record_2 = new CCSLogRecord();
            record_2.Id = "123123123";
            record_2.ThreadId = "2";
            record_2.Type = "I";
            record_2.Content = "aaaa :  login_Loginasdasdasdasd";
            CCSLogRecord record_3 = new CCSLogRecord();
            record_3.Id = "123123";
            record_3.ThreadId = "3";
            record_3.Type = "N";
            record_3.Content = "Workflow :  login_Loginasdasdasdasd";
            CCSLogRecord record_4 = new CCSLogRecord();
            record_4.Id = "10030101001";
            record_4.ThreadId = "4";
            record_4.Type = "I";
            record_4.Content = "Workflow :  login_Loginasdasdasdasd";

            //Set value to _allLogRecordsBuffer
            List<CCSLogRecord> lsCCSLogRecord = new List<CCSLogRecord>();

            lsCCSLogRecord.Add(record_1);
            lsCCSLogRecord.Add(record_2);
            List<CCSLogRecord> lsCCSLogRecord1 = new List<CCSLogRecord>();

            lsCCSLogRecord1.Add(record_3);
            lsCCSLogRecord1.Add(record_4);
            BackgroundWorker AnalyzePatternWorker = new BackgroundWorker();
            target.AnalyzePatternWorker = AnalyzePatternWorker;
            var privateObject = new PrivateObject(target);
            privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);
            target.ClearOldValue(false);
            Assert.AreEqual(0, target.FilteredLogRecordsBuffer.Count);
        }
        #endregion


        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LoadMemoLogFile_2()
        {
            string textUser =
@"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea></CommentArea><BookmarkArea></BookmarkArea><LogArea TotalLine='0'>
2013/10/02 13:36:38.305
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadMemoLogFile_2{0}.xml", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            CCSLogsAnalyser target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadMemoLogFile(fileFullPath);
            Assert.AreEqual(0, target.FilteredLogRecordsBuffer.Count);
                File.Delete(fileFullPath);
        }
        [TestMethod()]
        [ExpectedException(typeof (Exception))]
        public void LoadMemoLogFile_3()
        {

            CCSLogsAnalyser target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadMemoLogFile("MemoCCSsssss.xml");
            Assert.AreEqual(0, target.FilteredLogRecordsBuffer.Count);
        }

        [TestMethod()]
        public void LoadLogFile_2()
        {
            string text = @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea /><BookmarkArea><Bookmark Id='0' Line='8' /><Bookmark Id='1' Line='9' /><Bookmark Id='2' Line='12' /><Bookmark Id='3' Line='14' /><Bookmark Id='4' Line='10' /></BookmarkArea><LogArea TotalLine='2774'>2013-10-02 13:36:37.095,A-2013-P49540,,0001,W,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######,,,Logging.LogManager
2013-10-02 13:36:38.305,A-2013-P49540,,0001,D,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2013-10-02 13:36:38.306,A-2013-P49540,,0001,F,020200017,Workflow : ExamFacade.GetInstance : 38.305,,,WorkflowLibrary.Workflow
2013-10-02 13:36:38.307,A-2013-P49540,,0001,E,020200005,Configflow : facade.GetSystemInfoModelName : 38.307,,,WorkflowLibrary.Configflow
2013-10-02 13:36:38.308,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>
";

            string filename = string.Format("LoadLogFile_2{0}.txt", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            CCSLogsAnalyser target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadLogFile(fullPathName, false);
            Assert.AreEqual(4, target.AllLogRecordsBuffer.Count);
            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void WriteMemoTest1()
        {
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            string file = Path.GetFullPath("CCS20131002.txt");
            target.LoadLogFile(file,false);

            string filename = string.Format("{0}.xml", DateTime.Now.GetHashCode());
            string fullPathName = Path.GetFullPath(filename);
            target.WriteMemo(fullPathName);

            Assert.IsTrue(File.Exists(fullPathName));
            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void WriteMemoTest2()
        {
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            string file = Path.GetFullPath("CCS20131002.txt");
            target.LoadLogFile(file, false);
            bool actual = target.WriteMemo(string.Empty);
            
            bool expected = false;
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetColumnContentValueTest1()
        {
            CCSLogRecord ccsLog = new CCSLogRecord{Id = "1", Content = "abc", Line = 1};
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnContentValue", new object[] {ccsLog});
            var expected = "abc";
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void GetColumnContentValueTest2()
        {
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnContentValue", new object[] { null });
            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest1()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1 };
            string logItem = "Content";
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog,logItem });
            var expected = "abc";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest2()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1 };
            string logItem = "Content";
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { null, logItem });
            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest3()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1 };
            string logItem = ConfigValue.CCSHeader.HEADER_LINE;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = "1";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest4()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1,DateTime =DateTime.Parse("2014/10/20 10:10:10.400")};
            string logItem = ConfigValue.CCSHeader.HEADER_DATE;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.Date;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest5()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1, DateTime =DateTime.Parse("2014/10/20 10:10:10.400") };
            string logItem = ConfigValue.CCSHeader.HEADER_TIME;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.Time;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest6()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/20 10:10:10.400"),ThreadId = "abc"};
            string logItem = ConfigValue.CCSHeader.HEADER_THREADID;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.ThreadId;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest7()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/20 10:10:10.400"), ThreadId = "abc" ,};
            string logItem = ConfigValue.CCSHeader.HEADER_ID;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.Id;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest8()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/20 10:10:10.400"), ThreadId = "abc",
                AdditionalInfo = "abc"};
            string logItem = ConfigValue.CCSHeader.HEADER_ADDITIONINFO;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.AdditionalInfo;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest9()
        {
            CCSLogRecord ccsLog = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime = DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo ="abc"
            };
            string logItem = ConfigValue.CCSHeader.HEADER_PERSONALINFO;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.PersonalInfo;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest10()
        {
            CCSLogRecord ccsLog = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime =DateTime.Parse( "2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo ="abc",
                ClassName = "abc"

            };
            string logItem = ConfigValue.CCSHeader.HEADER_CLASSNAME;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.ClassName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest11()
        {
            CCSLogRecord ccsLog = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime = DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc",
                ClassName = "abc",
                Mode = "abc"

            };
            string logItem = ConfigValue.CCSHeader.HEADER_MODE;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.Mode;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest12()
        {
            CCSLogRecord ccsLog = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime =DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc",
                ClassName = "abc",
                Mode = "abc"

            };
            string logItem = ConfigValue.CCSHeader.HEADER_COMMENT;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest13()
        {
            CCSLogRecord ccsLog = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime = DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc",
                ClassName = "abc",
                Mode = "abc"

            };
            string logItem = ConfigValue.CCSHeader.HEADER_COMMENT;
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            target.Comments.Add(ccsLog,"abc");
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = "abc";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest14()
        {
            CCSLogRecord ccsLog = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime = DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc",
                ClassName = "abc",
                Mode = "abc"

            };
            string logItem = "abc";
            CCSLogsAnalyser target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }
    }
}
