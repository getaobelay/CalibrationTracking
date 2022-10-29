using CalibrationTracking.Desktop.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CalibrationTracking.Desktop.Helpers
{
    public static class EnterKeyCommandHelper
    {
        public static IAsyncCommand GetEnterKeyCommand(DependencyObject target)
        {
            return (IAsyncCommand)target.GetValue(EnterKeyCommandProperty);
        }

        public static void SetEnterKeyCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(EnterKeyCommandProperty, value);
        }

        public static readonly DependencyProperty EnterKeyCommandProperty =
            DependencyProperty.RegisterAttached(
                "EnterKeyCommand",
                typeof(ICommand),
                typeof(EnterKeyCommandHelper),
                new PropertyMetadata(null, OnEnterKeyCommandChanged));

        private static void OnEnterKeyCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            ICommand command = (ICommand)e.NewValue;
            FrameworkElement fe = (FrameworkElement)target;
            Control control = (Control)target;
            control.KeyDown += (s, args) =>
            {
                if (args.Key == Key.Enter)
                {
                    // make sure the textbox binding updates its source first
                    BindingExpression b = control.GetBindingExpression(TextBox.TextProperty);
                    if (b != null)
                    {
                        b.UpdateSource();
                    }
                    command.Execute(null);
                }
            };
        }
    }
}
