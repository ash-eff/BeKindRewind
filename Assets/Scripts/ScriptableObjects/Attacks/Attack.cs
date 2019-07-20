using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : ScriptableObject
{
    public abstract IEnumerator DoAttack(MonoBehaviour shooter);
}
