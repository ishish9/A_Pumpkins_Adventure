using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate : MonoBehaviour {

    private float speedd = 200f;
    [SerializeField] private bool CustomRotation = false;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;


    void Update()
    {
        if (CustomRotation)
        {
            transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Rotate(0f, speedd * Time.deltaTime, 0f, Space.Self);
        }
    }
}