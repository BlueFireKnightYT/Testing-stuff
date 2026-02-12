using System.Collections;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject[] pipes;
    int randomPipe;
    void Start()
    {
        StartCoroutine(spawnPipes());
    }
    IEnumerator spawnPipes()
    {
        while (true)
        { 
        yield return new WaitForSeconds(3);
        randomPipe = Random.Range(0, pipes.Length);
        Instantiate(pipes[randomPipe], new Vector2(15f, 0), Quaternion.identity);
        }
    }
}
