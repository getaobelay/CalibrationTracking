using System.Windows;
using System.Windows.Controls;

namespace CalibrationTracking.CustomeControls
{
    public class CustomeGroupBox : GroupBox
    {
        static CustomeGroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomeGroupBox), new FrameworkPropertyMetadata(typeof(CustomeGroupBox)));
        }
    }
}