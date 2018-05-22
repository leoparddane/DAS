using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win.Public
{
    class Common
    {
        public static bool hasSelect(DataGridView drv)
        {
            var hasSelect = false;
            foreach (DataGridViewRow item in drv.Rows)
            {
                if ((bool)item.Cells[0].EditedFormattedValue)
                {
                    hasSelect = true;
                }
            }
            if (!hasSelect)
            {
                MessageBox.Show("未选择记录,请选择");
            }
            return hasSelect;
        }
    }
}
