using System.Collections;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    SpriteRenderer squareSr;
    Color randColor = Color.red;

    void Start()
    {
        squareSr = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            randColor = Random.ColorHSV();
            squareSr.color = randColor;
        }
    }
}
