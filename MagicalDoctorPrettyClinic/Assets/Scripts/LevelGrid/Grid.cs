using UnityEngine;

public class Grid
{
    private int _width;
    private int _height;
    private float _cellSize;
    private TileData[,] _gridArray;

    public Grid(int width, int height, float cellSize)
    {
        this._width = width;
        this._height = height;
        this._cellSize = cellSize;
        _gridArray = new TileData[width, height];
    }

    public void SetTile(int x, int y, TileData tile)
    {
        if (IsValid(x, y)) _gridArray[x, y] = tile;
    }

    public TileData GetTile(int x, int y)
    {
        return IsValid(x, y) ? _gridArray[x, y] : null;
    }

    private bool IsValid(int x, int y)
    {
        return x >= 0 && y >= 0 && x < _width && y < _height;
    }
}