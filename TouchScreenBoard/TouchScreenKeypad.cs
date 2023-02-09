using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Reflection.Emit;

namespace TouchScreenBoard
{
    public class TouchScreenKeypad : Window
    {
        #region Property & Variable & Constructor
        private static double _WidthTouchKeypad = 300;

        private static double _heightTouchKeypad = 300;

        public static double HeightTouchKeyboard
        {
            get { return _heightTouchKeypad; }
            set { _heightTouchKeypad = value; }
        }

        public static double WidthTouchKeyboard
        {
            get { return _WidthTouchKeypad; }
            set { _WidthTouchKeypad = value; }

        }

        private static Window _InstanceObject;

        private static Brush _PreviousTextBoxBackgroundBrush = null;
        private static Brush _PreviousTextBoxBorderBrush = null;
        private static Thickness _PreviousTextBoxBorderThickness;

        private static Control _CurrentControl;
        public static string TouchScreenText
        {
            get
            {
                if (_CurrentControl is TextBox)
                {
                    return ((TextBox)_CurrentControl).Text;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    return ((PasswordBox)_CurrentControl).Password;
                }
                else return "";


            }
            set
            {
                if (_CurrentControl is TextBox)
                {
                    ((TextBox)_CurrentControl).Text = value;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    ((PasswordBox)_CurrentControl).Password = value;
                }


            }

        }

        public static RoutedUICommand Cmd1 = new RoutedUICommand();
        public static RoutedUICommand Cmd2 = new RoutedUICommand();
        public static RoutedUICommand Cmd3 = new RoutedUICommand();
        public static RoutedUICommand Cmd4 = new RoutedUICommand();
        public static RoutedUICommand Cmd5 = new RoutedUICommand();
        public static RoutedUICommand Cmd6 = new RoutedUICommand();
        public static RoutedUICommand Cmd7 = new RoutedUICommand();
        public static RoutedUICommand Cmd8 = new RoutedUICommand();
        public static RoutedUICommand Cmd9 = new RoutedUICommand();
        public static RoutedUICommand Cmd0 = new RoutedUICommand();
        public static RoutedUICommand CmdDot = new RoutedUICommand();
        public static RoutedUICommand CmdBackspace = new RoutedUICommand();

        //berk
        public static RoutedUICommand CmdScroll = new RoutedUICommand();


        public static RoutedUICommand CmdEnter = new RoutedUICommand();

        public static RoutedUICommand CmdClear = new RoutedUICommand();
        public static RoutedUICommand CmdClose = new RoutedUICommand();


        static bool moved = false;
        public TouchScreenKeypad()
        {
            Width = WidthTouchKeyboard;
            Height = HeightTouchKeyboard;
            moved = false;
        }

