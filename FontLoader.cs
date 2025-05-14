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
        private static readonly string ZombieFontFile = "Zombie.ttf";
        private static readonly string UbuntuMonoFontFile = "UbuntuMono-Regular.ttf";
        private static readonly string UbuntuMonoBoltFontFile = "UbuntuMono-Bolt.ttf";
        private static readonly string resourcePath = "ZomboidBackupManager.Fonts.";

        private static PrivateFontCollection _fonts = new PrivateFontCollection();

        public static Font GetStyleFont(float size = 40f)
        {
            string name = ZombieFontFile;
            PrintDebug($"[FontLoader] - [GetStyleFont] - [Font = {name}] - [ResourcePath = {resourcePath}] - [Size: {size}]");

            return GetFontFromFile(ZombieFontFile, size);
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
            return GetFontFromFile(name, size, style);
        }

        private static Font GetFontFromFile(string name, float size, FontStyle style = FontStyle.Regular)
        {
            PrivateFontCollection collection = new PrivateFontCollection();
            collection.AddFontFile("Fonts/" + name);
            var family = collection.Families[0];
            return new Font(family, size, style);
        }
    }
}