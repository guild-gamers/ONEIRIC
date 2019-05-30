class GameOverScreen : Screen
{
    protected Font font72;

    public GameOverScreen()
        : base(new Image("data/images/other/welcome.jpg"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        font72 = new Font("data/fonts/Joystix.ttf", 72);
    }

    public void Run()
    {
        LoadText(Oneiric.Languages[Oneiric.Language], "gameOver");
        SdlHardware.Pause(100);
        do
        {
            SdlHardware.ClearScreen();
            DrawMenu();
            SdlHardware.ShowHiddenScreen();
            if (SdlHardware.KeyPressed(SdlHardware.KEY_RETURN))
            {
                return;
            }
            SdlHardware.Pause(100);
        }
        while (true);
        //The loop ends when an option is choosed.
    }

    public void DrawMenu()
    {

        SdlHardware.WriteHiddenText(texts["go"],
           442, 102,
           0x00, 0x00, 0x00,
           font72);
        SdlHardware.WriteHiddenText(texts["go"],
            440, 100,
            0xFF, 0xFF, 0xFF,
            font72);
        SdlHardware.WriteHiddenText(texts["pe"],
           242, 302,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(texts["pe"],
            240, 300,
            0xFF, 0xFF, 0xFF,
            Font28);
    }
}
