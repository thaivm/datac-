using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Business;
using LogViewer.Model;
using System.ComponentModel;
using System.IO;
using System.Collections.ObjectModel;
using Moq;
using Moq.Protected;
namespace LogViewer.Tests.Business
{
    [TestClass]
    public class BaseLogsAnalyserTest
    {

        [TestMethod()]
        public void FilterTest1()
        {
            //arrange
            //add CssLogRecord List
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void FilterTest2()
        {
            //arrange
            //add CssLogRecord List
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void FilterTest3()
        {
            //arrange
            //add CssLogRecord List
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void FilterTest4()
        {
            //arrange
            //add CssLogRecord List
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void FilterTest5()
        {
            //arrange
            //add CssLogRecord List
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void SearchKeyWord1()
        {
            //arrange
            //add CssLogRecord List
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void SearchKeyWord2()
        {
            //arrange
            //add CssLogRecord List
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void SearchKeyWord3()
        {
            //arrange
            //add CssLogRecord List
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void SearchKeyWord4()
        {
            //arrange
            //add CssLogRecord List
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void SearchKeyWord5()
        {
            //arrange
            //add CssLogRecord List
            BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
            //var privateObject = new PrivateObject(target);
          //  privateObject.SetField("_filteredLogRecordsBuffer", lsCCSLogRecord);

            //define SearchItem object
            SearchItem key = new SearchItem();
            key.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;
            key.StringValue = "xxxx";
            //add expected List
            List<BaseLogRecord> expected = new List<BaseLogRecord>();
            //action
            target.SearchKeyword(key);
            CollectionAssert.AreEqual(expected, target.SearchKeywordBuffer);
        }
        [TestMethod()]
        public void SearchKeyWord6()
        {
            //arrange
            //add CssLogRecord List
            BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
              privateObject.SetField("_filteredLogRecordsBuffer", null);

            //define SearchItem object
            SearchItem key = new SearchItem();
            key.LogItem = ConfigValue.CCSHeader.HEADER_HOSTNAME;
            key.StringValue = "xxxx";
            //add expected List
            List<BaseLogRecord> expected = new List<BaseLogRecord>();
            //action
            target.SearchKeyword(key);
            CollectionAssert.AreEqual(expected, target.SearchKeywordBuffer);
        }
        [TestMethod()]
        public void CountKeyWord1()
        {
            //arrange
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

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
        public void CountKeyWord2()
        {
            //arrange
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void CountKeyWord3()
        {
            //arrange
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void CountKeyWord4()
        {
            //arrange
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

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
        public void CountKeyWord5()
        {
            //arrange
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

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
        public void CountKeyWord6()
        {
            //arrange
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

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
        public void CountKeyWord7()
        {
            //arrange
            BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            BackgroundWorker KeywordCountWorker = new BackgroundWorker();
            KeywordCountWorker.WorkerSupportsCancellation = true;
            target.KeywordCountWorker = KeywordCountWorker;
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
            target.KeywordCountWorker.CancelAsync();
            target.CountKeyword(lsKeywordCountItemSetting);

            //Assert
            int i = 0;
            Assert.AreEqual(0, target.CountKeywordBuffer.Count);
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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

             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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

             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
        public void LoadMemoLogFile_1()
        {
            string textUser =
@"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea></CommentArea><BookmarkArea></BookmarkArea><LogArea TotalLine='0'>
2013/10/02 13:36:37.095, A-2013-P49540, 0001, W, 060100001, ###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager
2013/10/02 13:36:38.305, A-2013-P49540, 0001, D, 030101001, G->F CALL [GetInstance()], , , Exam.ExamFacade
2013/10/02 13:36:38.306, A-2013-P49540, 0001, F, 020200017, Workflow : ExamFacade.GetInstance : 38.305, , , WorkflowLibrary.Workflow
2013/10/02 13:36:38.307, A-2013-P49540, 0001, E, 020200005, Configflow : facade.GetSystemInfoModelName : 38.307, , , WorkflowLibrary.Configflow
2013/10/02 13:36:38.308, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetSystemInfoModelName()], , , Exam.ExamFacade
2013/10/02 13:36:38.495, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 38.491, , , WindowLibrary.WindowUtility
2013/10/02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("LoadMemoLogFile_1{0}.xml", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadMemoLogFile(fileFullPath);
            Assert.AreEqual(10, target.AllLogRecordsBuffer.Count);
            File.Delete(fileFullPath);
        }
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

             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadMemoLogFile(fileFullPath);
            Assert.AreEqual(0, target.FilteredLogRecordsBuffer.Count);
            File.Delete(fileFullPath);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LoadMemoLogFile_3()
        {

             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadMemoLogFile("MemoCCSsssss.xml");
            Assert.AreEqual(0, target.FilteredLogRecordsBuffer.Count);
        }

        [TestMethod()]
        public void LoadMemoLogFile_4()
        {
            string text = @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea /><BookmarkArea><Bookmark Id='0' Line='8' /><Bookmark Id='1' Line='9' /><Bookmark Id='2' Line='12' /><Bookmark Id='3' Line='14' /><Bookmark Id='4' Line='10' /></BookmarkArea><LogArea TotalLine='2774'>2013-10-02 13:36:37.095,A-2013-P49540,,0001,W,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######,,,Logging.LogManager
2013-10-02 13:36:38.305,A-2013-P49540,,0001,D,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2013-10-02 13:36:38.306,A-2013-P49540,,0001,F,020200017,Workflow : ExamFacade.GetInstance : 38.305,,,WorkflowLibrary.Workflow
2013-10-02 13:36:38.307,A-2013-P49540,,0001,E,020200005,Configflow : facade.GetSystemInfoModelName : 38.307,,,WorkflowLibrary.Configflow
2013-10-02 13:36:38.308,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>
";

            string filename = string.Format("LoadMemoLogFile_4{0}.xml", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadLogFile(fullPathName, false);
            Assert.AreEqual(5, target.AllLogRecordsBuffer.Count);
            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void LoadLogFile1()
        {
            string text = @"
2013/10/02 13:36:37.095, A-2013-P49540, 0001, W, 060100001, ###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager
2013/10/02 13:36:38.305, A-2013-P49540, 0001, D, 030101001, G->F CALL [GetInstance()], , , Exam.ExamFacade
2013/10/02 13:36:38.306, A-2013-P49540, 0001, F, 020200017, Workflow : ExamFacade.GetInstance : 38.305, , , WorkflowLibrary.Workflow
2013/10/02 13:36:38.307, A-2013-P49540, 0001, E, 020200005, Configflow : facade.GetSystemInfoModelName : 38.307, , , WorkflowLibrary.Configflow
2013/10/02 13:36:38.308, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetSystemInfoModelName()], , , Exam.ExamFacade
2013/10/02 13:36:38.495, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 38.491, , , WindowLibrary.WindowUtility
2013/10/02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
";

            string filename = string.Format("LoadLogFile_1{0}.txt", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadLogFile(fullPathName, true);
            Assert.AreEqual(10, target.AllLogRecordsBuffer.Count);
            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void LoadLogFile2()
        {
            string text = "2013/20/02 13:36:37.095, \0A-2013-P49540, 0001, W, 060100001, \0###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager";

            string filename = string.Format("LoadLogFile_2{0}.txt", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadLogFile(fullPathName, true);
            Assert.AreEqual(0, target.AllLogRecordsBuffer.Count);
            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void LoadLogFile3()
        {
            string text = @"
2013/10/02 13:36:37.095, A-2013-P49540, 0001, W, 060100001, ###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager
2013/10/02 13:36:38.305, A-2013-P49540, 0001, D, 030101001, G->F CALL [GetInstance()], , , Exam.ExamFacade
2013/10/02 13:36:38.306, A-2013-P49540, 0001, F, 020200017, Workflow : ExamFacade.GetInstance : 38.305, , , WorkflowLibrary.Workflow
2013/10/02 13:36:38.307, A-2013-P49540, 0001, E, 020200005, Configflow : facade.GetSystemInfoModelName : 38.307, , , WorkflowLibrary.Configflow
2013/10/02 13:36:38.308, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetSystemInfoModelName()], , , Exam.ExamFacade
2013/10/02 13:36:38.495, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 38.491, , , WindowLibrary.WindowUtility
2013/10/02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
";

            string filename = string.Format("LoadLogFile_3{0}.txt", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadLogFile(fullPathName, true);
            Assert.AreEqual(10, target.AllLogRecordsBuffer.Count);
            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void LoadLogFile4()
        {
            string text = @"
2013/10/02 13:36:37.095, A-2013-P49540, 0001, W, 060100001, ###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager
2013/10/02 13:36:38.306, A-2013-P49540, 0001, F, 020200017, Workflow : ExamFacade.GetInstance : 38.305, , , WorkflowLibrary.Workflow
2013/10/02 13:36:38.305, A-2013-P49540, 0001, D, 030101001, G->F CALL [GetInstance()], , , Exam.ExamFacade
2013/10/02 13:36:38.307, A-2013-P49540, 0001, E, 020200005, Configflow : facade.GetSystemInfoModelName : 38.307, , , WorkflowLibrary.Configflow
2013/10/02 13:36:38.308, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetSystemInfoModelName()], , , Exam.ExamFacade
2013/10/02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013/10/02 13:36:38.495, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 38.491, , , WindowLibrary.WindowUtility
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
";

            string filename = string.Format("LoadLogFile_4{0}.txt", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();

            var privateObject = new PrivateObject(target);
            target.LoadLogFile(fullPathName, true);
            Assert.AreEqual(10, target.AllLogRecordsBuffer.Count);
            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void LoadLogFile5()
        {
            string text = @"
2013/10/02 13:36:37.095, A-2013-P49540, 0001, W, 060100001, ###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager
2013/10/02 13:36:38.306, A-2013-P49540, 0001, F, 020200017, Workflow : ExamFacade.GetInstance : 38.305, , , WorkflowLibrary.Workflow
2013/10/02 13:36:38.305, A-2013-P49540, 0001, D, 030101001, G->F CALL [GetInstance()], , , Exam.ExamFacade
2013/10/02 13:36:38.307, A-2013-P49540, 0001, E, 020200005, Configflow : facade.GetSystemInfoModelName : 38.307, , , WorkflowLibrary.Configflow
2013/10/02 13:36:38.308, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetSystemInfoModelName()], , , Exam.ExamFacade
2013/10/02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013/10/02 13:36:38.495, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 38.491, , , WindowLibrary.WindowUtility
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
";

            string filename = string.Format("LoadLogFile5{0}.txt", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            //BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            var mockBase = new Mock<BaseLogsAnalyser<CCSLogRecord>>();
            var mock = new Mock<ILogParser<CCSLogRecord>>();
            var setup = mock.Setup(x=>x.ParserFromFile(It.IsAny<string>()));
            setup.Returns<List<CCSLogRecord>>(null);
            var privateObject = new PrivateObject(mockBase.Object);
            privateObject.SetFieldOrProperty("iLogParser", mock.Object);
            privateObject.Invoke("LoadLogFile", fullPathName, true);
            var actual = (ReadOnlyCollection<CCSLogRecord>)privateObject.GetFieldOrProperty("AllLogRecordsBuffer");
            Assert.AreEqual(0, actual.Count);
            File.Delete(fullPathName);
        }

        [TestMethod()]
        public void WriteMemoTest1()
        {
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            string file = Path.GetFullPath("CCS20131002.txt");
            target.LoadLogFile(file, false);

            string filename = string.Format("{0}.xml", DateTime.Now.GetHashCode());
            string fullPathName = Path.GetFullPath(filename);
            target.WriteMemo(fullPathName);

            Assert.IsTrue(File.Exists(fullPathName));
            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void WriteMemoTest2()
        {
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            string file = Path.GetFullPath("CCS20131002.txt");
            target.LoadLogFile(file, false);
            bool actual = target.WriteMemo(string.Empty);

            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void WriteMemoTest3()
        {
            BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            string file = Path.GetFullPath("CCS20131002.txt");
            target.LoadLogFile(file, false);

            string filename = string.Format("dataabc\\WriteMemoTest3{0}.xml", DateTime.Now.ToString("ddMMyyyyhhmmssfff"));
            string fullPathName = Path.GetFullPath(filename);
            if(Directory.Exists(Path.GetDirectoryName(fullPathName)))Directory.Delete(Path.GetDirectoryName(fullPathName));
            target.WriteMemo(fullPathName);

            Assert.IsTrue(File.Exists(fullPathName));
            File.Delete(fullPathName);
            Directory.Delete(Path.GetDirectoryName(fullPathName));
        }

        [TestMethod]
        public void GetColumnContentValueTest1()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1 };
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnContentValue", new object[] { ccsLog });
            var expected = "abc";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnContentValueTest2()
        {
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = "abc";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest2()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1 };
            string logItem = "Content";
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = "1";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest4()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/20 10:10:10.400") };
            string logItem = ConfigValue.CCSHeader.HEADER_DATE;
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.Date;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest5()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/20 10:10:10.400") };
            string logItem = ConfigValue.CCSHeader.HEADER_TIME;
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.Time;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest6()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/20 10:10:10.400"), ThreadId = "abc" };
            string logItem = ConfigValue.CCSHeader.HEADER_THREADID;
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.ThreadId;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest7()
        {
            CCSLogRecord ccsLog = new CCSLogRecord { Id = "1", Content = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/20 10:10:10.400"), ThreadId = "abc", };
            string logItem = ConfigValue.CCSHeader.HEADER_ID;
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = ccsLog.Id;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetColumnValueTest8()
        {
            CCSLogRecord ccsLog = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime = DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc"
            };
            string logItem = ConfigValue.CCSHeader.HEADER_ADDITIONINFO;
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
                PersonalInfo = "abc"
            };
            string logItem = ConfigValue.CCSHeader.HEADER_PERSONALINFO;
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
                DateTime = DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc",
                ClassName = "abc"

            };
            string logItem = ConfigValue.CCSHeader.HEADER_CLASSNAME;
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
                DateTime = DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc",
                ClassName = "abc",
                Mode = "abc"

            };
            string logItem = ConfigValue.CCSHeader.HEADER_COMMENT;
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            target.Comments.Add(ccsLog, "abc");
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
             BaseLogsAnalyser<CCSLogRecord> target = new CCSLogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            var actual = (string)po.Invoke("GetColumnValue", new object[] { ccsLog, logItem });
            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }




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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
            BaseLogsAnalyser<CXDILogRecord> _logAnalyser = new CXDILogsAnalyser();
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
        public void LoadLogFileTest6()
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
        public void LoadLogFileTest7()
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
        public void LoadLogFileTest8()
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
        public void LoadLogFileTest9()
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
        public void LoadLogFileTest10()
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
        public void LoadLogFileTest11()
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
        public void LoadLogFileTest12()
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
        public void LoadLogFileTest13()
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
        public void LoadLogFileTest14()
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
        public void LoadLogFileTest15()
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
        public void LoadLogFileTest16()
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
        public void LoadLogFileTest17()
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
        public void LoadLogFileTest18()
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
        public void LoadLogFileTest19()
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
        public void WriteMemoTest4()
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
        public void WriteMemoTest5()
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
        public void WriteMemoTest6()
        {


            string filenameUser = string.Format("WriteMemoTest2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();
            cxdiLogsAnalyser.Firmware = new CXDIFirmware();
            var r1 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 1, Message = "exit status S_ExpReady" };
            var r2 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 2, Message = "Led Ready:ON,Priority:-1[msec]" };
            var r3 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 3, Message = "StateNotifySet. systemState:0xb0" };
            var r4 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 4, Message = "Status = S_EXPOSING" };
            var r5 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 5, Message = "entry status S_Exposing" };
            var r6 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 6, Message = "BatteryMgr:Stop." };
            var r7 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 7, Message = "TempMgr:Stop." };
            var r8 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 8, Message = "XIF:Resp Data:GRANT_OK\";" };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5, r6, r7, r8 };
            PrivateObject po = new PrivateObject(cxdiLogsAnalyser);
            po.SetFieldOrProperty("_allLogRecordsBuffer", ls);
            cxdiLogsAnalyser.AddBookmark(r1);
            cxdiLogsAnalyser.AddBookmark(r3);
            cxdiLogsAnalyser.WriteMemo(fileFullPath);
            bool expected = true;
            bool actual = File.Exists(fileFullPath);
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void WriteMemoTest7()
        {


            string filenameUser = string.Format("WriteMemoTest2_1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();
            cxdiLogsAnalyser.Firmware = new CXDIFirmware();
            var r1 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 1, Message = "exit status S_ExpReady" };
            var r2 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 2, Message = "Led Ready:ON,Priority:-1[msec]" };
            var r3 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 3, Message = "StateNotifySet. systemState:0xb0" };
            var r4 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 4, Message = "Status = S_EXPOSING" };
            var r5 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 5, Message = "entry status S_Exposing" };
            var r6 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 6, Message = "BatteryMgr:Stop." };
            var r7 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 7, Message = "TempMgr:Stop." };
            var r8 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 8, Message = "XIF:Resp Data:GRANT_OK\";" };
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
        public void WriteMemoTest8()
        {


            string filenameUser = string.Format("WriteMemoTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);
            CXDILogsAnalyser cxdiLogsAnalyser = new CXDILogsAnalyser();
            cxdiLogsAnalyser.Firmware = new CXDIFirmware();
            var r1 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 1, Message = "exit status S_ExpReady" };
            var r2 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 2, Message = "Led Ready:ON,Priority:-1[msec]" };
            var r3 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 3, Message = "StateNotifySet. systemState:0xb0" };
            var r4 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 4, Message = "Status = S_EXPOSING" };
            var r5 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 5, Message = "entry status S_Exposing" };
            var r6 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 6, Message = "BatteryMgr:Stop." };
            var r7 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 7, Message = "TempMgr:Stop." };
            var r8 = new CXDILogRecord { DateTime = DateTime.Parse("2013/09/11 09:54:05.434"), Line = 8, Message = "XIF:Resp Data:GRANT_OK\";" };
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
        public void GetColumnContentValueTest3()
        {
            var record = new CXDILogRecord { Message = "abc" };
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnContentValue", record);
            string expected = "abc";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnContentValueTest4()
        {
            var record = new CXDILogRecord { Message = "abc" };
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnContentValue", record);
            string expected = "a";
            Assert.AreNotEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnContentValueTest5()
        {
            var record = new CXDILogRecord { Message = "abc" };
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnContentValue", new object[] { null });
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnContentValueTest6()
        {
            var record = new CXDILogRecord { Message = "abc" };
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnContentValue", new object[] { null });
            string expected = "abc";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest15()
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
        public void GetColumnValueTest16()
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
        public void GetColumnValueTest17()
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
        public void GetColumnValueTest18()
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
        public void GetColumnValueTest19()
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
        public void GetColumnValueTest20()
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
        public void GetColumnValueTest21()
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
        public void GetColumnValueTest22()
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
        public void GetColumnValueTest23()
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
        public void GetColumnValueTest24()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10") };
            string logItem = ConfigValue.CXDIHeader.HEADER_DATE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "2014/10/10";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest25()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10") };
            string logItem = ConfigValue.CXDIHeader.HEADER_DATE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "2014";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest26()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100") };
            string logItem = ConfigValue.CXDIHeader.HEADER_TIME;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "10:10:10.100";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest27()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100") };
            string logItem = ConfigValue.CXDIHeader.HEADER_TIME;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "10";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest28()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100"), Module = "[M001]" };
            string logItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "[M001]";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest29()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100"), Module = "[M001]" };
            string logItem = ConfigValue.CXDIHeader.HEADER_MODULE;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "M001";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest30()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100") };
            string logItem = ConfigValue.CXDIHeader.HEADER_COMMENT;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest31()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100") };
            string logItem = ConfigValue.CXDIHeader.HEADER_COMMENT;
            CXDILogsAnalyser target = new CXDILogsAnalyser();
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "abc";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest32()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100") };
            string logItem = ConfigValue.CXDIHeader.HEADER_COMMENT;

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            target.Comments.Add(record, "abc");
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "abc";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest33()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100") };
            string logItem = ConfigValue.CXDIHeader.HEADER_COMMENT;

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            target.Comments.Add(record, "abc");
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "a";
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void GetColumnValueTest34()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100") };
            string logItem = "xxx";

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            target.Comments.Add(record, "abc");
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetColumnValueTest35()
        {
            var record = new CXDILogRecord { Message = "abc", Line = 1, DateTime = DateTime.Parse("2014/10/10 10:10:10.100") };
            string logItem = "xxx";

            CXDILogsAnalyser target = new CXDILogsAnalyser();
            target.Comments.Add(record, "abc");
            PrivateObject po = new PrivateObject(target);
            string actual = (string)po.Invoke("GetColumnValue", new object[] { record, logItem });
            string expected = "abc";
            Assert.AreNotEqual(expected, actual);

        }


    }
}
