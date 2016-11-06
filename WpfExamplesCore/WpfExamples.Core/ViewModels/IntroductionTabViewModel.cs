using System.IO;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using WpfExamples.ToolBox;

namespace WpfExamples.Core.ViewModels
{
    internal class IntroductionTabViewModel : TabViewModelBase
    {

        public FixedDocumentSequence Document
        {
            get
            {
                var dir = Directory.GetParent(Directory.GetCurrentDirectory())
                            .Parent
                            .GetFiles("Introduction.xps",SearchOption.AllDirectories
                        ).First().FullName;
                
                return new XpsDocument(dir, FileAccess.Read).GetFixedDocumentSequence();
            
                
            }
        }

        public IntroductionTabViewModel() 
            : base("Introduction to WpfExamples",typeof(IntroductionUserControl), ETabType.Essential, EDifficulty.None, "05.11.2015", EStatus.UnderDevelopment)
        {
        }
    }
}