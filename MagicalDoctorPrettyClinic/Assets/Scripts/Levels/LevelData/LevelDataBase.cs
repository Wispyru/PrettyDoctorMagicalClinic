using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Levels/LevelData")]

public class LevelDataBase : ScriptableObject
{
    // Level Base data:
    /*public [IllnessScript (will be renamed)] IllnessToBeat*/

    // Level completion requirements:

    public float TimeLimitInSeconds;
    public int TurnCount;
    public int MovesPerTurn;
    
}
