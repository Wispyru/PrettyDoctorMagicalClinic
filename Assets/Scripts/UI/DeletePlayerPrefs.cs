using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
