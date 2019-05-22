using System.Collections.Generic;

class BattleScreen : Screen
{
    protected Image selector, menu;
    protected int option;
    protected Font font72;

    const int YCURSOR_MAX = 4;
    const int YCURSOR_MIN = 0;

    public BattleScreen()
        : base(new Image("data/images/other/battleBackground.png"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        option = 0;
        selector = new Image("data/images/other/selector2.png");
        menu = new Image("data/images/other/screen_battle.png");
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
        LoadText(Oneiric.Languages[Oneiric.Language], "battleMenu");
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
        SdlHardware.DrawHiddenImage(menu, 650, 500);
        SdlHardware.WriteHiddenText(texts["at"],
            682, 522,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["at"],
            680, 520,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.DrawHiddenImage(selector, 670, 520 + 40 * option);
    }
}
