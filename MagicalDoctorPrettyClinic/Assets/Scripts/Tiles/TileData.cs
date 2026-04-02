using UnityEngine;

public class TileData
{
    public TileType Type;
    public Vector2Int GridPosition;
    public GameObject[] InRange;
    

    public TileData(TileType type, Vector2Int pos, GameObject[] InRange)
    {
        this.Type = type;
        this.GridPosition = pos;
        this.InRange = InRange;
    }
}