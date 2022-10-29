using System.Windows;
using System.Windows.Controls;

namespace CalibrationTracking.CustomeControls
{
    public class CustomeTabControl : TabControl
    {
        static CustomeTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomeTabControl), new
               FrameworkPropertyMetadata(typeof(CustomeTabControl)));
        }

        public static readonly DependencyProperty AdditionalTabStripContentTemplateProperty = DependencyProperty.Register(
           nameof(AdditionalTabStripContentTemplate), typeof(DataTemplate), typeof(CustomeTabControl), new PropertyMetadata(null));

        public static readonly DependencyProperty AdditionalTabStripContentProperty = DependencyProperty.Register(
           nameof(AdditionalTabStripContent), typeof(object), typeof(CustomeTabControl), new PropertyMetadata(null));

        public DataTemplate AdditionalTabStripContentTemplate
        {
            get => (DataTemplate)GetValue(AdditionalTabStripContentTemplateProperty);
            set => SetValue(AdditionalTabStripContentTemplateProperty, value);
        }

        public object AdditionalTabStripContent
        {
            get => GetValue(AdditionalTabStripContentProperty);
            set => SetValue(AdditionalTabStripContentProperty, value);
        }
    }
}
