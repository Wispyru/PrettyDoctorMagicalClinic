using System.Collections;
using UnityEngine;

public class GridTileSwapping : MonoBehaviour
{
    [SerializeField]
    private GameObject _gridObject;

    private GridGeneration _gridGeneration;
    private void Start()
    {
        _gridGeneration = FindAnyObjectByType<GridGeneration>();
    }

    public void SwapTiles(Vector2Int tile1Position, Vector2Int tile2Position)
    {
        GameObject tile1 = _gridGeneration.Grid[tile1Position.x, tile1Position.y];
        GameObject tile2 = _gridGeneration.Grid[tile2Position.x, tile2Position.y];

        // Swap world positions
        Vector2 tile1WorldPos = tile1.transform.position;
        tile1.transform.position = tile2.transform.position;
        tile2.transform.position = tile1WorldPos;

        // Swap in grid array
        _gridGeneration.Grid[tile1Position.x, tile1Position.y] = tile2;
        _gridGeneration.Grid[tile2Position.x, tile2Position.y] = tile1;

        // Update the Position field on each tile's MedicineSelect component
        tile1.GetComponent<MedicineSelect>().Position = tile2Position;
        tile2.GetComponent<MedicineSelect>().Position = tile1Position;

        _gridGeneration.Matching.CheckForMatches(tile1);
        _gridGeneration.Matching.CheckForMatches(tile2);
    }
    private IEnumerator delaySwitch(GameObject tile1, GameObject tile2)
    {
        Vector2 newPos = new Vector2(tile1.transform.position.x, tile1.transform.position.y);
        tile1.transform.position = tile2.transform.position;
        tile2.transform.position = newPos;

        yield return new WaitForSeconds(1f);
    }
}
