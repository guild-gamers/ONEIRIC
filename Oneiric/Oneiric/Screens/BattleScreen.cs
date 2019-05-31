using System;
using System.Collections.Generic;

class BattleScreen : Screen
{
    protected Image selector, menu, player, historyI, selector2, items;
    protected static int option;
    protected Font font72, font16;

    const int YCURSOR_MAX = 4;
    const int YCURSOR_MIN = 0;
    protected static NormalEnemy enemy;
    protected Queue<string> history;
    protected Dictionary<string,string> battleTexts;
    protected bool protecting;

    public BattleScreen()
        : base(new Image("data/images/other/battleBackground.png"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        option = 0;
        selector = new Image("data/images/other/selector2.png");
        selector2 = new Image("data/images/other/selector2.png");
        menu = new Image("data/images/other/screen_battle.png");
        items = new Image("data/images/other/screen_battle.png");
        historyI = new Image("data/images/other/history.png");
        player = new Image("data/images/player/Left_2.png");
        font72 = new Font("data/fonts/Joystix.ttf", 72);
        font16 = new Font("data/fonts/Joystix.ttf", 16);
        texts = new Dictionary<string, string>();
        battleTexts = new Dictionary<string, string>();
        history = new Queue<string>();
        for (int i = 0; i < 15; i++)
        {
            history.Enqueue(" ");
        }
        protecting = false;
    }

    public int GetChosenOption()
    {
        return option;
    }

    public void Run()
    {
        bool endBattle = false;
        LoadText(Oneiric.Languages[Oneiric.Language], "battleTexts");
        
        SdlHardware.Pause(100);
        PrepareBattle();
        do
        {
            bool endPlayerTurn = false;
            do
            { 
                PlayerTurn(ref endBattle, ref endPlayerTurn);
                UpdateScreen();
                SdlHardware.Pause(100);
            } while (!endPlayerTurn);

            SdlHardware.Pause(500);
            if (!endBattle)
            {
                EnemyTurn(ref endBattle);
                UpdateScreen();
                SdlHardware.Pause(100);
            }
        }
        while (!endBattle);
        
    }

    public void UpdateScreen() {
        SdlHardware.ClearScreen();
        DrawMenu();
        ShowHistory();
        SdlHardware.ShowHiddenScreen();
    }

    public void PlayerTurn(ref bool endBattle, ref bool endPlayerTurn)
    {
        if (protecting)
        {
            Oneiric.g.Mcharacter.Defense /= 2;
        }
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
            SelectedOption(ref endBattle, ref endPlayerTurn);
        }
    }

    public void EnemyTurn(ref bool endBattle)
    {
        WriteOnHistory(enemy.GetType() + texts["aa"] +
                    " Jugador");
        string damage = enemy.Attack(Oneiric.g.Mcharacter);
        WriteOnHistory(enemy.GetType() + texts["in"] +
                    " " + damage +  texts["dm"]);
        if (Oneiric.g.Mcharacter.ActualLife == 0)
        {
            WriteOnHistory(texts["yd"]);
            endBattle = true;
        }
    }

    public void SelectedOption(ref bool endBattle, ref bool endPlayerTurn)
    {
        switch (option)
        {
            case 0:
                WriteOnHistory(Oneiric.g.Mcharacter.Name + texts["aa"] + 
                    " " + enemy.GetType());
                string damage = Oneiric.g.Mcharacter.Attack(enemy);
                WriteOnHistory(Oneiric.g.Mcharacter.Name + texts["in"] +
                    " " + damage + texts["dm"]);
                if (enemy.ActualLife == 0)
                {
                    WriteOnHistory(enemy.GetType() + texts["de"]);
                    WriteOnHistory(Oneiric.g.Mcharacter.Name + texts["wn"]);
                    Item i = enemy.DropItem();
                    if (i != null)
                    {
                        Oneiric.g.Mcharacter.AddItem(i);
                        WriteOnHistory(texts["yg"] + " " + i.Name);
                    }
                    endBattle = true;
                }
                endPlayerTurn = true;
                break;
            case 1:
                break;
            case 2:
                endPlayerTurn = ShowItems();
                break;
            case 3:
                Oneiric.g.Mcharacter.Protect();
                protecting = true;
                break;
            case 4:
                if (Game.rand.Next(0,1)+1 == 1)
                {
                    endBattle = true;
                }
                endPlayerTurn = true;
                break;
        }
    }

    public List<string> LoadDrawItems()
    {
        List<string> dw = new List<string>();
        if (Oneiric.g.Mcharacter.GetInventory().Count > 0)
        {
            foreach (KeyValuePair<Item, byte> i in
                    Oneiric.g.Mcharacter.GetInventory())
            {
                if (i.Key is ConsumableItem)
                {
                    dw.Add(Oneiric.ItemsName[i.Key.Name.Substring(0, 2)]
                    + " x" + i.Value);
                }
            }

            return dw;
        }
        else
            return null;
    }

    public bool ShowItems()
    {
        int selected = 0;

        do
        {
            SdlHardware.Pause(100);
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
                short posX = 840;
                short posY = 420;

                int index = selected - 6;
                index = index < 0 ? 0 : index;

                SdlHardware.DrawHiddenImage(items, 780, 400);
                
                for (int i = 0; i < 10 && i < drawItems.Count - 1; i++)
                {
                    SdlHardware.WriteHiddenText(drawItems[index],
                        (short)(posX + 2), (short)(posY + 2),
                        0x00, 0x00, 0x00,
                        font16);
                    SdlHardware.WriteHiddenText(drawItems[index],
                        posX, posY,
                        0xFF, 0xFF, 0xFF,
                        font16);
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
                    return true;
                }
                
                SdlHardware.DrawHiddenImage(selector2, 800, 418 + 30 * selected);
                SdlHardware.ShowHiddenScreen();
                SdlHardware.Pause(100);

            }
        } while (!SdlHardware.KeyPressed(SdlHardware.KEY_ESC));
        return false;
    }

    public void ShowHistory() {
        short posX = 30;
        short posY = 450;
        foreach (string s in history) {
            SdlHardware.WriteHiddenText(s,
                (short)(posX+2), (short)(posY+2),
                0x00, 0x00, 0x00,
                font16);
            SdlHardware.WriteHiddenText(s,
                posX, posY,
                0xFF, 0xFF, 0xFF,
                font16);
            posY += 20;
        }
    }

    public void WriteOnHistory(string s)
    {
        history.Enqueue(s);
        history.Dequeue();
        UpdateScreen();
        SdlHardware.Pause(1000);
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
        SdlHardware.DrawHiddenImage(historyI, 20, 425);
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
           200, 375,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText(Convert.ToString(
            enemy.ActualLife),
            200, 375,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.DrawHiddenImage(player, 900,200);
        enemy.DrawOnHiddenScreen();
    }
}
