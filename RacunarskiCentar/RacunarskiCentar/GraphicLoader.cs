using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
   
    class GraphicLoader
    {
        static private PrivateFontCollection fontCollection;
        static private PrivateFontCollection fontCollectionBold;
        static private  string graficsFolder =  @"..\..\Graphics";
        static Dictionary<string, List<Bitmap>> images = new Dictionary<string, List<Bitmap>>();
        static public Font getFont(float size)
        {
            if (fontCollection == null)
            {
                fontCollection  = new PrivateFontCollection();
                fontCollection.AddFontFile(Path.Combine(graficsFolder, "Font", "lato", "Lato-Light.ttf"));
            }
            return new Font((FontFamily)fontCollection.Families[0], size);
        }

        static public Font getFontBold(float size)
        {
            if (fontCollectionBold == null)
            {

                fontCollectionBold = new PrivateFontCollection();
                fontCollectionBold.AddFontFile(Path.Combine(graficsFolder, "Font", "lato", "Lato-Regular.ttf"));

            }
            return new Font((FontFamily)fontCollectionBold.Families[0], size);
        }

        static public List<Bitmap> getImages(params string[] values)
        {
            string[] param = new string[values.Count()+1];
            
           param[0] = graficsFolder;
            for (int i = 0; i < values.Count(); i++)
            {
                param[i+1] = values[i];
            }
           string finalPath = Path.Combine(param);

            if (!images.ContainsKey(finalPath))
            {
                List<Bitmap> rets = new List<Bitmap>();
              

                if (Directory.Exists(finalPath))
                {
                    foreach (string fileName in Directory.GetFiles(finalPath))
                    {
                        Bitmap bmp = new Bitmap(fileName);
                        rets.Add(bmp);

                    }

                }
                else
                {
                    if (File.Exists(finalPath+".png"))
                    {
                        Bitmap bmp = new Bitmap(finalPath+ ".png");
                        rets.Add(bmp);
                    }
                }
                images.Add(finalPath, rets);
               

            }
            return images[finalPath];
        }

        public static void drawImages(Graphics g, Rectangle r, params string[] values)
        {
            foreach (Bitmap bmp in getImages(values))
            {
                g.DrawImage(bmp, r);
            }
        }

        static private void loadFont1()
        {
            var foo = new PrivateFontCollection();
            var myCustomFont = new Font((FontFamily)foo.Families[0], 36f);
            foo.AddFontFile("...");
        }
    }
}
