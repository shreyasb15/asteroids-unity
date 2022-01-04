using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public Sprite[] sprites;

    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    public float speed = 50f;
    public float maxLifeTime = 30f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);
        this.transform.localScale = Vector3.one * this.size;

        rb.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        rb.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if((this.size / 2) >= this.minSize)
            {
                SplitAsteroid();
                SplitAsteroid();
            }

            Destroy(this.gameObject);
        }
    }

    private void SplitAsteroid()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroids halfAsteroid = Instantiate(this, position, this.transform.rotation);
        halfAsteroid.size = this.size / 2;
        halfAsteroid.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }
}
