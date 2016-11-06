using System.Collections.ObjectModel;
using WpfExamples.ViewModels.Shapes;
using WpfExamples.ToolBox.Models;

namespace WpfExamples.ViewModels
{
    public class DragObjectOnCanvasTabViewModel
    {

        public ObservableCollection<ShapeViewModel> Shapes { get; }

        public DragObjectOnCanvasTabViewModel()
        {
            this.Shapes = new ObservableCollection<ShapeViewModel>()
            {
                new ShapeViewModel(new Rectangle() {X=50, Y=70, Width=75, Height=75},"Rectangle"),
                new ShapeViewModel(new Circle(){X=100, Y=10, Width=40, Height=40 },"Circle")
            };
        }
    }
}
