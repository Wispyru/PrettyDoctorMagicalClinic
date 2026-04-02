using UnityEngine;
using UnityEngine.UI;


public class TileSelect : MonoBehaviour
{
    private TileData _tileData;

    private void Start()
    {
        _tileData = GetComponentInParent<GridGenerator>().TileDataScript;
    }

    private void OnMouseDown()
    {
        if(GameData.CurrentSelectedTile == null)
        {
            SelectTile();
            Debug.Log(GameData.CurrentSelectedTile);
            return;
        }
        if (GameData.CurrentSelectedTile == gameObject)
        {
            DeselectTile();
            Debug.Log(GameData.CurrentSelectedTile);
            return;
        }
    }

    public void SelectTile()
    {
        GameData.CurrentSelectedTile = gameObject;
        GetComponentInParent<TileSwap>().CheckForSurroundingTiles((int)GameData.CurrentSelectedTile.transform.position.x, (int)GameData.CurrentSelectedTile.transform.position.y);
    }

    public void DeselectTile()
    {
        GameData.CurrentSelectedTile = null;
    }
}
