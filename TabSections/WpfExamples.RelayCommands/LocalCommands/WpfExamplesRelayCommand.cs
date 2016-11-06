using System;
using WpfExamples.Commands;

namespace WpfExamples.LocalCommands
{
    // this entire class is a copy of the implemetion of ICommand found in WpfExamples.ToolBox (3.11.2016)
    // it is copied to this assembly for encapsualting the explaing of RelayCommand, but is needed for other examples
    #region Command Implementations
    
    //relaycommand  which do not use CommandParameter
    internal class WpfExamplesRelayCommand : WpfExamplesCommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public WpfExamplesRelayCommand(Action execute) : this(execute, null) { }
        public WpfExamplesRelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException($"parameter {nameof(execute)} can not be null");
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public override bool CanExecute(object parameter) => this.canExecute?.Invoke() ?? true;

        public override void Execute(object parameter) => this.execute?.Invoke();
    }
    // relaycommand which use a CommandParameter value of type T
    internal class WpfExamplesRelayCommand<T> : WpfExamplesCommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public WpfExamplesRelayCommand(Action<T> execute) : this(execute, null) { }
        public WpfExamplesRelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException($"parameter {nameof(execute)} can not be null");
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {

            //if (!(parameter is T))
              //  throw new InvalidCastException($"CommandParameter is of type {parameter?.GetType()}, T is of type {typeof(T)}");
            return this.canExecute?.Invoke((T)parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            //if (!(parameter is T))
              //  throw new InvalidCastException($"CommandParameter is of type {parameter?.GetType()}, T is of type {typeof(T)}");
            this.execute?.Invoke((T)parameter);
        }
    }
    #endregion
    
}
