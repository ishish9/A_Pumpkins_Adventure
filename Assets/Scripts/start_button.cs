using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class start_button : MonoBehaviour
{
    [SerializeField] private Animator Fade = null;
    [SerializeField] private Animator StartButton = null;

    public void LoadScene()
    {
        Fade.Play("FadeMainMenu", 0, 0.0f);
        StartButton.Play("startButton", 0, 0.0f);
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.StartButtonClick);

        StartCoroutine(wait());

        IEnumerator wait()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("L1");
        }
    }
}
