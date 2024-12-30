using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    PlayerInputActions playerActionMap;
    [SerializeField] private InventoryObjects inventoryScritableObjects;
    public GameData gameData;
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject InventoryFullObj;
    [SerializeField] private GameObject SeedOBJ;
    [SerializeField] private GameObject CoinOBJ;
    [SerializeField] private GameObject[] InventorySlots = new GameObject [10];
    [SerializeField] private TextMeshProUGUI[] SlotTexts = new TextMeshProUGUI [10];
    private TextMeshProUGUI text;

    private void Awake()
    {
        gameData = new GameData();
        playerActionMap = new PlayerInputActions();
        playerActionMap.Player.Inventory.performed += OnInventory;
    }

    private void Start()
    {
        PopulateInventory();
        text = InventoryFullObj.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        playerActionMap.Player.Enable();
        InventoryItem.OnInventoryItemCollect += RecieveInventoryItem;
    }

    private void OnDisable()
    {
        playerActionMap.Player.Disable();
        InventoryItem.OnInventoryItemCollect -= RecieveInventoryItem;
    }
    // Populates inventory from json file on start.
    private void PopulateInventory()
    {
        string json = File.ReadAllText(Application.dataPath + "/gameData.json");
        gameData = JsonUtility.FromJson<GameData>(json);

        if (gameData.apple)
        {
            GameObject obj = Instantiate(inventoryScritableObjects.Apple, InventorySlots[gameData.appleIndex].transform.position, Quaternion.identity);
            SlotTexts[gameData.appleIndex].gameObject.SetActive(true);
            SlotTexts[gameData.appleIndex].text = "" + gameData.appleAmount.ToString();
        }
        if (gameData.book)
        {
            GameObject obj = Instantiate(inventoryScritableObjects.Book, InventorySlots[gameData.bookIndex].transform.position, Quaternion.identity);
            SlotTexts[gameData.bookIndex].gameObject.SetActive(true);
            SlotTexts[gameData.bookIndex].text = "" + gameData.bookAmount.ToString();
        }
        if (gameData.keyHouse)
        {
            GameObject obj = Instantiate(inventoryScritableObjects.Key, InventorySlots[gameData.keyHouseIndex].transform.position, Quaternion.identity);
            SlotTexts[gameData.keyHouseIndex].gameObject.SetActive(true);
            SlotTexts[gameData.keyHouseIndex].text = "" + gameData.keyHouseAmount.ToString();
        }
        if (gameData.keyGrave )
        {
            GameObject obj = Instantiate(inventoryScritableObjects.GraveKey, InventorySlots[gameData.keyGraveIndex].transform.position, Quaternion.identity);
            SlotTexts[gameData.keyGraveIndex].gameObject.SetActive(true);
            SlotTexts[gameData.keyGraveIndex].text = "" + gameData.keyGraveAmount.ToString();
        }
        if (gameData.goldBone)
        {
            GameObject obj = Instantiate(inventoryScritableObjects.GoldBone, InventorySlots[gameData.goldBoneIndex].transform.position, Quaternion.identity);
            SlotTexts[gameData.goldBoneIndex].gameObject.SetActive(true);
            SlotTexts[gameData.goldBoneIndex].text = "" + gameData.goldBoneAmount.ToString();
        }
        else { }
    }

    public void RecieveInventoryItem(int itemType)
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if (!InventorySlots[i].activeInHierarchy)
            {
                InventorySlots[i].SetActive(true);
                switch (itemType)
                {
                    case (int)ItemType.Apple:
                        gameData.appleAmount++;
                        if (gameData.apple)
                        {
                            SlotTexts[gameData.appleIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.appleIndex].text = gameData.appleAmount.ToString();
                        }
                        else
                        {
                            gameData.apple = true;
                            gameData.appleIndex = i;
                            SlotTexts[gameData.appleIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.appleIndex].text = gameData.appleAmount.ToString();
                            Instantiate(inventoryScritableObjects.Apple, InventorySlots[i].transform.position, Quaternion.identity);
                        }
                        break;

                    case (int)ItemType.Book:
                        gameData.bookAmount++;
                        if (gameData.book)
                        {
                            SlotTexts[gameData.bookIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.bookIndex].text = gameData.bookAmount.ToString();
                        }
                        else
                        {
                            gameData.book = true;
                            gameData.bookIndex = i;
                            SlotTexts[gameData.bookIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.bookIndex].text = gameData.bookAmount.ToString();
                            Instantiate(inventoryScritableObjects.Book, InventorySlots[i].transform.position, Quaternion.identity);
                        }
                        break;

                    case (int)ItemType.KeyHouse:
                        gameData.keyHouseAmount++;
                        if (gameData.keyHouse)
                        {
                            SlotTexts[gameData.keyHouseIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.keyHouseIndex].text = gameData.keyHouseAmount.ToString();
                        }
                        else
                        {
                            gameData.keyHouse = true;
                            gameData.keyHouseIndex = i;
                            SlotTexts[gameData.keyHouseIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.keyHouseIndex].text = gameData.keyHouseAmount.ToString();
                            Instantiate(inventoryScritableObjects.Key, InventorySlots[i].transform.position, Quaternion.identity);
                        }            
                        break;

                    case (int)ItemType.KeyGrave:
                        gameData.keyGraveAmount++;
                        if (gameData.keyGrave)
                        {
                            SlotTexts[gameData.keyGraveIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.keyGraveIndex].text = gameData.keyGraveAmount.ToString();
                        }
                        else
                        {
                            gameData.keyGrave = true;
                            gameData.keyGraveIndex = i;
                            SlotTexts[gameData.keyGraveIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.keyGraveIndex].text = gameData.keyGraveAmount.ToString();
                            Instantiate(inventoryScritableObjects.GraveKey, InventorySlots[i].transform.position, Quaternion.identity);
                        }
                        break;

                    case (int)ItemType.GoldBone:
                        gameData.goldBoneAmount++;
                        if (gameData.goldBone)
                        {
                            SlotTexts[gameData.goldBoneIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.goldBoneIndex].text = gameData.goldBoneAmount.ToString();
                        }
                        else
                        {
                            gameData.goldBone = true;
                            gameData.goldBoneIndex = i;
                            SlotTexts[gameData.goldBoneIndex].gameObject.SetActive(true);
                            SlotTexts[gameData.goldBoneIndex].text = gameData.goldBoneAmount.ToString();
                            Instantiate(inventoryScritableObjects.GoldBone, InventorySlots[i].transform.position, Quaternion.identity);
                        }                      
                        break;
                }
                string json = JsonUtility.ToJson(gameData);
                File.WriteAllText(Application.dataPath + "/gameData.json", json);
                AudioManager.instance.PlaySound(AudioManager.instance.audioClips.InventoryPickup);
                return;            
            }
            else if (i == 4)
            {
                
                if (!InventoryFullObj.activeInHierarchy)
                {
                    InventoryFullObj.SetActive(true);
                    text.text = "<Fade>Inventory Full!<fade>";
                }
                else
                {
                    InventoryFullObj.SetActive(false);
                    InventoryFullObj.SetActive(true);
                    text.text = "<fade>Inventory Full!<fade>";
                }
            }          
        }       
    }

    public void RemoveInventoryItem(Enum itemName)
    {
        for (int i = 0; i < 1; i++)
        {
            


            
        }
    }

    public void OnInventory(InputAction.CallbackContext contex)
    {
       if (InventoryUI.activeSelf == false)
        {
            InventoryUI.SetActive(true);
            SeedOBJ.SetActive(true);
            CoinOBJ.SetActive(true);
            AudioManager.instance.ChangeMusicPitch(2f, false);
        }
        else
        {
            InventoryUI.SetActive(false);
            SeedOBJ.SetActive(false);
            CoinOBJ.SetActive(false);
            AudioManager.instance.ChangeMusicPitch(0f, true);
        }
    }
    public enum inventoryList
    {
        Apple,
        Book,
        KeyHouse,
        keyGrave,
        GoldBone,
    }


}


   
