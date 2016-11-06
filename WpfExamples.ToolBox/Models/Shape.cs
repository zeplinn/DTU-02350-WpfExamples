using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExamples.ToolBox.Models
{
    public abstract class Shape: NotifyPropertyChanged
    {
        private double x;
        public double X
        {
            get { return this.x; }
            set { SetProperty(ref this.x, value); }
        }

        private double y;
        public double Y
        {
            get { return this.y; }
            set { SetProperty(ref this.y, value); }
        }

        private double width;

        public double Width
        {
            get { return this.width; }
            set { SetProperty(ref this.width, value); }
        }

        private double height;
        public double Height
        {
            get { return this.height; }
            set { SetProperty(ref this.height, value); }
        }
    }
}
