using UnityEngine;
using System;

[Serializable]
public class GameData 
{
    // Items in Inventory
    public bool apple;
    public bool book;
    public bool keyHouse;
    public bool keyGrave;
    public bool goldBone;

    // Amount of Items in Inventory
    public int appleAmount;
    public int bookAmount;
    public int keyHouseAmount;
    public int keyGraveAmount;
    public int goldBoneAmount;

    // Items Location in Inventory
    public int appleIndex;
    public int bookIndex;
    public int keyHouseIndex;
    public int keyGraveIndex;
    public int goldBoneIndex;

    // Gold and Seeds
    public int gold;
    public int seeds;
}
