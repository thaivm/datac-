using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using LogViewer.Model;

namespace LogViewer.Business.FileSetting
{
    /// <summary>
    /// Class provides methods for manager CXDI setting file
    /// </summary>
    public class CXDISettingManager : BaseSettingManager
    {
        /// <summary>
        /// Get the path of setting file for graph parameter
        /// </summary>
        public String UserGraphParramSettingFilePath
        {
            get
            {
                return ConfigValue.UserGraphParamSettingFile;
            }
        }
        /// <summary>
        /// Get or set parameter for graph
        /// </summary>

        public IList<GraphParamSetting> GraphParamSettingList { get; set; }
        /// <summary>
        ///  Default constructor
        /// </summary>
        public CXDISettingManager()
        {
            CreateDefaultAppFolder();


            BasePatternSettingFilePath = ConfigValue.UserCXDIPatternSettingFile;
            BaseFilterSettingFilePath = ConfigValue.UserCXDIFilteringSettingFile;
            BaseKeywordCountSettingFilePath = ConfigValue.UserCXDIKeywordSettingFile;
            BaseLogDisplaySettingFilePath = ConfigValue.UserCXDILogSettingFile;
        }
        /// <summary>
        /// Get path of user pattern setting file, if the path is not exists the default pattern setting file will be use, 
        /// if the default pattern setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected override string BasePatternSettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.UserCXDIPatternSettingFile))
                {
                    CurrentPatternFileType = EnumSettingFileType.UserFile;
                    return ConfigValue.UserCXDIPatternSettingFile;
                }
                else if (File.Exists(ConfigValue.DefaultCXDIPatternSettingFile))
                {
                    CurrentPatternFileType = EnumSettingFileType.DefaultFile;
                    return ConfigValue.DefaultCXDIPatternSettingFile;
                }
                else
                {
                    CurrentPatternFileType = EnumSettingFileType.SystemFile;

                    throw new FileNotFoundException(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(ConfigValue.DefaultCXDIPatternSettingFile)));
                }
            }
        }
        /// <summary>
        /// Get or set the path of user pattern setting file.
        /// </summary>
        protected override string UserPatternSettingFilePath { get { return ConfigValue.UserCXDIPatternSettingFile; } }
        /// <summary>
        /// Get path of user filter setting file, if the path is not exists the default filter setting file will be use, 
        /// if the default filter setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected override string BaseFilterSettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.UserCXDIFilteringSettingFile))
                {
                    CurrentFilterSettingFileType = EnumSettingFileType.UserFile;
                    return ConfigValue.UserCXDIFilteringSettingFile;
                }
                if (File.Exists(ConfigValue.DefaultCXDIFilteringSettingFile))
                {
                    CurrentFilterSettingFileType = EnumSettingFileType.DefaultFile;
                    return ConfigValue.DefaultCXDIFilteringSettingFile;
                }
                CurrentFilterSettingFileType = EnumSettingFileType.SystemFile;

                throw new FileNotFoundException(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(ConfigValue.DefaultCXDIFilteringSettingFile)));
            }
        }
        /// <summary>
        /// Get or set the path of user filter setting file.
        /// </summary>
        protected override string UserFilterSettingFilePath { get { return ConfigValue.UserCXDIFilteringSettingFile; } }
        /// <summary>
        /// Get path of user keyword count setting file, if the path is not exists the default keyword count setting file will be use, 
        /// if the default keyword count setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected override string BaseKeywordCountSettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.UserCXDIKeywordSettingFile))
                {
                    CurrentKeywordCountFileType = EnumSettingFileType.UserFile;
                    return ConfigValue.UserCXDIKeywordSettingFile;
                }
                else if (File.Exists(ConfigValue.DefaultCXDIKeywordSettingFile))
                {
                    CurrentKeywordCountFileType = EnumSettingFileType.DefaultFile;
                    return ConfigValue.DefaultCXDIKeywordSettingFile;
                }
                else
                {
                    CurrentKeywordCountFileType = EnumSettingFileType.SystemFile;

                    throw new FileNotFoundException(ConfigValue.DefaultCXDIKeywordSettingFile);
                }
            }
        }
        /// <summary>
        /// Get or set the path of user keyword count setting file.
        /// </summary>
        protected override string UserKeywordCountSettingFilePath { get { return ConfigValue.UserCXDIKeywordSettingFile; } }
        /// <summary>
        /// Get path of user log display setting file, if the path is not exists the default log display setting file will be use, 
        /// if the default log display setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected override string BaseLogDisplaySettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.UserCXDILogSettingFile))
                {
                    CurrentLogDisplayFileType = EnumSettingFileType.UserFile;
                    return ConfigValue.UserCXDILogSettingFile;
                }
                else if (File.Exists(ConfigValue.DefaultCXDILogSettingFile))
                {
                    CurrentLogDisplayFileType = EnumSettingFileType.DefaultFile;
                    return ConfigValue.DefaultCXDILogSettingFile;
                }
                else
                {
                    CurrentLogDisplayFileType = EnumSettingFileType.SystemFile;
                    throw new FileNotFoundException(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(ConfigValue.DefaultCXDILogSettingFile)));
                }
            }
        }
        /// <summary>
        /// Get or set the path of user log display setting file.
        /// </summary>
        protected override string UserLogDisplaySettingFilePath { get { return ConfigValue.UserCXDILogSettingFile; } }
        /// <summary>
        /// Initial log display setting if user or default log display setting file is not exists
        /// </summary>
        protected override string DefaultLogDisplaySettingFilePath { get { return ConfigValue.DefaultCXDILogSettingFile; } }
        /// <summary>
        /// Read parameter from setting file for displaying graph. The parameter file path is got from <see cref="UserGraphParramSettingFilePath"/>
        /// </summary>
        public void ReadGraphParamSetting()
        {
            GraphParamSettingList = new List<GraphParamSetting>();

            if (File.Exists(UserGraphParramSettingFilePath))
            {

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(UserGraphParramSettingFilePath);


                    XmlNodeList ParameterList =
                        doc.SelectNodes("/GraphParameters/Parameters/Parameter");
                    GraphParamSetting param = new GraphParamSetting();

                    foreach (XmlNode parameter in ParameterList)
                    {
                        //Get content attribute
                        GraphParamSetting parameterItem = new GraphParamSetting
                        {

                            Id = parameter.Attributes
                            .GetNamedItem("ID").Value,
                            Name = parameter.SelectSingleNode("Name").InnerText,
                            StringValue = parameter.SelectSingleNode("Keyword").InnerText,
                            Enabled = Boolean.Parse(parameter.SelectSingleNode("Visible").InnerText),
                            GraphTypeValue = GraphType.Value,
                            PrototypeValue = (Prototype)Enum.Parse(typeof(Prototype), parameter.Attributes
                            .GetNamedItem("Prototype").Value)

                        };
                        GraphParamSettingList.Add(parameterItem);
                    }


                    XmlNodeList EventList = doc.SelectNodes("/GraphParameters/Events/Parameter");
                    foreach (XmlNode parameter in EventList)
                    {
                        //Get content attribute
                        //Get content attribute
                        GraphParamSetting parameterItem = new GraphParamSetting
                        {

                            Id = parameter.Attributes
                            .GetNamedItem("ID").Value,
                            Name = parameter.SelectSingleNode("Name").InnerText,
                            StringValue = parameter.SelectSingleNode("Keyword").InnerText,
                            Enabled = Boolean.Parse(parameter.SelectSingleNode("Visible").InnerText),
                            GraphTypeValue = GraphType.Event,
                            PrototypeValue = (Prototype)Enum.Parse(typeof(Prototype), parameter.Attributes
                            .GetNamedItem("Prototype").Value)

                        };
                        GraphParamSettingList.Add(parameterItem);
                    }
                }

                catch
                {
                    //Read file error;
                    throw new Exception(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(UserGraphParramSettingFilePath)));
                }
            }
        }
        /// <summary>
        /// Read parameter from setting file for displaying graph. The parameter file path is got from <see cref="UserGraphParramSettingFilePath"/>
        /// </summary>
        public void WriteGraphParamSetting()
        {
            CreateDefaultAppFolder();


            try
            {

                using (FileStream fs = new FileStream(UserGraphParramSettingFilePath, FileMode.Create))
                {
                    using (XmlWriter w = XmlWriter.Create(fs))
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        doc.AppendChild(docNode);
                        XmlNode GraphParameters = doc.CreateElement("GraphParameters");
                        //Create parameters node
                        XmlNode parameters = doc.CreateElement("Parameters");
                        BuildNode(doc, GraphParamSettingList.Where(g => (g.GraphTypeValue == GraphType.Value)).ToList(), parameters);
                        GraphParameters.AppendChild(parameters);
                        //Create events node
                        XmlNode events = doc.CreateElement("Events");
                        BuildNode(doc, GraphParamSettingList.Where(g => (g.GraphTypeValue == GraphType.Event)).ToList(), events);
                        GraphParameters.AppendChild(events);

                        doc.AppendChild(GraphParameters);
                        doc.Save(w);
                        w.Close();
                    }
                    fs.Close();
                }
            }
            catch
            {
                throw new Exception(string.Format(Properties.Resources.FILE_WRITE_EXCEPTION, Path.GetFileName(UserGraphParramSettingFilePath)));
            }

        }
        /// <summary>
        /// Use to build list of node inside parent node
        /// </summary>
        /// <param name="doc">XMl document object</param>
        /// <param name="paramList">List of parameter item</param>
        /// <param name="parentNode">the node that hold all child node</param>
        protected void BuildNode(XmlDocument doc, List<GraphParamSetting> paramList, XmlNode parentNode)
        {
            foreach (GraphParamSetting param in paramList)
            {
                XmlNode paramNode = doc.CreateElement("Parameter");

                //Create content attribute
                XmlAttribute paramNodeAttribute = doc.CreateAttribute("ID");
                paramNodeAttribute.Value = param.Id;
                paramNode.Attributes.Append(paramNodeAttribute);

                paramNodeAttribute = doc.CreateAttribute("Prototype");
                paramNodeAttribute.Value = ((int)param.PrototypeValue).ToString();
                paramNode.Attributes.Append(paramNodeAttribute);


                XmlNode nameNode = doc.CreateElement("Name");
                nameNode.InnerText = param.Name;
                paramNode.AppendChild(nameNode);

                XmlNode keywordNode = doc.CreateElement("Keyword");
                keywordNode.InnerText = param.StringValue;
                paramNode.AppendChild(keywordNode);

                XmlNode visibleNode = doc.CreateElement("Visible");
                visibleNode.InnerText = param.Enabled.ToString();
                paramNode.AppendChild(visibleNode);
                parentNode.AppendChild(paramNode);
            }
        }
        /// <summary>
        /// Initialize for log display settings, the list of display setting is got from <see cref="ConfigValue.SystemCXDILogSetting()"/>
        /// </summary>
        protected override void InitSystemLogDisplaySetting()
        {
            DisplaySetting.AddRange(ConfigValue.SystemCXDILogSetting());
        }

        /// <summary>
        /// Get log display settings, the list of display setting is got from <see cref="ConfigValue.SystemCXDILogSetting()"/>
        /// </summary>

        protected override List<LogDisplay> GetSystemConfig()
        {
            return ConfigValue.SystemCXDILogSetting();
        }
        /// <summary>
        /// Get log header list for CXDI log file, the list of log header is got from <see cref="ConfigValue.CXDIHeader.AllLogField"/>
        /// </summary>
        protected override List<string> GetLogHeader()
        {
            return ConfigValue.CXDIHeader.AllLogField;
        }
        /// <summary>
        /// Get the path of default pattern count setting file
        /// </summary>

        protected override string DefaultPatternSettingFilePath
        {
            get
            {
                return ConfigValue.DefaultCXDIPatternSettingFile;
            }
        }
        /// <summary>
        /// Get the path of default filter setting file
        /// </summary>

        protected override string DefaultFilterSettingFilePath
        {
            get
            {
                return ConfigValue.DefaultCXDIFilteringSettingFile;
            }
        }
        /// <summary>
        /// Get the path of default keyword count setting file
        /// </summary>

        protected override string DefaultKeywordCountSettingFilePath
        {
            get
            {
                return ConfigValue.DefaultCXDIKeywordSettingFile;
            }
        }
    }
}
