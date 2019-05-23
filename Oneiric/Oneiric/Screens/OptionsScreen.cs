class OptionsScreen : Screen
{
    protected Image selector;
    protected int option;
    protected Font font72;

    const int YCURSOR_MAX = 4;
    const int YCURSOR_MIN = 0;

    public OptionsScreen()
        : base(new Image("data/images/other/welcome.jpg"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        option = 0;
        selector = new Image("data/images/other/selector.png");
        font72 = new Font("data/fonts/Joystix.ttf", 72);
    }

    public int GetChosenOption()
    {
        return option;
    }

    public int Run()
    {
        option = 0;
        LoadText(Oneiric.Languages[Oneiric.Language],"optionMenu");

        SdlHardware.Pause(100);
        do
        {
            SdlHardware.ClearScreen();
            DrawMenu(Oneiric.Languages[Oneiric.Language],
                Oneiric.Difficultation[Oneiric.Difficulty]);
            SdlHardware.ShowHiddenScreen();
            if (SdlHardware.KeyPressed(SdlHardware.KEY_W) && option > 
                YCURSOR_MIN)
            {
                option--;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_S) && option <
                YCURSOR_MAX)
            {
                option++;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            {
                option = YCURSOR_MAX;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_RETURN))
            {
                if (option == YCURSOR_MAX)
                {
                    return option;
                }
            }
            else if(SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
            {
                ChangeOptions(-1, Oneiric.Languages.Length-1, 
                    Oneiric.Difficultation.Length-1);
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_D))
            {
                ChangeOptions(1, Oneiric.Languages.Length - 1,
                    Oneiric.Difficultation.Length - 1);
            }
            SdlHardware.Pause(100);
        }
        while (true);
        //The loop ends when an option is choosed.
    }

    public void ChangeOptions(sbyte num, int totalLanguages, 
        int totalDifficulty)
    {
        switch (option)
        {
            case 0:
                if ((Oneiric.Language + num) >= 0 && 
                    (Oneiric.Language + num) <= totalLanguages)
                {
                    Oneiric.Language += (byte)num;
                }
                break;
            case 1:
                if ((Oneiric.Difficulty + num) >= 0 && 
                    (Oneiric.Difficulty + num) <= totalDifficulty)
                {
                    Oneiric.Difficulty += (byte)num;
                }
                break;
            case 2:
                Oneiric.FullScreen = Oneiric.FullScreen ? false : true;
                break;
            case 3:
                if ((Oneiric.Volume + num) >= 0 && (Oneiric.Volume + num) <= 
                    Oneiric.MAX_VOLUME)
                {
                    Oneiric.Volume += (byte)num;
                }
                break;
        }
    }

    public void DrawMenu(string lang, string difficulty)
    {
        SdlHardware.DrawHiddenImage(Wallpaper, 0, 0);
        SdlHardware.WriteHiddenText(texts["op"],
           422, 202,
           0x00, 0x00, 0x00,
           font72);
        SdlHardware.WriteHiddenText(texts["op"],
            420, 200,
            0xFF, 0xFF, 0xFF,
            font72);
        SdlHardware.WriteHiddenText(texts["lg"] + ": < " + lang + " >",
           422, 402,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(texts["lg"] + ": < " + lang + " >",
            420, 400,
            0xFF, 0xFF, 0xFF,
            Font28);

        SdlHardware.WriteHiddenText(texts["df"] + ": < " + texts[difficulty] +
            " >",
            422, 442,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["df"] + ": < " + texts[difficulty] +
            " >",
            420, 440,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["fs"] + ": < " +
            (Oneiric.FullScreen ? texts["ys"]: texts["no"]) + " >",
            422, 482,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["fs"] + ": < " +
            (Oneiric.FullScreen ? texts["ys"] : texts["no"]) + " >",
            420, 480,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["vl"] + ": - " + 
            new string('!', Oneiric.MAX_VOLUME),
            422, 522,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["vl"] + ": - " + 
            new string('!', Oneiric.Volume),
            420, 520,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText("+",
            900, 522,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText("+",
            900, 520,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["bc"],
            422, 562,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["bc"],
            420, 560,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.DrawHiddenImage(selector, 320, 380 + 40 * option);
    }
}
