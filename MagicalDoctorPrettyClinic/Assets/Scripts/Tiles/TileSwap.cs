using Unity.VisualScripting;
using UnityEngine;

public class TileSwap : MonoBehaviour
{
    public static TileSwap Instance;

    private GameObject _tileToSwap;
    private GameObject _selectedTile;

    private bool _matches = false;
    private int _movementSpeed = 5;
    private Grid _grid;

    private void Awake()
    {
        Instance = this;
        _selectedTile = GameData.CurrentSelectedTile;
        _grid = _selectedTile.GetComponent<GridGenerator>().Grid;
    }

    private void OnMouseDown()
    {
        if(GameData.CurrentSelectedTile != null)
        {
            SelectTileToSwap();
        }
    }

    private void SelectTileToSwap() 
    {
        _tileToSwap = gameObject;

        CheckTileType(_tileToSwap);
    }


    public void CheckTileType(GameObject otherTile)
    {
        TileType tileSwappedType = otherTile.GetComponent<GridGenerator>().TileDataScript.Type;
        TileType selectedTileType = GameData.CurrentSelectedTile.GetComponent<GridGenerator>().TileDataScript.Type;

        if (tileSwappedType != selectedTileType) _matches = false;

        _matches = true;
    }

    public void CheckDirection()
    {

    }

    private void SwapTiles()
    {
        
        Vector2 newPos = new Vector2(_selectedTile.transform.position.x, _selectedTile.transform.position.y);
        Vector2 oldPos = new Vector2(_tileToSwap.transform.position.x, _tileToSwap.transform.position.y);

        if (!_matches)
        {
            Mathf.MoveTowards(oldPos, newPos, Time.deltaTime);
        }
    }
}
