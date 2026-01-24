using System.Collections;
using UnityEngine;

public class GuardBehavior : MonoBehaviour
{
    SpriteRenderer sr;

    GameObject player;
    float distance;

    bool isCoroutineRunning = false;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("player");
        
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 3 && !isCoroutineRunning) StartCoroutine(GuardMove());

    }

    IEnumerator GuardMove()
    {
        isCoroutineRunning = true;
        sr.color = Color.yellow;
        yield return new WaitForSeconds(1.5f);

        sr.color = Color.red;

        while (distance <= 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1 * Time.deltaTime);
            yield return null;
        }

        sr.color = Color.lightBlue;
        isCoroutineRunning = false;
            
    }
}
