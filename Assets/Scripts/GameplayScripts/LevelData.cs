using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    public float MaxTime;
    public float ComboWindow;
    public int MaxMoves;
}