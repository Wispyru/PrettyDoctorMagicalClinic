using System;
using System.Collections.Generic;
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
        Debug.Log("reached.");
        //var matchCount = 0;


        HashSet<MedicineData> matches = new HashSet<MedicineData>();
        Stack<MedicineData> checkedList = new Stack<MedicineData>();

        checkedList.Push(current.GetComponent<MedicineData>());

        while(checkedList.TryPop(out var target))
        {
            Debug.Log(target.ToString());
            List<MedicineData> neighbours = GetNeighbours(target.transform);

            foreach (MedicineData x in neighbours)
            {
                Debug.Log($"Current tile = {x.ToString()}");
                if (!checkedList.TryPop(out target)) continue;

                if (x.Type != target.GetComponent<MedicineData>().Type) return;
                matches.Add(x);
                checkedList.Push(x);
            }
        }
    }

    private List<MedicineData> GetNeighbours(Transform current)
    {
        List<MedicineData> collectedNeighbors = new List<MedicineData>();
        if (!IsValid((int)current.position.x, (int)current.position.y)) return null;

        if (IsValid((int)current.position.x, (int)current.position.y + 1))
        {
            MedicineData up = _gridGeneration.Grid[(int)current.position.x, (int)current.position.y + 1].GetComponent<MedicineData>();
            Debug.Log($"top tile = {up}");
            collectedNeighbors.Add(up);
        }

        if (IsValid((int)current.position.x, (int)current.position.y - 1))
        {
            MedicineData down = _gridGeneration.Grid[(int)current.transform.position.x, (int)current.transform.position.y - 1].GetComponent<MedicineData>();
            Debug.Log($"bottom tile = {down}");
            collectedNeighbors.Add(down);
        }

        if (IsValid((int)current.position.x - 1, (int)current.position.y))
        {
            MedicineData left = _gridGeneration.Grid[(int)current.transform.position.x - 1, (int)current.transform.position.y].GetComponent<MedicineData>();
            Debug.Log($"left tile = {left}");
            collectedNeighbors.Add(left);
        }

        if (IsValid((int)current.position.x + 1, (int)current.position.y))
        {
            MedicineData right = _gridGeneration.Grid[(int)current.transform.position.x + 1, (int)current.transform.position.y].GetComponent<MedicineData>();
            Debug.Log($"right tile = {right}");
            collectedNeighbors.Add(right);
        }

        return collectedNeighbors;
    }

    private bool IsValid(int r, int c)
    {
        return r >= 0 && r < _gridGeneration.Width && c >= 0 && c < _gridGeneration.Height;
    }
}
