using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    [SerializeField] private float WindSpeed;
    public Rigidbody rb;
    [SerializeField] private GameObject leaves;

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlaySoundLooped(AudioManager.instance.audioClips.Wind);
        leaves.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        //rb.AddForce(0, 0, WindSpeed, ForceMode.Impulse);
        other.attachedRigidbody.AddForce(0, 0, WindSpeed, ForceMode.Impulse);

    }

    private void OnTriggerExit(Collider other)
    {
        AudioManager.instance.PlaySoundLoopedStop();
        leaves.SetActive(false);
    }
}
