// LevelMenu.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] LevelButtons;

    // How transparent a locked button becomes (0 = invisible, 1 = fully visible)
    private float _lockedAlpha = 0.4f;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        SetupLevelButtons(unlockedLevel);
    }

    /// <summary>
    /// Enables unlocked level buttons and visually locks the rest.
    /// </summary>
    private void SetupLevelButtons(int unlockedLevel)
    {
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            bool isUnlocked = i < unlockedLevel;
            SetButtonState(LevelButtons[i], isUnlocked);
        }
    }

    /// <summary>
    /// Sets a button as locked or unlocked, updating its interactability,
    /// alpha transparency, and lock icon visibility.
    /// </summary>
    private void SetButtonState(Button button, bool isUnlocked)
    {
        // Enable or disable the button interaction
        button.interactable = isUnlocked;

        // Adjust the alpha on the button's Image to show it's unavailable
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            Color color = buttonImage.color;
            color.a = isUnlocked ? 1f : _lockedAlpha;
            buttonImage.color = color;
        }

        // Show or hide a lock icon child object if one exists
        Transform lockIcon = button.transform.Find("LockIcon");
        if (lockIcon != null)
        {
            lockIcon.gameObject.SetActive(!isUnlocked);
        }
    }

    /// <summary>
    /// Loads the level scene that matches the given level ID.
    /// </summary>
    public void OpenLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
}