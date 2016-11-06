using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WpfExamples.ToolBox
{
    // a base view model which contains data all view models should have
    // this particular class propertis are associated with this demo and not a generel implementation to be copy pasted to your project


    public abstract class TabViewModelBase : ViewModelBase
    {
        
        private int width;
        public string Header { get; }
        public EStatus Status { get; }
        public EDifficulty Difficulty { get; }
        public ETabType TabType { get;  }
        public string Modified { get; }
        public string AssemblyName => this.GetType().Assembly.GetName().Name;
        public IEnumerable<string> RefrencedSolutionAssemblies => this.GetRefrencedAssemblies();

        public int Width
        {
            get { return this.width;}
            set { SetProperty(ref this.width, value); }
        }

        // this constructor ensure all inherited viewmodel is required to give a header name
        protected TabViewModelBase(string header, Type tabUserControl, ETabType tabType, EDifficulty difficulty, string modifiedLastDate, EStatus status)
        {
            this.Header = header;
            this.Difficulty = difficulty;
            this.Status = status;
            this.TabType = tabType;
            this.Modified = modifiedLastDate;
            this.TabViewType = tabUserControl;
        }

        public Type TabViewType { get;}

        private IEnumerable<string> GetRefrencedAssemblies()
        {
            return this.GetType().Assembly.GetReferencedAssemblies()
                    .Where(assemebly => assemebly.Name.Contains("WpfExamples"))
                    .Select(assemebly => assemebly.Name);
        }

    }
    

    
}
