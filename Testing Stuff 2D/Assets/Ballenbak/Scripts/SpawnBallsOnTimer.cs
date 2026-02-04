using System.Collections;
using UnityEngine;

public class SpawnBallsOnTimer : MonoBehaviour
{
    public GameObject ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBall());
    }

    IEnumerator SpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameObject lastBall = Instantiate(ball, new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z), Quaternion.identity);
            SpriteRenderer lBSR = lastBall.GetComponent<SpriteRenderer>();
            lBSR.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Rigidbody2D rb = lastBall.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode2D.Impulse);
        }
    }
}
