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
    ShakeCamera shakeCamera;
    public SplineContainer spline;
    public Vector3 offset;
    public bool isShakeing;
    public bool MenuCamera;
    delegate void ChangeAngle(Transform t);
    public UnityEvent disableSpline;

    //public static event ChangeAngle changeAngle;

    private void Start()
    {
        shakeCamera = GetComponent<ShakeCamera>();
        //changeAngle += ChangeCameraAngle;
        // CameraSceneButtonStart();

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
        
    }

    public void ChangeCameraAngle(Transform tmpTarget)
    {
        //offset
    }
}
