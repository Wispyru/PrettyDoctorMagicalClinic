using UnityEngine;

public class TileData
{
    public TileType Type;
    public Vector2Int GridPosition;
    public bool Selected;

    public TileData(TileType type, Vector2Int pos, bool selected)
    {
        this.Type = type;
        this.GridPosition = pos;
        this.Selected = selected;
    }
}