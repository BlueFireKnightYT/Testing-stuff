using UnityEngine;

public class bullet : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float bulletSpeed = 60f;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        sr.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    private void FixedUpdate()
    {
         rb.linearVelocity = new Vector2(bulletSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<SpriteRenderer>().color = sr.color;
        Destroy(this.gameObject);
    }
}
