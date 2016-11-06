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
    public class WpfExamplesActionToCommand : TriggerActionToCommandBase, ICommandSource
    {
        #region // Trigger Call

        protected override void Invoke(object eventArgs)
        {
            if (IsEnabled)
            {
                ExecuteCommand(this.CommandParameter, this.CommandTarget);
            }
        }
        #endregion
        

        #region // ICommandSource Implementation

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(WpfExamplesActionToCommand), new PropertyMetadata(null));

        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(WpfExamplesActionToCommand), new PropertyMetadata(null));


        #endregion

        protected override void CanExecuteCommandChanged(object sender, EventArgs e)
        {
             IsEnabled =(Command as RoutedCommand)?.CanExecute(this.CommandParameter, this.CommandTarget) 
                        ?? Command.CanExecute(this.CommandParameter);

        }
    }
}
