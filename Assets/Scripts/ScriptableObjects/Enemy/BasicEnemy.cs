using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/BasicEnemy")]
public class BasicEnemy : Enemy
{
    public override void TakeDamage(float amount)
    {
        Debug.Log(enemyName + " take " + amount + " damage.");
    }
}
