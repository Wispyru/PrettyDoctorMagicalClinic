using UnityEngine;

public class TileData
{
    public TileType Type;
    public Vector2Int GridPosition;
    public bool InRange;
    public bool Selected = false;

    public TileData(TileType type, Vector2Int pos, bool InRange, bool selected)
    {
        this.Type = type;
        this.GridPosition = pos;
        this.InRange = InRange;
        this.Selected = selected;
    }
}