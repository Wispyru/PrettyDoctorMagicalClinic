using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Scripting;

public class MedicineMatch : MonoBehaviour
{
    private GridGeneration _gridGeneration;

    private void Start()
    {
        _gridGeneration = GetComponent<GridGeneration>();
    }
    
    public void CheckForMatches(GameObject current)
    {
        Debug.Log("Running check for matches");

        
        HashSet<MedicineData> matches = new HashSet<MedicineData>();
        Stack<MedicineData> checkedList = new Stack<MedicineData>();
        MedicineData currentData = current.GetComponent<MedicineData>();

        checkedList.Push(currentData);
        if (checkedList.TryPop(out var target))
        {
            Debug.Log($"reached checked list target, target is {target}");
            List<MedicineData> neighbours = GetNeighbours(target.transform);
            MedicineType targetType = target.Type;

            foreach (MedicineData neighbour in neighbours)
            {
                Debug.Log(neighbour);
                checkedList.Push(currentData);
                if (neighbour.Type == targetType)
                {
                    Debug.Log($"{neighbour} matches with {target}");
                    matches.Add(neighbour);
                    continue;
                }
            }
        }
    }



    private List<MedicineData> GetNeighbours(Transform current)
    {
        int x = (int)current.position.x;
        int y = (int)current.position.y;

        if (!IsValid(x, y)) return null;

        List<MedicineData> collectedNeighbors = new List<MedicineData>();

        Vector2Int[] directions = {
        new Vector2Int(x, y + 1), // up
        new Vector2Int(x, y - 1), // down
        new Vector2Int(x - 1, y),     // left
        new Vector2Int(x + 1, y),     // right
    };

        foreach (Vector2Int dir in directions)
        {
            if (IsValid(dir.x, dir.y))
                TryAddNeighbour(dir.x, dir.y, collectedNeighbors);
        }

        return collectedNeighbors;
    }

    private void TryAddNeighbour(int x, int y, List<MedicineData> neighbours)
    {
        MedicineData neighbour = _gridGeneration.Grid[x, y].GetComponent<MedicineData>();
        //Debug.Log($"neighbour is = {neighbour}");
        neighbours.Add(neighbour);
    }

    private void MatchDestroy(HashSet<MedicineData> matches )
    {
        foreach (MedicineData g in matches)
        {
            g.gameObject.SetActive(false);
        }
        matches.Clear();
        
    }

    private bool IsValid(int r, int c)
    {
        return r >= 0 && r < _gridGeneration.Width && c >= 0 && c < _gridGeneration.Height;
    }
}
