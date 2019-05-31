using System.Collections.Generic;
using System.IO;

class Room
{
    const int TOTAL_IMAGES = 20;
    protected Image[] images = new Image[TOTAL_IMAGES];

    public int mapHeight = 16, mapWidth = 25;
    protected int tileWidth = 48, tileHeight = 48;
    protected int leftMargin = 0, topMargin = 0;

    public int MaxRight = 1150;
    public int MaxDown = 720;

    public string[] levelData;
    protected char[,] mapData;

    public byte ActualCol = 1;
    public byte ActualRow = 1;

    public List<Chest> chests;

    public Room()
    {
        images[0] = new Image("data/images/map/floor1.jpg");
        images[1] = new Image("data/images/map/wall1Down.jpg");
        images[2] = new Image("data/images/map/table.png");
        images[3] = new Image("data/images/map/wall1Center.jpg");
        images[4] = new Image("data/images/map/wall1Up.jpg");
        images[5] = new Image("data/images/map/wall1Center.jpg");
        images[6] = new Image("data/images/map/wall1EndDownCenter.jpg");
        images[7] = new Image("data/images/map/wall1EndUpCenter.jpg");
        images[8] = new Image("data/images/map/wall1MidCenterVertical.jpg");
        images[9] = new Image("data/images/map/wall1MidCenterHorizontal.jpg");
        images[10] = new Image("data/images/map/wall1EndUpRightCorner.jpg");
        images[11] = new Image("data/images/map/wall1EndUpRightCorner.jpg");
        images[12] = new Image("data/images/map/wall1EndUpLeftCorner.jpg");
        images[13] = new Image("data/images/map/wall1EndDownRightCorner.jpg");
        images[14] = new Image("data/images/map/wall1EndDownLeftCorner.jpg");
        levelData = File.ReadAllLines("data/maps/level.map");
        chests = new List<Chest>();
        mapData = new char[mapWidth, mapHeight];
        UpdateScreenMap(ActualCol, ActualRow);
    }

    public int GetTopMargin() { return topMargin; }

    public void UpdateScreenMap(int col, int row)
    {
        chests.Clear();
        int startRow = row * mapHeight;
        int startCol = col * mapWidth;

        for (int r = 0; r < mapHeight; r++)
        {
            for (int c = 0; c < mapWidth; c++)
            {
                mapData[c, r] = levelData[startRow + r][startCol + c];
            }
        }
    }

    public void DrawOnHiddenScreen()
    {
        for (int row = 0; row < mapHeight; row++)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                int posX = col * tileWidth + leftMargin;
                int posY = row * tileHeight + topMargin;
                switch (mapData[col, row])
                {
                    case 'A': SdlHardware.DrawHiddenImage(images[0], posX,
                        posY); break;
                    case 'W':
                        SdlHardware.DrawHiddenImage(images[1], posX,
                        posY); break;
                    case 'R':
                        SdlHardware.DrawHiddenImage(images[4], posX,
                        posY); break;
                    case 'F':
                        SdlHardware.DrawHiddenImage(images[6], posX,
                        posY); break;
                    case 'P':
                        SdlHardware.DrawHiddenImage(images[5], posX,
                        posY); break;
                    case 'C':
                        mapData[col, row] = 'T';
                        SdlHardware.DrawHiddenImage(images[0], posX,
                        posY);
                        SdlHardware.DrawHiddenImage(images[2], posX,
                        posY);
                        Chest c = new Chest("data/images/map/computerOff.png", 1);
                        c.MoveTo(posX,posY);
                        chests.Add(c);
                        break;
                    case 'T':
                        SdlHardware.DrawHiddenImage(images[0], posX,
                        posY);
                        SdlHardware.DrawHiddenImage(images[2], posX,
                        posY);
                        break;
                }
            }
        }
        foreach (Chest c in chests)
            c.DrawOnHiddenScreen();
    }

    public bool CanMoveTo(int x1, int y1, int x2, int y2)
    {
        for (int column = 0; column < mapWidth; column++)
        {
            for (int row = 0; row < mapHeight; row++)
            {
                char tile = mapData[column, row];

                if (tile != 'A')
                {
                    int x1tile = leftMargin + column * tileWidth;
                    int y1tile = topMargin + row * tileHeight;
                    int x2tile = x1tile + tileWidth;
                    int y2tile = y1tile + tileHeight;

                    if ((x1tile < x2) &&
                        (x2tile > x1) &&
                        (y1tile < y2) &&
                        (y2tile > y1))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
