using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfExamples.ToolBox.Commands.TriggerActions
{
    public class WpfExamplesEventToCommand:WpfExamplesActionToCommand
    {
        protected override void Invoke(object eventArgs)
        {
            if (!(eventArgs is EventArgs))
                throw new ArgumentNullException($"{nameof(WpfExamplesEventToCommand)} is not attached to an event");
            if (IsEnabled)
            {
                ExecuteCommand(new Tuple<object, EventArgs>(CommandParameter, (EventArgs) eventArgs), CommandTarget);
            }
        }
        
    }
}
