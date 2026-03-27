using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public LevelDataBase LevelToLoad;
    
    public void LoadingLevel()
    {
        LoadedLevel.TimeLimitInSeconds = LevelToLoad.TimeLimitInSeconds;
        LoadedLevel.TurnCount = LevelToLoad.TurnCount;
        LoadedLevel.MovesPerTurn = LevelToLoad.MovesPerTurn;

        SceneManager.LoadScene(1);
    }

    public void ClearLevel()
    {
        LoadedLevel.TimeLimitInSeconds = 0f;
        LoadedLevel.TurnCount = 0;
        LoadedLevel.MovesPerTurn = 0;

        SceneManager.LoadScene(0);
    }
}
