using System;
using System.ComponentModel;
using System.Windows.Media;

public abstract class Block
{
    public int[,] Shape { get; protected set; }
    public Color color { get; protected set; }

    public int Size => Shape.GetLength(0);

    public Block()
    {
        Shape = new int[4, 4];
    }

    public void Rotate()
    {
        int[,] rotated = new int[Size, Size];
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                rotated[col, Size - row - 1] = Shape[row, col];
            }
        }
        Shape = rotated;
    }

    public void SetColor()
    {
        Random random = new Random();

        switch (random.Next(6))
        {
            case 0:
                color = Colors.Blue;
                break;
            case 1:
                color = Colors.Green;
                break;
            case 2:
                color = Colors.Red;
                break;
            case 3:
                color = Colors.Magenta;
                break;
            case 4:
                color = Colors.Yellow;
                break;
            case 5:
                color = Colors.Orange;
                break;
        }
    }
}

// Blocks

public class TBlock : Block
{
    public TBlock()
    {
        Shape = new int[,]
        {
            {0, 1, 0 },
            {0, 1, 0 },
            {0, 0, 0 }
        };
        SetColor();
    }
}


public class LBlock : Block
{
    public LBlock()
    {
        Shape = new int[,]
        {
            {0, 0, 1 },
            {1, 1, 1 },
            {0, 0, 0 }
        };
        SetColor();
    }
}


public class IBlock : Block
{
    public IBlock()
    {
        Shape = new int[,]
        {
            {1, 1, 1, 1,}
        };
        SetColor();
    }
}
