using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack/Shotgun")]
public class ShotgunAttack : Attack
{
    public GameObject bullet;
    public int numOfBullets;
    public float angle;

    public override IEnumerator DoAttack(MonoBehaviour shooter)
    {
        float bulletDirection = angle / (float)numOfBullets;
        float adjustedAngle = angle / 2;
        float direction = 0;
        for (int i = 0; i < numOfBullets + 1; i++)
        {
            direction = shooter.transform.eulerAngles.z + ((bulletDirection * i) - adjustedAngle);
            Quaternion rot = Quaternion.Euler(0f, 0f, direction);
            Instantiate(bullet, shooter.transform.position, rot);
        }

        yield return null;
    }
}
