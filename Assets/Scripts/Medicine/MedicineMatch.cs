using System;
using System.Collections.Generic;
using UnityEngine;

public class MedicineMatch : MonoBehaviour
{
    private GridGeneration _gridGeneration;
    
    private List<GameObject> matchedColumnTiles;
    private List<GameObject> matchedRowTiles;

    private void Start()
    {
        _gridGeneration = GetComponent<GridGeneration>();
        matchedColumnTiles = new List<GameObject>();
        matchedRowTiles = new List<GameObject>();  
        
    }

    public bool CheckMatches()
    {
        HashSet<GameObject> matches = new HashSet<GameObject>();
        for (int row = 0; row < _gridGeneration.Width; row++)
        {
            for (int column = 0; column < _gridGeneration.Height; column++)
            {
                GameObject current = _gridGeneration.GetMedicineAt(column, row);
                List<GameObject> horizontalMatches = FindColumnMatches(column, row, current);
                if (horizontalMatches.Count >= 2) 
                { 
                    matches.UnionWith(horizontalMatches);
                    matches.Add(current);
                }

                List<GameObject> verticalMatches = FindRowMatches(column, row, current);
                if(verticalMatches.Count >= 2)
                {
                    matches.UnionWith(verticalMatches);
                    matches.Add(current);
                }
            }
        }

        foreach (GameObject current in matchedColumnTiles) 
        {
            Destroy(current);
        }
        return matches.Count > 0;

    }

    private List<GameObject> FindColumnMatches(int column, int row, GameObject currentTile)
    {
        for (int i = column + 1; i < _gridGeneration.Height; i++)
        {
            GameObject nextColumn = _gridGeneration.GetMedicineAt(i, row);
            if (nextColumn.GetComponent<MedicineData>().Type != currentTile.GetComponent<MedicineData>().Type)
            {
                Debug.Log($"{nextColumn} doesn't match with {currentTile}");
                break;
            }

            Debug.Log($"{nextColumn} matches with {currentTile}");
            matchedColumnTiles.Add(nextColumn);
            
        }
        return matchedColumnTiles;
    }

    private List<GameObject> FindRowMatches(int column, int row, GameObject currentTile)
    {
        for (int i = row + 1; i < _gridGeneration.Width; i++)
        {
            GameObject nextRow = _gridGeneration.GetMedicineAt(column, i);
            if (nextRow.GetComponent<MedicineData>().Type != currentTile.GetComponent<MedicineData>().Type)
            {
                break;
            }
            matchedRowTiles.Add(nextRow);
        }
        return matchedRowTiles;
    }
}
