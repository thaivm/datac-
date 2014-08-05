using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Drawing;
using LogViewer.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Linq;
using LogViewer.CustomException;
using System;
using Microsoft.Windows.Controls;
using LogViewer.Business;

namespace LogViewer.MVVMHelper
{
    public class RichTextBoxHelper : DependencyObject
    {
        /// <summary>
        /// Get property LineOfContent
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <returns>line of content</returns>
        public static string GetLineOfContent(DependencyObject obj)
        {
            return (string)obj.GetValue(LineOfContentProperty);
        }
        /// <summary>
        /// Set property LineOfContent
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <param name="value">Line of content</param>
        public static void SetLineOfContent(DependencyObject obj, string value)
        {
            obj.SetValue(LineOfContentProperty, value);
        }
        /// <summary>
        /// Dependency property for the <see cref="P:LineOfContent"/> property.
        /// </summary>
        private static readonly DependencyProperty LineOfContentProperty =
          DependencyProperty.RegisterAttached("LineOfContent", typeof(string), typeof(RichTextBoxHelper),
          new PropertyMetadata(null, new PropertyChangedCallback(OnLineOfContentPropertyChanged)));
        /// <summary>
        /// On Line of Content Property changed
        /// </summary>
        /// <param name="o">DependencyObject</param>
        /// <param name="args">DependencyPropertyChangedEventArgs</param>
        private static void OnLineOfContentPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        { }
        ///<summary>
        /// Get property content value of rich text box
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <returns>content of rich text box</returns>
        public static string GetDocumentXaml(DependencyObject obj)
        {
            return (string)obj.GetValue(DocumentXamlProperty);
        }
        /// <summary>
        /// Set property content value of rich text box
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <param name="value">Value for set to content</param>
        public static void SetDocumentXaml(DependencyObject obj, string value)
        {
            obj.SetValue(DocumentXamlProperty, value);
        }
        /// <summary>
        /// Dependency property for the <see cref="P:DocumentXaml"/> property.
        /// </summary>
        private static readonly DependencyProperty DocumentXamlProperty =
          DependencyProperty.RegisterAttached("DocumentXaml", typeof(string), typeof(RichTextBoxHelper),
          new PropertyMetadata(null, new PropertyChangedCallback(OnDocumentXamlPropertyChanged)));
        /// <summary>
        /// On document xaml property changed.
        /// </summary>
        /// <param name="o">DependencyObject</param>
        /// <param name="args">DependencyPropertyChangedEventArgs</param>
        private static void OnDocumentXamlPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var richTextBox = (o as RichTextBox);
            string name = richTextBox.Name.Trim();
            List<FilterItemSetting> filterSettingList = richTextBox.GetValue(FilterToShowProperty) as List<FilterItemSetting>;
            object patternColor = null;
            if(filterSettingList != null)
                patternColor = filterSettingList.SingleOrDefault(x => x.PatternColor != null);
            // pattern
            if (patternColor != null)
            {
                ShowPatternColoring(richTextBox, patternColor, filterSettingList);
            }
            else
            {
                // filter
                FilterColorToRichTextBox(richTextBox, filterSettingList, name, false);
            }
        }
        /// <summary>
        /// Dependency property for the <see cref="P:ShowPatternColoring"/> property.
        /// </summary>
        private static readonly DependencyProperty ShowPatternColoringProperty =
              DependencyProperty.RegisterAttached("ShowPatternColoring", typeof(object), typeof(RichTextBoxHelper),
              new PropertyMetadata(null, new PropertyChangedCallback(OnShowPatternColoringChanged)));
        ///<summary>
        /// Get property ShowPatternColoring of rich text box
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <returns>object</returns>
        public static object GetShowPatternColoring(DependencyObject o)
        {
            return o.GetValue(ShowPatternColoringProperty);
        }
        ///<summary>
        /// Set property ShowPatternColoring of rich text box
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <param name="value">object</param>
        public static void SetShowPatternColoring(DependencyObject o, object value)
        {
            o.SetValue(ShowPatternColoringProperty, value);
        }
        /// <summary>
        /// On ShowPatternColoringChanged
        /// </summary>
        /// <param name="o">DependencyObject</param>
        /// <param name="args">DependencyPropertyChangedEventArgs</param>
        private static void OnShowPatternColoringChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var richTextBox = (o as RichTextBox);
        }
        /// <summary>
        /// Show pattern coloring when click in data grid of pattern analyzer tab.
        /// </summary>
        /// <param name="richTextBox">Rich text box content or message</param>
        /// <param name="pattern">type of object pattern is PatternColor</param>
        /// <param name="filterItemSetting">A collection FilterItemSetting</param>
        private static void ShowPatternColoring(RichTextBox richTextBox, object pattern, List<FilterItemSetting> filterItemSetting)
        {
            string name = richTextBox.Name.Trim();
            int line = Convert.ToInt32(richTextBox.GetValue(LineOfContentProperty));
            if (name.Equals("Content"))
            {
                FilterItemSetting item = ConfigValue.DefaultPatternItem.Copy();
                item.LogItem = name;
                List<FilterItemSetting> items = new List<FilterItemSetting>();
                PatternColor<CCSLogRecord> patternColor = ((FilterItemSetting)pattern).PatternColor as PatternColor<CCSLogRecord>;
                if (patternColor == null) return;
                if (patternColor._rootKey.ContainsKey(line))
                {
                    item.StringValue = patternColor._rootKey[line].Key;
                    item.Background = "#FF0000";
                    item.Id = "rootkey";
                    item.index = patternColor._rootKey[line].Index;
                    items.Add(item);

                    foreach (var record in patternColor._dicKey)
                    {
                        if (record.Line == line)
                        {
                            item = ConfigValue.DefaultPatternItem.Copy();
                            item.LogItem = name;
                            item.StringValue = record.Key;
                            item.Background = record.Color;
                            item.Id = "string";
                            item.index = record.Index;
                            items.Add(item);
                        }
                    }
                    items.AddRange(filterItemSetting);
                    FilterColorToRichTextBox(richTextBox, items, name, true);
                    return;
                }
                foreach (var record in patternColor._dicKey)
                {
                    if (record.Line == line)
                    {
                        item = ConfigValue.DefaultPatternItem.Copy();
                        item.LogItem = name;
                        item.StringValue = record.Key;
                        item.Background = record.Color;
                        item.Id = "string";
                        item.index = record.Index;
                        items.Add(item);
                    }
                }

                items.AddRange(filterItemSetting);
                FilterColorToRichTextBox(richTextBox, items, name, true);
                return;
            }
            if (name.Equals("Message"))
            {
                FilterItemSetting item = ConfigValue.DefaultPatternItem.Copy();
                item.LogItem = name;
                List<FilterItemSetting> items = new List<FilterItemSetting>();
                PatternColor<CXDILogRecord> patternColor = ((FilterItemSetting)pattern).PatternColor as PatternColor<CXDILogRecord>;
                if (patternColor == null) return;
                if (patternColor._rootKey.ContainsKey(line))
                {
                    item.StringValue = patternColor._rootKey[line].Key;
                    item.Background = "#FF0000";
                    item.Id = "rootkey";
                    item.index = patternColor._rootKey[line].Index;
                    items.Add(item);
                    foreach (var record in patternColor._dicKey)
                    {
                        if (record.Line == line)
                        {
                            item = ConfigValue.DefaultPatternItem.Copy();
                            item.LogItem = name;
                            item.StringValue = record.Key;
                            item.Background = record.Color;
                            item.Id = "string";
                            item.index = record.Index;
                            items.Add(item);
                        }
                    }

                    items.AddRange(filterItemSetting);
                    FilterColorToRichTextBox(richTextBox, items, name, true);
                    return;
                }

                foreach (var record in patternColor._dicKey)
                {
                    if (record.Line == line)
                    {
                        item = ConfigValue.DefaultPatternItem.Copy();
                        item.LogItem = name;
                        item.StringValue = record.Key;
                        item.Background = record.Color;
                        item.Id = "string";
                        item.index = record.Index;
                        items.Add(item);
                    }
                }

                items.AddRange(filterItemSetting);
                FilterColorToRichTextBox(richTextBox, items, name, true);
                return;
            }
            FilterColorToRichTextBox(richTextBox, filterItemSetting, name, true);
        }
        /// <summary>
        /// Dependency property for the <see cref="P:FilterToShow"/> property.
        /// </summary>
        private static readonly DependencyProperty FilterToShowProperty =
              DependencyProperty.RegisterAttached("FilterToShow", typeof(object), typeof(RichTextBoxHelper),
              new PropertyMetadata(null, new PropertyChangedCallback(OnFilterToShowChanged)));
        ///<summary>
        /// Get property FilterToShow of rich text box
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <returns>object</returns>
        public static object GetFilterToShow(DependencyObject o)
        {
            return o.GetValue(FilterToShowProperty);
        }
        ///<summary>
        /// Set property FilterToShow of rich text box
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <param name="value">object</param>
        public static void SetFilterToShow(DependencyObject o, object value)
        {
            o.SetValue(FilterToShowProperty, value);
        }
        /// <summary>
        /// On FilterToShowChanged
        /// </summary>
        /// <param name="o">DependencyObject</param>
        /// <param name="args">DependencyPropertyChangedEventArgs</param>
        private static void OnFilterToShowChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var richTextBox = (o as RichTextBox);
            string name = richTextBox.Name.Trim();
            List<FilterItemSetting> filterSettingList = richTextBox.GetValue(FilterToShowProperty) as List<FilterItemSetting>;
            object patternColor = filterSettingList.SingleOrDefault(x => x.PatternColor != null);
            // pattern
            if (patternColor != null)
            {
                ShowPatternColoring(richTextBox, patternColor, filterSettingList);
            }
            else
            {
                // filter
                FilterColorToRichTextBox(richTextBox, filterSettingList, name, false);
            }
        }
        private static void FilterColorToRichTextBox(RichTextBox richTextBox, List<FilterItemSetting> filterSettingList, string name, bool isPattern)
        {
            var value = richTextBox.GetValue(DocumentXamlProperty) as string;
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(value)));
            if (filterSettingList == null || value == null)
            {
                return;
            }
            List<FilterItemSetting> effectiveFilterSettingList = filterSettingList.Where(x => x.Enabled && x.LogItem == name && !x.IsPattern).Cast<FilterItemSetting>().ToList();
            List<FilterItemSetting> listPattern = filterSettingList.FindAll(x => x.IsPattern == true);
            if (effectiveFilterSettingList.Count() == 0 && listPattern.Count() == 0)
            {
                return;
            }
            // get all filter string list on content
            List<FilterItemSetting> listFilterDisplay = new List<FilterItemSetting>();
            listFilterDisplay = ExtractFilterStringRegular(effectiveFilterSettingList, value);
            if (listFilterDisplay.Count == 0 && listPattern.Count() == 0)
            {
                return;
            }

            if (name.Equals("Content") || name.Equals("Message"))
            {
                foreach (var item in listPattern)
                {
                    listFilterDisplay.Add(item);
                }
            }

            listFilterDisplay = listFilterDisplay.OrderBy(x => x.index).ThenBy(y => y.StringValue.Length).ToList();

            Dictionary<FilterItemSetting, FilterItemMerge> listFilterValueMergeDic = new Dictionary<FilterItemSetting, FilterItemMerge>();
            List<FilterItemSetting> listFilterValueMergeList = new List<FilterItemSetting>();
            string stringMerge = listFilterDisplay[0].StringValue;
            int indexOfStringMerge = listFilterDisplay[0].index;
            FilterItemSetting filterTemp = new FilterItemSetting();
            filterTemp.StringValue = value.Substring(0, listFilterDisplay[0].index);
            filterTemp.Foreground = System.Windows.Media.Brushes.Black.ToString();
            filterTemp.Background = System.Windows.Media.Brushes.Transparent.ToString();
            FilterItemMerge filterItemMerge = new FilterItemMerge();
            listFilterValueMergeList.Add(filterTemp);
            bool flagMerge = false;
            var filterDisplayITemp = listFilterDisplay[0];
            for (int i = 0; i < listFilterDisplay.Count - 1; i++)
            {
                for (int j = i + 1; j < listFilterDisplay.Count; j++)
                {
                    int lastIndexOfI = filterDisplayITemp.index + filterDisplayITemp.StringValue.Length - 1;
                    int lastIndexOfJ = listFilterDisplay[j].index + listFilterDisplay[j].StringValue.Length - 1;
                    if (lastIndexOfI >= listFilterDisplay[j].index)
                    {
                        if (lastIndexOfI >= lastIndexOfJ && listFilterDisplay[j].index >= filterDisplayITemp.index)
                        {
                            if (!filterItemMerge.ItemSetings.Contains(filterDisplayITemp))
                            {
                                filterItemMerge.ItemSetings.Add(filterDisplayITemp);
                            }
                            if (!filterItemMerge.ItemSetings.Contains(listFilterDisplay[j]))
                            {
                                filterItemMerge.ItemSetings.Add(listFilterDisplay[j]);
                            }
                        }
                        else if (lastIndexOfJ >= lastIndexOfI && filterDisplayITemp.index >= listFilterDisplay[j].index)
                        {
                            if (!filterItemMerge.ItemSetings.Contains(filterDisplayITemp))
                            {
                                filterItemMerge.ItemSetings.Add(filterDisplayITemp);
                            }
                            if (!filterItemMerge.ItemSetings.Contains(listFilterDisplay[j]))
                            {
                                filterItemMerge.ItemSetings.Add(listFilterDisplay[j]);
                            }
                            filterDisplayITemp = listFilterDisplay[j];
                        }
                        else
                        {
                            stringMerge = value.Substring(indexOfStringMerge, lastIndexOfJ - indexOfStringMerge + 1);
                            filterItemMerge.IsMerge = true;
                            if (!filterItemMerge.ItemSetings.Contains(filterDisplayITemp))
                            {
                                filterItemMerge.ItemSetings.Add(filterDisplayITemp);
                            }
                            if (!filterItemMerge.ItemSetings.Contains(listFilterDisplay[j]))
                            {
                                filterItemMerge.ItemSetings.Add(listFilterDisplay[j]);
                            }
                            filterDisplayITemp = listFilterDisplay[j];
                            flagMerge = true;
                        }
                    }
                    else
                    {
                        if (flagMerge == false)
                        {
                            filterItemMerge.ItemSetings.Add(filterDisplayITemp);
                            listFilterValueMergeList.Add(filterDisplayITemp);
                            listFilterValueMergeDic.Add(filterDisplayITemp, filterItemMerge);
                            filterItemMerge = new FilterItemMerge();
                            filterItemMerge = new FilterItemMerge();
                            FilterItemSetting filter2 = new FilterItemSetting();
                            filter2 = filterTemp.Copy();
                            filter2.StringValue = value.Substring(filterDisplayITemp.index + filterDisplayITemp.StringValue.Length, listFilterDisplay[j].index - filterDisplayITemp.index - filterDisplayITemp.StringValue.Length);
                            listFilterValueMergeList.Add(filter2);
                            filterItemMerge = new FilterItemMerge();
                            stringMerge = listFilterDisplay[j].StringValue;
                            indexOfStringMerge = listFilterDisplay[j].index;
                            filterDisplayITemp = listFilterDisplay[j];
                            break;
                        }
                        FilterItemSetting filter3 = new FilterItemSetting();
                        filter3 = filterTemp.Copy();
                        filter3.index = listFilterDisplay[j].index;
                        filter3.StringValue = stringMerge;
                        filterItemMerge.ItemSetings.Add(filter3);
                        listFilterValueMergeDic.Add(filter3, filterItemMerge);
                        listFilterValueMergeList.Add(filter3);
                        
                        filterItemMerge = new FilterItemMerge();
                        FilterItemSetting filter4 = new FilterItemSetting();
                        filter4 = filter3.Copy();
                        filter4.StringValue = value.Substring(indexOfStringMerge + stringMerge.Length, listFilterDisplay[j].index - indexOfStringMerge - stringMerge.Length);
                        listFilterValueMergeList.Add(filter4);
                        filterItemMerge = new FilterItemMerge();
                        stringMerge = listFilterDisplay[j].StringValue;
                        indexOfStringMerge = listFilterDisplay[j].index;
                        flagMerge = false;
                        filterDisplayITemp = listFilterDisplay[j];
                    }
                    break;
                }
            }

            if (filterItemMerge.ItemSetings.Count == 0)
            {
                filterItemMerge.ItemSetings.Add(listFilterDisplay.Last());
            }

            FilterItemSetting filter6 = new FilterItemSetting();

            filter6 = listFilterDisplay.FirstOrDefault().Copy();
            int indexFilter = filter6.index + filter6.StringValue.Length;
            foreach (var i in listFilterDisplay)
            {
                if (indexFilter <= i.index + i.StringValue.Length)
                {
                    filter6 = i.Copy();
                    indexFilter = i.index + i.StringValue.Length;
                }
            }
            listFilterValueMergeList.Add(filter6);
            listFilterValueMergeDic.Add(filter6, filterItemMerge);

            if(value.Length > filter6.index + filter6.StringValue.Length)
            {
                FilterItemSetting filter4 = new FilterItemSetting();
                filter4 = filterTemp.Copy();
                filter4.index = filter6.index + filter6.StringValue.Length;
                filter4.StringValue = value.Substring(filter6.index + filter6.StringValue.Length, value.Length - filter6.index - filter6.StringValue.Length);
                listFilterValueMergeList.Add(filter4);
            }
            
            List<FilterItemSetting> filterDisplays = new List<FilterItemSetting>();
            foreach (var filterString in listFilterValueMergeList)
            {
                if (!listFilterValueMergeDic.ContainsKey(filterString))
                {
                    filterTemp = new FilterItemSetting();
                    filterTemp.Foreground = System.Windows.Media.Brushes.Black.ToString();
                    filterTemp.Background = System.Windows.Media.Brushes.Transparent.ToString();
                    filterTemp.StringValue = filterString.StringValue;
                    filterTemp.index = filterString.index;
                    filterDisplays.Add(filterTemp);
                }
                else if (listFilterValueMergeDic.ContainsKey(filterString))
                {
                    if (listFilterValueMergeDic[filterString].ItemSetings.Count != 0)
                    {
                        List<FilterItemSetting> itemsSettings = new List<FilterItemSetting>();
                        foreach (var i in listFilterValueMergeDic[filterString].ItemSetings)
                        {
                            if (!itemsSettings.Contains(i))
                            {
                                itemsSettings.Add(i);
                            }
                        }
                        itemsSettings = itemsSettings.OrderBy(x => x.index).ThenByDescending(y => y.StringValue.Length).ToList();
                        var filter = itemsSettings.FirstOrDefault().Copy(); ;
                        if (itemsSettings.Count > 1)
                        {
                            var filterFirst = itemsSettings[0];
                            var filterSecond = itemsSettings[1];
                            List<FilterItemSetting> itemSettingSplit = new List<FilterItemSetting>();
                            if (filterFirst.index + filterFirst.StringValue.Length > filterSecond.index && filterFirst.index <= filterSecond.index)
                            {
                                itemSettingSplit = MergeColor(itemSettingSplit, value, filterFirst, filterSecond);
                            }
                            else if (filterSecond.index + filterSecond.StringValue.Length > filterFirst.index && filterFirst.index > filterSecond.index)
                            {
                                itemSettingSplit = MergeColor(itemSettingSplit, value, filterSecond, filterFirst);
                            }
                            if (itemsSettings.Count > 2)
                            {
                                for (int i = 2; i < itemsSettings.Count; i++)
                                {
                                    List<FilterItemSetting> itemSettingSplitTemp = new List<FilterItemSetting>();
                                    foreach (var j in itemSettingSplit)
                                    {
                                        if (itemsSettings[i].index + itemsSettings[i].StringValue.Length > j.index && itemsSettings[i].index <= j.index)
                                        {
                                            itemSettingSplitTemp = MergeColor(itemSettingSplitTemp, value, itemsSettings[i], j);
                                        }
                                        else if (j.index + j.StringValue.Length > itemsSettings[i].index && itemsSettings[i].index > j.index)
                                        {
                                            itemSettingSplitTemp = MergeColor(itemSettingSplitTemp, value, j, itemsSettings[i]);
                                        }
                                        else
                                        {
                                            itemSettingSplitTemp = new List<FilterItemSetting>(AddItem(itemSettingSplitTemp, j));
                                        }
                                    }
                                    itemSettingSplit = new List<FilterItemSetting>(itemSettingSplitTemp);
                                }
                            }

                            foreach (var i in itemSettingSplit)
                            {
                                filterDisplays.Add(i);
                            }
                        }
                        else
                        {
                            if (filterDisplays.FindAll(x => x.index == filter.index && x.StringValue.Equals(filter.StringValue)).Count == 0)
                                filterDisplays.Add(filter);
                        }
                    }
                }
            }

            // apply all string after split to datagrid
            Paragraph para = new Paragraph();
            var converter = new System.Windows.Media.BrushConverter();
            foreach (var filter in filterDisplays)
            {
                if (filter.StringValue.Equals(String.Empty)) continue;
                Run run = new Run(filter.StringValue);
                try
                {
                    run.Background = (System.Windows.Media.Brush)converter.ConvertFromString(filter.Background);
                    run.Foreground = (System.Windows.Media.Brush)converter.ConvertFromString(filter.Foreground);
                }
                catch
                { }
                if (filter.FontStyle != null)
                {
                    SetFontStyle(run, filter.FontStyle);
                }
                para.Inlines.Add(run);
            }
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(para);
        }

        private static List<FilterItemSetting> MergeColor(List<FilterItemSetting> splitFilter, string value, FilterItemSetting itemFirst, FilterItemSetting itemSecond)
        {
            List<FilterItemSetting> list = new List<FilterItemSetting>(splitFilter);
            var lcs = LongestCommonSubstring(value, itemFirst.index, itemSecond.index, itemFirst.StringValue.Length, itemSecond.StringValue.Length);
            FilterItemSetting item = itemFirst.Copy();
            item.index = itemFirst.index;
            item.Name = item.index.ToString();
            item.StringValue = lcs[0];
            if (!item.StringValue.Equals(String.Empty))
                list = new List<FilterItemSetting>(AddItem(list, item));


            item = item.Copy();
            item.index = item.index + item.StringValue.Length;
            item.Name = item.index.ToString();
            item.StringValue = lcs[1];
            item.Foreground = RBGToHex(LabtoRGB(mixLabColor(RGBtoLab(ColorToRGB(itemFirst.Foreground)), RGBtoLab(ColorToRGB(itemSecond.Foreground)))));
            item.Background = RBGToHex(LabtoRGB(mixLabColor(RGBtoLab(ColorToRGB(itemFirst.Background)), RGBtoLab(ColorToRGB(itemSecond.Background)))));
            if (!item.StringValue.Equals(String.Empty))
                list = new List<FilterItemSetting>(AddItem(list, item));

            item = item.Copy();
            item.index = item.index + item.StringValue.Length;
            item.Name = item.index.ToString();
            item.StringValue = lcs[2];
            if (itemFirst.index + itemFirst.StringValue.Length > itemSecond.index + itemSecond.StringValue.Length)
            {
                item.Background = itemFirst.Background;
                item.Foreground = itemFirst.Foreground;
                item.FontStyle = itemFirst.FontStyle;
            }
            else
            {
                item.Background = itemSecond.Background;
                item.Foreground = itemSecond.Foreground;
                item.FontStyle = itemSecond.FontStyle;
            }

            if (!item.StringValue.Equals(String.Empty))
                list = new List<FilterItemSetting>(AddItem(list, item));
            return list;
        }

        /// <summary>
        /// Add item to list FilterItemSetting <see cref="FilterItemSetting"/>, if not contains in list-> add  else merge color with item exists.
        /// </summary>
        /// <param name="itemSettingSplit">List FilterItemSetting</param>
        /// <param name="item">FilterItemSetting</param>
        /// <returns>List FilterItemSetting</returns>
        private static List<FilterItemSetting> AddItem(List<FilterItemSetting> itemSettingSplit, FilterItemSetting item)
        {
            List<FilterItemSetting> itemSettingSplitTemp = new List<FilterItemSetting>(itemSettingSplit);
            FilterItemSetting itemExists = itemSettingSplitTemp.SingleOrDefault(x => x.index == item.index && x.StringValue.Equals(item.StringValue));
            if (itemExists == null)
            {
                itemSettingSplitTemp.Add(item);
            }
            else
            {
                itemSettingSplitTemp.Remove(itemExists);
                FilterItemSetting itemTemp = itemExists.Copy();
                itemTemp.Foreground = RBGToHex(LabtoRGB(mixLabColor(RGBtoLab(ColorToRGB(itemTemp.Foreground)), RGBtoLab(ColorToRGB(item.Foreground)))));
                itemTemp.Background = RBGToHex(LabtoRGB(mixLabColor(RGBtoLab(ColorToRGB(itemTemp.Background)), RGBtoLab(ColorToRGB(item.Background)))));
                itemSettingSplitTemp.Add(itemTemp);
            }
            return itemSettingSplitTemp;
        }
        /// <summary>
        /// Extract filter string contains regular
        /// </summary>
        /// <param name="effectiveFilterSettingList">List FilterItemSetting have regular</param>
        /// <param name="value">Content of richtextbox</param>
        /// <returns>List FilterItemSeting after extract</returns>
        private static List<FilterItemSetting> ExtractFilterStringRegular(List<FilterItemSetting> effectiveFilterSettingList, string value)
        {
            List<FilterItemSetting> listFilterDisplay = new List<FilterItemSetting>();
            List<int> listIndex = new List<int>();
            foreach (var filter in effectiveFilterSettingList)
            {
                string stringValue = filter.StringValue.Trim();
                if (stringValue.Contains("\""))
                {
                    List<int> notAndOr = IndexOfAll1(stringValue, "\"");
                    Regex regex = null;
                    try
                    {
                        if (notAndOr.Count != 2)
                        {
                            regex = new Regex(Regex.Split(stringValue, "\"")[1]);
                        }
                        else
                        {
                            regex = new Regex(stringValue.Replace("\"", ""));
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }

                    var v = regex.Matches(value);
                    foreach (Match match in v)
                    {
                        string s = match.Groups[0].ToString();
                        if (!s.Equals(String.Empty))
                        {
                            int index = match.Index;
                            FilterItemSetting item = new FilterItemSetting();
                            item = filter.Copy();
                            item.StringValue = value.Substring(index, s.Length);
                            item.index = index;
                            listFilterDisplay.Add(item);
                        }
                    }
                }
                else
                {
                    if (stringValue.Contains(ConfigValue.SEARCH_KEY_OR))
                    {
                        string[] stringValueOrArray = Regex.Split(stringValue, Regex.Escape(ConfigValue.SEARCH_KEY_OR));
                        for (int i = 0; i < stringValueOrArray.Length; i++)
                        {
                            string stringValueOr = stringValueOrArray[i].Trim();
                            if (stringValueOr.Equals(String.Empty))
                            {
                                continue;
                            }
                            if (stringValueOr.Contains(ConfigValue.SEARCH_KEY_AND))
                            {
                                string[] stringValueAndArray = Regex.Split(stringValueOr, ConfigValue.SEARCH_KEY_AND);
                                bool flag = true;
                                for (int j = 0; j < stringValueAndArray.Length; j++)
                                {
                                    if (stringValueAndArray[j].Trim().Equals(String.Empty)) continue;
                                    if (!value.ToLower().Contains(stringValueAndArray[j].ToLower()))
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                if (flag == true)
                                {
                                    for (int j = 0; j < stringValueAndArray.Length; j++)
                                    {
                                        if (stringValueAndArray[j].Trim().Equals(String.Empty)) continue;
                                        listIndex = IndexOfAll(value, stringValueAndArray[j]);
                                        foreach (var index in listIndex)
                                        {
                                            FilterItemSetting item = new FilterItemSetting();
                                            item = filter.Copy();
                                            item.StringValue = value.Substring(index, stringValueAndArray[j].Length);
                                            item.index = index;
                                            listFilterDisplay.Add(item);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (value.ToLower().Contains(stringValueOr.ToLower()))
                                {
                                    listIndex = IndexOfAll(value, stringValueOr);
                                    foreach (var index in listIndex)
                                    {
                                        FilterItemSetting item = new FilterItemSetting();
                                        item = filter.Copy();
                                        item.StringValue = value.Substring(index, stringValueOr.Length);
                                        item.index = index;
                                        listFilterDisplay.Add(item);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (stringValue.Contains(ConfigValue.SEARCH_KEY_AND))
                        {
                            string[] stringValueAndArray = Regex.Split(stringValue, ConfigValue.SEARCH_KEY_AND);
                            bool flag = true;
                            for (int j = 0; j < stringValueAndArray.Length; j++)
                            {
                                if (stringValueAndArray[j].Trim().Equals(String.Empty)) continue;
                                if (!value.ToLower().Contains(stringValueAndArray[j].ToLower()))
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag == true)
                            {
                                for (int j = 0; j < stringValueAndArray.Length; j++)
                                {
                                    if (stringValueAndArray[j].Trim().Equals(String.Empty)) continue;
                                    listIndex = IndexOfAll(value, stringValueAndArray[j]);
                                    foreach (var index in listIndex)
                                    {
                                        FilterItemSetting item = new FilterItemSetting();
                                        item = filter.Copy();
                                        item.index = index;
                                        item.StringValue = value.Substring(index, stringValueAndArray[j].Length);
                                        listFilterDisplay.Add(item);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (value.ToLower().Contains(stringValue.ToLower()))
                            {
                                listIndex = IndexOfAll(value, stringValue);
                                foreach (var i in listIndex)
                                {
                                    FilterItemSetting item = new FilterItemSetting();
                                    item = filter.Copy();
                                    item.index = i;
                                    item.StringValue = value.Substring(i, stringValue.Length);
                                    listFilterDisplay.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            return listFilterDisplay;
        }
        /// <summary>
        /// Change color from RGB to hex string
        /// </summary>
        /// <param name="rgb">RGB Color</param>
        /// <returns>Hex string</returns>
        public static string RBGToHex(RGB rgb)
        {
            return "#" + rgb.Red.ToString("X2") + rgb.Green.ToString("X2") + rgb.Blue.ToString("X2");
        }
        /// <summary>
        /// Change color from hex to RGB
        /// </summary>
        /// <param name="hex">hex string</param>
        /// <returns>RGB color</returns>
        public static RGB ColorToRGB(string hex)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(hex);
            return new RGB(color.R, color.G, color.B);
        }
        /// <summary>
        /// Mid to lab color
        /// </summary>
        /// <param name="color1">CIELab color1</param>
        /// <param name="color2">CIELab color2</param>
        /// <returns>CIELab color</returns>
        public static CIELab mixLabColor(CIELab color1, CIELab color2)
        {
            double l = (color1.L + color2.L) / 2;
            double a = (color1.A + color2.A) / 2;
            double b = (color1.B + color2.B) / 2;
            return new CIELab(l, a, b);
        }
        /// <summary>
        /// Get Index of sub string in parent string with lower case
        /// </summary>
        /// <param name="str">parent string</param>
        /// <param name="substr">sub string</param>
        /// <param name="ignoreCase"></param>
        /// <returns>A collect of index</returns>
        public static List<int> IndexOfAll(string str, string substr, bool ignoreCase = false)
        {
            str = str.ToLower();
            substr = substr.ToLower();
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(substr))
            {
                throw new ArgumentException("String or substring is not specified.");
            }

            var indexes = new List<int>();
            int index = 0;

            while ((index = str.IndexOf(substr, index, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) != -1)
            {
                indexes.Add(index++);
            }

            return indexes;
        }
        /// <summary>
        /// Get Index of sub string in parent string without lower case
        /// </summary>
        /// <param name="str">parent string</param>
        /// <param name="substr">sub string</param>
        /// <param name="ignoreCase"></param>
        /// <returns>A collection of index</returns>
        public static List<int> IndexOfAll1(string str, string substr, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(substr))
            {
                throw new ArgumentException("String or substring is not specified.");
            }

            var indexes = new List<int>();
            int index = 0;

            while ((index = str.IndexOf(substr, index, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) != -1)
            {
                indexes.Add(index++);
            }

            return indexes;
        }
        /// <summary>
        /// Get common substring of str1 and str2 using index and length base on parent string
        /// </summary>
        /// <param name="str">Parent string</param>
        /// <param name="index1">Index of string 1 in parent string</param>
        /// <param name="index2">Index of string 2 in parent string</param>
        /// <param name="length1">Length of string 1</param>
        /// <param name="length2">Length of string 2</param>
        /// <returns>A collection of string</returns>
        public static List<string> LongestCommonSubstring(string str, int index1, int index2, int length1, int length2)
        {
            List<string> list = new List<string>();
            if ((index2 + length2) < (index1 + length1))
            {
                list.Add(str.Substring(index1, index2 - index1));
                list.Add(str.Substring(index2, length2));
                list.Add(str.Substring(index2 + length2, index1 + length1 - index2 - length2));
            }
            else
            {
                list.Add(str.Substring(index1, index2 - index1));
                list.Add(str.Substring(index2, index1 + length1 - index2));
                list.Add(str.Substring(index1 + length1, index2 + length2 - index1 - length1));
            }
            return list;
        }
        /// <summary>
        /// Set font style to Control 
        /// </summary>
        /// <param name="control">Run</param>
        /// <param name="fontStyle">font style string</param>
        private static void SetFontStyle(Run control, string fontStyle)
        {
            switch (fontStyle)
            {
                case ConfigValue.FilterSettingFontStyles.BOLD:
                    {
                        control.FontWeight = FontWeights.Bold;
                        control.FontStyle = FontStyles.Normal;
                        break;
                    }
                case ConfigValue.FilterSettingFontStyles.ITALIC:
                    {
                        control.FontWeight = FontWeights.Normal;
                        control.FontStyle = FontStyles.Italic;
                        break;
                    }
                case ConfigValue.FilterSettingFontStyles.NORMAL:
                    {
                        control.FontWeight = FontWeights.Normal;
                        control.FontStyle = FontStyles.Normal;
                        break;
                    }
                case ConfigValue.FilterSettingFontStyles.BOLDITALIC:
                    {
                        control.FontWeight = FontWeights.Bold;
                        control.FontStyle = FontStyles.Italic;
                        break;
                    }
                default:
                    throw new DataValueNotSupportedException();
            }
        }
        /// <summary>
        /// Class contains a collection can merge.
        /// </summary>
        public class FilterItemMerge
        {
            /// <summary>
            /// Get and set IsMerge
            /// </summary>
            public bool IsMerge { get ; set;}
            /// <summary>
            /// Get and Set Collection 
            /// </summary>
            public List<FilterItemSetting> ItemSetings { get; set; }
            /// <summary>
            /// Initialize FilterItemMerge
            /// </summary>
            public FilterItemMerge()
            {
                ItemSetings = new List<FilterItemSetting>();
            }
        }
        /// <summary>
        /// Structure to define CIE L*a*b*.
        /// </summary>
        public struct CIELab
        {
            /// <summary>
            /// Gets an empty CIELab structure.
            /// </summary>
            public static readonly CIELab Empty = new CIELab();

            private double l;
            private double a;
            private double b;


            public static bool operator ==(CIELab item1, CIELab item2)
            {
                return (
                    item1.L == item2.L
                    && item1.A == item2.A
                    && item1.B == item2.B
                    );
            }

            public static bool operator !=(CIELab item1, CIELab item2)
            {
                return (
                    item1.L != item2.L
                    || item1.A != item2.A
                    || item1.B != item2.B
                    );
            }


            /// <summary>
            /// Gets or sets L component.
            /// </summary>
            public double L
            {
                get
                {
                    return this.l;
                }
                set
                {
                    this.l = value;
                }
            }

            /// <summary>
            /// Gets or sets a component.
            /// </summary>
            public double A
            {
                get
                {
                    return this.a;
                }
                set
                {
                    this.a = value;
                }
            }

            /// <summary>
            /// Gets or sets a component.
            /// </summary>
            public double B
            {
                get
                {
                    return this.b;
                }
                set
                {
                    this.b = value;
                }
            }

            public CIELab(double l, double a, double b)
            {
                this.l = l;
                this.a = a;
                this.b = b;
            }

            public override bool Equals(Object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;

                return (this == (CIELab)obj);
            }

            public override int GetHashCode()
            {
                return L.GetHashCode() ^ a.GetHashCode() ^ b.GetHashCode();
            }

        }
        /// <summary>
        /// Structure to define CIE XYZ.
        /// </summary>
        public struct CIEXYZ
        {
            /// <summary>
            /// Gets an empty CIEXYZ structure.
            /// </summary>
            public static readonly CIEXYZ Empty = new CIEXYZ();
            /// <summary>
            /// Gets the CIE D65 (white) structure.
            /// </summary>
            public static readonly CIEXYZ D65 = new CIEXYZ(0.9505, 1.0, 1.0890);


            private double x;
            private double y;
            private double z;

            public static bool operator ==(CIEXYZ item1, CIEXYZ item2)
            {
                return (
                    item1.X == item2.X
                    && item1.Y == item2.Y
                    && item1.Z == item2.Z
                    );
            }

            public static bool operator !=(CIEXYZ item1, CIEXYZ item2)
            {
                return (
                    item1.X != item2.X
                    || item1.Y != item2.Y
                    || item1.Z != item2.Z
                    );
            }

            /// <summary>
            /// Gets or sets X component.
            /// </summary>
            public double X
            {
                get
                {
                    return this.x;
                }
                set
                {
                    this.x = (value > 0.9505) ? 0.9505 : ((value < 0) ? 0 : value);
                }
            }

            /// <summary>
            /// Gets or sets Y component.
            /// </summary>
            public double Y
            {
                get
                {
                    return this.y;
                }
                set
                {
                    this.y = (value > 1.0) ? 1.0 : ((value < 0) ? 0 : value);
                }
            }

            /// <summary>
            /// Gets or sets Z component.
            /// </summary>
            public double Z
            {
                get
                {
                    return this.z;
                }
                set
                {
                    this.z = (value > 1.089) ? 1.089 : ((value < 0) ? 0 : value);
                }
            }

            public CIEXYZ(double x, double y, double z)
            {
                this.x = (x > 0.9505) ? 0.9505 : ((x < 0) ? 0 : x);
                this.y = (y > 1.0) ? 1.0 : ((y < 0) ? 0 : y);
                this.z = (z > 1.089) ? 1.089 : ((z < 0) ? 0 : z);
            }

            public override bool Equals(Object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;

                return (this == (CIEXYZ)obj);
            }

            public override int GetHashCode()
            {
                return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
            }

        }
        /// <summary>
        /// RGB structure.
        /// </summary>
        public struct RGB
        {
            /// <summary>
            /// Gets an empty RGB structure;
            /// </summary>
            public static readonly RGB Empty = new RGB();

            private int red;
            private int green;
            private int blue;

            public static bool operator ==(RGB item1, RGB item2)
            {
                return (
                    item1.Red == item2.Red
                    && item1.Green == item2.Green
                    && item1.Blue == item2.Blue
                    );
            }

            public static bool operator !=(RGB item1, RGB item2)
            {
                return (
                    item1.Red != item2.Red
                    || item1.Green != item2.Green
                    || item1.Blue != item2.Blue
                    );
            }

            /// <summary>
            /// Gets or sets red value.
            /// </summary>
            public int Red
            {
                get
                {
                    return red;
                }
                set
                {
                    red = (value > 255) ? 255 : ((value < 0) ? 0 : value);
                }
            }

            /// <summary>
            /// Gets or sets red value.
            /// </summary>
            public int Green
            {
                get
                {
                    return green;
                }
                set
                {
                    green = (value > 255) ? 255 : ((value < 0) ? 0 : value);
                }
            }

            /// <summary>
            /// Gets or sets red value.
            /// </summary>
            public int Blue
            {
                get
                {
                    return blue;
                }
                set
                {
                    blue = (value > 255) ? 255 : ((value < 0) ? 0 : value);
                }
            }

            public RGB(int R, int G, int B)
            {
                this.red = (R > 255) ? 255 : ((R < 0) ? 0 : R);
                this.green = (G > 255) ? 255 : ((G < 0) ? 0 : G);
                this.blue = (B > 255) ? 255 : ((B < 0) ? 0 : B);
            }

            public override bool Equals(Object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;

                return (this == (RGB)obj);
            }

            public override int GetHashCode()
            {
                return Red.GetHashCode() ^ Green.GetHashCode() ^ Blue.GetHashCode();
            }
        }
        /// <summary>
        /// XYZ to L*a*b* transformation function.
        /// </summary>
        private static double Fxyz(double t)
        {
            return ((t > 0.008856) ? Math.Pow(t, (1.0 / 3.0)) : (7.787 * t + 16.0 / 116.0));
        }

        /// <summary>
        /// Converts CIEXYZ to CIELab.
        /// </summary>
        public static CIELab XYZtoLab(double x, double y, double z)
        {
            CIELab lab = CIELab.Empty;

            lab.L = 116.0 * Fxyz(y / CIEXYZ.D65.Y) - 16;
            lab.A = 500.0 * (Fxyz(x / CIEXYZ.D65.X) - Fxyz(y / CIEXYZ.D65.Y));
            lab.B = 200.0 * (Fxyz(y / CIEXYZ.D65.Y) - Fxyz(z / CIEXYZ.D65.Z));

            return lab;
        }
        /// <summary>
        /// Converts RGB to CIELab.
        /// </summary>
        public static CIELab RGBtoLab(RGB rgb)
        {
            CIEXYZ xyz = RGBtoXYZ(rgb.Red, rgb.Green, rgb.Blue);
            return XYZtoLab(xyz.X, xyz.Y, xyz.Z);
        }
        /// <summary>
        /// Converts RGB to CIE XYZ (CIE 1931 color space)
        /// </summary>
        public static CIEXYZ RGBtoXYZ(int red, int green, int blue)
        {
            // normalize red, green, blue values
            double rLinear = (double)red / 255.0;
            double gLinear = (double)green / 255.0;
            double bLinear = (double)blue / 255.0;

            // convert to a sRGB form
            double r = (rLinear > 0.04045) ? Math.Pow((rLinear + 0.055) / (
                1 + 0.055), 2.2) : (rLinear / 12.92);
            double g = (gLinear > 0.04045) ? Math.Pow((gLinear + 0.055) / (
                1 + 0.055), 2.2) : (gLinear / 12.92);
            double b = (bLinear > 0.04045) ? Math.Pow((bLinear + 0.055) / (
                1 + 0.055), 2.2) : (bLinear / 12.92);

            // converts
            return new CIEXYZ(
                (r * 0.4124 + g * 0.3576 + b * 0.1805),
                (r * 0.2126 + g * 0.7152 + b * 0.0722),
                (r * 0.0193 + g * 0.1192 + b * 0.9505)
                );
        }
        /// <summary>
        /// Converts CIELab to RGB.
        /// </summary>
        public static RGB LabtoRGB(CIELab lab)
        {
            CIEXYZ xyz = LabtoXYZ(lab.L, lab.A, lab.B);
            return XYZtoRGB(xyz.X, xyz.Y, xyz.Z);
        }
        /// <summary>
        /// Converts CIEXYZ to RGB structure.
        /// </summary>
        public static RGB XYZtoRGB(double x, double y, double z)
        {
            double[] Clinear = new double[3];
            Clinear[0] = x * 3.2410 - y * 1.5374 - z * 0.4986; // red
            Clinear[1] = -x * 0.9692 + y * 1.8760 - z * 0.0416; // green
            Clinear[2] = x * 0.0556 - y * 0.2040 + z * 1.0570; // blue

            for (int i = 0; i < 3; i++)
            {
                Clinear[i] = (Clinear[i] <= 0.0031308) ? 12.92 * Clinear[i] : (
                    1 + 0.055) * Math.Pow(Clinear[i], (1.0 / 2.4)) - 0.055;
            }

            return new RGB(
                Convert.ToInt32(Double.Parse(String.Format("{0:0.00}",
                    Clinear[0] * 255.0))),
                Convert.ToInt32(Double.Parse(String.Format("{0:0.00}",
                    Clinear[1] * 255.0))),
                Convert.ToInt32(Double.Parse(String.Format("{0:0.00}",
                    Clinear[2] * 255.0)))
                );
        }
        /// <summary>
        /// Converts CIELab to CIEXYZ.
        /// </summary>
        public static CIEXYZ LabtoXYZ(double l, double a, double b)
        {
            double delta = 6.0 / 29.0;

            double fy = (l + 16) / 116.0;
            double fx = fy + (a / 500.0);
            double fz = fy - (b / 200.0);

            return new CIEXYZ(
                (fx > delta) ? CIEXYZ.D65.X * (fx * fx * fx) : (fx - 16.0 / 116.0) * 3 * (
                    delta * delta) * CIEXYZ.D65.X,
                (fy > delta) ? CIEXYZ.D65.Y * (fy * fy * fy) : (fy - 16.0 / 116.0) * 3 * (
                    delta * delta) * CIEXYZ.D65.Y,
                (fz > delta) ? CIEXYZ.D65.Z * (fz * fz * fz) : (fz - 16.0 / 116.0) * 3 * (
                    delta * delta) * CIEXYZ.D65.Z
                );
        }
    }
}
