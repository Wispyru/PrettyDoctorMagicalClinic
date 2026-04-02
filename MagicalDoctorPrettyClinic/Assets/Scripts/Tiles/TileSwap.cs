using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

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

    private void Update()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position, -transform.right * Mathf.Infinity, Color.white);
        int layerToCheck = 3;
        if (Physics.Raycast(transform.position, -transform.right, out hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * Mathf.Infinity, Color.red);
            Debug.Log(hit.distance);
        }
        else
        {
            Debug.Log("SHIT AINT WORKIE");


        }
    }

    private void OnMouseDown()
    {
        if(GameData.CurrentSelectedTile != null)
        {
            CheckForSurroundingTiles();
        }
    }

    private void CheckForSurroundingTiles()
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
