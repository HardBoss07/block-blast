﻿using System;
using System.ComponentModel;
using System.Reflection;
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

    public void rotate()
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

    public void setColor()
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

    public static int getNumberOfBlockTypes()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Count(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Block)));
    }

    public static Block getRandomBlock()
    {
        Block block = null;
        Random random = new Random();
        switch (random.Next(getNumberOfBlockTypes()))
        {
            case 0:
                block = new TBlock();
                break;
            case 1:
                block = new LBlock();
                break;
            case 2:
                block = new IBlock();
                break;
        }

        return block;
    }

    public override string ToString()
    {
        string blockType = GetType().Name;
        string colorName = color.ToString();
        string shapeRepresentation = "";

        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                shapeRepresentation += Shape[row, col] == 1 ? "■ " : "  ";
            }
            shapeRepresentation += "\n";
        }

        return $"Block Type: {blockType}\nColor: {colorName}\nShape:\n{shapeRepresentation}";
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
            {1, 1, 1 },
            {0, 0, 0 }
        };
        setColor();
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
        setColor();
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
        setColor();
    }
}
