using System;
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
        public int speedPlayer;
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
                case 4: break;
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
        gD.speedPlayer = g.Mcharacter.GetSpeedX();
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
        g.Mcharacter.SetSpeed(gD.speedPlayer,gD.speedPlayer);
        g.Groom.ActualCol = gD.actualColMap;
        g.Groom.ActualRow = gD.actualRowMap;
        g.Groom.UpdateScreenMap(gD.actualColMap,gD.actualRowMap);
        g.Steps = gD.steps;
        g.Time = gD.time;
    }
}
