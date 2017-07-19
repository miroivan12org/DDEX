using Framework.UI.Interfaces;
using System.Windows.Forms;

namespace Framework.UI.Helpers
{
    public static class StaticHelpers
    {
        public static void EnableChildren(IMRControlCollectionParent parent)
        {
            if (parent.Controls != null)
            {
                foreach (Control ctrl in parent.Controls)
                {
                    if (ctrl is IMRControlCollectionParent)
                    {
                        ((IMRControlCollectionParent)ctrl).Editable = parent.Editable;
                        if (ctrl is IMREditableControl && !((IMREditableControl)ctrl).IgnoreParentsEnabled)
                        {
                            ctrl.Enabled = parent.Editable;
                        }
                    }
                }
            }
        }
    }
}
