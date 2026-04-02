using UnityEngine;

public class TileData
{
    public TileType Type;
    public Vector2Int GridPosition;

    public TileData(TileType type, Vector2Int pos)
    {
        this.Type = type;
        this.GridPosition = pos;
    }
}