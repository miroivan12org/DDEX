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
            var lsIndirectContributors = Properties.Settings.Default.IndirectContributors.Split(';').ToList();
            var ret = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { Value = null, Text = "" }
            };
            foreach (string c in lsIndirectContributors)
            {
                ret.Add(new ComboBoxItem() { Value = c, Text = c });
            }
            
            return ret;
        }
    }
}
