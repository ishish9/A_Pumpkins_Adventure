using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "InventoryObjects", menuName = "InventoryObjectsScriptable")]


public class InventoryObjects : ScriptableObject
{
   // [CustomEditor(typeof(InventoryObjects))]



    [Header("Inventory Items")]
    public GameObject Apple;
    public GameObject Book;
    public GameObject Key;
    public GameObject GraveKey;
    public GameObject GoldBone;

    [Header("Items in Inventory")]
    public bool apple;
    public bool book;
    public bool keyHouse;
    public bool keyGrave;
    public bool bone;

    [Header("Amount of Items in Inventory")]
    public int appleAmount;
    public int bookAmount;
    public int keyHouseAmount;
    public int keyGraveAmount;
    public int boneAmount;

    [Header("Gold and Seeds")]
    public int gold;
    public int seeds;
    
}

public enum ItemType
{
    Apple,
    Book,
    KeyHouse,
    KeyGrave,
    GoldBone,
}

public enum Levels
{
    L1,
    Library,
    Home1,
    Windmill,
    Dungeon,
}
