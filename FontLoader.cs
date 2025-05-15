using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using static ZomboidBackupManager.Configuration;
using System.Xml.Linq;
using System.Drawing;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;

namespace ZomboidBackupManager
{
    public class FontLoader
    {
        private static readonly string ZombieFontFile = "Zombie.ttf";
        private static readonly string UbuntuMonoFontFile = "UbuntuMono-Regular.ttf";
        private static readonly string UbuntuMonoBoltFontFile = "UbuntuMono-Bolt.ttf";

        private static PrivateFontCollection collection1 = new PrivateFontCollection();
        private static PrivateFontCollection collection2 = new PrivateFontCollection();
        private static Dictionary<string, System.Drawing.Font> _styleFontCache = new Dictionary<string, System.Drawing.Font>();
        private static Dictionary<string, System.Drawing.Font> _monoFontCache = new Dictionary<string, System.Drawing.Font>();

        public static void LoadDefaultCustomFonts()
        {
            LoadMonoFont(UbuntuMonoFontFile, 11f, false);
            LoadMonoFont(UbuntuMonoBoltFontFile, 12f, true);
            LoadStyleFont(ZombieFontFile, 40f);
        }

        public static System.Drawing.Font LoadMonoFont(string name, float size, bool bBolt = false)
        {
            FontStyle style;
            if (bBolt)
            {
                style = FontStyle.Bold;
            }
            else
            {
                style = FontStyle.Regular;
            }

            collection1.AddFontFile("Fonts/" + name);
            string key = $"{name}|{size}|{bBolt}";
            var family = collection1.Families[0];
            _monoFontCache.Add(key, new System.Drawing.Font(family, size, style));
            return _monoFontCache[key];
        }

        public static System.Drawing.Font LoadStyleFont(string name, float size)
        {
            collection2.AddFontFile("Fonts/" + ZombieFontFile);

            var family = collection2.Families[0];
            string key = $"{name}|{size}|{false}";
            _styleFontCache.Add(key, new System.Drawing.Font(family, size));
            return _styleFontCache[key];
        }

        public static System.Drawing.Font GetStyleFont(float size)
        {
            string key = $"{ZombieFontFile}|{size}|{false}";
            if (_styleFontCache.ContainsKey(key))
            {
                return _styleFontCache[key];
            }
            return LoadStyleFont(ZombieFontFile, size);
        }

        public static System.Drawing.Font GetMonoFont(float size, bool bBolt = false)
        {
            string name = bBolt ? UbuntuMonoBoltFontFile : UbuntuMonoFontFile;
            //MessageBox.Show($"Bolt = {bBolt} --> Name = {name}");
            string key = $"{name}|{size}|{bBolt}";
            if (_monoFontCache.ContainsKey(key))
            {
                return _monoFontCache[key];
            }
            return LoadMonoFont(name, size, bBolt);
        }
    }
}