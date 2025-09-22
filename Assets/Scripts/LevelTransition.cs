using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTransition : MonoBehaviour
{
    public Levels PreviousLevel;
    public Levels TransitionToLevel;

    [SerializeField] private Animator Transition = null;
    [SerializeField] private string transitionEffectName;
    public static int PreviouslevelPosition;
    public static int transitionToLevelName;

    [SerializeField] private string scene;
    [SerializeField] private float transitionTime;
    //public static LevelTransition instance;
    private bool triggerEnabled = true;

    private void Awake()
    {
       // instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && triggerEnabled == true)
        {
            
            triggerEnabled = false;
            PreviouslevelPosition = (int)PreviousLevel;
            transitionToLevelName = (int)TransitionToLevel;
            LevelLoad();
            Debug.Log(transitionToLevelName);
        }        
    }

    private void LevelLoad()
    {
        Transition.Play(transitionEffectName, 0, 0.0f);
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LevelTransitionIn);

        StartCoroutine(wait());

        IEnumerator wait()
        {
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(scene);
            gameObject.SetActive(false);
        }
    }
}

