﻿using System.Windows;
using System.Windows.Controls;
using CalibrationTracking.CustomeControls;

namespace CalibrationTracking.CustomeControls
{
    public class AnimatedTextBox : TextBox
    {
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(AnimatedTextBox),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(AnimatedTextBox),
                new FrameworkPropertyMetadata(null));

        static AnimatedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimatedTextBox),
                new FrameworkPropertyMetadata(typeof(AnimatedTextBox)));
        }

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
    }
}
