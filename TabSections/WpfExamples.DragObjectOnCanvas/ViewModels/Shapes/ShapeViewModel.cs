using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using WpfExamples.Commands;
using WpfExamples.ToolBox;
using WpfExamples.ToolBox.Models;

namespace WpfExamples.ViewModels.Shapes
{
    public class ShapeViewModel :TabViewModelBase 
    {
        public string Name { get; }
        public Shape Shape { get; }
        public ShapeViewModel(Shape shape, string name):base("Move objects around on canvas",ETabType.Essential,EDifficulty.Intermediate,"04.11.2016",EStatus.UnderDevelopment)
        {
            this.Shape = shape;
            this.Name = name;
            this.MoveShapeCommand = new WpfExamplesRelayCommand<DragDeltaEventArgs>(this.MoveShape);
        }


        public ICommand MoveShapeCommand { get; }
        private void MoveShape(DragDeltaEventArgs e)
        {
            if (!(e.Source as Thumb)?.DataContext?.Equals(this) == true) return;
            this.Shape.X += e.HorizontalChange;
            this.Shape.Y += e.VerticalChange;
            e.Handled = true;

        }

        public ICommand BeginMoveShapeCommand { get; }



        




        

    }
}
