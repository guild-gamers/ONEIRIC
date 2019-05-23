using System.Collections.Generic;

class HelpScreen : Screen
{
    protected Image controls;
    protected Font font72, font28;

    public HelpScreen()
        : base(new Image("data/images/other/welcome.jpg"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        controls = new Image("data/images/other/controls.png");
        font72 = new Font("data/fonts/Joystix.ttf", 72);
        font28 = new Font("data/fonts/Joystix.ttf", 28);
        texts = new Dictionary<string, string>();
    }

    public void Run()
    {
        LoadText(Oneiric.Languages[Oneiric.Language], "helpMenu");
        SdlHardware.Pause(100);
        do
        {
            SdlHardware.ClearScreen();
            DrawMenu();
            SdlHardware.ShowHiddenScreen();
            if  (SdlHardware.KeyPressed(SdlHardware.KEY_RETURN))
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
        SdlHardware.DrawHiddenImage(Wallpaper, 0, 0);
        SdlHardware.DrawHiddenImage(controls, 30, 100);

        SdlHardware.WriteHiddenText(texts["hp"],
           442, 102,
           0x00, 0x00, 0x00,
           font72);
        SdlHardware.WriteHiddenText(texts["hp"],
            440, 100,
            0xFF, 0xFF, 0xFF,
            font72);

        SdlHardware.WriteHiddenText(texts["mv"],
           132, 552,
           0x00, 0x00, 0x00,
           font28);
        SdlHardware.WriteHiddenText(texts["mv"],
            130, 550,
            0xFF, 0xFF, 0xFF,
            font28);
        SdlHardware.WriteHiddenText(texts["iv"],
           512, 552,
           0x00, 0x00, 0x00,
           font28);
        SdlHardware.WriteHiddenText(texts["iv"],
            510, 550,
            0xFF, 0xFF, 0xFF,
            font28);
        SdlHardware.WriteHiddenText(texts["it"],
           872, 552,
           0x00, 0x00, 0x00,
           font28);
        SdlHardware.WriteHiddenText(texts["it"],
            870, 550,
            0xFF, 0xFF, 0xFF,
            font28);
        SdlHardware.WriteHiddenText(texts["mg"],
           322, 652,
           0x00, 0x00, 0x00,
           font28);
        SdlHardware.WriteHiddenText(texts["mg"],
            320, 650,
            0xFF, 0xFF, 0xFF,
            font28);
    }
}
