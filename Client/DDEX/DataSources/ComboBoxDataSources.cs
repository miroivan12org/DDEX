using Business.DDEXSchemaERN_382.Schema;
using Framework.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDEX.DataSources
{
    public static class ComboBoxDataSources
    {
        public static List<ComboBoxItem> GetComboDataSourceIndirectResourceContributorRole()
        {
            var ret = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { Value = null, Text = "" },
                new ComboBoxItem() { Value = "Composer", Text = "Composer" },
                new ComboBoxItem() { Value = "Producer", Text = "Producer" },
                new ComboBoxItem() { Value = "Lyricist", Text = "Lyricist" },
                new ComboBoxItem() { Value = "Arranger", Text = "Arranger" },
            };

            // TODO: dodati neki setting koji definira indirect contributore
            
            return ret;
        }
    }
}
