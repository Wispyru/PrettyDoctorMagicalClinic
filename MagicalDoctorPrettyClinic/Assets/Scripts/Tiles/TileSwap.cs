using UnityEngine;

public class TileSwap : MonoBehaviour
{
    public static TileSwap Instance;

    private bool _matches = false;
    private string _tagToCompare = "tile";

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != _tagToCompare) return;

        CheckTileType(other.gameObject);
    }


    public void CheckTileType(GameObject otherTile)
    {
        TileType currentTileCheck = GameData.CurrentSelectedTile.GetComponent<TileData>().type;
        TileType otherTileCheck = otherTile.GetComponent<TileData>().type;
        if (currentTileCheck != otherTileCheck) _matches = false;

        _matches = true;

    }

}
