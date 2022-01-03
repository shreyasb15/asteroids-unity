using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeeed = 500f;
    public float maxLifeTime = 10f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rb.AddForce(direction * this.bulletSpeeed);

        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
