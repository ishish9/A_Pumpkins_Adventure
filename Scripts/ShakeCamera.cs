using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private bool isShaking;
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            isShaking = true;
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-2f, 2f) * magnitude;
            transform.localPosition += new Vector3(originalPos.x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        isShaking = false;
        transform.localPosition = originalPos;
    }

    public bool ShakeStatus()
    {
        return isShaking;
    }
}
