using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Threading.Commands;
using WpfExamples.Commands;
using WpfExamples.ToolBox;
using WpfExamples.ToolBox.Commands;
using WpfExamples.Views;

namespace WpfExamples.ViewModels
{
    public class ThreadingTabViewModel : TabViewModelBase
    {
        #region fields 

        private int heavyProcessValue;
        private int progressMin;
        private int progressMax;
        private int progressValue;
        private UIElement myControl;
        private object myModel;
        
        private bool isPerformHeavyProcess1;
        #endregion fields

        public ThreadingTabViewModel() 
            : base("Threading",typeof(ThreadingTabUserControl),ETabType.Essential,EDifficulty.Advanced,"3.11.2016",EStatus.Complete)
        {
            // borrowed from WpfExamplesCommands
            this.HeavyProcess = new WpfExamplesRelayCommand<object>(this.PerformHeavyProcess1);
            this.HeavyProcessOnNewThread = new AsyncRelayCommand<object>(this.PerformHeavyProcess1, (a) => !this.IsPerformHeavyProcess1);
            this.CreateUIElementInThread = new AsyncRelayCommand<object>(this.PerformCreateUIElementInThread);
            this.CreateModel = new AsyncRelayCommand<object>(this.PerformCreateModel);
        }


        public bool IsPerformHeavyProcess1
        {
            get { return this.isPerformHeavyProcess1; }
            set { this.SetProperty(ref this.isPerformHeavyProcess1, value); }
        }

        #region Update Bindable properties 

        public int HeavyProcessValue
        {
            get { return this.heavyProcessValue; }
            set { this.SetProperty(ref this.heavyProcessValue, value); }
        }
        public int ProgressMin
        {
            get { return this.progressMin; }
            set { this.SetProperty(ref this.progressMin, value); }
        }
        public int ProgressMax
        {
            get { return this.progressMax; }
            set { this.SetProperty(ref this.progressMax, value); }
        }
        public int ProgressValue
        {
            get { return this.progressValue; }
            set { this.SetProperty(ref this.progressValue, value); }
        }

        public UIElement MyControl
        {
            get { return this.myControl; }
            set { this.SetProperty( ref this.myControl, value); }
        }

        public object MyModel
        {
            get { return this.myModel; }
            set { this.SetProperty(ref this.myModel, value); }
        }
        #endregion update Bindable properties

        #region Command Properties 
        public ICommand HeavyProcess { get; set; }
        public ICommand HeavyProcessOnNewThread { get; set; }
        public ICommand CreateUIElementInThread { get; set; }
        public ICommand CreateModel { get; set; }
        #endregion Command Properties

        #region private Methods 

        // Here we dont actually need to invoke the Dispatcher.  
        // We are only setting atomic types.
        // Note: that the method is regular just like any other, 
        //       it is the AsyncRelayCommand which execute it on a new thread
        private void PerformHeavyProcess1(object param)
        {
            // Monitor ensures that only one thread at the time can execute the inclosed code. 
            //all other threads will wait and queue up, until the enterered thread have exited
            Monitor.Enter(this);
            if (!this.IsPerformHeavyProcess1)
            {
                this.IsPerformHeavyProcess1 = true;
                int count = 50;
                this.ProgressMin = 1;
                this.ProgressMax = count * count * count * count;
                this.heavyProcessValue = 0;
                for (int i = 1; i <= this.progressMax; i++)
                {
                    this.HeavyProcessValue++;
                    this.ProgressValue = this.heavyProcessValue;
                }
                this.IsPerformHeavyProcess1 = false;
            }
            Monitor.Exit(this);
        }    

        // Here we actually need to invoke the dispatcher.
        // We cannot create UIelements on a different thread than the parent.
        private void PerformCreateUIElementInThread(object param)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                TextBox control = new TextBox();
                control.Height = 25;
                control.Width = 350;
                Binding binding = new Binding("Value1");
                binding.Mode = BindingMode.OneWay;
                control.SetBinding(TextBox.TextProperty, binding);
                this.MyControl = control;
            });
        }

        // Likewise we cannot set the datacontext or other protected properties
        // from any other thread than the UI thread.
        private void PerformCreateModel(object param)
        {
            if (this.MyControl != null)
            {
                this.MyModel = new { Value1 = "I was created on different thread." };
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ((TextBox)this.MyControl).DataContext = this.MyModel;
                });
            }
        }
        #endregion private Methods
    }
}