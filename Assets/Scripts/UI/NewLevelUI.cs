using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelUI : MonoBehaviour
{
    public void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1); // adds one playable level
            PlayerPrefs.Save(); // save setting
        }
    }
}
