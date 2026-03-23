using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private float _tileSpacing = 1f;

    /// <summary>
    /// Generates the full grid at level start and passes it to the GridManager.
    /// </summary>
    public void GenerateGrid(int width, int height)
    {
        Tile[,] grid = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = SpawnTile(x, y, width, height);
            }
        }

        _gridManager.SetGrid(grid, width, height);
    }

    /// <summary>
    /// Spawns a single tile at the given grid position with a guaranteed non-matching type.
    /// </summary>
    private Tile SpawnTile(int x, int y, int width, int height)
    {
        Vector2 spawnPosition = GetWorldPosition(x, y);
        GameObject tileObject = Instantiate(_tilePrefab, spawnPosition, Quaternion.identity);
        Tile tile = tileObject.GetComponent<Tile>();

        TileType tileType = GetNonMatchingType(x, y, width, height);
        tile.Initialize(x, y, tileType);

        return tile;
    }

    /// <summary>
    /// Returns a tile type that won't cause an immediate match at the given position.
    /// </summary>
    private TileType GetNonMatchingType(int x, int y, int width, int height)
    {
        // Placeholder — full no-match logic comes with [18]
        return (TileType)Random.Range(0, System.Enum.GetValues(typeof(TileType)).Length);
    }

    /// <summary>
    /// Converts a grid coordinate to a world position.
    /// </summary>
    private Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(x * _tileSpacing, y * _tileSpacing);
    }
}