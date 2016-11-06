using System.Windows;
using System.Windows.Controls;

namespace WpfExamples.Views.Components
{
    /// <summary>
    /// Interaction logic for ShapesItemsControlThumb.xaml
    /// </summary>
    public partial class ShapesItemsControlThumb : ItemsControl
    {
        
        // the outcommented code is needed if the dataTemplate is positioned in a resourceDictionary;


        //private DataTemplate temp;
        //private bool isDataTemplateFound;
        protected override DependencyObject GetContainerForItemOverride()
        {
            return this.ItemTemplate.LoadContent();  //temp.LoadContent()
        }
        //protected override bool IsItemItsOwnContainerOverride(object item)
        //{
        //    if (isDataTemplateFound) return false;
        //    if (!(item is ShapeViewModel)) throw new InvalidCastException($"Added {nameof(item)} is not of type {nameof(ShapeViewModel)} ");
        //    var s = item as ShapeViewModel;
        //    temp = FindResource("ShapeDataTemplate") as DataTemplate;
        //    if (temp == null) throw new InvalidCastException($"resource found is not of type {nameof(DataTemplate)}");
        //    isDataTemplateFound = true;
        //    return false;
        //}

        public ShapesItemsControlThumb()
        {
            InitializeComponent();
        }
    }
}
