#if NETFX_CORE

using System.Collections.Generic;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Framework.Xaml
{
     // Using the TextBoxUpdateSourceBehavior
    // xmlns:util="clr-namespace:Framework.Xaml"
    // <TextBox Text="{Binding Username}" fvm:TextBoxUpdateSourceBehaviour.BindingSource="Username" />
    /// This class is for WinRT only
    /// http://www.codeproject.com/Articles/540839/Using-Smart-cards-with-a-Windows-Store-App
    /// https://social.msdn.microsoft.com/Forums/windowsapps/en-US/a04dc907-9ca8-4302-bbad-c00b01b8193f/no-updatesourcetrigger?forum=winappswithcsharp
    //
    public class TextBoxUpdateSourceBehaviour
    {
        private static Dictionary<TextBox, PropertyInfo> _boundProperties = new Dictionary<TextBox, PropertyInfo>();

        public static readonly DependencyProperty BindingSourceProperty =
            DependencyProperty.RegisterAttached(
            "BindingSource",
            typeof(string),
            typeof(TextBoxUpdateSourceBehaviour),
            new PropertyMetadata(default(string), OnBindingChanged));

        public static void SetBindingSource(TextBox element, string value)
        {
            element.SetValue(BindingSourceProperty, value);
        }

        public static string GetBindingSource(TextBox element)
        {
            return (string)element.GetValue(BindingSourceProperty);
        }

        private static void OnBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var txtBox = d as TextBox;
            if (txtBox != null)
            {
                txtBox.Loaded += OnLoaded;
                txtBox.TextChanged += OnTextChanged;
            }
        }

        static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var txtBox = sender as TextBox;
            if (txtBox != null)
            {

                // Reflect the datacontext of the textbox to find the field to bind to.
                if (txtBox.DataContext != null) // DataContext is null in the designer
                {
                    var dataContextType = txtBox.DataContext.GetType();
                    AddToBoundPropertyDictionary(txtBox, dataContextType.GetRuntimeProperty(GetBindingSource(txtBox)));
                }

                // If you want the behaviour to handle your binding as well, uncomment the following.
                //var binding = new Binding();
                //binding.Mode = BindingMode.TwoWay;
                //binding.Path = new PropertyPath(GetBindingSource(txt));
                //binding.Source = txt.DataContext;
                //BindingOperations.SetBinding(txt, TextBox.TextProperty, binding);
            }
        }

        static void AddToBoundPropertyDictionary(TextBox txtBox, PropertyInfo boundProperty)
        {
            PropertyInfo propInfo;
            if (!_boundProperties.TryGetValue(txtBox, out propInfo))
            {
                _boundProperties.Add(txtBox, boundProperty);
            }
        }
		
        static void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var txtBox = sender as TextBox;
            if (txtBox != null)
            {
                //_boundProperties[txtBox].SetValue(txtBox.DataContext, txtBox.Text);

                var data = _boundProperties[txtBox].GetValue(txtBox.DataContext);

                if (data == null || (data != null && string.IsNullOrWhiteSpace(data.ToString()) &&  !data.ToString().Equals(txtBox.Text)))
                {
                    if (data is string)
                    {
                        _boundProperties[txtBox].SetValue(txtBox.DataContext, txtBox.Text);
                    }
                    else if (data is byte)
                    {
                        byte typeValue;
                        if (byte.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.Int16)
                    {
                        System.Int16 typeValue;
                        if (System.Int16.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.Int32)
                    {
                        System.Int32 typeValue;
                        if (System.Int32.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.Int64)
                    {
                        System.Int64 typeValue;
                        if (System.Int64.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is sbyte)
                    {
                        sbyte typeValue;
                        if (sbyte.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.UInt16)
                    {
                        System.UInt16 typeValue;
                        if (System.UInt16.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.UInt32)
                    {
                        System.UInt32 typeValue;
                        if (System.UInt32.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.UInt32)
                    {
                        System.UInt32 typeValue;
                        if (System.UInt32.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.UInt64)
                    {
                        System.UInt64 typeValue;
                        if (System.UInt64.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.DateTime)
                    {
                        System.DateTime typeValue;
                        if (System.DateTime.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.DateTimeOffset)
                    {
                        System.DateTimeOffset typeValue;
                        if (System.DateTimeOffset.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.Guid)
                    {
                        System.Guid typeValue;
                        if (System.Guid.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.Boolean)
                    {
                        System.Boolean typeValue;
                        if (System.Boolean.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.Decimal)
                    {
                        System.Decimal typeValue;
                        if (System.Decimal.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.Double)
                    {
                        System.Double typeValue;
                        if (System.Double.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else if (data is System.Single)
                    {
                        System.Single typeValue;
                        if (System.Single.TryParse(txtBox.Text, out typeValue))
                        {
                            _boundProperties[txtBox].SetValue(txtBox.DataContext, typeValue);
                        }
                    }
                    else
                    {
                    }
                }
            }
        }
    }
}
#endif