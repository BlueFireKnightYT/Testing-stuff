using System.Collections;
using UnityEngine;

public class SmoothScaleCoroutine : MonoBehaviour
{
    Vector3 targetScale = new Vector3(2, 2, 2);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SmoothScale(targetScale));
    }

    IEnumerator SmoothScale(Vector3 targetScale)
    {
        float duration = 5;
        float elapsedTime = 0;

        Vector3 initialScale = transform.localScale;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / duration;

            transform.localScale = Vector3.Lerp(initialScale, targetScale, percent);
            yield return null;
        }
        transform.localScale = targetScale;

        targetScale = (targetScale != new Vector3(1, 1, 1)) ? targetScale = new Vector3(1, 1, 1) : targetScale = new Vector3(2, 2, 2);

        StartCoroutine(SmoothScale(targetScale));
    }
}
