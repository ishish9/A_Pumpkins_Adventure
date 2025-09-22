using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Trigger : MonoBehaviour
{
    [SerializeField] private Transform respawnLocation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool LavaFall;

    private void OnTriggerEnter(Collider other)
    {
        if (LavaFall)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LavaFall);
        }
        else
        {
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.Fall);
        }
        MeshRenderer  m = other.GetComponent<MeshRenderer>();
        rb.isKinematic = true;
        m.enabled = false;
        StartCoroutine(wait());

        IEnumerator wait()
        {
            yield return new WaitForSeconds(3);
            rb.isKinematic = false;
            m.enabled = true;
            rb.Move(respawnLocation.position, Quaternion.identity);

        }
    }
}
