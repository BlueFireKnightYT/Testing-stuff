using UnityEngine;

public class bullet : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float bulletSpeed = 60f;
    public float baseBulletSpeed = 60f;

    GameObject player;
    Movement moveScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        if (player != null)
            moveScript = player.GetComponent<Movement>();

        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        sr.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        float direction = (moveScript != null && moveScript.flipped) ? -1f : 1f;
        bulletSpeed = baseBulletSpeed * direction;

        rb.linearVelocity = new Vector2(bulletSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherSr = other.GetComponent<SpriteRenderer>();
        if (otherSr != null)
            otherSr.color = sr.color;

        Destroy(this.gameObject);
    }
}
