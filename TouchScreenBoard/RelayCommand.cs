using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TouchScreenBoard
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Action<T> execute)
           : this(execute, null)
        {
            _execute = execute;
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
    public class RelayCommand : ICommand
    {
        public Key GestureKey { get; set; }
        public ModifierKeys GestureModifier { get; set; }
        public MouseAction MouseGesture { get; set; }
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute)
           : this(execute, null)
        {
            _execute = execute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // Ensures WPF commanding infrastructure asks all RelayCommand objects whether their
        // associated views should be enabled whenever a command is invoked 
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        private event EventHandler CanExecuteChangedInternal;

        public void RaiseCanExecuteChanged()
        {
            //CanExecuteChangedInternal.Raise(this);
        }
    }
    public class EnableDragHelper
    {
        //public static readonly DependencyProperty EnableDragProperty = DependencyProperty.RegisterAttached(
        //    "EnableDrag",
        //    typeof(bool),
        //    typeof(EnableDragHelper),
        //    new PropertyMetadata(default(bool), OnLoaded));

        //private static void OnLoaded(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        //{
        //    var uiElement = dependencyObject as UIElement;
        //    if (uiElement == null || (dependencyPropertyChangedEventArgs.NewValue is bool) == false)
        //    {
        //        return;
        //    }
        //    if ((bool)dependencyPropertyChangedEventArgs.NewValue == true)
        //    {
        //        uiElement.MouseMove += UIElementOnMouseMove;
        //    }
        //    else
        //    {
        //        uiElement.MouseMove -= UIElementOnMouseMove;
        //    }

        //}

        //private static void UIElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        //{
        //    var uiElement = sender as UIElement;
        //    if (uiElement != null)
        //    {
        //        if (mouseEventArgs.LeftButton == MouseButtonState.Pressed)
        //        {
        //            DependencyObject parent = uiElement;
        //            int avoidInfiniteLoop = 0;
        //            // Search up the visual tree to find the first parent window.
        //            while ((parent is Window) == false)
        //            {
        //                parent = VisualTreeHelper.GetParent(parent);
        //                avoidInfiniteLoop++;
        //                if (avoidInfiniteLoop == 1000)
        //                {
        //                    // Something is wrong - we could not find the parent window.
        //                    return;
        //                }
        //            }
        //            var window = parent as Window;
        //            window.DragMove();
        //        }
        //    }
        //}

        //public static void SetEnableDrag(DependencyObject element, bool value)
        //{
        //    element.SetValue(EnableDragProperty, value);
        //}

        //public static bool GetEnableDrag(DependencyObject element)
        //{
        //    return (bool)element.GetValue(EnableDragProperty);
        //}
    }
}
