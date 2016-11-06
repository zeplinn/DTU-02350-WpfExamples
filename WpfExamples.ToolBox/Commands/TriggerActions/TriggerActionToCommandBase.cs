using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace WpfExamples.ToolBox.Commands.TriggerActions
{
    public abstract class TriggerActionToCommandBase:TriggerAction<DependencyObject>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(TriggerActionToCommandBase), new PropertyMetadata(null, OnCommandChanged));

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) 
            => (d as TriggerActionToCommandBase)?.CommandHookUp((ICommand)e.OldValue, (ICommand)e.NewValue);

        #region // Command Hookup
        protected virtual void CommandHookUp(ICommand eOldValue, ICommand eNewValue)
        {
            if (eOldValue != null) eOldValue.CanExecuteChanged -= this.CanExecuteCommandChanged;
            if (eNewValue != null) eNewValue.CanExecuteChanged += this.CanExecuteCommandChanged;
        }
        
        #endregion

        protected abstract void CanExecuteCommandChanged(object sender, EventArgs e);
        
        protected virtual void ExecuteCommand(object parameter,IInputElement target)
        {
            if (this.Command is RoutedCommand)
            {
                (this.Command as RoutedCommand)?.Execute(parameter, target);
            }
            else
            {
                this.Command?.Execute(parameter);
            }
        }

    }
}
