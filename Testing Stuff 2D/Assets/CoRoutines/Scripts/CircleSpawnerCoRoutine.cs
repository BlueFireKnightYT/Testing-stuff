using System.Collections;
using UnityEngine;

public class CircleSpawnerCoRoutine : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    int waveAmt = 5;
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        for (int i = 0; i < waveAmt; i++)
        { 
            yield return new WaitForSeconds(1);
            Instantiate(enemy, new Vector2(-5, -5), Quaternion.identity);
        }
        yield return new WaitForSeconds(2);
        Debug.Log("WaveComplete");

        yield return new WaitForSeconds(5);
        waveAmt++;
        Debug.Log("WaveStart");
        StartCoroutine(spawnEnemy());
        
    }
}
