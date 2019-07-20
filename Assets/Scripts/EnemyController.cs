using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    public Attack[] attacks;

    private SpriteRenderer spr;
    private VCR vcr;

    private void Start()
    {
        vcr = GetComponent<VCR>();
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = enemy.sprite[Random.Range(0, enemy.sprite.Length)];
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        int randAttack = Random.Range(0, attacks.Length);
        Attack attack = attacks[randAttack];
        StartCoroutine(attack.DoAttack(this));
        StartCoroutine(Wait(5f));
        yield return null;
    }

    IEnumerator Wait(float _time)
    {
        yield return new WaitForSeconds(_time);
        StartCoroutine(Attack());
    }
}
