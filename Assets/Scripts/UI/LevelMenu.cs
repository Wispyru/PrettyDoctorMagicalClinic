using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] levelButtons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // value to 1 so the first level is unlocked
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].enabled = false; // disables all the levels buttons
        }
        for (int i = 0; i < unlockedLevel; i++) // re-enables all the level buttons
        {
            levelButtons[i].enabled = true;
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelId);
    }
}
