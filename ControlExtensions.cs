using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomboidBackupManager
{
    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { enable });
        }

        // ToolStrip items with a fixed size and images are not scaled by AutoScaleMode.Dpi
        public static void ScaleToolStripItemsToDpi(this Form form, params ToolStrip[] toolStrips)
        {
            float scale = form.DeviceDpi / 96f;
            if (scale <= 1f)
            {
                return;
            }
            foreach (ToolStrip toolStrip in toolStrips)
            {
                toolStrip.ImageScalingSize = new Size((int)(toolStrip.ImageScalingSize.Width * scale), (int)(toolStrip.ImageScalingSize.Height * scale));
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (!item.AutoSize)
                    {
                        item.Size = new Size((int)(item.Width * scale), (int)(item.Height * scale));
                    }
                    if (item.Image != null)
                    {
                        item.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                    }
                }
            }
        }
    }
}
