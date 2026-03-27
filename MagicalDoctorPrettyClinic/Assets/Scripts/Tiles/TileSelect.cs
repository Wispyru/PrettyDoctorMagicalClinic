using UnityEngine;
using UnityEngine.UI;


public class TileSelect : MonoBehaviour
{
    [SerializeField] Color orignialColor;
    [SerializeField] Image img;


    private void Start()
    {
        img = GetComponent<Image>();
        orignialColor = img.color;
    }

    private void OnMouseDrag()
    {
        if (!CompareTag("tile") && GameData.CurrentSelectedTile != null) return;

        SelectTile();
    }

    private void OnMouseUp()
    {
        GameData.CurrentSelectedTile = null;
    }

    public void SelectTile()
    {
        GameData.CurrentSelectedTile = gameObject;
        Debug.Log("Successful!");
    }

}
