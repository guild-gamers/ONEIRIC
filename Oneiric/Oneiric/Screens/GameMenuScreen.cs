using System.Collections.Generic;
using System;

[Serializable]
class GameMenuScreen : Screen
{
    protected Image selector, secondSelector, saveBackground, greyBackground;
    protected int option;
    protected Font font72;

    const int YCURSOR_MAX = 6;
    const int YCURSOR_MIN = 0;

    public GameMenuScreen()
        : base(new Image("data/images/other/menuInGame.png"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        option = 0;
        selector = new Image("data/images/other/selector2.png");
        secondSelector = new Image("data/images/other/selector2.png");
        saveBackground = new Image("data/images/other/loadGame.png");
        greyBackground = new Image("data/images/other/greyBackground.png");
        font72 = new Font("data/fonts/Joystix.ttf", 72);
        texts = new Dictionary<string, string>();
    }

    public int Run(Room room, MainCharacter character)
    {
        option = 0;
        LoadText(Oneiric.Languages[Oneiric.Language], "gameMenu");
        
        do
        {
            SdlHardware.ClearScreen();
            room.DrawOnHiddenScreen();
            character.DrawOnHiddenScreen();
            DrawMenu();
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
                return ChoosedOption();
            }
            SdlHardware.Pause(100);
        }
        while (true);
        //The loop ends when the option choosed is Title or Back.
    }

    public int ChoosedOption()
    {
        int value = 0;
        switch (option)
        {
            case 0:
                value = 0;
                break;
            case 1:
                ShowInventory();
                value = 1;
                break;
            case 2:
                value = 2;
                break;
            case 3:
                SaveMenu();
                value = 3;
                break;
            case 4:
                Oneiric.os.Run();
                Oneiric.SaveOptions();
                value = 4;
                break;
            case 5:
                value = 5;
                break;
            case 6:
                value = 6;
                break;
        }

        return value;
    }

    public void ShowInventory()
    {
        int selected = 0;
        List<string> drawItems = new List<string>();

        foreach (KeyValuePair<Item, byte> i in
                Oneiric.g.Mcharacter.GetInventory())
        {
            drawItems.Add(Oneiric.ItemsName[i.Key.Name.Substring(0, 2)]
                + " x" + i.Value);
        }

        do
        {
            short posX = 200;
            short posY = 230;

            int index = selected - 10;
            index = index < 0 ? 0:index;

            SdlHardware.DrawHiddenImage(greyBackground, 0, 0);
            SdlHardware.DrawHiddenImage(selector, 160, 232 + 30 * selected);
            for (int i = 0; i < 10 && i < drawItems.Count-1; i++)
            {
                SdlHardware.WriteHiddenText(drawItems[index],
                        (short)(posX + 2), (short)(posY + 2),
                        0x00, 0x00, 0x00,
                        Font28);
                SdlHardware.WriteHiddenText(drawItems[index],
                    posX, posY,
                    0xFF, 0xFF, 0xFF,
                    Font28);
                posY += 30;
                index++;
            }

            int minSelected = selected - 10;
            minSelected = minSelected < 10 ? 0 : minSelected;
            int maxSelected = minSelected + 10;
            maxSelected = minSelected < 10 ? index-1 : maxSelected;
            
            SdlHardware.ShowHiddenScreen();
            if (SdlHardware.KeyPressed(SdlHardware.KEY_W) && selected >
                 minSelected)
            {
                selected--;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_S) && selected <
                maxSelected)
            {
                selected++;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_RETURN))
            {
                Oneiric.g.Mcharacter.UseItem(drawItems[selected]);
            }
            SdlHardware.Pause(100);
            SdlHardware.ShowHiddenScreen();

        } while (!SdlHardware.KeyPressed(SdlHardware.KEY_ESC));
        
    }

    public string SelectedOption()
    {
        string rt = "";
        switch (option)
        {
            case 0:
                rt = "eq";
                break;
            case 1:
                rt = "in";
                break;
            case 2:
                rt = "sn";
                break;
            case 3:
                rt = "sv";
                break;
            case 4:
                rt = "op";
                break;
            case 5:
                rt = "tt";
                break;
            case 6:
                rt = "cl";
                break;
        }

        return rt;
    }

    public void DrawMenu()
    {
        SdlHardware.DrawHiddenImage(Wallpaper, 0, 0);
        SdlHardware.WriteHiddenText(texts[SelectedOption()],
            352, 132,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts[SelectedOption()],
            350, 132,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["mn"],
            962, 132,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["mn"],
            960, 130,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["eq"],
            922, 182,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["eq"],
            920, 180,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["in"],
            922, 252,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["in"],
            920, 250,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["sn"],
            922, 322,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["sn"],
            920, 320,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["sv"],
            922, 392,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["sv"],
            920, 390,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["op"],
            922, 462,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["op"],
            920, 460,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["tt"],
            922, 532,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["tt"],
            920, 530,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["cl"],
            922, 602,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["cl"],
            920, 600,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.DrawHiddenImage(selector, 890, 183 + 70 * option);
    }

    public void SaveMenu()
    {
        int optionSave = 0;
        const int YSECONDCURSOR_MAX = 2;
        const int YSECONDCURSOR_MIN = 0;
        SdlHardware.Pause(100);
        do
        {
            SdlHardware.DrawHiddenImage(greyBackground, 0, 0);
            SdlHardware.DrawHiddenImage(saveBackground, -100, 0);
            SdlHardware.DrawHiddenImage(selector, 200, 270 + 120 * optionSave);
            SdlHardware.ShowHiddenScreen();
            if (SdlHardware.KeyPressed(SdlHardware.KEY_W) && optionSave >
                 YSECONDCURSOR_MIN)
            {
                optionSave--;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_S) && optionSave <
                YSECONDCURSOR_MAX)
            {
                optionSave++;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_RETURN))
            {
                Oneiric.SaveGame("data/savedGames/" + (optionSave + 1) + "_game.save");
            }
            SdlHardware.Pause(100);
        } while (!SdlHardware.KeyPressed(SdlHardware.KEY_ESC));
    }
}
