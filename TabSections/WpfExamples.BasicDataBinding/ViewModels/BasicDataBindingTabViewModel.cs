using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WpfExamples.ToolBox;
using WpfExamples.Views;

namespace WpfExamples.ViewModels
{
    public class BasicDataBindingTabViewModel : TabViewModelBase
    {
        #region fields 
        
        private int progressMin;
        private int progressMax;
        private int progressValue;
        private UIElement myControl;
        private object myModel;
        private string name;
        private string selectedName;
        #endregion fields

        public BasicDataBindingTabViewModel() 
            : base("Basic DataBining",typeof(BasicDataBindingTabUserControl),ETabType.Essential,EDifficulty.Beginner,"3.11.2015",EStatus.Complete)
        {
            this.Names = new List<string> { "Shane", "Jesper", "Bjarne", "Rip", "Rap", "Rup" };
          
        }

        public List<string> Names { get; set; }
        public string Name
        {
            get { return this.name; }
            set { this.SetProperty( ref this.name, value); }
        }
        public string SelectedName
        {
            get { return this.selectedName; }
            set { this.SetProperty( ref this.selectedName, value); }
        }
      

        #region Update Bindable properties 

      
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
        
        public ICommand CreateModel { get; set; }
        #endregion Command Properties

        #region private Methods 
        
        #endregion private Methods
    }
}