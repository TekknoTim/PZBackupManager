using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ZomboidBackupManager
{
    public class FontLoader
    {
        private static PrivateFontCollection _fonts = new PrivateFontCollection();

        public static Font LoadEmbeddedFont(string resourceName, float size, FontStyle style = FontStyle.Regular)
        {
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new Exception("Font-Ressource nicht gefunden.");
                }

                byte[] fontData = new byte[stream.Length];
                stream.ReadExactly(fontData, 0, (int)stream.Length);

                IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                _fonts.AddMemoryFont(fontPtr, fontData.Length);

                Marshal.FreeCoTaskMem(fontPtr);

                return new Font(_fonts.Families[0], size, style);
            }
        }
    }
}