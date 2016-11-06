using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfExamples.ToolBox;
using WpfExamples.Views;

namespace WpfExamples.ViewModels
{
    public class RelayCommandsTabViewModel:TabViewModelBase
    {
        public RelayCommandsTabViewModel() : 
            base("ICommand Implementations and use", typeof(RelayCommandsTabUserControl), ETabType.Essential, EDifficulty.Intermediate, "05.11.2016", EStatus.UnderDevelopment)
        {
        }
    }

    
}
