using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Events;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float lookSpeed;
    public SplineContainer spline;
    public Vector3 offset;
    public bool isShakeing;
    public bool MenuCamera;
    delegate void ChangeAngle(Transform t);
    public UnityEvent disableSpline;

    public static cameraFollow instance;
    private Vector3 initialPosition;
    [SerializeField] private float shakeDuration = 0.5f;
    [SerializeField] private float shakeMagnitude = 0.1f;
    [SerializeField] private float dampingSpeed = 1.0f;
    private float currentShakeDuration;
    private float currentShakeMagnitude;
    private bool isShaking = false;

    //public static event ChangeAngle changeAngle;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        initialPosition = transform.localPosition;      
    }
    void Update()
    {    
       // transform.position = target.position + offset;
        Vector3 desiredp = target.position + offset;
        Vector3 smoothedp = Vector3.Lerp(transform.position, desiredp, smoothSpeed * Time.deltaTime);
        transform.position = smoothedp;
        if (MenuCamera)
        {
            float dist = Vector3.Distance(transform.position, target.position);
            Quaternion lookDirection = Quaternion.LookRotation(target.position - transform.position);
            lookDirection = Quaternion.Euler(0, lookDirection.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, lookSpeed * Time.deltaTime);
        }

        if (isShaking)
        {
            if (currentShakeDuration > 0)
            {
                // Apply random offset to camera position
                transform.localPosition = initialPosition + Random.insideUnitSphere * currentShakeMagnitude;

                // Reduce duration and magnitude over time
                currentShakeDuration -= Time.deltaTime * dampingSpeed;
                currentShakeMagnitude = Mathf.Lerp(currentShakeMagnitude, 0, Time.deltaTime * dampingSpeed);
            }
            else
            {
                // Reset when shake is complete
                isShaking = false;
                transform.localPosition = initialPosition;
            }
        }

    }

    public void ChangeCameraAngle(Transform tmpTarget)
    {
        //offset
    }

    public void TriggerShake()
    {
        TriggerShake(shakeDuration, shakeMagnitude);
    }

    public void TriggerShake(float duration, float magnitude)
    {
        if (!isShaking)
        {
            initialPosition = transform.localPosition;
        }

        isShaking = true;
        currentShakeDuration = duration;
        currentShakeMagnitude = magnitude;
    }
}
