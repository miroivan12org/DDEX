using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;

namespace Framework.UI.Interfaces
{
    public interface IMREditableControl
    {
        bool Editable { get; set; }
        bool IgnoreParentsEnabled { get; set; }
    }
    public interface IMRControlCollectionParent
    {
        bool Editable { get; set; }
        ControlCollection Controls { get;  }
    }
}
