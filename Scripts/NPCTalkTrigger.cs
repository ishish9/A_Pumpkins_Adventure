using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using System.Threading.Tasks;
using UnityEngine.UI;

public class NPCTalkTrigger : MonoBehaviour
{
    PlayerInputActions playerActionMap;
    [SerializeField] private List<String> speeches = new List<String>();
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private NpcSpeech npcSpeech;
    [SerializeField] private TextMeshProUGUI npcSpeechUI;
    [SerializeField] private GameObject OBJnpcSpeechUI;
    [SerializeField] private Animator FadeIn = null;
    [SerializeField] private Animator FadeOut = null;
    [SerializeField] private Animator SpeechBarTop = null;
    [SerializeField] private Animator SpeechBarBottom = null;
    [SerializeField] private int selectSpeech;
    private bool speechActive = true;
    private bool firstSpeech0 = true;
    private bool firstSpeech1 = true;
    private bool firstSpeech2 = true;
    private bool firstSpeech3 = true;
    private bool dialogueBool = false;
    bool hi;
    public UnityEvent f;
    controller input;

    private void Awake()
    {
        playerActionMap = new PlayerInputActions();
        //playerActionMap.UI.Submit.performed += DialogueManager;
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        playerActionMap.Player.Enable();
        playerActionMap.UI.Enable();

    }

    private void OnDisable()
    {
        playerActionMap.Player.Disable();
        playerActionMap.UI.Disable();

    }

    private void OnSubmit(InputAction.CallbackContext c)
    {
        
        if (playerActionMap.UI.Submit.triggered)
        {

        }
    }

    private async Task OnTriggerEnter(Collider other)
    {
        input = other.GetComponent<controller>();

        if (other.CompareTag("Player") && speechActive)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.NPCSpeech_Start);
            speechActive = false;
            OBJnpcSpeechUI.SetActive(true);
            npcSpeechUI.text = "";
            FadeIn.Play("NPC_Speech_Text_fade_In", 0, 0.0f);
            SpeechBarTop.Play("Top_Bar_Enter", 0, 0.0f);
            SpeechBarBottom.Play("Bottom_Bar_Enter", 0, 0.0f);

            switch (selectSpeech)
            {///////////////////////////// Fishing
                case 0:
                    if (inventoryManager.gameData.book)
                    {

                        if (firstSpeech0)
                        {
                            firstSpeech0 = false;
                            npcSpeechUI.text = npcSpeech.npcWouldLikeBook0.ToString();
                        }
                        else
                        {
                            switch (Random.Range(0, 5))
                            {
                                case 0: npcSpeechUI.text = npcSpeech.npcWouldLikeBook0.ToString(); break;
                                case 1: npcSpeechUI.text = npcSpeech.npcWouldLikeBook1.ToString(); break;
                                case 2: npcSpeechUI.text = npcSpeech.npcWouldLikeBook2.ToString(); break;
                                case 3: npcSpeechUI.text = npcSpeech.npcWouldLikeBook3.ToString(); break;
                                case 4: npcSpeechUI.text = npcSpeech.npcWouldLikeBook4.ToString(); break;
                            }
                        }

                    }
                    /// New Speech lines for after you give NPC the item they want.
                    else
                    {
                        input.ToggleControls();
                        speeches.Add(npcSpeech.npcWouldLikeApple5);
                        speeches.Add(npcSpeech.npcWouldLikeApple6);
                        speeches.Add(npcSpeech.npcWouldLikeApple7);
                        for (int i = 0; i > speeches.Count; i++)
                        {

                            npcSpeechUI.text = speeches[i];
                            StartCoroutine(potionTimer());

                            IEnumerator potionTimer()
                            {
                                yield return new WaitUntil(() => playerActionMap.UI.Submit.triggered == true);

                                
                                Debug.Log("Submit Pressed! after Toggle");
                            }
                        }
                    }

                    break;
                ///////////////////////////////////  Home
                case 1:
                    if (firstSpeech1)
                    {
                        firstSpeech1 = false;
                        npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    }
                    else
                    {
                        switch (Random.Range(0, 4))
                        {
                            case 0:
                                npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                                break;
                            case 1:
                                npcSpeechUI.text = npcSpeech.npcLostKey1.ToString();
                                break;
                            case 2:
                                npcSpeechUI.text = npcSpeech.npcLostKey2.ToString();
                                break;
                            case 3:
                                npcSpeechUI.text = npcSpeech.npcLostKey3.ToString();
                                break;

                        }
                    }
                    break;
                //////////////////////////////////////////////  Grave
                case 2:
                    if (firstSpeech2)
                    {
                        firstSpeech2 = false;
                        npcSpeechUI.text = npcSpeech.npcMourn0.ToString();
                    }
                    else
                    {
                        switch (Random.Range(0, 4))
                        {
                            case 0:
                                npcSpeechUI.text = npcSpeech.npcMourn0.ToString();
                                break;
                            case 1:
                                npcSpeechUI.text = npcSpeech.npcMourn1.ToString();
                                break;
                            case 2:
                                npcSpeechUI.text = npcSpeech.npcMourn2.ToString();
                                break;
                            case 3:
                                npcSpeechUI.text = npcSpeech.npcMourn3.ToString();
                                break;

                        }
                    }
                    break;
                //////////////////////////////////////////////////////  Library
                case 3:
                    if (!inventoryManager.gameData.apple)
                    {

                        if (firstSpeech3)
                        {
                            firstSpeech3 = false;
                            npcSpeechUI.text = npcSpeech.npcWouldLikeApple0.ToString();
                        }
                        else
                        {
                            switch (Random.Range(0, 4))
                            {
                                case 0:
                                    npcSpeechUI.text = npcSpeech.npcWouldLikeApple0.ToString();
                                    break;
                                case 1:
                                    npcSpeechUI.text = npcSpeech.npcWouldLikeApple2.ToString();
                                    break;
                                case 2:
                                    npcSpeechUI.text = npcSpeech.npcWouldLikeApple3.ToString();
                                    break;
                                case 3:
                                    npcSpeechUI.text = npcSpeech.npcWouldLikeApple4.ToString();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        speeches.Add(npcSpeech.npcWouldLikeApple5);
                        speeches.Add(npcSpeech.npcWouldLikeApple6);
                        speeches.Add(npcSpeech.npcWouldLikeApple7);
                        DialogueManager();

                    }
            
                    break;
                case 4:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 5:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 6:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 7:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 8:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 9:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 10:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;           
            }
        }
    }
    private async Task lo()
    {
        while (true)
        {
            if (playerActionMap.UI.Submit.triggered)
            {

            }
        }
        
    }
    

    public async Task DialogueManager()
    {
        input.ToggleControls();
        
        for (int i = 0; i < speeches.Count; i++)
        {

            npcSpeechUI.text = speeches[i];

            await lo();

            //input.ToggleControls();

            Debug.Log("Submit Pressed! after Toggle");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.NPCSpeech_End);
            speechActive = true;
            FadeOut.Play("NPC_Speech_Text_fade_Out", 0, 0.0f);
            SpeechBarTop.Play("Top_Bar_Exit", 0, 0.0f);
            SpeechBarBottom.Play("Bottom_Bar_Exit", 0, 0.0f);
        }
    }
}
