using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack/Spiral")]
public class SpiralAttack : Attack
{
    public GameObject bullet;
    public int numOfBullets;
    public bool spinRight;
    public bool random;

    public override IEnumerator DoAttack(MonoBehaviour shooter)
    {
        float direction = 0;
        int b = 0;
        float rotAmount = 360;
        if (!spinRight)
        {
            rotAmount = -rotAmount;
        }

        while (b < numOfBullets)
        {
            
            if (random)
            {
                direction = shooter.transform.eulerAngles.z + rotAmount * Mathf.Sin(Time.time / (numOfBullets * .001f));
            }
            else
            {
                direction = shooter.transform.eulerAngles.z + rotAmount * Mathf.Cos(Time.time);
            }

            Quaternion rot = Quaternion.Euler(0f, 0f, direction);
            Instantiate(bullet, shooter.transform.position, rot);
            b++;

            yield return new WaitForSeconds(numOfBullets * .001f);
        }
    }
}