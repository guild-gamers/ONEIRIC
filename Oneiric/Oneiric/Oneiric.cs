using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class Oneiric
{
    [Serializable]
    struct Option
    {
        public byte language;
        public byte difficulty;
        public byte volume;
        public bool fullScreen;
    }

    [Serializable]
    struct GameData
    {
        public int xPlayer;
        public int yPlayer;
        public byte currentDirectionPlayer;
        public int level;
        public int maxiumLife;
        public int actualLife;
        public int lifeIncreaser;
        public int maxiumPm;
        public int actualPm;
        public int pmIncreaser;
        public int damage;
        public int damageIncreaser;
        public int defense;
        public int defenseIncreaser;
        public int speed;
        public int speedIncreaser;
        public int speedPlayer;
        public int lucky;
        public List<Skill> skills;
        public List<Item> inventory;
        public List<Weapon> weapons;
        public byte actualColMap;
        public byte actualRowMap;
        public int steps;
        public long time;
    }

    public static byte Language { get; set; }
    public static byte Difficulty { get; set; }
    public static byte MAX_VOLUME = 10;
    public static byte Volume { get; set; }
    public static bool FullScreen { get; set; }
    public static string[] Languages = { "ESPAÑOL", "ENGLISH" };
    public static string[] Difficultation = { "es", "md", "hr" };
    public static Game g;
    public static OptionsScreen os;

    public static void Inicialize()
    {
        string file = "data/sys/options.dat";
        if (File.Exists(file))
        {
            Option op;
            IFormatter formatter = new BinaryFormatter();
            Stream input = new FileStream(file, FileMode.Open,
                FileAccess.Read, FileShare.Read);
            op = (Option)formatter.Deserialize(input);
            input.Close();

            Language = op.language;
            Difficulty = op.difficulty;
            Volume = op.volume;
            FullScreen = op.fullScreen;
        }
        else
        {
            FullScreen = false;
            Language = 0;
            Difficulty = 1;
            Volume = 10;
        }
    }

    static void Main()
    {
        Inicialize();

        SdlHardware.Init(1200, 768, 24, FullScreen);
        WelcomeScreen w = new WelcomeScreen();
        os = new OptionsScreen();
        LoadGamesScreen lg = new LoadGamesScreen();
        HelpScreen hs = new HelpScreen();

        int option;

        do
        {
            option = w.Run();
            switch (option)
            {
                case 0: break;
                case 1: g = new Game();  g.Run();
                    break;
                case 2:
                    if (lg.Run() == 0)
                    {
                        g.Run();
                    }
                    break;
                case 3: os.Run();
                    SaveOptions();
                    SdlHardware.Init(1200, 768, 24, FullScreen);
                    break;
                case 4: hs.Run();
                    break;
            }
        } while (option != 5);
        
    }

    public static void SaveLog(string error)
    {
        StreamWriter file = File.AppendText("data/sys/err.log");

        file.WriteLine(DateTime.Now + " → " + error);

        file.Close();
    }

    public static void SaveGame(string file)
    {
        GameData gD = new GameData();
        gD.xPlayer = g.Mcharacter.GetX();
        gD.yPlayer = g.Mcharacter.GetY();
        gD.currentDirectionPlayer = g.Mcharacter.GetCurrentDirection();
        gD.level = g.Mcharacter.Level;
        gD.maxiumLife = g.Mcharacter.MaxiumLife;
        gD.actualLife = g.Mcharacter.ActualLife;
        gD.lifeIncreaser = g.Mcharacter.LifeIncreaser;
        gD.maxiumPm = g.Mcharacter.MaxiumPm;
        gD.actualPm = g.Mcharacter.ActualPm;
        gD.pmIncreaser = g.Mcharacter.PmIncreaser;
        gD.damage = g.Mcharacter.Damage;
        gD.damageIncreaser = g.Mcharacter.DamageIncreaser;
        gD.defense = g.Mcharacter.Defense;
        gD.defenseIncreaser = g.Mcharacter.DefenseIncreaser;
        gD.speed = g.Mcharacter.Speed;
        gD.speedIncreaser = g.Mcharacter.SpeedIncreaser;
        gD.speedPlayer = g.Mcharacter.GetSpeedX();
        gD.lucky = g.Mcharacter.Lucky;
        gD.skills = g.Mcharacter.Skills;
        gD.inventory = g.Mcharacter.Inventory;
        gD.weapons = g.Mcharacter.Weapons;
        gD.actualColMap = g.Groom.ActualCol;
        gD.actualRowMap = g.Groom.ActualRow;
        gD.steps = g.Steps;
        gD.time = g.Time;

        IFormatter formatter = new BinaryFormatter();
        Stream output = new FileStream(file, FileMode.Create,
            FileAccess.Write, FileShare.None);
        formatter.Serialize(output, gD);
        output.Close();
    }

    public static void SaveOptions()
    {
        Option op = new Option();
        op.language = Language;
        op.difficulty = Difficulty;
        op.volume = Volume;
        op.fullScreen = FullScreen;

        string file = "data/sys/options.dat";
        IFormatter formatter = new BinaryFormatter();
        Stream output = new FileStream(file, FileMode.Create,
            FileAccess.Write, FileShare.None);
        formatter.Serialize(output, op);
        output.Close();
    }

    public static void LoadGame(string file)
    {
        g = new Game();
        GameData gD = new GameData();
        IFormatter formatter = new BinaryFormatter();
        Stream input = new FileStream(file, FileMode.Open,
            FileAccess.Read, FileShare.Read);
        gD = (GameData)formatter.Deserialize(input);
        input.Close();

        g.Mcharacter.MoveTo(gD.xPlayer,gD.yPlayer);
        g.Mcharacter.ChangeDirection(gD.currentDirectionPlayer);
        g.Mcharacter.Level = gD.level;
        g.Mcharacter.MaxiumLife = gD.maxiumLife;
        g.Mcharacter.ActualLife = gD.actualLife;
        g.Mcharacter.LifeIncreaser = gD.lifeIncreaser;
        g.Mcharacter.MaxiumPm = gD.maxiumPm;
        g.Mcharacter.ActualPm = gD.actualPm;
        g.Mcharacter.PmIncreaser = gD.pmIncreaser;
        g.Mcharacter.Damage = gD.damage;
        g.Mcharacter.DamageIncreaser = gD.damageIncreaser;
        g.Mcharacter.Defense = gD.defense;
        g.Mcharacter.DefenseIncreaser = gD.defenseIncreaser;
        g.Mcharacter.Speed = gD.speed;
        g.Mcharacter.SpeedIncreaser = gD.speedIncreaser;
        g.Mcharacter.SetSpeed(gD.speedPlayer,gD.speedPlayer);
        g.Mcharacter.Lucky = gD.lucky;
        g.Mcharacter.Skills = gD.skills;
        g.Mcharacter.Inventory = gD.inventory;
        g.Mcharacter.Weapons = gD.weapons;
        g.Groom.ActualCol = gD.actualColMap;
        g.Groom.ActualRow = gD.actualRowMap;
        g.Groom.UpdateScreenMap(gD.actualColMap,gD.actualRowMap);
        g.Steps = gD.steps;
        g.Time = gD.time;
    }

    public static long GetTime(string file)
    {
        g = new Game();
        GameData gD = new GameData();
        IFormatter formatter = new BinaryFormatter();
        Stream input = new FileStream(file, FileMode.Open,
            FileAccess.Read, FileShare.Read);
        gD = (GameData)formatter.Deserialize(input);
        input.Close();

        return gD.time;
    }
}
