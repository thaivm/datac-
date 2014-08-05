using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LogViewer.Business;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileSetting
{
    
    [TestClass()]
    public class CCSSettingManagerTest
    {

        [TestMethod()]
        public void CCSSettingManagerConstructorTest()
        {
            CCSSettingManager target = new CCSSettingManager();
            Assert.IsNotNull(target);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetLogHeaderTest()
        {
            CCSSettingManager_Accessor target = new CCSSettingManager_Accessor();
            List<string> expected = ConfigValue.CCSHeader.AllLogField; 
            List<string> actual;
            actual = target.GetLogHeader();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReadErrorActionSettingTest()
        {
            string text = @"E,020201001,内部エラーが発生しました。,再度実行してください。問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201003,センサーのバッテリー残量が低下しています。,充電してください。
E,020201004,パターンファイルの読み込みに予期せぬエラーが発生したため、ガンマ調整できません。,システムを再起動してください。再起動後も問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201005,バーコードリーダーへの接続に失敗しました。,ケーブルが正しく接続されていることを確認し、システムを再起動してください。再起動後も問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201006,指定された検査を開始できませんでした。,検査画面に戻って再度実行してください。
E,020201007,センサー通信エラーが発生しました。,このプロトコルで再撮影を行ってください。問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201008,センサーの温度が動作可能な範囲を超過しました。,電源投入のまましばらく使用を停止してください。
E,020201009,オーバーラップソフトの起動に失敗しました。,システムを再起動してください。再起動後も問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201010,センサーのバッテリー残量が低下しています。,充電してください。
E,020201011,センサーにバッテリーが装着されていないため、撮影できません。,撮影を行う場合はセンサーにバッテリーを装着してください。
";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string old = ConfigValue.ErrorActionList;
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.ErrorActionList = fullPathName;

            CCSSettingManager target = new CCSSettingManager(); 
            target.ReadErrorActionSetting();
            Assert.AreEqual(10,target.ErrorActionSettingList.Count);
            ConfigValue.ErrorActionList = old;
            File.Delete(fullPathName);

        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ReadErrorActionSettingTest1()
        {
            string text = @"E,020201001,内部エラーが発生しました。,再度実行してください。問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201003,センサーのバッテリー残量が低下しています。,充電してください。
E,020201004,パターンファイルの読み込みに予期せぬエラーが発生したため、ガンマ調整できません。,システムを再起動してください。再起動後も問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201005,バーコードリーダーへの接続に失敗しました。,ケーブルが正しく接続されていることを確認し、システムを再起動してください。再起動後も問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201006,指定された検査を開始できませんでした。,検査画面に戻って再度実行してください。
E,020201007,センサー通信エラーが発生しました。,このプロトコルで再撮影を行ってください。問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201008,センサーの温度が動作可能な範囲を超過しました。,電源投入のまましばらく使用を停止してください。
E,020201009,オーバーラップソフトの起動に失敗しました。,システムを再起動してください。再起動後も問題が解決しない場合は、サービスパーソンに連絡してください。
E,020201010,センサーのバッテリー残量が低下しています。,充電してください。
E,020201011,センサーにバッテリーが装着されていないため、撮影できません。,撮影を行う場合はセンサーにバッテリーを装着してください。
";
            string filename = string.Format("ReadErrorActionSettingTest1{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string old = ConfigValue.ErrorActionList;
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.ErrorActionList = fullPathName;

            CCSSettingManager target = new CCSSettingManager();
            FileStream fs =  File.OpenWrite(fullPathName);
            target.ReadErrorActionSetting();
            Assert.AreEqual(10, target.ErrorActionSettingList.Count);
            ConfigValue.ErrorActionList = old;
            fs.Close();
            File.Delete(fullPathName);

        }

      

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadErrorActionSettingTest2()
        {
            string old = ConfigValue.ErrorActionList;
            ConfigValue.ErrorActionList = string.Empty;

            CCSSettingManager target = new CCSSettingManager();
            target.ReadErrorActionSetting();
            ConfigValue.ErrorActionList = old;

        }


        [TestMethod()]
        public void ReadUserActionSettingTest()
        {
            string text = @"1,Workflow : login_Login :,ログインボタンが押されました
2,Workflow : readyForShutdown :,シャットダウンボタンが押されました
3,ProvideExamflow : InputedClient :,入力ボタンが押されました/検査開始ボタンが押されました
4,Workflow : facade.ChangeOffLine :,OnLineボタンが押されました
5,Workflow : facade.ChangeOnLine :,OffLineボタンが押されました
6,ProvideExamflow : Mediator_EditProgramProvide : ,緊急患者ボタンが押されました
7,ProvideExamflow : Mediator_EditProgramProvide :,検査開始ボタンが押されました
8,ProvideExamflow : facade.DeletePatientInfoCandidate :,削除ボタンが押されました
9,ExamMgr[GetManualPCV],プロトコルボタンが押されました
10,Workflow : EditProgramCancelClick :,キャンセルボタンが押されました
";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string old = ConfigValue.UserActionList;
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserActionList = fullPathName;

            CCSSettingManager target = new CCSSettingManager();
            target.ReadUserActionSetting();
            Assert.AreEqual(10, target.UserActionSettingList.Count);
            ConfigValue.UserActionList = old;
            File.Delete(fullPathName);
        }
        [TestMethod()]
    [ExpectedException(typeof(FileNotFoundException))]
        public void ReadUserActionSettingTest1()
        {
            string old = ConfigValue.UserActionList;
            ConfigValue.UserActionList = string.Empty;

            CCSSettingManager target = new CCSSettingManager();
            target.ReadUserActionSetting();
            Assert.AreEqual(10, target.UserActionSettingList.Count);
            ConfigValue.UserActionList = old;
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseKeywordCountSettingFilePathTest()
        {
            string u = ConfigValue.UserCCSKeywordSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCCSKeywordSettingFile = fullPathName;

            CCSSettingManager target = new CCSSettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseKeywordCountSettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCCSKeywordSettingFile = u;
            File.Delete(fullPathName);
        }


        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseKeywordCountSettingFilePathTest1()
        {
            string u = ConfigValue.UserCCSKeywordSettingFile;
            string d = ConfigValue.DefaultCCSKeywordSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCCSKeywordSettingFile = string.Empty;
            ConfigValue.DefaultCCSKeywordSettingFile = fullPathName;

            CCSSettingManager target = new CCSSettingManager(); 
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseKeywordCountSettingFilePath");
            Assert.AreEqual(fullPathName,actual);
            ConfigValue.UserCCSKeywordSettingFile = u;
            ConfigValue.DefaultCCSKeywordSettingFile = d;
            File.Delete(fullPathName);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BaseKeywordCountSettingFilePathTest2()
        {
            string u = ConfigValue.UserCCSKeywordSettingFile;
            string d = ConfigValue.DefaultCCSKeywordSettingFile;

            ConfigValue.UserCCSKeywordSettingFile = string.Empty;
            ConfigValue.DefaultCCSKeywordSettingFile = string.Empty;

            CCSSettingManager target = new CCSSettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseKeywordCountSettingFilePath");
            ConfigValue.UserCCSKeywordSettingFile = u;
            ConfigValue.DefaultCCSKeywordSettingFile = d;
        }


        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseLogDisplaySettingFilePathTest()
        {
            string u = ConfigValue.UserCCSLogSettingFile;
            string d = ConfigValue.DefaultCCSLogSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCCSLogSettingFile = string.Empty;
            ConfigValue.DefaultCCSLogSettingFile = fullPathName;

            CCSSettingManager target = new CCSSettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseLogDisplaySettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCCSLogSettingFile = u;
            ConfigValue.DefaultCCSLogSettingFile = d;
            File.Delete(fullPathName);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BaseLogDisplaySettingFilePathTest1()
        {
            string u = ConfigValue.UserCCSLogSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCCSLogSettingFile = fullPathName;

            CCSSettingManager target = new CCSSettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BaseLogDisplaySettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCCSLogSettingFile = u;
            File.Delete(fullPathName);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BaseLogDisplaySettingFilePathTest2()
        {
            string u = ConfigValue.UserCCSLogSettingFile;
            string d = ConfigValue.DefaultCCSLogSettingFile;

            ConfigValue.UserCCSLogSettingFile = string.Empty;
            ConfigValue.DefaultCCSLogSettingFile = string.Empty;

            CCSSettingManager target = new CCSSettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            po.GetFieldOrProperty("BaseLogDisplaySettingFilePath");
            ConfigValue.UserCCSLogSettingFile = u;
            ConfigValue.DefaultCCSLogSettingFile = d;
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BasePatternSettingFilePathTest()
        {

            string u = ConfigValue.UserCCSPatternSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCCSPatternSettingFile = fullPathName;

            CCSSettingManager target = new CCSSettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BasePatternSettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCCSPatternSettingFile = u;
            File.Delete(fullPathName);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void BasePatternSettingFilePathTest2()
        {

            string u = ConfigValue.UserCCSPatternSettingFile;
            string d = ConfigValue.DefaultCCSPatternSettingFile;

            string text = "";
            string filename = string.Format("{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);
            ConfigValue.UserCCSPatternSettingFile = string.Empty;
            ConfigValue.DefaultCCSPatternSettingFile = fullPathName;

            CCSSettingManager target = new CCSSettingManager();
            string actual;
            PrivateObject po = new PrivateObject(target);
            actual = (string)po.GetFieldOrProperty("BasePatternSettingFilePath");
            Assert.AreEqual(fullPathName, actual);
            ConfigValue.UserCCSPatternSettingFile = u;
            ConfigValue.DefaultCCSPatternSettingFile = d;
            File.Delete(fullPathName);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BasePatternSettingFilePathTest1()
        {

            string u = ConfigValue.UserCCSPatternSettingFile;
            string d = ConfigValue.DefaultCCSPatternSettingFile;

            ConfigValue.UserCCSPatternSettingFile = string.Empty;
            ConfigValue.DefaultCCSPatternSettingFile = string.Empty;

            var target = new CCSSettingManager();
            var po = new PrivateObject(target);
            po.GetFieldOrProperty("BasePatternSettingFilePath");
            ConfigValue.UserCCSPatternSettingFile = u;
            ConfigValue.DefaultCCSPatternSettingFile = d;
        }
    }
}
