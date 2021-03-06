﻿using System;
using System.Collections.Generic;
using System.IO;

class LoadGamesScreen : Screen
{
    protected Image selector, realWallpaper;
    protected int option;
    protected Font font72, font12;

    const int YCURSOR_MAX = 3;
    const int YCURSOR_MIN = 0;

    public LoadGamesScreen()
        : base(new Image("data/images/other/loadGame.png"),
            new Font("data/fonts/Joystix.ttf", 28))
    {
        option = 0;
        selector = new Image("data/images/other/selector.png");
        realWallpaper = new Image("data/images/other/welcome.jpg");
        font72 = new Font("data/fonts/Joystix.ttf", 72);
        font12 = new Font("data/fonts/Joystix.ttf", 12);
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
                string nameFile = "data/savedGames/" + (option + 1) +
                        "_game.save";
                if (option == YCURSOR_MAX)
                {
                    return 1;  
                }
                else
                {
                    if (!File.Exists(nameFile))
                    {
                        Oneiric.SaveLog("Can't load the game. File Not Found "+
                            nameFile);
                    }
                    else
                    {
                        Oneiric.LoadGame(nameFile);
                        return 0;
                    }
                }
                
            }
            SdlHardware.Pause(100);
        }
        while (true);
        //The loop ends when an option is choosed.
    }

    public void DrawMenu()
    {
        SdlHardware.DrawHiddenImage(realWallpaper, 0, 0);
        SdlHardware.DrawHiddenImage(Wallpaper, 0, 0);
        SdlHardware.WriteHiddenText(texts["lg"],
           202, 102,
           0x00, 0x00, 0x00,
           font72);
        SdlHardware.WriteHiddenText(texts["lg"],
            200, 100,
            0xFF, 0xFF, 0xFF,
            font72);
        SdlHardware.WriteHiddenText("1",
           372, 267,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText("1",
            370, 265,
            0xFF, 0xFF, 0xFF,
            Font28);

        if (File.Exists("data/savedGames/1_game.save"))
        {
            string time = CalculateTime(
                Oneiric.GetTime("data/savedGames/1_game.save"));

            SdlHardware.WriteHiddenText(texts["gt"] + time,
                592, 302,
                0x00, 0x00, 0x00,
                font12);
            SdlHardware.WriteHiddenText(texts["gt"] + time,
                590, 300,
                0xFF, 0xFF, 0xFF,
                font12);
        }
        else
        {
            SdlHardware.WriteHiddenText(texts["nd"],
                482, 267,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText(texts["nd"],
                480, 265,
                0xFF, 0xFF, 0xFF,
                Font28);
        }
        SdlHardware.WriteHiddenText("2",
           372, 387,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText("2",
            370, 385,
            0xFF, 0xFF, 0xFF,
            Font28);
        if (File.Exists("data/savedGames/2_game.save"))
        {
            string time = CalculateTime(
                Oneiric.GetTime("data/savedGames/2_game.save"));

            SdlHardware.WriteHiddenText(texts["gt"] + time,
                592, 422,
                0x00, 0x00, 0x00,
                font12);
            SdlHardware.WriteHiddenText(texts["gt"] + time,
                590, 420,
                0xFF, 0xFF, 0xFF,
                font12);
        }
        else
        {
            SdlHardware.WriteHiddenText(texts["nd"],
                482, 387,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText(texts["nd"],
                480, 385,
                0xFF, 0xFF, 0xFF,
                Font28);
        }
        SdlHardware.WriteHiddenText("3",
           372, 497,
           0x00, 0x00, 0x00,
           Font28);
        SdlHardware.WriteHiddenText("3",
            370, 495,
            0xFF, 0xFF, 0xFF,
            Font28);
        if (File.Exists("data/savedGames/3_game.save"))
        {
            string time = CalculateTime(
                Oneiric.GetTime("data/savedGames/3_game.save"));

            SdlHardware.WriteHiddenText(texts["gt"] + time,
                592, 532,
                0x00, 0x00, 0x00,
                font12);
            SdlHardware.WriteHiddenText(texts["gt"] + time,
                590, 530,
                0xFF, 0xFF, 0xFF,
                font12);
        }
        else
        {
            SdlHardware.WriteHiddenText(texts["nd"],
                482, 497,
                0x00, 0x00, 0x00,
                Font28);
            SdlHardware.WriteHiddenText(texts["nd"],
                480, 495,
                0xFF, 0xFF, 0xFF,
                Font28);
        }
        SdlHardware.WriteHiddenText(texts["bc"],
            502, 618,
            0x00, 0x00, 0x00,
            Font28);
        SdlHardware.WriteHiddenText(texts["bc"],
            500, 616,
            0xFF, 0xFF, 0xFF,
            Font28);
        SdlHardware.DrawHiddenImage(selector, option != YCURSOR_MAX? 235:430,
            250 + 115 * option);
    }

    public string CalculateTime(long seconds)
    {
        long hours = (seconds / 3600);
        long minutes = ((seconds - hours * 3600) / 60);
        long secs = seconds - (hours * 3600 + minutes * 60);
        return hours.ToString() + ":" + minutes.ToString() + ":" + secs.ToString();
    }
}
