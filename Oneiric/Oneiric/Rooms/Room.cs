using System.IO;

class Room
{
    const int TOTAL_IMAGES = 10;
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

    public Room()
    {
        images[0] = new Image("data/images/map/floor1.jpg");
        images[1] = new Image("data/images/map/wall1Down.jpg");
        images[2] = new Image("data/images/map/table.png");
        images[3] = new Image("data/images/map/computerOff.png");
        levelData = File.ReadAllLines("data/maps/level.map");
        mapData = new char[mapWidth, mapHeight];
        UpdateScreenMap(ActualCol, ActualRow);
    }

    public int GetTopMargin() { return topMargin; }

    public void UpdateScreenMap(int col, int row)
    {
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
                    case 'C':

                        SdlHardware.DrawHiddenImage(images[0], posX,
                        posY);
                        SdlHardware.DrawHiddenImage(images[2], posX,
                        posY);
                        SdlHardware.DrawHiddenImage(images[3], posX,
                        posY); break;
                }
            }
        }
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
