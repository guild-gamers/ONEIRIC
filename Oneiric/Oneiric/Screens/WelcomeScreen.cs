using System;
using System.Collections.Generic;

class WelcomeScreen : Screen
{
    protected Image selector;
    protected int option;
    protected Font font94;

    const int YCURSOR_MAX = 5;
    const int YCURSOR_MIN = 0;

    string[,] title = new string[,] { { "O", "200" }, { "N", "200" },
        { "E", "200" }, {"I", "200"}, { "R", "200" }, { "I", "200" },
        { "C", "200" } };

    byte actualLetter = 0;
    bool isDown = true;
    const string LETTER_Y_MAX = "250";
    const string LETTER_Y_MIN = "200";
    const int Y_MODIFIER = 25;

    public WelcomeScreen()
        : base(new Image("data/images/other/welcome.jpg"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        option = 0;
        selector = new Image("data/images/other/selector.png");
        font94 = new Font("data/fonts/Joystix.ttf", 94);
        texts = new Dictionary<string, string>();
    }

    public int GetChosenOption()
    {
        return option;
    }

    public int Run()
    {
        option = 0;
        LoadText(Oneiric.Languages[Oneiric.Language], "mainMenu");

        do
        {
            SdlHardware.ClearScreen();
            MoveLetters();
            DrawMenu();
            SdlHardware.ShowHiddenScreen();
            if (SdlHardware.KeyPressed(SdlHardware.KEY_UP) && option > 
                YCURSOR_MIN)
            {
                option--;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN) && option < 
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
                return option;
            }
            SdlHardware.Pause(100);
        }
        while (true);
        //The loop ends when an option is choosed.
    }

    public void MoveLetters()
    {
        if (isDown)
        {
            title[actualLetter, 1] = (Convert.ToInt16(title[actualLetter, 1]) +
                Y_MODIFIER).ToString();
        }
        else
        {
            title[actualLetter, 1] = (Convert.ToInt16(title[actualLetter, 1]) -
                Y_MODIFIER).ToString();
        }

        if (title[actualLetter, 1] == LETTER_Y_MAX && isDown)
        {
            isDown = false;
        }
        else if (title[actualLetter, 1] == LETTER_Y_MIN && !isDown)
        {
            isDown = true;
            actualLetter++;
        }

        if (actualLetter == title.GetLength(0))
        {
            actualLetter = 0;
        }
    }

    public void DrawMenu()
    {
        SdlHardware.DrawHiddenImage(Wallpaper, 0, 0);
        SdlHardware.WriteHiddenText(title[0,0],
           352, (short)(Convert.ToInt16(title[0, 1]) + 2),
           0x00, 0x00, 0x00,
           font94);
        SdlHardware.WriteHiddenText(title[0, 0],
            350, Convert.ToInt16(title[0, 1]),
            0xFF, 0xFF, 0xFF,
            font94);
        SdlHardware.WriteHiddenText(title[1, 0],
           424, (short)(Convert.ToInt16(title[1, 1]) + 2),
           0x00, 0x00, 0x00,
           font94);
        SdlHardware.WriteHiddenText(title[1, 0],
            422, Convert.ToInt16(title[1, 1]),
            0xFF, 0xFF, 0xFF,
            font94);
        SdlHardware.WriteHiddenText(title[2, 0],
           494, (short)(Convert.ToInt16(title[2, 1]) + 2),
           0x00, 0x00, 0x00,
           font94);
        SdlHardware.WriteHiddenText(title[2, 0],
            492, Convert.ToInt16(title[2, 1]),
            0xFF, 0xFF, 0xFF,
            font94);
        SdlHardware.WriteHiddenText(title[3, 0],
           566, (short)(Convert.ToInt16(title[3, 1]) + 2),
           0x00, 0x00, 0x00,
           font94);
        SdlHardware.WriteHiddenText(title[3, 0],
            564, Convert.ToInt16(title[3, 1]),
            0xFF, 0xFF, 0xFF,
            font94);
        SdlHardware.WriteHiddenText(title[4, 0],
           638, (short)(Convert.ToInt16(title[4, 1]) + 2),
           0x00, 0x00, 0x00,
           font94);
        SdlHardware.WriteHiddenText(title[4, 0],
            636, Convert.ToInt16(title[4, 1]),
            0xFF, 0xFF, 0xFF,
            font94);
        SdlHardware.WriteHiddenText(title[5, 0],
           710, (short)(Convert.ToInt16(title[5, 1]) + 2),
           0x00, 0x00, 0x00,
           font94);
        SdlHardware.WriteHiddenText(title[5, 0],
            708, Convert.ToInt16(title[5, 1]),
            0xFF, 0xFF, 0xFF,
            font94);
        SdlHardware.WriteHiddenText(title[6, 0],
           782, (short)(Convert.ToInt16(title[6, 1])+2),
           0x00, 0x00, 0x00,
           font94);
        SdlHardware.WriteHiddenText(title[6, 0],
            780, Convert.ToInt16(title[6, 1]),
            0xFF, 0xFF, 0xFF,
            font94);
        SdlHardware.WriteHiddenText(texts["co"],
           422, 482,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(texts["co"],
            420, 480,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["ng"],
            422, 522,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["ng"],
            420, 520,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["lg"],
            422, 562,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["lg"],
            420, 560,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["op"],
            422, 602,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["op"],
            420, 600,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["hl"],
            422, 642,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["hl"],
            420, 640,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["ex"],
            422, 682,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["ex"],
            420, 680,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.DrawHiddenImage(selector, 320, 460 + 40 * option);
    }
}