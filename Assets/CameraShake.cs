using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalTransform;
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.7f;
    private float dampingShake = 1.0f;
    private void Awake()
    {

        shakeDuration = 0f;
        Debug.Log("CameraShake Awake");
    }
    private void Update()
    {
        originalTransform = transform.position;
        if (shakeDuration > 0)
        {
            transform.localPosition = originalTransform + Random.insideUnitSphere * shakeMagnitude;
            Debug.Log("Shaking...");
            shakeDuration -= Time.deltaTime * dampingShake;
        }
        else
        {
            shakeDuration = 0f;
            transform.position = originalTransform;
        }
    }
    public void startShake(float duration)
    {
        Debug.Log($"StartShake for {duration} seconds");
        shakeDuration = duration;
    }
}
