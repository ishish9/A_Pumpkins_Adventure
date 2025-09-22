using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    [SerializeField] private Animator MainGateRight = null;
    [SerializeField] private Animator MainGateLeft = null;
    [SerializeField] private Animator Button = null;
    [SerializeField] private Animator DungeonGate = null;
    [SerializeField] private Animator Locked1 = null;
    [SerializeField] private Animator Locked2 = null;

    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip doorClose;
    [SerializeField] private string openLeft;
    [SerializeField] private string openRight;
    [SerializeField] private string closeLeft;
    [SerializeField] private string closeRight;
    [SerializeField] private string buttonPress;
    [SerializeField] private string dungeonGate;
    [SerializeField] private string lockedGate1;
    [SerializeField] private string lockedGate2;



    [SerializeField] private bool openTrig = false;
    [SerializeField] private bool closeTrig = false;
    [SerializeField] private bool button = false;
    [SerializeField] private bool graveGate = false;
    [SerializeField] private InventoryManager inventoryManager;


    public GateAnimation gateAnimation;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (openTrig)
            {
                MainGateRight.Play(openRight, 0, 0.0f);
                MainGateLeft.Play(openLeft, 0, 0.0f);
                AudioManager.instance.PlaySound(doorOpen);
                gameObject.SetActive(false);
            }

            else if (closeTrig)
            {
                MainGateRight.Play(closeRight, 0, 0.0f);
                MainGateLeft.Play(closeLeft, 0, 0.0f);
                AudioManager.instance.PlaySound(doorClose);
                gameObject.SetActive(false);
            }

            else if (button)
            {
                Button.Play(buttonPress, 0, 0.0f);
                DungeonGate.Play(dungeonGate, 0, 0.0f);
                AudioManager.instance.PlaySound(AudioManager.instance.audioClips.Switch1);
                AudioManager.instance.PlaySound(AudioManager.instance.audioClips.DungeonGateOpen);

                gameObject.SetActive(false);
            }

            else if (graveGate)
            {
                //if (inventoryManager.gameData.keyGrave) // JSON save
                 if (GameData.keyGrave)
                {
                    MainGateRight.Play(openRight, 0, 0.0f);
                    MainGateLeft.Play(openLeft, 0, 0.0f);
                    AudioManager.instance.PlaySound(doorOpen);
                    gameObject.SetActive(false);
                }
                else
                {
                    Locked1.Play(lockedGate1, 0, 0.0f);
                    Locked2.Play(lockedGate2, 0, 0.0f);
                    AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LockedGate);
                }
            }
        }

        

    }

    public enum GateAnimation
    {
        GateOpen,
        GateClose,
    }
}
