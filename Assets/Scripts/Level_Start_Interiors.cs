using System.Collections;
using UnityEngine;
using TMPro;

public class Level_Start_Interiors : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private TextMeshProUGUI levelIntroDisplay;
    [SerializeField] private GameObject playerOBJ;
    [SerializeField] private GameObject introDisplayOBJ;
    private int positionSelect;
    [SerializeField] private Animator Transition = null;
    [SerializeField] private string transitionEffectName;
    [SerializeField] private Transform[] playerStartPosition;
    private int level;
    private int previousLevel;

    private Rigidbody rb;
    [SerializeField] private bool PlayClipOnStart;
    private void Awake()
    {
        Application.targetFrameRate = 120;
        rb = playerOBJ.GetComponent<Rigidbody>();
        level = LevelTransition.transitionToLevelName;
        previousLevel = LevelTransition.PreviouslevelPosition;
    }

    void Start()
    {
        if (PlayClipOnStart)
        {
            AudioManager.instance.PlayMusic(clip);
        }

        switch (level)
        {
            case (int)Levels.L1:
                
                switch (previousLevel)
                {
                    case (int)Levels.L1:
                        positionSelect = 4;
                        rb.MovePosition(playerStartPosition[positionSelect].position);
                        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LevelTransitionOut);

                        break;

                    case (int)Levels.Library:
                        positionSelect = 0;
                        rb.MovePosition(playerStartPosition[positionSelect].position);
                        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LevelTransitionOut);

                        break;

                    case (int)Levels.Home1:
                        positionSelect = 1;
                        rb.MovePosition(playerStartPosition[positionSelect].position);
                        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LevelTransitionOut);

                        break;

                    case (int)Levels.Windmill:
                        positionSelect = 2;
                        rb.MovePosition(playerStartPosition[positionSelect].position);
                        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LevelTransitionOut);

                        break;

                    case (int)Levels.Dungeon:
                        positionSelect = 3;
                        rb.MovePosition(playerStartPosition[positionSelect].position);
                        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LevelTransitionOut);

                        break;
                }

                break;
            case (int)Levels.Library:
                Transition.Play(transitionEffectName, 0, 0.0f);
                AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LevelTransitionOut);
                positionSelect = 0;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                levelIntroDisplay.text = "Library";
                introDisplayOBJ.SetActive(true);
                StartCoroutine(wait0());

                IEnumerator wait0()
                {
                    yield return new WaitForSeconds(3);
                    introDisplayOBJ.SetActive(false);
                }
                break;
            case (int)Levels.Home1:
                Transition.Play(transitionEffectName, 0, 0.0f);
                positionSelect = 1;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                break;
            case (int)Levels.Windmill:
                Transition.Play(transitionEffectName, 0, 0.0f);
                positionSelect = 2;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                levelIntroDisplay.text = "WindMill";
                introDisplayOBJ.SetActive(true);
                StartCoroutine(wait2());

                IEnumerator wait2()
                {
                    yield return new WaitForSeconds(4);
                    introDisplayOBJ.SetActive(false);
                }
                break;
            case (int)Levels.Dungeon:
                Transition.Play(transitionEffectName, 0, 0.0f);
                positionSelect = 3;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                levelIntroDisplay.text = "<wiggle>Dungeon<wiggle>";
                introDisplayOBJ.SetActive(true);
                StartCoroutine(wait3());

                IEnumerator wait3()
                {
                    yield return new WaitForSeconds(4);
                    introDisplayOBJ.SetActive(false);
                }
                break;
        }
    }
}

   
