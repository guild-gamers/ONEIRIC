using System;

class Game
{
    public MainCharacter Mcharacter { get; set; }
    public Room Groom { get; set; }
    protected bool finished;
    protected Font font18;
    protected Random rand;
    public int Steps { get; set; }
    protected int randMax = 350;
    protected int randMin = 50;
    protected byte countTimer;
    public long Time { get; set; }
    protected GameMenuScreen gm;
    protected BattleScreen bs;

    public Game()
    {
        Mcharacter = new MainCharacter();
        finished = false;
        font18 = new Font("data/fonts/Joystix.ttf", 18);
        Groom = new Room();
        rand = new Random();
        Steps = rand.Next(randMin,randMax);
        Time = 0;
        countTimer = 0;
        gm = new GameMenuScreen();
    }

    void UpdateScreen()
    {
        SdlHardware.ClearScreen();
        Groom.DrawOnHiddenScreen();

        Mcharacter.DrawOnHiddenScreen();

        SdlHardware.ShowHiddenScreen();
    }

    void CheckInput()
    {
        if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT) && Mcharacter.GetX()
            >= Groom.MaxRight)
        {
            Groom.ActualCol++;
            Groom.UpdateScreenMap(Groom.ActualCol, Groom.ActualRow);
            Mcharacter.MoveTo(0, Mcharacter.GetY());
            Steps--;
        }
        else if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
        {
            if (Groom.CanMoveTo(Mcharacter.GetX() + Mcharacter.GetSpeedX(),
                    Mcharacter.GetY(),
                    Mcharacter.GetX() + Mcharacter.GetWidth() +
                    Mcharacter.GetSpeedX(),
                    Mcharacter.GetY() + Mcharacter.GetHeight()))
            {
                Mcharacter.MoveRight();
                Steps--;
            }
            else
            {
                Mcharacter.NextFrame();
            }
            Mcharacter.ChangeDirection(Sprite.RIGHT);
        }
        else if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT) &&
            Mcharacter.GetX() <= 0)
        {
            Groom.ActualCol--;
            Groom.UpdateScreenMap(Groom.ActualCol, Groom.ActualRow);
            Mcharacter.MoveTo(Groom.MaxRight, Mcharacter.GetY());
            Steps--;
        }
        else if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
        {
            if (Groom.CanMoveTo(Mcharacter.GetX() - Mcharacter.GetSpeedX(),
                    Mcharacter.GetY(),
                    Mcharacter.GetX() + Mcharacter.GetWidth() -
                    Mcharacter.GetSpeedX(),
                    Mcharacter.GetY() + Mcharacter.GetHeight()))
            {
                Mcharacter.MoveLeft();
                Steps--;
            }
            else
            {
                Mcharacter.NextFrame();
            }
            Mcharacter.ChangeDirection(Sprite.LEFT);
        }
        else if (SdlHardware.KeyPressed(SdlHardware.KEY_UP) &&
            Mcharacter.GetY() <= Groom.GetTopMargin())
        {
            Groom.ActualRow--;
            Groom.UpdateScreenMap(Groom.ActualCol, Groom.ActualRow);
            Mcharacter.MoveTo(Mcharacter.GetX(), Groom.MaxDown);
            Steps--;
        }
        else if (SdlHardware.KeyPressed(SdlHardware.KEY_UP))
        {
            if (Groom.CanMoveTo(Mcharacter.GetX(),
                    Mcharacter.GetY() - Mcharacter.GetSpeedY(),
                    Mcharacter.GetX() + Mcharacter.GetWidth(),
                    Mcharacter.GetY() + Mcharacter.GetHeight() -
                    Mcharacter.GetSpeedY()))
            {
                Mcharacter.MoveUp();
                Steps--;
            }
            else
            {
                Mcharacter.NextFrame();
            }
            Mcharacter.ChangeDirection(Sprite.UP);
        }
        else if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN) &&
            Mcharacter.GetY() >= Groom.MaxDown)
        {
            Groom.ActualRow++;
            Groom.UpdateScreenMap(Groom.ActualCol, Groom.ActualRow);
            Mcharacter.MoveTo(Mcharacter.GetX(), Groom.GetTopMargin());
            Steps--;
        }
        else if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN))
        {
            if (Groom.CanMoveTo(Mcharacter.GetX(),
                    Mcharacter.GetY() + Mcharacter.GetSpeedY(),
                    Mcharacter.GetX() + Mcharacter.GetWidth(),
                    Mcharacter.GetY() + Mcharacter.GetHeight() +
                    Mcharacter.GetSpeedY()))
            {
                Mcharacter.MoveDown();
                Steps--;
            }
            else
            {
                Mcharacter.NextFrame();
            }
            Mcharacter.ChangeDirection(Sprite.DOWN);
        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_I))
        {
            if (gm.Run(Groom, Mcharacter) == 5)
            {
                finished = true;
            }
        }
    }

    void CheckFights()
    {
        if (Steps == 0)
        {
            bs = new BattleScreen();
            bs.Run();
            Steps = rand.Next(randMin,randMax);
        }
    }

    void Timer()
    {
        if (countTimer == 25)
        {
            Time++;
            countTimer = 0;
        }

        countTimer++;
    }

    void PauseUntilNextFrame()
    {
        SdlHardware.Pause(40); //(40 ms = 25 fps)
    }

    public void Run()
    {
        do
        {
            UpdateScreen();

            CheckInput();

            CheckFights();

            Timer();

            PauseUntilNextFrame();
        }
        while (!finished);
    }
}