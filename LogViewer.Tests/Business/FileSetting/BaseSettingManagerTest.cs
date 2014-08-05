using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Documents;
using LogViewer.Business;
using LogViewer.Business.FileSetting;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileSetting
{
    
    
    /// <summary>
    ///This is a test class for BaseSettingManagerTest and is intended
    ///to contain all BaseSettingManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseSettingManagerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion



        /// <summary>
        ///A test for CreateDefaultAppFolder
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateDefaultAppFolderTest1()
        {
            PrivateObject param0 = new PrivateObject(typeof (CCSSettingManager));
            string old = ConfigValue.ConfigFolder;
            string tempfolder = DateTime.Now.ToString("yy-mm-dd");
            ConfigValue.ConfigFolder = tempfolder;
            var target = new BaseSettingManager_Accessor(param0); 
            //Delete for make sure no config folder existed
            if(Directory.Exists(ConfigValue.ConfigFolder)) Directory.Delete(ConfigValue.ConfigFolder);
            target.CreateDefaultAppFolder();
            Assert.IsTrue(Directory.Exists(ConfigValue.ConfigFolder));
            ConfigValue.ConfigFolder = old;
            Directory.Delete(tempfolder);
        }
        /// <summary>
        ///A test for CreateDefaultAppFolder
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateDefaultAppFolderTest2()
        {
            PrivateObject param0 = new PrivateObject(typeof(CCSSettingManager));
            var target = new BaseSettingManager_Accessor(param0);
            if (Directory.Exists(ConfigValue.ConfigFolder)) Directory.CreateDirectory(ConfigValue.ConfigFolder);
            target.CreateDefaultAppFolder();
            Assert.IsTrue(Directory.Exists(ConfigValue.ConfigFolder));
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateDefaultAppFolderTest3()
        {
            PrivateObject param0 = new PrivateObject(typeof(CCSSettingManager));
            string old = ConfigValue.ActionListFolder;
            string tempfolder = DateTime.Now.ToString("yyMMddhhmmss");
            ConfigValue.ActionListFolder =Path.GetFullPath(tempfolder);
            var target = new BaseSettingManager_Accessor(param0);
            //Delete for make sure no config folder existed
            if (Directory.Exists(ConfigValue.ActionListFolder)) Directory.Delete(ConfigValue.ActionListFolder);
            target.CreateDefaultAppFolder();
            Assert.IsTrue(Directory.Exists(ConfigValue.ActionListFolder));
            ConfigValue.ActionListFolder = old;
            Directory.Delete(tempfolder);
        }

        private CCSSettingManager CreateBaseSettingManager()
        {
            return  new CCSSettingManager();
        }


        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidLogDisplayTest()
        {
            BaseSettingManager target = new CCSSettingManager();
            List<LogDisplay> displaySetting = new List<LogDisplay>(); 
            bool expected = false;
            var po = new PrivateObject(target,new PrivateType(typeof(BaseSettingManager)));
            bool actual;
            actual = (bool)po.Invoke("IsValidLogDisplay",new object[]{displaySetting});
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidLogDisplayTest1()
        {
            BaseSettingManager target = new CCSSettingManager();
            List<LogDisplay> displaySetting = new List<LogDisplay>();
            displaySetting.Add(new LogDisplay { key = "Bookmark",value = true});
            displaySetting.Add(new LogDisplay { key = "Line", value = true });
            displaySetting.Add(new LogDisplay { key = "Date", value = true });
            bool expected = false;
            var po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            bool actual;
            actual = (bool)po.Invoke("IsValidLogDisplay", new object[] { displaySetting });
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidLogDisplayTest3()
        {
            BaseSettingManager target = new CCSSettingManager();
            List<LogDisplay> displaySetting = new List<LogDisplay>();
            displaySetting.Add(new LogDisplay { key = "Bookmark", value = true });
            displaySetting.Add(new LogDisplay { key = "Line", value = true });
            displaySetting.Add(new LogDisplay { key = "Date", value = true });
            displaySetting.Add(new LogDisplay { key = "Time", value = true });
            displaySetting.Add(new LogDisplay { key = "HostName", value = true });
            displaySetting.Add(new LogDisplay { key = "ThreadId", value = true });
            displaySetting.Add(new LogDisplay { key = "LogType", value = true });
            displaySetting.Add(new LogDisplay { key = "LogId", value = true });
            displaySetting.Add(new LogDisplay { key = "Content", value = true });
            displaySetting.Add(new LogDisplay { key = "AdditionalInfo", value = true });
            displaySetting.Add(new LogDisplay { key = "PersonalInfo", value = true });
            displaySetting.Add(new LogDisplay { key = "ClassName", value = true });
            displaySetting.Add(new LogDisplay { key = "Comment", value = true });
            bool expected = true;
            var po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            bool actual;
            actual = (bool)po.Invoke("IsValidLogDisplay", new object[] { displaySetting });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidLogDisplayTest4()
        {
            BaseSettingManager target = new CCSSettingManager();
            List<LogDisplay> displaySetting = new List<LogDisplay>();
            displaySetting.Add(new LogDisplay { key = "Bookmark", value = true });
            displaySetting.Add(new LogDisplay { key = "Line", value = true });
            displaySetting.Add(new LogDisplay { key = null, value = true });
            displaySetting.Add(new LogDisplay { key = "Time", value = true });
            displaySetting.Add(new LogDisplay { key = "HostName", value = true });
            displaySetting.Add(new LogDisplay { key = "ThreadId", value = true });
            displaySetting.Add(new LogDisplay { key = "LogType", value = true });
            displaySetting.Add(new LogDisplay { key = "LogId", value = true });
            displaySetting.Add(new LogDisplay { key = "Content", value = true });
            displaySetting.Add(new LogDisplay { key = "AdditionalInfo", value = true });
            displaySetting.Add(new LogDisplay { key = "PersonalInfo", value = true });
            displaySetting.Add(new LogDisplay { key = "ClassName", value = true });
            displaySetting.Add(new LogDisplay { key = "Comment", value = true });
            bool expected = false;
            var po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            bool actual;
            actual = (bool)po.Invoke("IsValidLogDisplay", new object[] { displaySetting });
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidLogDisplayTest5()
        {
            BaseSettingManager target = new CCSSettingManager();
            bool expected = false;
            var po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            bool actual;
            actual = (bool)po.Invoke("IsValidLogDisplay", new object[] { null });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidLogDisplayTest6()
        {
            BaseSettingManager target = new CCSSettingManager();
            List<LogDisplay> displaySetting = new List<LogDisplay>();
            displaySetting.Add(new LogDisplay { key = "Bookmark", value = true });
            displaySetting.Add(new LogDisplay { key = "Line", value = true });
            displaySetting.Add(new LogDisplay { key = "Date", value = true });
            displaySetting.Add(new LogDisplay { key = "Time", value = true });
            displaySetting.Add(new LogDisplay { key = "HostName", value = true });
            displaySetting.Add(new LogDisplay { key = "ThreadId", value = true });
            displaySetting.Add(new LogDisplay { key = "LogType", value = true });
            displaySetting.Add(new LogDisplay { key = "LogId", value = true });
            displaySetting.Add(new LogDisplay { key = "Content", value = true });
            displaySetting.Add(new LogDisplay { key = "AdditionalInfo", value = true });
            displaySetting.Add(new LogDisplay { key = "PersonalInfo", value = true });
            displaySetting.Add(new LogDisplay { key = "ClassName", value = true });
            //displaySetting.Add(new LogDisplay { key = "Comment", value = true });
            bool expected = false;
            var po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            bool actual;
            actual = (bool)po.Invoke("IsValidLogDisplay", new object[] { displaySetting });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ReadDisplaySettingTest1()
        {
            string text = @"1,Bookmark,true
                            2,Line,true
                            3,Date,true
                            4,Time,true
                            5,HostName,false
                            6,ThreadId,false
                            7,LogType,true
                            8,LogId,false
                            9,Content,true
                            10,AdditionalInfo,false
                            11,PersonalInfo,false
                            12,ClassName,false
                            13,Comment,true";
            string filename = string.Format("ReadDisplaySettingTest1{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filename, text);
            string old = ConfigValue.UserCCSLogSettingFile;
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCCSLogSettingFile = fullPathName;

            BaseSettingManager target = CreateBaseSettingManager();
            target.ReadDisplaySetting();
            Assert.AreEqual(13,target.DisplaySetting.Count);

            ConfigValue.UserCCSLogSettingFile = old;
            File.Delete(fullPathName);

        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ReadDisplaySettingTest2()
        {
            string textUser = @"1,Bookmark,true
                            2,Line,true
                            3,Date,true
                            4,Time,true
                            5,HostName,false
                            6,ThreadId,false
                            7,LogType,true
                            8,LogId,false
                            9,Content,true
                            10,AdditionalInfo,false
                            11,PersonalInfo,false
                            12,ClassName,false";
            string textDefault = @"1,Bookmark,true
                            2,Line,true
                            3,Date,true
                            4,Time,true
                            5,HostName,false
                            6,ThreadId,false
                            7,LogType,true
                            8,LogId,false
                            9,Content,true
                            10,AdditionalInfo,false
                            11,PersonalInfo,false
                            12,ClassName,false
                            13,Comment,true";
            string filenameUser = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            string filenameDefault = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            System.IO.File.WriteAllText(filenameDefault, textDefault);
            string u = ConfigValue.UserCCSLogSettingFile;
            string d = ConfigValue.DefaultCCSLogSettingFile;
            string userFullPath = Path.GetFullPath(filenameUser);
            string defaultFullPath = Path.GetFullPath(filenameUser);
            
            ConfigValue.UserCCSLogSettingFile = userFullPath;
            ConfigValue.DefaultCCSLogSettingFile = defaultFullPath;

            BaseSettingManager target = CreateBaseSettingManager();
            PrivateObject po = new PrivateObject(target,new PrivateType(typeof(BaseSettingManager)));
            po.SetField("CurrentLogDisplayFileType", EnumSettingFileType.UserFile);
            target.ReadDisplaySetting();
            Assert.AreEqual(13, target.DisplaySetting.Count);

            ConfigValue.UserCCSLogSettingFile = u;
            ConfigValue.DefaultCCSLogSettingFile = d;
            File.Delete(userFullPath);
            File.Delete(defaultFullPath);

        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException (typeof(FileNotFoundException))]
        public void ReadDisplaySettingTest3()
        {
            string textUser = @"1,Bookmark,true
                            2,Line,true
                            3,Date,true
                            4,Time,true
                            5,HostName,false
                            6,ThreadId,false
                            7,LogType,true
                            8,LogId,false
                            9,Content,true
                            10,AdditionalInfo,false
                            11,PersonalInfo,false
                            12,ClassName,false";
            string textDefault = @"1,Bookmark,true
                            2,Line,true
                            3,Date,true
                            4,Time,true
                            5,HostName,false
                            6,ThreadId,false
                            7,LogType,true
                            8,LogId,false
                            9,Content,true
                            10,AdditionalInfo,false
                            11,PersonalInfo,false
                            12,ClassName,false";
            string filenameUser = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            string filenameDefault = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            System.IO.File.WriteAllText(filenameDefault, textDefault);
            string u = ConfigValue.UserCCSLogSettingFile;
            string d = ConfigValue.DefaultCCSLogSettingFile;
            string userFullPath = Path.GetFullPath(filenameUser);
            string defaultFullPath = Path.GetFullPath(filenameUser);

            ConfigValue.UserCCSLogSettingFile = string.Empty;
            ConfigValue.DefaultCCSLogSettingFile = string.Empty;

            BaseSettingManager target = CreateBaseSettingManager();
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            po.SetField("CurrentLogDisplayFileType", EnumSettingFileType.UserFile);
            target.ReadDisplaySetting();
            Assert.AreEqual(0, target.DisplaySetting.Count);

            ConfigValue.UserCCSLogSettingFile = u;
            ConfigValue.DefaultCCSLogSettingFile = d;
            File.Delete(userFullPath);
            File.Delete(defaultFullPath);

        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException(typeof(UserSettingFileException))]
        public void ReadDisplaySettingTest4()
        {
            string textUser = @"1,Bookmark,true
                            2,Line,true
                            3,Date,true
                            4,Time,true
                            5,HostName,false
                            6,ThreadId,false
                            7,LogType,true
                            8,LogId,false
                            9,Content,true
                            10,AdditionalInfo,false
                            11,PersonalInfo,false
                            12,ClassName,false";
            string textDefault = @"1,Bookmark,true
                            2,Line,true
                            3,Date,true
                            4,Time,true
                            5,HostName,false
                            6,ThreadId,false
                            7,LogType,true
                            8,LogId,false
                            9,Content,true
                            10,AdditionalInfo,false
                            11,PersonalInfo,false
                            12,ClassName,false";
            string filenameUser = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            string filenameDefault = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            System.IO.File.WriteAllText(filenameDefault, textDefault);
            string u = ConfigValue.UserCCSLogSettingFile;
            string d = ConfigValue.DefaultCCSLogSettingFile;
            string userFullPath = Path.GetFullPath(filenameUser);
            string defaultFullPath = Path.GetFullPath(filenameUser);

            ConfigValue.UserCCSLogSettingFile = userFullPath;
            ConfigValue.DefaultCCSLogSettingFile = defaultFullPath;

            BaseSettingManager target = CreateBaseSettingManager();
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            po.SetField("CurrentLogDisplayFileType", EnumSettingFileType.UserFile);
            target.ReadDisplaySetting();
            Assert.AreEqual(0, target.DisplaySetting.Count);

            ConfigValue.UserCCSLogSettingFile = u;
            ConfigValue.DefaultCCSLogSettingFile = d;
            File.Delete(userFullPath);
            File.Delete(defaultFullPath);

        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ReadFilterSettingTest1()
        {
            string textUser = @"1,Type0008,8,ThreadId,#000105,#FAFD0F,Normal,False
2,Error,E,LogType,#5512FF,#FD1F1F,Normal,False
3,GetProtocolCandidateList,GetProtocolCandidateList(),Content,#E0D807,#21C24E,Normal,False
4,LogID020200017,20200017,LogId,#DADD21,#E96209,Normal,False";
            string textDefault = @"1,Type0008,8,ThreadId,#000105,#FAFD0F,Normal,False
2,Error,E,LogType,#5512FF,#FD1F1F,Normal,False
3,GetProtocolCandidateList,GetProtocolCandidateList(),Content,#E0D807,#21C24E,Normal,False
4,LogID020200017,20200017,LogId,#DADD21,#E96209,Normal,False";
            string filenameUser = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            string filenameDefault = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            System.IO.File.WriteAllText(filenameDefault, textDefault);
            string u = ConfigValue.UserCCSFilteringSettingFile;
            string d = ConfigValue.DefaultCCSFilteringSettingFile;
            string userFullPath = Path.GetFullPath(filenameUser);
            string defaultFullPath = Path.GetFullPath(filenameUser);

            ConfigValue.UserCCSFilteringSettingFile= userFullPath;
            ConfigValue.DefaultCCSFilteringSettingFile= defaultFullPath;

            BaseSettingManager target = CreateBaseSettingManager();
            //PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            //po.SetField("CurrentLogDisplayFileType", EnumSettingFileType.UserFile);
            target.ReadFilterSetting();
            Assert.AreEqual(4, target.ColorFilterSettingList.Count);

            ConfigValue.UserCCSFilteringSettingFile= u;
            ConfigValue.DefaultCCSFilteringSettingFile= d;
            File.Delete(userFullPath);
            File.Delete(defaultFullPath);

        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException(typeof(Exception))]
        public void ReadFilterSettingTest2()
        {
            string textUser = @"1,Type0008,8,ThreadId,#000105,#FAFD0F,Normal,False
2,Error,E,LogType,#5512FF,#FD1F1F,Normal,False
3,GetProtocolCandidateList,GetProtocolCandidateList(),Content,#E0D807,#21C24E,Normal,False
4,LogID020200017,20200017,LogId,#DADD21,#E96209,Normal,False";
            string textDefault = @"1,Type0008,8,ThreadId,#000105,#FAFD0F,Normal,False
2,Error,E,LogType,#5512FF,#FD1F1F,Normal,False
3,GetProtocolCandidateList,GetProtocolCandidateList(),Content,#E0D807,#21C24E,Normal,False
4,LogID020200017,20200017,LogId,#DADD21,#E96209,Normal,False";
            string filenameUser = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            string filenameDefault = string.Format("{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            System.IO.File.WriteAllText(filenameDefault, textDefault);
            string u = ConfigValue.UserCCSFilteringSettingFile;
            string d = ConfigValue.DefaultCCSFilteringSettingFile;
            string userFullPath = Path.GetFullPath(filenameUser);
            string defaultFullPath = Path.GetFullPath(filenameUser);

            ConfigValue.UserCCSFilteringSettingFile = string.Empty;
            ConfigValue.DefaultCCSFilteringSettingFile = string.Empty;

            BaseSettingManager target = CreateBaseSettingManager();
            //PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            //po.SetField("CurrentLogDisplayFileType", EnumSettingFileType.UserFile);
            target.ReadFilterSetting();
            Assert.AreEqual(4, target.ColorFilterSettingList.Count);

            ConfigValue.UserCCSFilteringSettingFile = u;
            ConfigValue.DefaultCCSFilteringSettingFile = d;
            File.Delete(userFullPath);
            File.Delete(defaultFullPath);

        }
       

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException(typeof(Exception))]
        public void ReadPatternSettingTest1()
        {
            string textUser = @"?xml xxxversion='1.0' encoding='utf-8' ?>
                                <PatternAnalyze>
                                <Content ID='0' Name='Workflow_Start' Enable='True'>
	                                <RootItem Time='100' TimeUnit='s'>Workflow_Start</RootItem>
	                                <Items>
		                                <Item>SensorStatus</Item>
		                                <Item>Workflow_Start</Item>
	                                </Items></Content>
                                <Content ID='1' Name='SensorStatus' Enable='True'>
	                                <RootItem Time='100' TimeUnit='s'>SensorStatus</RootItem>
	                                <Items>
		                                <Item>GetSensorCatalogInfo</Item>
	                                </Items>
                                </Content>
                                </xxxxPatternAnalyze>
                                ";
            string textDefault = @"<?xml version='1.0' encoding='utf-8' ?>
                                <PatternAnalyze>
                                <Content ID='0' Name='Workflow_Start' Enable='True'>
	                                <RootItem Time='100' TimeUnit='s'>Workflow_Start</RootItem>
	                                <Items>
		                                <Item>SensorStatus</Item>
		                                <Item>Workflow_Start</Item>
	                                </Items></Content>
                                <Content ID='1' Name='SensorStatus' Enable='True'>
	                                <RootItem Time='100' TimeUnit='s'>SensorStatus</RootItem>
	                                <Items>
		                                <Item>GetSensorCatalogInfo</Item>
	                                </Items>
                                </Content>
                                </PatternAnalyze>
                                ";
            string filenameUser = string.Format("a{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            string filenameDefault = string.Format("b{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            System.IO.File.WriteAllText(filenameDefault, textDefault);
            string u = ConfigValue.UserCCSPatternSettingFile;
            string d = ConfigValue.DefaultCCSPatternSettingFile;
            string userFullPath = Path.GetFullPath(filenameUser);
            string defaultFullPath = Path.GetFullPath(filenameUser);

            ConfigValue.UserCCSPatternSettingFile= userFullPath;
            ConfigValue.DefaultCCSPatternSettingFile= defaultFullPath;

            BaseSettingManager target = CreateBaseSettingManager();

            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseSettingManager)));
            po.SetField("CurrentPatternFileType", EnumSettingFileType.SystemFile);

            target.ReadPattermSetting();
            Assert.AreEqual(2, target.PatternSettingList.Count);

            ConfigValue.UserCCSLogSettingFile = u;
            ConfigValue.DefaultCCSLogSettingFile = d;
            File.Delete(userFullPath);
            File.Delete(defaultFullPath);

        }
        [TestMethod()]
        public void ReadKeywordCountSettingFileTest()
        {

            string text = "1,G->F CALL,G->F CALL,Content,True\n2,G->F CALL1,G->F CALL1,Content,True";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string old = ConfigValue.UserCCSKeywordSettingFile;
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCCSKeywordSettingFile = fullPathName;

            BaseSettingManager target = CreateBaseSettingManager(); 
            target.ReadKeywordCountSettingFile();
            Assert.IsTrue(target.KeywordCountSettingList.Count>0);

            ConfigValue.UserCCSKeywordSettingFile = old;
            File.Delete(fullPathName);
        }

        /// <summary>
        ///A test for ReadPattermSetting
        ///</summary>
        //[TestMethod()]
        //public void ReadPattermSettingTest()
        //{
        //    BaseSettingManager target = CreateBaseSettingManager(); // TODO: Initialize to an appropriate value
        //    target.ReadPattermSetting();
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        [TestMethod()]
        public void SetKeywordCountSettingListTest()
        {
            BaseSettingManager target = CreateBaseSettingManager(); 
            List<KeywordCountItemSetting> data = null; 
            target.SetKeywordCountSettingList(data);
            Assert.IsNull(target.KeywordCountSettingList);
        }

        /// <summary>
        ///A test for WriteDisplaySetting
        ///</summary>
        //[TestMethod()]
        //public void WriteDisplaySettingTest()
        //{
        //    BaseSettingManager target = CreateBaseSettingManager(); // TODO: Initialize to an appropriate value
        //    target.WriteDisplaySetting();
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        [TestMethod()]
        public void WriteFilterSettingTest()
        {

            string textUser =
@"1,Type0008,8,ThreadId,#000105,#FAFD0F,Normal,False
2,Error,E,LogType,#5512FF,#FD1F1F,Normal,False
3,GetProtocolCandidateList,GetProtocolCandidateList(),Content,#E0D807,#21C24E,Normal,False
4,LogID020200017,20200017,LogId,#DADD21,#E96209,Normal,False
";

            string filenameUser = string.Format("a{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            string old = ConfigValue.UserCCSFilteringSettingFile;
            ConfigValue.UserCCSFilteringSettingFile = fileFullPath;

            string filterWrite = string.Format("b{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));

            BaseSettingManager target = CreateBaseSettingManager(); 
            CCSSettingManager ccsSetting = new CCSSettingManager();
            ccsSetting.ReadFilterSetting();
            target.ColorFilterSettingList = ccsSetting.ColorFilterSettingList;

            ConfigValue.UserCCSFilteringSettingFile = Path.GetFullPath(filterWrite);
            if (File.Exists(ConfigValue.UserCCSFilteringSettingFile)) File.Delete(ConfigValue.UserCCSFilteringSettingFile);
            target.WriteFilterSetting();
            Assert.IsTrue(File.Exists(ConfigValue.UserCCSFilteringSettingFile));
            
            File.Delete(fileFullPath);
            ConfigValue.UserCCSFilteringSettingFile = old;
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void WriteFilterSettingTest1()
        {
            BaseSettingManager target = CreateBaseSettingManager();
            CCSSettingManager ccsSetting = new CCSSettingManager();
            ccsSetting.ReadFilterSetting();
            target.ColorFilterSettingList = ccsSetting.ColorFilterSettingList;
            if (File.Exists(ConfigValue.UserCCSFilteringSettingFile)) File.Delete(ConfigValue.UserCCSFilteringSettingFile);
            string old = ConfigValue.UserCCSFilteringSettingFile;
            ConfigValue.UserCCSFilteringSettingFile = string.Empty;

            target.WriteFilterSetting();
            Assert.IsTrue(File.Exists(ConfigValue.UserCCSFilteringSettingFile));
            ConfigValue.UserCCSFilteringSettingFile = old;
        }
        

        [TestMethod()]
        public void WriteKeywordCountSettingFileTest()
        {
            BaseSettingManager target = CreateBaseSettingManager();
            var keywordcountItemSettings = new List<KeywordCountItemSetting>();
            //1,G->F CALL,G->F CALL,G->F CALL,True
            keywordcountItemSettings.Add(new KeywordCountItemSetting { Id = "1", Enabled = true, Name = "G->F CALL", LogItem = "Content", StringValue = "G->F CALL" });
            string old = ConfigValue.UserCCSKeywordSettingFile;
            string filenameUser = string.Format("WriteKeywordCountSettingFileTest{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            ConfigValue.UserCCSKeywordSettingFile = fileFullPath;

            target.KeywordCountSettingList = keywordcountItemSettings; 
            target.WriteKeywordCountSettingFile();
            Assert.IsTrue(File.Exists(ConfigValue.UserCCSKeywordSettingFile));
            ConfigValue.UserCCSKeywordSettingFile = old;
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void WriteKeywordCountSettingFileTest2()
        {
            BaseSettingManager target = CreateBaseSettingManager();
            var keywordcountItemSettings = new List<KeywordCountItemSetting>();
            //1,G->F CALL,G->F CALL,G->F CALL,True
            keywordcountItemSettings.Add(new KeywordCountItemSetting { Id = "1", Enabled = true, Name = "G->F CALL", LogItem = "Content", StringValue = "G->F CALL" });
            if (File.Exists(ConfigValue.UserCCSPatternSettingFile)) File.Delete(ConfigValue.UserCCSPatternSettingFile);

            target.KeywordCountSettingList = keywordcountItemSettings;
            string old = ConfigValue.UserCCSKeywordSettingFile;
            ConfigValue.UserCCSKeywordSettingFile = string.Empty;
            target.WriteKeywordCountSettingFile();
            Assert.IsTrue(File.Exists(ConfigValue.UserCCSKeywordSettingFile));
            ConfigValue.UserCCSKeywordSettingFile = old;
        }

        /// <summary>
        ///A test for WritePattermSetting
        ///</summary>
        [TestMethod()]
        public void WritePattermSettingTest()
        {
            BaseSettingManager target = CreateBaseSettingManager(); 
            List<PatternItemSetting> patternItemSettings = new List<PatternItemSetting>();
            target.PatternSettingList = patternItemSettings;
            if(File.Exists(ConfigValue.UserCCSPatternSettingFile)) File.Delete(ConfigValue.UserCCSPatternSettingFile);

            target.WritePattermSetting();
            Assert.IsTrue(File.Exists(ConfigValue.UserCCSPatternSettingFile));
            
        }

        [TestMethod()]
        public void WritePattermSettingTest1()
        {
            BaseSettingManager target = CreateBaseSettingManager();
            List<PatternItemSetting> patternItemSettings = new List<PatternItemSetting>();
            patternItemSettings.Add(new PatternItemSetting{Id = "1",Name = "AAA",Enabled = true,Keys = new List<string>(),RootKey = "abc",Time = 100,TimeUnit = "ms"});
            patternItemSettings.Add(new PatternItemSetting { Id = "2", Name = "BBB", Enabled = true, Keys = new List<string>(), RootKey = "bbb", Time = 100, TimeUnit = "ms" });
            target.PatternSettingList = patternItemSettings;
            if (File.Exists(ConfigValue.UserCCSPatternSettingFile)) File.Delete(ConfigValue.UserCCSPatternSettingFile);

            target.WritePattermSetting();
            Assert.IsTrue(File.Exists(ConfigValue.UserCCSPatternSettingFile));

        }
        [TestMethod()]
        public void WritePattermSettingTest2()
        {
            BaseSettingManager target = CreateBaseSettingManager();
            List<PatternItemSetting> patternItemSettings = new List<PatternItemSetting>();
            patternItemSettings.Add(new PatternItemSetting { Id = "1", Name = "AAA", Enabled = true, Keys = new List<string>{"a","b"}, RootKey = "abc", Time = 100, TimeUnit = "ms" });
            patternItemSettings.Add(new PatternItemSetting { Id = "2", Name = "BBB", Enabled = true, Keys = new List<string>{"c","d"}, RootKey = "bbb", Time = 100, TimeUnit = "ms" });
            target.PatternSettingList = patternItemSettings;
            if (File.Exists(ConfigValue.UserCCSPatternSettingFile)) File.Delete(ConfigValue.UserCCSPatternSettingFile);

            target.WritePattermSetting();
            Assert.IsTrue(File.Exists(ConfigValue.UserCCSPatternSettingFile));

        }

        [TestMethod()]
        [ExpectedException( typeof(Exception))]
        public void WritePattermSettingTest3()
        {
            BaseSettingManager target = CreateBaseSettingManager();
            List<PatternItemSetting> patternItemSettings = new List<PatternItemSetting>();
            patternItemSettings.Add(new PatternItemSetting { Id = "1", Name = "AAA", Enabled = true, Keys = new List<string> { "a", "b" }, RootKey = "abc", Time = 100, TimeUnit = "ms" });
            patternItemSettings.Add(new PatternItemSetting { Id = "2", Name = "BBB", Enabled = true, Keys = new List<string> { "c", "d" }, RootKey = "bbb", Time = 100, TimeUnit = "ms" });
            target.PatternSettingList = patternItemSettings;
            if (File.Exists(ConfigValue.UserCCSPatternSettingFile)) File.Delete(ConfigValue.UserCCSPatternSettingFile);

            string oldUserPatternPath = ConfigValue.UserCCSPatternSettingFile;
            ConfigValue.UserCCSPatternSettingFile = string.Empty;
            target.WritePattermSetting();
            Assert.IsTrue(File.Exists(ConfigValue.UserCCSPatternSettingFile));

            ConfigValue.UserCCSPatternSettingFile = oldUserPatternPath;

        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void WritePattermSettingTest4()
        {
            BaseSettingManager target = CreateBaseSettingManager();
            var patternItemSettings = new List<PatternItemSetting>();
            patternItemSettings.Add(new PatternItemSetting { Id = "2", Name = "BBB", Enabled = true, RootKey = "bbb", Time = 100, TimeUnit = "ms" });
            target.PatternSettingList = patternItemSettings;
            if (File.Exists(ConfigValue.UserCCSPatternSettingFile)) File.Delete(ConfigValue.UserCCSPatternSettingFile);
            target.WritePattermSetting();

            Assert.IsTrue(File.Exists(ConfigValue.UserCCSPatternSettingFile));


        }
        //[TestMethod()]
        //public void WritePattermSettingTest5()
        //{
        //    BaseSettingManager target = CreateBaseSettingManager();
        //    var patternItemSettings = new List<PatternItemSetting>();
        //    patternItemSettings.Add(new PatternItemSetting { Id = "1", Name = "AAA", Enabled = true, Keys = new List<string> { "a", "b" }, RootKey = "abc", Time = 100, TimeUnit = "ms" });
        //    patternItemSettings.Add(new PatternItemSetting { Id = "2", Name = "BBB", Enabled = true, Keys = new List<string> { "c", "d" }, RootKey = "bbb", Time = 100, TimeUnit = "ms" });
        //    target.PatternSettingList = patternItemSettings;

        //    target.WritePattermSetting();
        //    target.ReadPattermSetting();

        //    foreach (var pattern in target.PatternSettingList)
        //    {
        //        Assert.AreEqual(2,pattern.Keys.Count);
        //    }

        //}

        [TestMethod()]
        public void AllEnabledColorFiltersTest2()
        {

            BaseSettingManager target = CreateBaseSettingManager();
            target.NarrowFilterSettingItem = new FilterItemSetting ();
            
            target.ColorFilterSettingList = new List<FilterItemSetting>();
            target.ColorFilterSettingList.Add(new FilterItemSetting{Name = "abc1",StringValue = "abc1",LogItem = "Content"});
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc2", StringValue = "abc2", LogItem = "Content" });
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc3", StringValue = "abc3", LogItem = "Content" });
            List<FilterItemSetting> actual;
            actual = target.AllEnabledColorFilters;
            Assert.AreEqual(1, actual.Count);

        }
        [TestMethod()]
        public void AllEnabledColorFiltersTest3()
        {

            BaseSettingManager target = CreateBaseSettingManager();
            target.NarrowFilterSettingItem = new FilterItemSetting { Name = "abc", StringValue = "abc", LogItem = "Content" };

            target.ColorFilterSettingList = new List<FilterItemSetting>();
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc1", StringValue = "abc1", LogItem = "Content" });
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc2", StringValue = "abc2", LogItem = "Content" });
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc3", StringValue = "abc3", LogItem = "Content" });
            List<FilterItemSetting> actual;
            actual = target.AllEnabledColorFilters;
            Assert.AreEqual(1, actual.Count);

        }
        [TestMethod()]
        public void AllEnabledColorFiltersTest4()
        {

            BaseSettingManager target = CreateBaseSettingManager();
            target.NarrowFilterSettingItem = new FilterItemSetting { Name = "abc", StringValue = "abc", LogItem = "Content" };

            target.ColorFilterSettingList = new List<FilterItemSetting>();
            List<FilterItemSetting> actual;
            actual = target.AllEnabledColorFilters;
            Assert.AreEqual(1, actual.Count);

        }
        [TestMethod()]
        public void AllEnabledColorFiltersTest5()
        {

            BaseSettingManager target = CreateBaseSettingManager();
            target.NarrowFilterSettingItem = new FilterItemSetting ();

            target.ColorFilterSettingList = new List<FilterItemSetting>();
            List<FilterItemSetting> actual;
            actual = target.AllEnabledColorFilters;
            Assert.AreEqual(1, actual.Count);

        }
        [TestMethod()]
        public void AllEnabledColorFiltersTest6()
        {

            BaseSettingManager target = CreateBaseSettingManager();
            target.NarrowFilterSettingItem = new FilterItemSetting { Name = "abc1", StringValue = "abc1", LogItem = "Content" };

            target.ColorFilterSettingList = new List<FilterItemSetting>();
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc1", StringValue = "abc1", LogItem = "Content" });
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc1", StringValue = "abc1", LogItem = "Content" });
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc3", StringValue = "abc3", LogItem = "Content" });
            List<FilterItemSetting> actual;
            actual = target.AllEnabledColorFilters;
            Assert.AreEqual(1, actual.Count);

        }
        [TestMethod()]
        public void AllEnabledColorFiltersTest7()
        {

            BaseSettingManager target = CreateBaseSettingManager();
            target.NarrowFilterSettingItem = new FilterItemSetting { Name = "abc1", StringValue = "abc1", LogItem = "Content" };

            target.ColorFilterSettingList = new List<FilterItemSetting>();
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc2", StringValue = "abc2", LogItem = "Content" });
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc2", StringValue = "abc2", LogItem = "Content" });
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc1", StringValue = "abc1", LogItem = "Content" });
            List<FilterItemSetting> actual;
            actual = target.AllEnabledColorFilters;
            Assert.AreEqual(1, actual.Count);

        }
        [TestMethod()]
        public void AllEnabledColorFiltersTest8()
        {

            BaseSettingManager target = CreateBaseSettingManager();
            target.NarrowFilterSettingItem = new FilterItemSetting { Name = "abc", StringValue = "abc", LogItem = "Content" };

            target.ColorFilterSettingList = new List<FilterItemSetting>();
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc2", StringValue = "abc2", LogItem = "Content" });
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc2", StringValue = "abc2", LogItem = "Content" });
            target.ColorFilterSettingList.Add(new FilterItemSetting { Name = "abc1", StringValue = "abc1", LogItem = "Content" });
            List<FilterItemSetting> actual;
            actual = target.AllEnabledColorFilters;
            Assert.AreEqual(1, actual.Count);

        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [DeploymentItem("FileConfig/CCSFilter.csv", "FileConfig")]
        public void BaseFilterSettingFilePathTest()
        {
            var param0 = new PrivateObject(typeof(CCSSettingManager)); 
            var target = new BaseSettingManager_Accessor(param0);
            var expected = Path.GetFullPath("FileConfig/CCSFilter.csv"); 
            string actual;

            string oldUserFilter = ConfigValue.UserCCSFilteringSettingFile;
            ConfigValue.UserCCSFilteringSettingFile = expected;

            actual = target.BaseFilterSettingFilePath;
            Assert.AreEqual(expected, actual);
            ConfigValue.UserCCSFilteringSettingFile = oldUserFilter;
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [DeploymentItem("FileConfig/CCSFilter.csv", "FileConfig")]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BaseFilterSettingFilePathTest1()
        {
            string u =ConfigValue.UserCCSFilteringSettingFile;
            string d = ConfigValue.DefaultCCSFilteringSettingFile;

            ConfigValue.UserCCSFilteringSettingFile = string.Empty;
            ConfigValue.DefaultCCSFilteringSettingFile = string.Empty;

            var param0 = new PrivateObject(typeof(CCSSettingManager));
            var target = new BaseSettingManager_Accessor(param0);

            var s = target.BaseFilterSettingFilePath;

            ConfigValue.UserCCSFilteringSettingFile = u;
            ConfigValue.DefaultCCSFilteringSettingFile = d;
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseKeywordCountSettingFilePathTest()
        {
            string text = @"0,Date,Date,Date,True
1,Time,Time,Time,True
2,Host.Host,Host,False
";

            string filename = string.Format("BaseKeywordCountSettingFilePathTest{0}.txt", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            PrivateObject param0 = new PrivateObject(typeof(CCSSettingManager)); 
            BaseSettingManager_Accessor target = new BaseSettingManager_Accessor(param0);
            string expected = fullPathName;
            string old = ConfigValue.UserCCSKeywordSettingFile;
            ConfigValue.UserCCSKeywordSettingFile = expected;

            string actual;
            actual = target.BaseKeywordCountSettingFilePath;
            Assert.AreEqual(expected, actual);
            ConfigValue.UserCCSKeywordSettingFile = old;
            File.Delete(fullPathName);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseLogDisplaySettingFilePathTest()
        {
            string text = @"0,Date,True
1,Time,True
2,Host,False
";

            string filename = string.Format("BaseLogDisplaySettingFilePathTest{0}.txt", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);


            PrivateObject param0 = new PrivateObject(typeof(CCSSettingManager)); 
            var target = new BaseSettingManager_Accessor(param0);
            string expected = fullPathName;
            string old = ConfigValue.UserCCSLogSettingFile;
            ConfigValue.UserCCSLogSettingFile = expected;
            string actual;
            actual = target.BaseLogDisplaySettingFilePath;
            Assert.AreEqual(expected, actual);

            ConfigValue.UserCCSLogSettingFile = old;
            File.Delete(fullPathName);
        }

        /// <summary>
        ///A test for BasePatternSettingFilePath
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BasePatternSettingFilePathTest()
        {

            string text = @"<?xml version='1.0' encoding='utf-8' ?>
<PatternAnalyze>
	<Content ID='1' Name='Workflow Pattern' Enable='True' >
		<RootItem Time='1000' TimeUnit='s'>Workflow</RootItem>
		<Items>
			<Item>UseOverwrap</Item>
			<Item>Exam</Item>
			<Item>Configflow</Item>
		</Items>
	</Content>
	<Content ID='2' Name='Configflow Pattern' Enable='True'>
		<RootItem Time='1000' TimeUnit='s' Enable='True'>Configflow</RootItem>
		<Items>
			<Item>GetInstance</Item>
			<Item>WorkflowLibrary</Item>
		</Items>
	</Content>
		<Content ID='3' Name='ERROR Pattern' Enable='True'>
		<RootItem Time='1000' TimeUnit='s'>FPGA_CONFIG</RootItem>
		<Items>
			<Item>errorCode</Item>
		</Items>
	</Content>
</PatternAnalyze>
";

            string filename = string.Format("BasePatternSettingFilePathTest{0}.txt", DateTime.Now.ToString("yyMMddhhmmssfff"));
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            var param0 = new PrivateObject(typeof(CCSSettingManager));
            var target = new BaseSettingManager_Accessor(param0);
            var expected = Path.GetFullPath(fullPathName);
            string old = ConfigValue.UserCCSPatternSettingFile;
            ConfigValue.UserCCSPatternSettingFile = expected;
            string actual;
            actual = target.BasePatternSettingFilePath;
            Assert.AreEqual(expected, actual);
            ConfigValue.UserCCSPatternSettingFile = old;
            File.Delete(fullPathName);
        }

        /// <summary>
        ///A test for ColorFilterSettingList
        ///</summary>
        [TestMethod()]
        public void ColorFilterSettingListTest()
        {
            BaseSettingManager target = CreateBaseSettingManager(); 
            List<FilterItemSetting> expected = new List<FilterItemSetting>(); 
            expected.Add(new FilterItemSetting{Id = "1",Name = "aaa"});
            expected.Add(new FilterItemSetting { Id = "2", Name = "BBB" });
            List<FilterItemSetting> actual;
            target.ColorFilterSettingList = expected;
            actual = target.ColorFilterSettingList;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DefaultFilterSettingFilePathTest()
        {
            var param0 = new PrivateObject(typeof(CCSSettingManager));
            var target = new BaseSettingManager_Accessor(param0);
            var expected = ConfigValue.DefaultCCSFilteringSettingFile;
            string actual;

            actual = target.DefaultFilterSettingFilePath;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DefaultKeywordCountSettingFilePathTest()
        {
            PrivateObject param0 = new PrivateObject(typeof(CCSSettingManager));
            BaseSettingManager_Accessor target = new BaseSettingManager_Accessor(param0);
            string expected = ConfigValue.DefaultCCSKeywordSettingFile;

            string actual;
            actual = target.DefaultKeywordCountSettingFilePath;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DefaultLogDisplaySettingFilePathTest()
        {
            PrivateObject param0 = new PrivateObject(typeof(CCSSettingManager));
            var target = new BaseSettingManager_Accessor(param0);
            string expected = ConfigValue.DefaultCCSLogSettingFile;
            string actual;
            actual = target.DefaultLogDisplaySettingFilePath;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for BasePatternSettingFilePath
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DefaultPatternSettingFilePathTest()
        {
            var param0 = new PrivateObject(typeof(CCSSettingManager));
            var target = new BaseSettingManager_Accessor(param0);
            var expected = ConfigValue.DefaultCCSPatternSettingFile;
            string actual;
            actual = target.DefaultPatternSettingFilePath;
            Assert.AreEqual(expected, actual);
        }




        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserFilterSettingFilePathTest()
        {
            var param0 = new PrivateObject(typeof(CCSSettingManager));
            var target = new BaseSettingManager_Accessor(param0);
            var expected = ConfigValue.UserCCSFilteringSettingFile;
            string actual;

            actual = target.UserFilterSettingFilePath;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserKeywordCountSettingFilePathTest()
        {
            PrivateObject param0 = new PrivateObject(typeof(CCSSettingManager));
            BaseSettingManager_Accessor target = new BaseSettingManager_Accessor(param0);
            string expected = ConfigValue.UserCCSKeywordSettingFile;

            string actual;
            actual = target.UserKeywordCountSettingFilePath;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserLogDisplaySettingFilePathTest()
        {
            PrivateObject param0 = new PrivateObject(typeof(CCSSettingManager));
            var target = new BaseSettingManager_Accessor(param0);
            string expected = ConfigValue.UserCCSLogSettingFile;
            string actual;
            actual = target.UserLogDisplaySettingFilePath;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UserPatternSettingFilePathTest()
        {
            var param0 = new PrivateObject(typeof(CCSSettingManager));
            var target = new BaseSettingManager_Accessor(param0);
            var expected = ConfigValue.UserCCSPatternSettingFile;
            string actual;
            actual = target.UserPatternSettingFilePath;
            Assert.AreEqual(expected, actual);
        }

    }
}
