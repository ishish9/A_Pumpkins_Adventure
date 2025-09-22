using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class ManageMovementSound : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;
    private Rigidbody rb;
    private AudioSource audioSource;
    public float minPitch;
    public float maxPitch;
    private float pitchPumpkin;
    private controller controllerScript;
    [SerializeField] private bool Generic;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        if (!Generic)
        {
            controllerScript = GetComponent<controller>();
        }
    }

    private void Update()
    {
        if (!Generic)
        {
            PumpkinRollSound();

        }
        else
        {
            GenericSound();
        }
    }

    private void PumpkinRollSound()
    {
        currentSpeed = rb.linearVelocity.magnitude;
        pitchPumpkin = rb.linearVelocity.magnitude / 50f;
        if (controllerScript.GetGroundedstatus() == true)
        {
            if (currentSpeed < minSpeed)
            {
                audioSource.pitch = minPitch;
            }

            if (currentSpeed >minSpeed && currentSpeed < maxSpeed)
            {
                audioSource.pitch = minPitch + pitchPumpkin;
            }

            if (currentSpeed >maxSpeed)
            {
                audioSource.pitch = maxPitch;
            }
        }    
    }

    public void GenericSound()
    {     
            if (currentSpeed < minSpeed)
            {
                audioSource.pitch = minPitch;
            }

            if (currentSpeed >minSpeed && currentSpeed < maxSpeed)
            {
                audioSource.pitch = minPitch + pitchPumpkin;
            }

            if (currentSpeed >maxSpeed)
            {
                audioSource.pitch = maxPitch;
            }      
    }
}
