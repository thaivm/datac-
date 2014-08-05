using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using LogViewer.Business;
using LogViewer.Business.FileSetting;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileSetting
{
    
    
    [TestClass()]
    public class CXDISettingManagerTest
    {

        [TestMethod()]
        public void CXDISettingManagerConstructorTest()
        {
            CXDISettingManager target = new CXDISettingManager();
            Assert.IsNotNull(target);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BuildNodeTest()
        {
            CXDISettingManager target = new CXDISettingManager(); 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<?xml version='1.0' encoding='utf-8' ?>
                        <GraphParameters>
                        </GraphParameters>");

            List<GraphParamSetting> paramList = new List<GraphParamSetting>();
            paramList.Add(new GraphParamSetting{Id = "0",Name = "abc",Enabled = true,StringValue = "aba",GraphTypeValue = GraphType.Value,PrototypeValue = 0});
            paramList.Add(new GraphParamSetting { Id = "1", Name = "abc1", Enabled = true, StringValue = "aba1", GraphTypeValue = GraphType.Value, PrototypeValue = 0 });
            XmlNode parentNode = doc.CreateElement("Parameters"); 
            var po = new PrivateObject(target);

            po.Invoke("BuildNode",new object[]{doc, paramList, parentNode});

            Assert.IsTrue(parentNode.HasChildNodes);

        }


        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetLogHeaderTest()
        {
            CXDISettingManager_Accessor target = new CXDISettingManager_Accessor();
            List<string> expected = ConfigValue.CXDIHeader.AllLogField;
            List<string> actual;
            actual = target.GetLogHeader();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ReadGraphParamSettingTest()
        {

            string text = @"<?xml version='1.0' encoding='utf-8'?><GraphParameters><Parameters><Parameter ID='' Prototype='0'><Name>object</Name><Keyword>abc</Keyword><Visible>True</Visible></Parameter></Parameters><Events><Parameter ID='' Prototype='0'><Name>adf</Name><Keyword>fdsa</Keyword><Visible>True</Visible></Parameter></Events></GraphParameters>";

            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string old = ConfigValue.UserGraphParamSettingFile;
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserGraphParamSettingFile = fullPathName;

            var target = new CXDISettingManager();
            target.ReadGraphParamSetting();
            Assert.IsTrue(target.GraphParamSettingList.Count > 0); ConfigValue.ErrorActionList = old;
            ConfigValue.UserGraphParamSettingFile = old;
            File.Delete(fullPathName);


        }

        [TestMethod()]
        public void WriteGraphParamSettingTest()
        {
            string s = ConfigValue.UserGraphParamSettingFile;
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserGraphParamSettingFile = fullPathName;

            CXDISettingManager target = new CXDISettingManager(); 
            target.GraphParamSettingList = new List<GraphParamSetting>();
            target.WriteGraphParamSetting();
            bool expected = true;
            Assert.AreEqual(expected,File.Exists(fullPathName));
            File.Delete(fullPathName);

        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void WriteGraphParamSettingTest1()
        {
            string s = ConfigValue.UserGraphParamSettingFile;
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserGraphParamSettingFile = fullPathName;

            CXDISettingManager target = new CXDISettingManager();
            target.WriteGraphParamSetting();
            bool expected = true;
            Assert.AreEqual(expected, File.Exists(fullPathName));
            File.Delete(fullPathName);

        }
        [TestMethod()]
        public void WriteGraphParamSettingTest2()
        {
            string s = ConfigValue.UserGraphParamSettingFile;
            string filename = string.Format("WriteGraphParamSettingTest2{0}.xml", DateTime.Now.GetHashCode());
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserGraphParamSettingFile = fullPathName;

            var target = new CXDISettingManager();
            target.GraphParamSettingList = new List<GraphParamSetting>
            {
               new GraphParamSetting{Enabled = true, Name = "abc",GraphTypeValue = GraphType.Value,Id = "1", StringValue = "abc",PrototypeValue = 0}
            };
            target.WriteGraphParamSetting();
            bool expected = true;
            Assert.AreEqual(expected, File.Exists(fullPathName));
            File.Delete(fullPathName);

        }
        [TestMethod()]
        public void WriteGraphParamSettingTest3()
        {
            string s = ConfigValue.UserGraphParamSettingFile;
            string filename = string.Format("WriteGraphParamSettingTest2{0}.xml", DateTime.Now.GetHashCode());
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserGraphParamSettingFile = fullPathName;

            var target = new CXDISettingManager();
            target.GraphParamSettingList = new List<GraphParamSetting>
            {
               new GraphParamSetting{Enabled = true, Name = "abc",GraphTypeValue = GraphType.Value,Id = "1", StringValue = "abc",PrototypeValue = 0},
               new GraphParamSetting{Enabled = true, Name = "abc",GraphTypeValue = GraphType.Event,Id = "1", StringValue = "abc",PrototypeValue = 0}
            };
            target.WriteGraphParamSetting();
            bool expected = true;
            Assert.AreEqual(expected, File.Exists(fullPathName));
            File.Delete(fullPathName);

        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseFilterSettingFilePathTest()
        {
            string u = ConfigValue.UserCXDIFilteringSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCXDIFilteringSettingFile= fullPathName;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseFilterSettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCXDIFilteringSettingFile = u;
            File.Delete(fullPathName);
        }
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BaseFilterSettingFilePathTest1()
        {
            string u = ConfigValue.UserCXDIFilteringSettingFile;
            var d = ConfigValue.DefaultCXDIFilteringSettingFile;
            ConfigValue.UserCXDIFilteringSettingFile = string.Empty;
            ConfigValue.DefaultCXDIFilteringSettingFile = string.Empty;
            CXDISettingManager target = new CXDISettingManager();
            PrivateObject po = new PrivateObject(target);
            po.GetFieldOrProperty("BaseFilterSettingFilePath");
            ConfigValue.UserCXDIFilteringSettingFile = u;
            ConfigValue.DefaultCXDIFilteringSettingFile = d;
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseKeywordCountSettingFilePathTest()
        {
            string u = ConfigValue.UserCXDIKeywordSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCXDIKeywordSettingFile = fullPathName;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseKeywordCountSettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCXDIKeywordSettingFile = u;
            File.Delete(fullPathName);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseFilterSettingFilePathTest2()
        {
            string u = ConfigValue.UserCXDIFilteringSettingFile;
            string d = ConfigValue.DefaultCXDIFilteringSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCXDIFilteringSettingFile = string.Empty;
            ConfigValue.DefaultCXDIFilteringSettingFile = fullPathName;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseFilterSettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCXDIFilteringSettingFile = u;
            ConfigValue.DefaultCXDIFilteringSettingFile = d;
            File.Delete(fullPathName);
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BaseFilterSettingFilePathTest3()
        {
            string u = ConfigValue.UserCXDIFilteringSettingFile;
            string d = ConfigValue.DefaultCXDIFilteringSettingFile;

            ConfigValue.UserCXDIFilteringSettingFile = string.Empty;
            ConfigValue.DefaultCXDIFilteringSettingFile = string.Empty;

            var target = new CXDISettingManager();
            var po = new PrivateObject(target);
            po.GetFieldOrProperty("BaseFilterSettingFilePath");
            ConfigValue.UserCXDIFilteringSettingFile = u;
            ConfigValue.DefaultCXDIFilteringSettingFile = d;
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseKeywordCountSettingFilePathTest1()
        {
            string u = ConfigValue.UserCXDIKeywordSettingFile;
            string d = ConfigValue.DefaultCXDIKeywordSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCXDIKeywordSettingFile = string.Empty;
            ConfigValue.DefaultCXDIKeywordSettingFile = fullPathName;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseKeywordCountSettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCXDIKeywordSettingFile = u;
            ConfigValue.DefaultCXDIKeywordSettingFile = d;
            File.Delete(fullPathName);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BaseKeywordCountSettingFilePathTest2()
        {
            string u = ConfigValue.UserCXDIKeywordSettingFile;
            string d = ConfigValue.DefaultCXDIKeywordSettingFile;

            ConfigValue.UserCXDIKeywordSettingFile = string.Empty;
            ConfigValue.DefaultCXDIKeywordSettingFile = string.Empty;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseKeywordCountSettingFilePath");
            ConfigValue.UserCXDIKeywordSettingFile = u;
            ConfigValue.DefaultCXDIKeywordSettingFile = d;
        }


        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseLogDisplaySettingFilePathTest()
        {
            string u = ConfigValue.UserCXDILogSettingFile;
            string d = ConfigValue.DefaultCXDILogSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCXDILogSettingFile = string.Empty;
            ConfigValue.DefaultCXDILogSettingFile = fullPathName;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseLogDisplaySettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCXDILogSettingFile = u;
            ConfigValue.DefaultCXDILogSettingFile = d;
            File.Delete(fullPathName);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseLogDisplaySettingFilePathTest1()
        {
            string u = ConfigValue.UserCXDILogSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCXDILogSettingFile = fullPathName;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseLogDisplaySettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCXDILogSettingFile = u;
            File.Delete(fullPathName);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BaseLogDisplaySettingFilePathTest2()
        {
            string u = ConfigValue.UserCXDILogSettingFile;
            string d = ConfigValue.DefaultCXDILogSettingFile;

            ConfigValue.UserCXDILogSettingFile = string.Empty;
            ConfigValue.DefaultCXDILogSettingFile = string.Empty;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            po.GetFieldOrProperty("BaseLogDisplaySettingFilePath");
            ConfigValue.UserCXDILogSettingFile = u;
            ConfigValue.DefaultCXDILogSettingFile = d;
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BasePatternSettingFilePathTest()
        {

            string u = ConfigValue.UserCXDIPatternSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCXDIPatternSettingFile = fullPathName;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BasePatternSettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCXDIPatternSettingFile = u;
            File.Delete(fullPathName);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BasePatternSettingFilePathTest2()
        {

            string u = ConfigValue.UserCXDIPatternSettingFile;
            string d = ConfigValue.DefaultCXDIPatternSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCXDIPatternSettingFile = string.Empty;
            ConfigValue.DefaultCXDIPatternSettingFile = fullPathName;

            CXDISettingManager target = new CXDISettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BasePatternSettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCXDIPatternSettingFile = u;
            ConfigValue.DefaultCXDIPatternSettingFile = d;
            File.Delete(fullPathName);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BasePatternSettingFilePathTest1()
        {

            string u = ConfigValue.UserCXDIPatternSettingFile;
            string d = ConfigValue.DefaultCXDIPatternSettingFile;

            ConfigValue.UserCXDIPatternSettingFile = string.Empty;
            ConfigValue.DefaultCXDIPatternSettingFile = string.Empty;

            var target = new CXDISettingManager();
            var po = new PrivateObject(target);
            po.GetFieldOrProperty("BasePatternSettingFilePath");
            ConfigValue.UserCXDIPatternSettingFile = u;
            ConfigValue.DefaultCXDIPatternSettingFile = d;
        }
        /// <summary>
        ///A test for GraphParamSettingList
        ///</summary>
        [TestMethod()]
        public void GraphParamSettingListTest()
        {
            CXDISettingManager target = new CXDISettingManager(); 
            IList<GraphParamSetting> expected = null; 
            IList<GraphParamSetting> actual;
            target.GraphParamSettingList = expected;
            actual = target.GraphParamSettingList;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DefaultLogDisplaySettingFilePathTest()
        {
            CXDISettingManager_Accessor target = new CXDISettingManager_Accessor();
            string expected = ConfigValue.DefaultCXDILogSettingFile;
            string actual;
            actual = target.DefaultLogDisplaySettingFilePath;
            Assert.AreEqual(expected,actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DefaultPatternSettingFilePathTest()
        {
            CXDISettingManager_Accessor target = new CXDISettingManager_Accessor();
            string expected = ConfigValue.DefaultCXDIPatternSettingFile;
            string actual;
            actual = target.DefaultPatternSettingFilePath;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DefaultFilterSettingFilePathTest()
        {
            CXDISettingManager_Accessor target = new CXDISettingManager_Accessor();
            string expected = ConfigValue.DefaultCXDIFilteringSettingFile;
            string actual;
            actual = target.DefaultFilterSettingFilePath;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserFilterSettingFilePathTest()
        {
            CXDISettingManager_Accessor target = new CXDISettingManager_Accessor();
            string expected = ConfigValue.UserCXDIFilteringSettingFile;
            string actual;
            actual = target.UserFilterSettingFilePath;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserPatternSettingFilePathTest()
        {
            CXDISettingManager_Accessor target = new CXDISettingManager_Accessor();
            string expected = ConfigValue.UserCXDIPatternSettingFile;
            string actual;
            actual = target.UserPatternSettingFilePath;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserKeywordCountSettingFilePathTest()
        {
            CXDISettingManager_Accessor target = new CXDISettingManager_Accessor();
            string expected = ConfigValue.UserCXDIKeywordSettingFile;
            string actual;
            actual = target.UserKeywordCountSettingFilePath;
            Assert.AreEqual(expected, actual);
        }
        
    }
}
