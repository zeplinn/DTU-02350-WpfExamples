using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WpfExamples.ToolBox;
using WpfExamples.Views;
using WpfExamples.ToolBox.Commands;
using WpfExamples.ViewModels;

namespace WpfExamples.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object content;
        public ObservableCollection<TabViewModelBase> DropDown { get; set; }

        public object Content
        {
            get { return this.content; }
            set { SetProperty(ref this.content, value); }
        }

        public WpfExamplesCommand SelectionChangedCommand { get; }

        public WpfExamplesCommand TabForwardCommand { get; }

        public WpfExamplesCommand TabBackWordCommand { get; }

        public MainViewModel()
        {
            this.DropDown = new ObservableCollection<TabViewModelBase>(this.InitializeTabSystem());

            this.Content = Activator.CreateInstance(this.DropDown.First().TabViewType);
            
            this.SelectionChangedCommand = new WpfExamplesRelayCommand<ComboBox>(this.SelectionChanged);
            this.TabForwardCommand = new WpfExamplesRelayCommand<ComboBox>(this.TabForward);
            this.TabBackWordCommand = new WpfExamplesRelayCommand<ComboBox>(this.TabBackWord);
        }

        private IEnumerable<TabViewModelBase> InitializeTabSystem()
        {
            return new List<TabViewModelBase>()
            {
                new IntroductionTabViewModel(),
                // beginner
                new BasicDataBindingTabViewModel(),
                // intermediate
                new RelayCommandsTabViewModel(),
                // advanced
                new ThreadingTabViewModel()

            };
            #region old experiment
            /*
             var ab = Assembly.GetExecutingAssembly().GetTypes();
            var tabSectionsPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.GetDirectories().Single(d => d.Name == "TabSections").FullName;
            var asc = this.GetType().Assembly.GetLoadedModules();
            var a = System.IO.Directory.GetFiles(tabSectionsPath, "WpfExamples.Tabs.*.dll",
                System.IO.SearchOption.AllDirectories);
            var refAssemeblies = this.GetType().Assembly.GetReferencedAssemblies();//.Where(a => a.Name.Contains("WpfExamples.Tabs"));
            var count = 2 + refAssemeblies.Count();
            this.tabs = new List<Type>(count);
            //constant tabs used for introduction
            this.tabs.Add(typeof(IntroductionUserControl));
            this.tabs.Add(typeof(TeachingAssistentsIntroductionUserControl));

            foreach (var assemblyName in refAssemeblies)
            {
                var assembly = Assembly.Load(assemblyName);
                var vmType = assembly.GetTypes().Where(t => t.Namespace.Equals("WpfExamples.ViewModels"));
                var ucType = assembly.GetTypes().Where(t => t.Namespace.Equals("WpfExamples.Views"));
                if (vmType.Count() != 1)
                    throw new InvalidProgramException($"Assembly {assembly.FullName} have less or more than 1 viewmodel in Namespace WpfExamples.ViewModels ");
                if (ucType.Count() != 1)
                    throw new InvalidProgramException($"Assembly {assembly.FullName} have less or more than 1 viewmodel in Namespace WpfExamples.Views ");
                var tabVm = Activator.CreateInstance(vmType.First()) as TabViewModelBase;
                if (tabVm == null)
                    throw new ArgumentNullException($"type: {tabVm}, do no inherit from {nameof(TabViewModelBase)}");
                this.tabs.Add(ucType.First());
                yield return tabVm;



            }
            */
            #endregion

        }



        private void SelectionChanged(ComboBox cb) => this.Content = Activator.CreateInstance(this.DropDown[cb.SelectedIndex].TabViewType);

        private void TabForward(ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == comboBox.Items.Count - 1)
                comboBox.SelectedIndex = 0;
            else
                comboBox.SelectedIndex++;
        }
        private void TabBackWord(ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == 0)
                comboBox.SelectedIndex = comboBox.Items.Count - 1;
            else
                comboBox.SelectedIndex--;
        }
    }
}
