using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public float speed;

    private VCR vcr;
    private Rigidbody2D rb2d;
    private float lifeTime;
    private float rewindTime;

    private void Start()
    {
        vcr = GetComponent<VCR>();
        rb2d = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if (!vcr.isRewinding)
        {
            lifeTime += Time.deltaTime;
            rewindTime = 0;
        }
        else
        {
            rewindTime += Time.deltaTime;
            if (rewindTime > lifeTime)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!vcr.isRewinding)
        {
          Vector3 movePos = transform.position + transform.right * speed * Time.deltaTime;
          rb2d.MovePosition(movePos);
        }
    }
}
