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
            var lsIndirectContributors = AppSettings.GetInstance().IndirectContributors.Split(';').ToList();
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

        public static List<ComboBoxItem> GetComboDataSourceDisplayArtistRole()
        {
            var ls = AppSettings.GetInstance().DisplayArtistRoles.Split(';').ToList();
            var ret = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { Value = null, Text = "" }
            };
            foreach (string c in ls)
            {
                ret.Add(new ComboBoxItem() { Value = c, Text = c });
            }

            return ret;
        }

        public static List<ComboBoxItem> GetComboDataSourceAudioCodecType()
        {

            var lsValues = Enum.GetValues(typeof(AudioCodecType)).Cast<AudioCodecType>().ToList<AudioCodecType>();
            
            var ret = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { Value = null, Text = "" }
            };
            foreach (AudioCodecType c in lsValues)
            {
                ret.Add(new ComboBoxItem() { Value = c, Text = Enum.GetName(typeof(AudioCodecType), c) });
            }

            return ret;
        }
    }
}
