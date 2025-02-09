using System;
using System.ComponentModel;

public abstract class Block
{
    public int[,] Shape { get; protected set; };

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
        }
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
        }
    }
}

public class IBlock : Block
{
    public IBlock()
    {
        Shape = new int[,]
        {
            {1, 1, 1, 1,}
        }
    }
}