        static TouchScreenKeypad()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TouchScreenKeypad), new FrameworkPropertyMetadata(typeof(TouchScreenKeypad)));

            SetCommandBinding();
        }
        #endregion
        #region CommandRelatedCode
        private static void SetCommandBinding()
        {
            CommandBinding Cb1 = new CommandBinding(Cmd1, RunCommand);
            CommandBinding Cb2 = new CommandBinding(Cmd2, RunCommand);
            CommandBinding Cb3 = new CommandBinding(Cmd3, RunCommand);
            CommandBinding Cb4 = new CommandBinding(Cmd4, RunCommand);
            CommandBinding Cb5 = new CommandBinding(Cmd5, RunCommand);
            CommandBinding Cb6 = new CommandBinding(Cmd6, RunCommand);
            CommandBinding Cb7 = new CommandBinding(Cmd7, RunCommand);
            CommandBinding Cb8 = new CommandBinding(Cmd8, RunCommand);
            CommandBinding Cb9 = new CommandBinding(Cmd9, RunCommand);
            CommandBinding Cb0 = new CommandBinding(Cmd0, RunCommand);
            CommandBinding CbDot = new CommandBinding(CmdDot, RunCommand);
            CommandBinding CbBackspace = new CommandBinding(CmdBackspace, RunCommand);
            //berk
            CommandBinding CbScroll = new CommandBinding(CmdScroll, RunCommand);


            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb1);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb2);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb3);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb4);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb5);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb6);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb7);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb8);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb9);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb0);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbDot);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbBackspace);
            //berk
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbScroll);


            CommandBinding CbEnter = new CommandBinding(CmdEnter, RunCommand);

            CommandBinding CbClear = new CommandBinding(CmdClear, RunCommand);
            CommandBinding CbClose = new CommandBinding(CmdClose, RunCommand);

            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbEnter);

            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbClear);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbClose);
        }
        private static bool IsRunning;
        static void RunCommand(object sender, ExecutedRoutedEventArgs e)
        {
            string result = "";
            if (e.Command == Cmd1)
            {
                result = "1";
            }
            else if (e.Command == Cmd2)
            {
                result = "2";

            }
            else if (e.Command == Cmd3)
            {
                result = "3";

            }
            else if (e.Command == Cmd4)
            {
                result = "4";
            }
            else if (e.Command == Cmd5)
            {
                result = "5";
            }
            else if (e.Command == Cmd6)
            {
                result = "6";
            }
            else if (e.Command == Cmd7)
            {
                result = "7";
            }
            else if (e.Command == Cmd8)
            {
                result = "8";
            }
            else if (e.Command == Cmd9)
            {
                result = "9";
            }
            else if (e.Command == Cmd0)
            {
                result = "0";
            }
            else if (e.Command == CmdDot)
            {
                result = ".";
            }
            else if (e.Command == CmdBackspace)
            {
                IsRunning = true;
                if (SelectionStart > 0)
                {
                    if (TouchScreenKeypad.SelectedText.Length > 0)
                    {
                        TouchScreenKeypad.TouchScreenText =
                            TouchScreenKeypad.TouchScreenText.Remove(SelectionStart, SelectedText.Length);
                        SelectedText = "";
                    }
                    else
                    {
                        TouchScreenKeypad.TouchScreenText = TouchScreenKeypad.TouchScreenText.Remove(SelectionStart - 1, 1);
                        --SelectionStart;
                        if (SelectionStart < 0) SelectionStart = 0;
                    }
                }
                IsRunning = false;
            }
            else if (e.Command == CmdEnter)
            {
                if (_InstanceObject != null)
                {
                    if (TouchScreenText == "" || TouchScreenText == null || TouchScreenText == string.Empty)
                    {
                        TouchScreenText = "0";
                    }
                    _InstanceObject.Close();
                    _InstanceObject = null;
                }
                _CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                //System.Windows.Input.Keyboard.ClearFocus();
                SelectionStart = TouchScreenKeypad.TouchScreenText.Length;
                SelectedText = "";
            }
            else if (e.Command == CmdClear)//Last row
            {
                TouchScreenKeypad.TouchScreenText = "";
                SelectionStart = 0;
                SelectedText = "";
            }
            else if (e.Command == CmdClose)
            {
                if (TouchScreenText == "" || TouchScreenText == null || TouchScreenText == string.Empty)
                {
                    TouchScreenText = "0";
                }
                OnLostFocus(_CurrentControl, null);
            }
            else if (e.Command == CmdScroll)
            {
                if (!TouchScreenKeypad.TouchScreenText.Equals(""))
                {
                    string firstCharacter = TouchScreenKeypad.TouchScreenText.Substring(0, 1);
                    if (!firstCharacter.Equals("-"))
                    {
                        TouchScreenKeypad.TouchScreenText = "-" + TouchScreenKeypad.TouchScreenText;
                    }
                    else
                    {
                        TouchScreenKeypad.TouchScreenText = TouchScreenKeypad.TouchScreenText.Replace("-", "");
                    }
                }
                else
                {
                    TouchScreenKeypad.TouchScreenText = "-" + TouchScreenKeypad.TouchScreenText;
                }


            }
            AddResult(result);
        }
        private static void AddResult(string result)
        {
            IsRunning = true;
            if (_CurrentControl != null)
            {
                if (_CurrentControl is TextBox)
                {
                    TextBox tb = (TextBox)_CurrentControl;
                    if (SelectedText == null)
                    {
                        SelectedText = "";
                        SelectionStart = tb.Text.Length;
                    }
                    if (TouchScreenKeypad.SelectedText.Length > 0)
                    {
                        TouchScreenKeypad.TouchScreenText =
                            TouchScreenKeypad.TouchScreenText.Remove(tb.SelectionStart, tb.SelectedText.Length);
                    }
                    if (SelectionStart > TouchScreenKeypad.TouchScreenText.Length)
                        SelectionStart = TouchScreenKeypad.TouchScreenText.Length;
                    TouchScreenKeypad.TouchScreenText =
                        TouchScreenKeypad.TouchScreenText.Insert(SelectionStart, result);
                    if (result != "") ++SelectionStart;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    PasswordBox tb = (PasswordBox)_CurrentControl;
                    TouchScreenKeypad.TouchScreenText =
                        TouchScreenKeypad.TouchScreenText.Insert(SelectionStart, result);
                    if (result != "") ++SelectionStart;
                }
            }
            IsRunning = false;
        }
        #endregion
        #region Main Functionality

        private static void syncchild()
        {
            try
            {
                if (_CurrentControl != null && _InstanceObject != null)
                {

                    Point virtualpoint = new Point(0, _CurrentControl.ActualHeight + 3);
                    Point Actualpoint = _CurrentControl.PointToScreen(virtualpoint);

                    if (WidthTouchKeyboard + Actualpoint.X > SystemParameters.VirtualScreenWidth)
                    {
                        double difference = WidthTouchKeyboard + Actualpoint.X - SystemParameters.VirtualScreenWidth;
                        _InstanceObject.Left = Actualpoint.X - difference;
                    }
                    else if (!(Actualpoint.X > 1))
                    {
                        _InstanceObject.Left = 1;
                    }
                    else
                    {
                        _InstanceObject.Left = Actualpoint.X;
                    }

                    if (HeightTouchKeyboard + Actualpoint.Y > SystemParameters.VirtualScreenHeight)
                    {
                        _InstanceObject.Top = _CurrentControl.PointToScreen(new Point(0, 0)).Y - HeightTouchKeyboard - 3;
                    }
                    else
                    {
                        _InstanceObject.Top = Actualpoint.Y;
                    }

                    _InstanceObject.Show();
                    var abc = (TextBox)_CurrentControl;
                    if (abc.Text == "0")
                    {
                        abc.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                _InstanceObject.Close();
                //throw;
            }



        }

        public static bool GetTouchScreenKeypad(DependencyObject obj)
        {
            return (bool)obj.GetValue(TouchScreenKeypadProperty);
        }

        public static void SetTouchScreenKeypad(DependencyObject obj, bool value)
        {
            obj.SetValue(TouchScreenKeypadProperty, value);
        }

        public static readonly DependencyProperty TouchScreenKeypadProperty =
            DependencyProperty.RegisterAttached("TouchScreenKeypad", typeof(bool), typeof(TouchScreenKeypad), new UIPropertyMetadata(default(bool), TouchScreenKeypadPropertyChanged));

        static void TouchScreenKeypadPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement host = sender as FrameworkElement;
            if (host != null)
            {
                host.GotFocus += new RoutedEventHandler(OnGotFocus);
                host.LostFocus += new RoutedEventHandler(OnLostFocus);
            }
            if (host is TextBox)
            {
                ((TextBox)host).SelectionChanged += TouchScreenKeypad_SelectionChanged;
            }
        }
        static int SelectionStart;
        static string SelectedText;
        private static void TouchScreenKeypad_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!IsRunning)
            {
                SelectionStart = ((TextBox)sender).SelectionStart;
                SelectedText = ((TextBox)sender).SelectedText;
            }
        }

        static void OnGotFocus(object sender, RoutedEventArgs e)
        {
            Control host = sender as Control;

            //_PreviousTextBoxBackgroundBrush = host.Background;
            _PreviousTextBoxBorderBrush = host.BorderBrush;
            _PreviousTextBoxBorderThickness = host.BorderThickness;

            //host.Background = Brushes.Cyan;
            host.BorderBrush = Brushes.Blue;
            host.BorderThickness = new Thickness(4);


            _CurrentControl = host;

            if (_InstanceObject == null)
            {
                FrameworkElement ct = host;
                while (ct != null)
                {
                    if (ct is Window)
                    {
                        ((Window)ct).LocationChanged += new EventHandler(TouchScreenKeypad_LocationChanged);
                        ((Window)ct).Activated += new EventHandler(TouchScreenKeypad_Activated);
                        ((Window)ct).Deactivated += new EventHandler(TouchScreenKeypad_Deactivated);
                        break;
                    }
                    ct = (FrameworkElement)ct.Parent;
                }

                if (ct == null)
                {
                    host.GotFocus += new RoutedEventHandler(TouchScreenKeypad_Activated);
                    host.LostFocus += new RoutedEventHandler(TouchScreenKeypad_Deactivated);
                }

                _InstanceObject = new TouchScreenKeypad();
                _InstanceObject.AllowsTransparency = true;
                _InstanceObject.WindowStyle = WindowStyle.None;
                _InstanceObject.ShowInTaskbar = false;
                _InstanceObject.Topmost = true;

                host.LayoutUpdated += new EventHandler(tb_LayoutUpdated);
            }



        }

        static void TouchScreenKeypad_Deactivated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }
        static void TouchScreenKeypad_Deactivated(object sender, RoutedEventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }

        static void TouchScreenKeypad_Activated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }

        static void TouchScreenKeypad_Activated(object sender, RoutedEventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }


        static void TouchScreenKeypad_LocationChanged(object sender, EventArgs e)
        {
            syncchild();
        }

        static void tb_LayoutUpdated(object sender, EventArgs e)
        {
            if (!moved)
                syncchild();
        }

        static void OnLostFocus(object sender, RoutedEventArgs e)
        {

            Control host = sender as Control;
            //host.Background = _PreviousTextBoxBackgroundBrush;
            host.BorderBrush = _PreviousTextBoxBorderBrush;
            host.BorderThickness = _PreviousTextBoxBorderThickness;

            if (_InstanceObject != null)
            {
                if (TouchScreenText == "" || TouchScreenText == null || TouchScreenText == string.Empty)
                {
                    TouchScreenText = "0";
                }

                _InstanceObject.Close();
                _InstanceObject = null;
            }
        }
        #endregion
        #region Drag Window
        public static readonly DependencyProperty EnableDragProperty = DependencyProperty.RegisterAttached(
            "EnableDragPad",
            typeof(bool),
            typeof(EnableDragHelper),
            new PropertyMetadata(default(bool), OnLoaded));

        private static void OnLoaded(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var uiElement = dependencyObject as UIElement;
            if (uiElement == null || (dependencyPropertyChangedEventArgs.NewValue is bool) == false)
            {
                return;
            }
            if ((bool)dependencyPropertyChangedEventArgs.NewValue == true)
            {
                uiElement.MouseMove += UIElementOnMouseMove;
            }
            else
            {
                uiElement.MouseMove -= UIElementOnMouseMove;
            }

        }

        private static void UIElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            var uiElement = sender as UIElement;
            if (uiElement != null)
            {
                if (mouseEventArgs.LeftButton == MouseButtonState.Pressed)
                {
                    DependencyObject parent = uiElement;
                    int avoidInfiniteLoop = 0;
                    // Search up the visual tree to find the first parent window.
                    while ((parent is Window) == false)
                    {
                        parent = VisualTreeHelper.GetParent(parent);
                        avoidInfiniteLoop++;
                        if (avoidInfiniteLoop == 1000)
                        {
                            // Something is wrong - we could not find the parent window.
                            return;
                        }
                    }
                    var window = parent as Window;
                    window.DragMove();
                }
            }
        }

        public static void SetEnableDrag(DependencyObject element, bool value)
        {
            moved = true;
            element.SetValue(EnableDragProperty, value);
        }

        public static bool GetEnableDrag(DependencyObject element)
        {
            return (bool)element.GetValue(EnableDragProperty);
        }
        #endregion
    }
}

