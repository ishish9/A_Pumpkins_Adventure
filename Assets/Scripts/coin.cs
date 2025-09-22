using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private AudioClips audioClip;
    public delegate void coinE(int c);
    public static event coinE OnCollectCoin;

    void Update()
    {
        transform.Rotate(0f , 0f, 400f * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlaySound(audioClip.CollectCoin);
            OnCollectCoin(1);
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "Player_Pumpkin")
        {
            AudioManager.instance.PlaySound(audioClip.CollectCoin);
            OnCollectCoin(1);
            this.gameObject.SetActive(false);
        }
    }
}
