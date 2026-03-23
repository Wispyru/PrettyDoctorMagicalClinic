using UnityEngine;

public class Tile : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public TileType Type { get; private set; }

    /// <summary>
    /// Initializes the tile with its grid position and type.
    /// </summary>
    public void Initialize(int x, int y, TileType type)
    {
        X = x;
        Y = y;
        Type = type;

        UpdateVisual();
    }

    /// <summary>
    /// Updates the visual state of the tile to match its type.
    /// Placeholder until art assets are connected.
    /// </summary>
    private void UpdateVisual()
    {
        // Placeholder — hook up sprite/icon here later
    }
}