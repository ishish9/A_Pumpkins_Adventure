using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableNPCSpeech", menuName = "NpcSpeechScriptable")]

public class NpcSpeech : ScriptableObject
{
    // These hold the scentences NPC's will speak.
    [Header("LibraryNPCSpeech")]
    public string npcWouldLikeApple0; // 0
    public string npcWouldLikeApple1; // 1
    public string npcWouldLikeApple2; // 2
    public string npcWouldLikeApple3; // 3
    public string npcWouldLikeApple4; // 4
    ///////////////////////////////// //
    public string npcWouldLikeApple5; // 5
    public string npcWouldLikeApple6; // 6
    public string npcWouldLikeApple7; // 7
    public string npcWouldLikeApple8; // 8
    public string npcWouldLikeApple9; // 9
    public string npcWouldLikeApple10; // 10


    [Header("FishingNPCSpeech")]
    public string npcWouldLikeBook0; // 0 Sure wish I had a good book to read while fishing.
    public string npcWouldLikeBook1; // 1 Great night for fishing.
    public string npcWouldLikeBook2; // 2 Haven't caught anything yet.
    public string npcWouldLikeBook3; // 3 Quiet night ...
    public string npcWouldLikeBook4; // 4 No bites yet.
    public string npcWouldLikeBook5; // 5 Hope I catch something soon.
    public string npcWouldLikeBook6; // 6 Really!? A book for me ?. . . why thank you!
    public string npcWouldLikeBook7; // 7 Hay you can have this, I found it while fishing.
    public string npcWouldLikeBook8; // 8 Thanks for the book.

    [Header("Home1NPCSpeech")]
    public string npcLostKey0; // 0 Hmm...Now where did I put my keys? 
    public string npcLostKey1; // 1 Hmm.... Where did I put it?
    public string npcLostKey2; // 2 I just got done fishing . . . where could my keys be?
    public string npcLostKey3; // 3 Have you seen any keys laying around?
    public string npcLostKey4; // 4 Oh wow! My key, thanks!
    public string npcLostKey5; // 5 All I have in return is another key, here take it.
    public string npcLostKey6; // 6 Thanks again for finding my key.


    [Header("GraveNPCSpeech")]
    public string npcMourn0; // 0 Poor Jack. 
    public string npcMourn1; // 1 I'd like to be alone now.
    public string npcMourn2; // 2 Did you know him?
    public string npcMourn3; // 3 .........

}
