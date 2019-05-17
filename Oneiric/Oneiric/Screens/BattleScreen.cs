using System.Collections.Generic;

class BattleScreen : Screen
{
    protected Image selector;
    protected int option;
    protected Font font72;

    const int YCURSOR_MAX = 3;
    const int YCURSOR_MIN = 0;

    public BattleScreen()
        : base(new Image("data/images/other/battleBackground.png"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        option = 0;
        selector = new Image("data/images/other/selector.png");
        font72 = new Font("data/fonts/Joystix.ttf", 72);
        texts = new Dictionary<string, string>();
    }

    public int GetChosenOption()
    {
        return option;
    }

    public int Run()
    {
        option = 0;
        LoadText(Oneiric.Languages[Oneiric.Language], "loadSaveMenu");
        SdlHardware.Pause(100);
        do
        {
            SdlHardware.ClearScreen();
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
                
            }
            SdlHardware.Pause(100);
        }
        while (true);
        //The loop ends when an option is choosed.
    }

    public void DrawMenu()
    {
        SdlHardware.DrawHiddenImage(Wallpaper, 0, 0);

        SdlHardware.DrawHiddenImage(selector, option != YCURSOR_MAX ? 235 : 430,
            250 + 115 * option);
    }
}
