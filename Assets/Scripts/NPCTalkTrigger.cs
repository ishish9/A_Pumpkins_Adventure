using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using System.IO;


public class NPCTalkTrigger : MonoBehaviour
{
    PlayerInputActions playerActionMap;
    [SerializeField] private List<String> speeches = new List<String>();
    [SerializeField] private InventoryObjects inventoryScritableObjects;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private NpcSpeech npcSpeech;
    [SerializeField] private TextMeshProUGUI npcSpeechUI;
    [SerializeField] private GameObject OBJnpcSpeechUI;
    [SerializeField] private GameObject SpeechAdvanceIcon;
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
    private bool talking = false;
    controller input;

    private void Awake()
    {
        playerActionMap = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerActionMap.UI.Enable();
    }

    private void OnDisable()
    {
        playerActionMap.UI.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        talking = true;
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
            { ///////////////////////////// Fishing
                case 0:
                    /// Pre Recieved item.
                    if (!GameData.book && !GameData.bookComplete)
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
                                case 0: npcSpeechUI.text = npcSpeech.npcWouldLikeBook0.ToString(); talking = false; break;
                                case 1: npcSpeechUI.text = npcSpeech.npcWouldLikeBook1.ToString(); break;
                                case 2: npcSpeechUI.text = npcSpeech.npcWouldLikeBook2.ToString(); break;
                                case 3: npcSpeechUI.text = npcSpeech.npcWouldLikeBook3.ToString(); break;
                                case 4: npcSpeechUI.text = npcSpeech.npcWouldLikeBook4.ToString(); break;
                                case 5: npcSpeechUI.text = npcSpeech.npcWouldLikeBook5.ToString(); break;

                            }
                        }
                    }
                    else
                    {
                        /// Recieve item.
                        if (!GameData.bookComplete)
                        {
                            speeches.Add(npcSpeech.npcWouldLikeBook6);
                            speeches.Add(npcSpeech.npcWouldLikeBook7);

                            StartCoroutine(ProcessDialogue());

                            IEnumerator ProcessDialogue()
                            {
                                input.ToggleControls();
                                for (int i = 0; i < speeches.Count; i++)
                                {
                                    npcSpeechUI.text = speeches[i];
                                    SpeechAdvanceIcon.SetActive(true);

                                    yield return new WaitUntil(() => playerActionMap.UI.Submit.ReadValue<float>() == 1);
                                    AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DialogueAdvance);
                                    SpeechAdvanceIcon.SetActive(false);

                                    yield return new WaitForSeconds(0.2f);
                                }
                                input.ToggleControls();
                                speeches.Clear();
                                GameData.bookComplete = true;
                                GameData.book = false;
                                GameData.bookAmount = 0;
                                inventoryManager.SlotTexts[GameData.bookIndex].text = "";
                                inventoryManager.RemoveInventoryItem(GameData.bookIndex);
                                //SaveData();

                                AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DialogueEnd);
                                Instantiate(inventoryScritableObjects.Key, other.transform.position  + new Vector3(0, 3, 0), Quaternion.identity);
                            }
                        }
                        else
                        {
                            /// After Recieved item.                   
                            npcSpeechUI.text = npcSpeech.npcWouldLikeBook8;
                            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DialogueEnd);
                        }
                    }
                        
                    break;
                ///////////////////////////////////  HOME  //////////////////////
                case 1:
                    /// Pre Recieved item.
                    if (!GameData.keyHouse && !GameData.keyHouseComplete)
                    {
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
                    }
                    else 
                    {
                        /// Recieve item.
                        if (!GameData.keyHouseComplete)
                        {
                            speeches.Add(npcSpeech.npcLostKey4);
                            speeches.Add(npcSpeech.npcLostKey5);
                            StartCoroutine(ProcessDialogue());

                            IEnumerator ProcessDialogue()
                            {
                                input.ToggleControls();
                                for (int i = 0; i < speeches.Count; i++)
                                {
                                    npcSpeechUI.text = speeches[i];
                                    SpeechAdvanceIcon.SetActive(true);

                                    yield return new WaitUntil(() => playerActionMap.UI.Submit.ReadValue<float>() == 1);
                                    AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DialogueAdvance);
                                    SpeechAdvanceIcon.SetActive(false);

                                    yield return new WaitForSeconds(0.2f);
                                }
                                input.ToggleControls();

                                speeches.Clear();
                                GameData.keyHouseComplete = true;
                                GameData.keyHouse = false;
                                GameData.keyHouseAmount = 0;
                                inventoryManager.SlotTexts[GameData.keyHouseIndex].text = "";
                                inventoryManager.RemoveInventoryItem(GameData.keyHouseIndex);
                                //SaveData();

                                AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DialogueEnd);
                                Instantiate(inventoryScritableObjects.GraveKey, other.transform.position  + new Vector3(0, 3, 0), Quaternion.identity);
                            }
                        }
                        else
                        {
                            /// After Recieved item.                   
                            npcSpeechUI.text = npcSpeech.npcLostKey6;
                            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DialogueEnd);
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
                    /// Pre Recieved item.
                    if (!GameData.apple && !GameData.appleComplete)
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
                        /// Recieve item.
                        if (!GameData.appleComplete)
                        {                       
                        speeches.Add(npcSpeech.npcWouldLikeApple5);
                        speeches.Add(npcSpeech.npcWouldLikeApple6);
                        speeches.Add(npcSpeech.npcWouldLikeApple7);

                        StartCoroutine(ProcessDialogue());

                        IEnumerator ProcessDialogue()
                        {
                            input.ToggleControls();
                            for (int i = 0; i < speeches.Count; i++)
                            {
                                npcSpeechUI.text = speeches[i];
                                SpeechAdvanceIcon.SetActive(true);
                                yield return new WaitUntil(() => playerActionMap.UI.Submit.ReadValue<float>() == 1);
                                AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DialogueAdvance);
                                SpeechAdvanceIcon.SetActive(false);
                                yield return new WaitForSeconds(0.2f);
                            }
                            input.ToggleControls();
                            speeches.Clear();
                            GameData.appleComplete = true;
                            GameData.apple = false;
                            GameData.appleAmount = 0;
                            inventoryManager.SlotTexts[GameData.appleIndex].text = "";
                            inventoryManager.RemoveInventoryItem(GameData.appleIndex);
                            //SaveData();

                            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DialogueEnd);
                            Instantiate(inventoryScritableObjects.Book, other.transform.position  + new Vector3(0, 3, 0), Quaternion.identity);
                        }

                        }
                        else
                        {
                            /// After Recieved item.                   
                            npcSpeechUI.text = npcSpeech.npcWouldLikeApple8;
                            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DialogueEnd);                          
                        }
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


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            input.ControlsOn();
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.NPCSpeech_End);
            speechActive = true;
            FadeOut.Play("NPC_Speech_Text_fade_Out", 0, 0.0f);
            SpeechBarTop.Play("Top_Bar_Exit", 0, 0.0f);
            SpeechBarBottom.Play("Bottom_Bar_Exit", 0, 0.0f);
            npcSpeechUI.text = "";

        }
    }

    private void SaveData()
    {
        //string json = JsonUtility.ToJson(inventoryManager.gameData);
        //File.WriteAllText(Application.dataPath + "/gameData.json", json);
    }
}
