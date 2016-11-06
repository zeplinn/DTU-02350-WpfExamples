using System;
using System.Windows.Input;

namespace WpfExamples.ToolBox.Commands
{
    public abstract class WpfExamplesCommand:ICommand 
    {
        
        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;
        
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }

    public abstract class WpfExamplesCommand<TAction, TFunc>:WpfExamplesCommand
    {
        protected readonly TAction execute;
        protected readonly TFunc canExecute;
        
        protected  WpfExamplesCommand(TAction execute,TFunc canExecute)
        {
            if (execute == null) throw new ArgumentNullException($"parameter {nameof(execute)} can not be null");
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}
