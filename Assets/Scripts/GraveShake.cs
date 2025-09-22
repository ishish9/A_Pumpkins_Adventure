using UnityEngine;

public class GraveShake : MonoBehaviour
{
    [SerializeField] private Animator GraveShakeAnimation = null;
    [SerializeField] private AudioClip Shake;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySound(Shake);
            GraveShakeAnimation.Play("Grave_Shake", 0, 0.0f);
        }
    }
}
