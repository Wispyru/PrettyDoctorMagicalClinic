using UnityEngine;

public class IllnessHealthSystem : MonoBehaviour
{
    private CombatSystem _combatSystem;

    private void DecreaseHealth()
    {
        _combatSystem.CalculateDamage();
        Debug.Log(_combatSystem.PlayerDamage);
        /**/
    }

}
