using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class TileSwap : MonoBehaviour
{
    public static TileSwap Instance;

    private GameObject _tileToSwap;
    private GameObject _selectedTile;
    private List<GameObject> _availableTiles;


  //  private bool _matches = false;
    //private int _maxDist = 5;

    private void Awake()
    {
        Instance = this;
        _availableTiles = new List<GameObject>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_selectedTile)
        {
            Debug.Log(collision.name);
        }
        
    }
    public void CheckForSurroundingTiles()
    {
        _selectedTile = GameData.CurrentSelectedTile;



    }
}

/*  private void SelectTileToSwap() 
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

      CheckDirection();
  }


  public void CheckDirection()
  {

      Physics.Raycast(_selectedTile.transform.position, _tileToSwap.transform.position, out RaycastHit hit);
      Debug.Log(hit.normal);
      return hit.normal;
  }

  private void SwapTiles()
  {

      Vector2 newPos = new Vector2(_selectedTile.transform.position.x, _selectedTile.transform.position.y);
      Vector2 oldPos = new Vector2(_tileToSwap.transform.position.x, _tileToSwap.transform.position.y);

      if (!_matches)
      {
          Mathf.MoveTowards(oldPos, newPos, Time.deltaTime);
      }
  } */
