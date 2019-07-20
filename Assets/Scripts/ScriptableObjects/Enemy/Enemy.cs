using UnityEngine;

public abstract class Enemy : ScriptableObject
{
    public Sprite[] sprite;
    public string enemyName;
    public float health;

    public abstract void TakeDamage(float amount);
}
