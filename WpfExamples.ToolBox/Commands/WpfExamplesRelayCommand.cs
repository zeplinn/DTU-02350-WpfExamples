using System;

namespace WpfExamples.ToolBox.Commands
{

    #region Command Implementations
    
    //relaycommand  which do not use CommandParameter
    public class WpfExamplesRelayCommand : WpfExamplesCommand
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
    public class WpfExamplesRelayCommand<TCommandParameter> : WpfExamplesCommand<Action<TCommandParameter>,Func<TCommandParameter,bool>>
    {
        public WpfExamplesRelayCommand(Action<TCommandParameter> execute) : this(execute, null) { }
        public WpfExamplesRelayCommand(Action<TCommandParameter> execute,Func<TCommandParameter,bool> canExecute) : base(execute, canExecute) { }
        public override bool CanExecute(object parameter)
        {

            //if (!(parameter is T))
              //  throw new InvalidCastException($"CommandParameter is of type {parameter?.GetType()}, T is of type {typeof(T)}");
            return this.canExecute?.Invoke((TCommandParameter)parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            //if (!(parameter is T))
              //  throw new InvalidCastException($"CommandParameter is of type {parameter?.GetType()}, T is of type {typeof(T)}");
            this.execute?.Invoke((TCommandParameter)parameter);
        }
    }
    #endregion

    #region Command implementations with Eventargs passed
    //paremeter is allways a Tuple<object, EventArgs>
    public class WpfExamplesRelayCommand<TCommandParameter, TArgs> : WpfExamplesCommand<Action<TCommandParameter,TArgs>,Func<TCommandParameter,TArgs,bool>> where TArgs : EventArgs
    {

        public override bool CanExecute(object parameter)
        {
            if (!(parameter is Tuple<object, EventArgs>)) return false;
            var p = parameter as Tuple<object, EventArgs>;
            return this.canExecute?.Invoke((TCommandParameter)p.Item1, (TArgs)p.Item2) ?? true; ;
        }

        public override void Execute(object parameter)
        {
            if (!(parameter is Tuple<object, EventArgs>)) return;
            var p = parameter as Tuple<object, EventArgs>;
            this.execute?.Invoke((TCommandParameter) p.Item1, (TArgs) p.Item2);
        }

        public WpfExamplesRelayCommand(Action<TCommandParameter, TArgs> execute) :this(execute,null){}
        public WpfExamplesRelayCommand(Action<TCommandParameter, TArgs> execute, Func<TCommandParameter, TArgs, bool> canExecute) 
            : base(execute, canExecute){}
    }
    #endregion
}
