using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    Rigidbody2D pipeRb;
    [SerializeField] float speed = 5;
    void Start()
    {
        pipeRb = GetComponent<Rigidbody2D>();
        Destroy(this, 10);
    }

    // Update is called once per frame
    void Update()
    {
        pipeRb.linearVelocityX = -speed;
    }
}
