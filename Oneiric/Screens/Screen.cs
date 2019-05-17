using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
abstract class Screen
{
    public Image Wallpaper { get; set; }
    public Font Font28 { get; set; }
    protected Dictionary<string, string> texts;

    public Screen(Image wallpaper, Font font28)
    {
        Wallpaper = wallpaper;
        Font28 = font28;
        texts = new Dictionary<string, string>();
    }

    public void LoadText(string language, string fileName)
    {
        texts.Clear();
        try
        {
            StreamReader file = File.OpenText("data/langs/" +
                language.Substring(0, 2).ToLower() + "/systemText/" + fileName +
                ".dat");

            string line;

            do
            {
                line = file.ReadLine();

                if (line != null)
                {
                    texts.Add((line.Split(';'))[0], (line.Split(';'))[1]);
                }
            } while (line != null);
            file.Close();
        }
        catch (PathTooLongException)
        {
            Oneiric.SaveLog("Path too long Error");
        }
        catch (FileNotFoundException)
        {
            Oneiric.SaveLog("File Not Found");
        }
        catch (IOException e)
        {
            Oneiric.SaveLog("IO Error: " + e);
        }
        catch (Exception e)
        {
            Oneiric.SaveLog("Error: " + e);
        }
    }
}
