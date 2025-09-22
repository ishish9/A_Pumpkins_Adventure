using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public AudioClip audioClip;
    void TriggerEvent()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.creakOpen);
    }

    void TriggerEvent2()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.creakClose);
    }

    void TriggerEvent3Custom()
    {
        AudioManager.instance.PlaySound(audioClip);
    }


}
