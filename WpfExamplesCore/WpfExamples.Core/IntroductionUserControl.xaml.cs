using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;

namespace WpfExamples.Core
{
    /// <summary>
    /// Interaction logic for IntroductionUserControl.xaml
    /// </summary>
    public partial class IntroductionUserControl : UserControl
    {
        public IntroductionUserControl()
        {
            InitializeComponent();
            Loaded += IntroductionUserControl_Loaded;
        }

        private void IntroductionUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.GetFiles("Introduction.xps", SearchOption.AllDirectories).First().FullName;

            this.doc.Document = new XpsDocument(dir, FileAccess.Read).GetFixedDocumentSequence();
            this.doc.FitToWidth();

        }
    }
}
