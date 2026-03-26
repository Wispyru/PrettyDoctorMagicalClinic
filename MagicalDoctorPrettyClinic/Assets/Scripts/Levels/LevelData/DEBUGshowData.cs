using UnityEngine;

public class DEBUGshowData : MonoBehaviour
{
    public void ShowLevelData()
    {
        Debug.Log("Moves per turn: " + LoadedLevel.MovesPerTurn.ToString() + 
            " Turns: " + LoadedLevel.TurnCount.ToString() + " Time limit: " + LoadedLevel.TimeLimitInSeconds.ToString());
    }
}
