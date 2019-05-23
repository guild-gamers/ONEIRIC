using System;
using System.Collections.Generic;

class BattleScreen : Screen
{
    protected Image selector, menu, player;
    protected int option;
    protected Font font72;

    const int YCURSOR_MAX = 4;
    const int YCURSOR_MIN = 0;
    protected static NormalEnemy enemy;

    public BattleScreen()
        : base(new Image("data/images/other/battleBackground.png"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        option = 0;
        selector = new Image("data/images/other/selector2.png");
        menu = new Image("data/images/other/screen_battle.png");
        player = new Image("data/images/player/Left_2.png");
        font72 = new Font("data/fonts/Joystix.ttf", 72);
        texts = new Dictionary<string, string>();
        enemy = new NormalEnemy();
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
        PrepareBattle();
        do
        {
            SdlHardware.ClearScreen();
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
                SelectedOption(option);
            }
            SdlHardware.Pause(100);
        }
        while (true);
        //The loop ends when an option is choosed.
    }

    public static void SelectedOption(int option)
    {
        switch (option)
        {
            case 0:
                enemy.ActualLife -= Oneiric.g.Mcharacter.Damage;
                break;
        }
    }

    public static void PrepareBattle()
    {
        RandomEnemy(Game.rand.Next(0,15)+1);
        enemy.MoveTo(100,100);
        
    }

    public static NormalEnemy RandomEnemy(int random)
    {
        switch (random)
        {
            case 1:
                enemy = new Brigthrooster();
                break;
            case 2:
                enemy = new Chimera();
                break;
            case 3:
                enemy = new Garuda();
                break;
            case 4:
                enemy = new Ghost();
                break;
            case 5:
                enemy = new Mimic();
                break;
            case 6:
                enemy = new Nightmare();
                break;
            case 7:
                enemy = new NightmareSoldier();
                break;
            case 8:
                enemy = new Ogre();
                break;
            case 9:
                enemy = new Orc();
                break;
            case 10:
                enemy = new Puppet();
                break;
            case 11:
                enemy = new Skeleton();
                break;
            case 12:
                enemy = new Succubus();
                break;
            case 13:
                enemy = new Vampire();
                break;
            case 14:
                enemy = new Werewolf();
                break;
            case 15:
                enemy = new Zombie();
                break;
        }

        return enemy;
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
        SdlHardware.WriteHiddenText(texts["sk"],
           682, 562,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(texts["sk"],
            680, 560,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["it"],
           682, 602,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(texts["it"],
            680, 600,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["pt"],
           682, 642,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(texts["pt"],
            680, 640,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(texts["rn"],
           682, 682,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(texts["rn"],
            680, 680,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.DrawHiddenImage(selector, 670, 522 + 40 * option);
        SdlHardware.WriteHiddenText(Convert.ToString(
            Oneiric.g.Mcharacter.ActualLife),
           900, 250,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(Convert.ToString(
            Oneiric.g.Mcharacter.ActualLife),
            900, 250,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.WriteHiddenText(Convert.ToString(
            enemy.ActualLife),
           200, 500,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(Convert.ToString(
            enemy.ActualLife),
            200, 500,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.DrawHiddenImage(player, 900,200);
        enemy.DrawOnHiddenScreen();
    }
}
