using UnityEngine;

public class MoveTo_00 : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        Destroy(this.gameObject, 5);
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, -2), 1 * Time.deltaTime);
    }
}
