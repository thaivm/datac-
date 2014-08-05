using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace LogViewer.MVVMHelper
{

    /// <summary>
    /// An element whose content changes depending on a set of conditions.
    /// </summary>
    [ContentProperty("Cases")]
    [TemplatePart(Name = "Content", Type = typeof(ContentPresenter))]
    public class SwitchedContent : Control
    {

        #region Fields

        private ContentPresenter _Content;
        private Binding _Binding;
        private SwitchConverter _Converter;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the <see cref="T:SwitchedContent"/> class.
        /// </summary>
        static SwitchedContent()
        {

            DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchedContent), new FrameworkPropertyMetadata(typeof(SwitchedContent)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SwitchedContent"/> class.
        /// </summary>
        public SwitchedContent()
        {
            _Converter = new SwitchConverter();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the binding for the content property.
        /// </summary>
        public Binding Binding
        {
            get
            {
                return _Binding;
            }
            set
            {
                if (value != _Binding)
                {

                    _Binding = value;

                    if (_Binding != null)
                    {
                        _Binding.Converter = _Converter;
                    }

                    UpdateBindings();

                }
            }
        }

        /// <summary>
        /// A collection of switch cases that determine the content used.
        /// </summary>
        public SwitchCaseCollection Cases
        {
            get
            {
                return _Converter.Cases;
            }
        }

        /// <summary>
        /// Gets or sets the value to use when none of the cases match.
        /// </summary>
        public object Else
        {
            get
            {
                return _Converter.Else;
            }
            set
            {
                _Converter.Else = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call 
        /// <see cref="M:FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {

            base.OnApplyTemplate();

            _Content = GetTemplateChild("Content") as ContentPresenter;

            UpdateBindings();

        }

        /// <summary>
        /// Binds the ContentPresenter's Content property to the Binding set on this control.
        /// </summary>
        private void UpdateBindings()
        {
            if (_Content != null)
            {
                if (_Binding != null)
                {
                    _Content.SetBinding(ContentPresenter.ContentProperty, _Binding);
                }
                else
                {
                    _Content.ClearValue(ContentPresenter.ContentProperty);
                }
            }
        }

        #endregion

    }   // class

}   // namespace
