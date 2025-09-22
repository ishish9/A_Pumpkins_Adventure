using UnityEngine;

public class Trigger_Audio : MonoBehaviour
{
    [SerializeField] private AudioClip PlayAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlayMusic(PlayAudio);
            this.gameObject.SetActive(false);
        }   
    }
}
