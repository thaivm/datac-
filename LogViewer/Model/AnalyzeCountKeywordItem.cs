// File:    AnalyzeCountKeywordItem.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 11:03:59 AM
// Purpose: Definition of Class AnalyzeCountKeywordItem

using System;

namespace LogViewer.Model
{
    /// <summary>
    /// Class provide method for holding keyword count info
    /// </summary>
   public class AnalyzedCountKeywordItem
   {
       /// <summary>
       /// Get or set name of keyword count
       /// </summary>
      public string Name{set;get;}
       /// <summary>
       /// Get or set number of found keyword 
       /// </summary>
      public int Count{set;get;}
   
   }
}