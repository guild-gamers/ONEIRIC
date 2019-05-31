using System.Collections.Generic;
using System;

[Serializable]
class GameMenuScreen : Screen
{
    protected Image selector, secondSelector, saveBackground, greyBackground, face;
    protected Image[] icons;
    protected int option;
    protected Font font72;

    const int YCURSOR_MAX = 6;
    const int YCURSOR_MIN = 0;
    const int TOTAL_ICONS = 7;

    public GameMenuScreen()
        : base(new Image("data/images/other/menuInGame.png"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        option = 0;
        selector = new Image("data/images/other/selector2.png");
        secondSelector = new Image("data/images/other/selector2.png");
        saveBackground = new Image("data/images/other/loadGame.png");
        greyBackground = new Image("data/images/other/greyBackground.png");
        face = new Image("data/images/player/Face.png");
        icons = new Image[TOTAL_ICONS];
        icons[0] = new Image("data/images/other/icons/Life.png");
        icons[1] = new Image("data/images/other/icons/Laptoop.png");
        icons[2] = new Image("data/images/other/icons/Damage.png");
        icons[3] = new Image("data/images/other/icons/Defense.png");
        icons[4] = new Image("data/images/other/icons/XP.png");
        icons[5] = new Image("data/images/other/icons/Speed.png");
        icons[6] = new Image("data/images/other/icons/Lucky.png");
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
                int optionSelected = ChoosedOption();
                if (optionSelected == 5 || optionSelected == YCURSOR_MAX)
                {
                    return ChoosedOption();
                }
                SdlHardware.Pause(200);
            }
            SdlHardware.Pause(100);
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_ESC));
        return 0;
    }

    public int ChoosedOption()
    {
        int value = 0;
        switch (option)
        {
            case 0:
                ShowParty();
                value = 0;
                break;
            case 1:
                SdlHardware.Pause(200);
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

    public void ShowParty()
    {
        SdlHardware.Pause(100);
        do
        {
            SdlHardware.DrawHiddenImage(greyBackground, 0, 0);
            SdlHardware.DrawHiddenImage(face, 620, 200);
            SdlHardware.DrawHiddenImage(icons[0], 212, 200);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.ActualLife.ToString()
                + " / " + Oneiric.g.Mcharacter.MaxiumLife.ToString(),
                252, 202,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.ActualLife.ToString()
                + " / " + Oneiric.g.Mcharacter.MaxiumLife.ToString(),
                250, 200,
                0xFF, 0xFF, 0xFF,
                Font28);
            SdlHardware.DrawHiddenImage(icons[1], 212, 250);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.ActualPm.ToString()
                + " / " + Oneiric.g.Mcharacter.MaxiumPm.ToString(),
                252, 252,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.ActualPm.ToString()
                + " / " + Oneiric.g.Mcharacter.MaxiumPm.ToString(),
                250, 250,
                0xFF, 0xFF, 0xFF,
                Font28);
            SdlHardware.DrawHiddenImage(icons[2], 212, 300);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.Damage.ToString(),
                252, 302,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.Damage.ToString(),
                250, 300,
                0xFF, 0xFF, 0xFF,
                Font28);
            SdlHardware.DrawHiddenImage(icons[3], 212, 350);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.Defense.ToString(),
                252, 352,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.Defense.ToString(),
                250, 350,
                0xFF, 0xFF, 0xFF,
                Font28);
            SdlHardware.DrawHiddenImage(icons[5], 212, 400);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.Speed.ToString(),
                252, 402,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.Speed.ToString(),
                250, 400,
                0xFF, 0xFF, 0xFF,
                Font28);
            SdlHardware.DrawHiddenImage(icons[6], 212, 450);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.Lucky.ToString(),
                252, 452,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.Lucky.ToString(),
                250, 450,
                0xFF, 0xFF, 0xFF,
                Font28);
            SdlHardware.WriteHiddenText(Oneiric.g.Mcharacter.Speed.ToString(),
                250, 400,
                0xFF, 0xFF, 0xFF,
                Font28);
            SdlHardware.WriteHiddenText("ESC -->",
                602, 622,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText("ESC -->",
                600, 620,
                0xFF, 0xFF, 0xFF,
                Font28);
            SdlHardware.ShowHiddenScreen();

            SdlHardware.Pause(100);
        } while (!SdlHardware.KeyPressed(SdlHardware.KEY_ESC));
    }

    public List<string> LoadDrawItems() {
        List<string> dw = new List<string>();
        if (Oneiric.g.Mcharacter.GetInventory().Count > 0)
        {
            foreach (KeyValuePair<Item, byte> i in
                    Oneiric.g.Mcharacter.GetInventory())
            {
                dw.Add(Oneiric.ItemsName[i.Key.Name.Substring(0, 2)]
                    + " x" + i.Value);
            }

            return dw;
        }
        else
            return null;
    }

    public void ShowInventory()
    {
        int selected = 0;

        do
        {
            List<string> drawItems = LoadDrawItems();
            if (drawItems == null)
            {
                SdlHardware.WriteHiddenText("NO HAY OBJETOS",
                    552, 422,
                    0x00, 0x00, 0x00,
                    Font28);
                SdlHardware.WriteHiddenText("NO HAY OBJETOS",
                    550, 420,
                    0xFF, 0xFF, 0xFF,
                    Font28);
            }
            else
            {
                short posX = 200;
                short posY = 230;

                int index = selected - 10;
                index = index < 0 ? 0 : index;

                SdlHardware.DrawHiddenImage(greyBackground, 0, 0);
                SdlHardware.DrawHiddenImage(selector, 160, 232 + 30 * selected);
                for (int i = 0; i < 10 && i < drawItems.Count - 1; i++)
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
                maxSelected = minSelected < 10 ? index - 1 : maxSelected;

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
                    Oneiric.g.Mcharacter.UseItem(drawItems[selected].Substring(0, 2));
                }
                SdlHardware.Pause(100);
                SdlHardware.ShowHiddenScreen();
            }
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
