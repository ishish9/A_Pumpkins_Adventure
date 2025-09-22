using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAudioClips", menuName = "AudioClipsScriptable")]

public class AudioClips : ScriptableObject
{
    [Header("AudioClips For Player")]
    public AudioClip Move;
    public AudioClip Jump;
    public AudioClip JumpDouble;
    public AudioClip Land;
    public AudioClip Stomp;
    public AudioClip Fall;

    [Header("Collectable Sounds")]
    public AudioClip CollectSeed;
    public AudioClip CollectCoin;
    public AudioClip CollectCoinBush;
    public AudioClip BushShake;
    public AudioClip GetPowerUp;
    public AudioClip InventoryPickup;


    [Header("Chest Sounds")]
    public AudioClip ChestOpen;
    public AudioClip TaDa;
    public AudioClip TaDaBad;

    [Header("Door Sounds")]
    public AudioClip CreekyDoorOpen;
    public AudioClip LockedGate;
    public AudioClip creakOpen;
    public AudioClip creakClose;

    [Header("Misc")]
    public AudioClip Wind;
    public AudioClip LevelTransitionIn;
    public AudioClip LevelTransitionOut;
    public AudioClip StartButtonClick;
    public AudioClip Switch1;
    public AudioClip DungeonGateOpen;
    public AudioClip LavaFall;
    public AudioClip LibraryMusic;


    [Header("Dialogue")]
    public AudioClip NPCSpeech_Start;
    public AudioClip NPCSpeech_End;
    public AudioClip DialogueAdvance;
    public AudioClip DialogueEnd;
    public AudioClip AcquireItem;

    [Header("Enemy")]
    public AudioClip Rat_Hit;
    public AudioClip Rat_Death;









}
