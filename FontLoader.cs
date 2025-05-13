using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using static ZomboidBackupManager.Configuration;

namespace ZomboidBackupManager
{
    public class FontLoader
    {
        private static readonly string ZombieFontFile = "ZOMBIE.TTF";
        private static readonly string UbuntuMonoFontFile = "UbuntuMono-Regular.ttf";
        private static readonly string UbuntuMonoBoltFontFile = "UbuntuMono-Bolt.ttf";
        private static readonly string resourcePath = "ZomboidBackupManager.Fonts.";

        private static PrivateFontCollection _fonts = new PrivateFontCollection();

        public static Font GetStyleFont(float size = 40f)
        {
            string name = ZombieFontFile;
            PrintDebug($"[FontLoader] - [GetStyleFont] - [Font = {name}] - [ResourcePath = {resourcePath}] - [Size: {size}]");
            return LoadEmbeddedFont(name, size);
        }

        public static Font GetUbuntuMonoFont(float size = 12f, bool bBolt = false)
        {
            FontStyle style = FontStyle.Regular;
            string name = UbuntuMonoFontFile;
            if (bBolt)
            {
                style = FontStyle.Bold;
                name = UbuntuMonoBoltFontFile;
            }
            PrintDebug($"[FontLoader] - [GetUbuntuMonoFont] - [Font = {name}] - [ResourcePath = {resourcePath}] - [Size: {size}]");
            return LoadEmbeddedFont(name, size, style);
        }

        public static Font LoadEmbeddedFont(string resourceName, float size, FontStyle style = FontStyle.Regular)
        {
            string fullResourceName = resourcePath + resourceName;
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullResourceName))
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