using System;
using System.Windows.Input;

namespace WpfExamples.Commands
{
    internal abstract class WpfExamplesCommand:ICommand
    {
        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;
        
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
