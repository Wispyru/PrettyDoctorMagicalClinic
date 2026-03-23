using UnityEngine;

[System.Serializable]
public class Illness :MonoBehaviour
{
    public string Name;
    public string Description;

    public int BaseDamage;
    public int Health;

    public void Attack(int calculatedDamage)
    {
        Debug.Log("Attack! RAAAAAAAAAAAAAH");
    }
}
