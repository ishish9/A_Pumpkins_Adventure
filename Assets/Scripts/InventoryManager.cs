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
    //public GameData gameData;
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject InventoryFullObj;
    [SerializeField] private GameObject SeedOBJ;
    [SerializeField] private GameObject CoinOBJ;
    [SerializeField] private GameObject[] InventorySlots = new GameObject [10];
    [SerializeField] public TextMeshProUGUI[] SlotTexts = new TextMeshProUGUI [10];
    private TextMeshProUGUI text;

    private void Awake()
    {
       // gameData = new GameData();
       // DontDestroyOnLoad(gameObject);
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
       // PopulateInventory();

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
        //string json = File.ReadAllText(Application.dataPath + "/gameData.json");
       // gameData = JsonUtility.FromJson<GameData>(json);

        if (GameData.apple)
        {
            GameObject obj = Instantiate(inventoryScritableObjects.Apple, InventorySlots[GameData.appleIndex].transform.position, Quaternion.identity);
            obj.transform.parent = InventorySlots[GameData.appleIndex].transform;
            InventorySlots[GameData.appleIndex].SetActive(true);

            SlotTexts[GameData.appleIndex].gameObject.SetActive(true);
            SlotTexts[GameData.appleIndex].text = "" + GameData.appleAmount.ToString();
        }
        if (GameData.book)
        {
            GameObject obj = Instantiate(inventoryScritableObjects.Book, InventorySlots[GameData.bookIndex].transform.position, Quaternion.identity);
            obj.transform.parent = InventorySlots[GameData.bookIndex].transform;
            InventorySlots[GameData.bookIndex].SetActive(true);
            SlotTexts[GameData.bookIndex].gameObject.SetActive(true);
            SlotTexts[GameData.bookIndex].text = "" + GameData.bookAmount.ToString();
        }
        if (GameData.keyHouse)
        {
            GameObject obj = Instantiate(inventoryScritableObjects.Key, InventorySlots[GameData.keyHouseIndex].transform.position, Quaternion.identity);
            obj.transform.parent = InventorySlots[GameData.keyHouseIndex].transform;
            InventorySlots[GameData.keyHouseIndex].SetActive(true);
            SlotTexts[GameData.keyHouseIndex].gameObject.SetActive(true);
            SlotTexts[GameData.keyHouseIndex].text = "" + GameData.keyHouseAmount.ToString();
        }
        if (GameData.keyGrave )
        {
            GameObject obj = Instantiate(inventoryScritableObjects.GraveKey, InventorySlots[GameData.keyGraveIndex].transform.position, Quaternion.identity);
            obj.transform.parent = InventorySlots[GameData.keyGraveIndex].transform;
            InventorySlots[GameData.keyGraveIndex].SetActive(true);
            SlotTexts[GameData.keyGraveIndex].gameObject.SetActive(true);
            SlotTexts[GameData.keyGraveIndex].text = "" + GameData.keyGraveAmount.ToString();
        }
        if (GameData.goldBone)
        {
            GameObject obj = Instantiate(inventoryScritableObjects.GoldBone, InventorySlots[GameData.goldBoneIndex].transform.position, Quaternion.identity);
            obj.transform.parent = InventorySlots[GameData.goldBoneIndex].transform;
            InventorySlots[GameData.goldBoneIndex].SetActive(true);

            SlotTexts[GameData.goldBoneIndex].gameObject.SetActive(true);
            SlotTexts[GameData.goldBoneIndex].text = "" + GameData.goldBoneAmount.ToString();
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
                        GameData.appleAmount++;
                        if (GameData.apple)
                        {
                            SlotTexts[GameData.appleIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.appleIndex].text = GameData.appleAmount.ToString();
                        }
                        else
                        {
                            GameData.apple = true;
                            GameData.appleIndex = i;
                            SlotTexts[GameData.appleIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.appleIndex].text = GameData.appleAmount.ToString();
                            var obj = Instantiate(inventoryScritableObjects.Apple, InventorySlots[i].transform.position, Quaternion.identity);
                            obj.gameObject.transform.parent = InventorySlots[i].transform;
                            InventorySlots[i].SetActive(true);

                        }
                        break;

                    case (int)ItemType.Book:
                        GameData.bookAmount++;
                        if (GameData.book)
                        {
                            SlotTexts[GameData.bookIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.bookIndex].text = GameData.bookAmount.ToString();
                        }
                        else
                        {
                            GameData.book = true;
                            GameData.bookIndex = i;
                            SlotTexts[GameData.bookIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.bookIndex].text = GameData.bookAmount.ToString();
                            var obj = Instantiate(inventoryScritableObjects.Book, InventorySlots[i].transform.position, Quaternion.identity);
                            obj.gameObject.transform.parent = InventorySlots[i].transform;
                            InventorySlots[i].SetActive(true);

                        }
                        break;

                    case (int)ItemType.KeyHouse:
                        GameData.keyHouseAmount++;
                        if (GameData.keyHouse)
                        {
                            SlotTexts[GameData.keyHouseIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.keyHouseIndex].text = GameData.keyHouseAmount.ToString();
                        }
                        else
                        {
                            GameData.keyHouse = true;
                            GameData.keyHouseIndex = i;
                            SlotTexts[GameData.keyHouseIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.keyHouseIndex].text = GameData.keyHouseAmount.ToString();
                            var obj = Instantiate(inventoryScritableObjects.Key, InventorySlots[i].transform.position, Quaternion.identity);
                            obj.gameObject.transform.parent = InventorySlots[i].transform;
                            InventorySlots[i].SetActive(true);


                        }
                        break;

                    case (int)ItemType.KeyGrave:
                        GameData.keyGraveAmount++;
                        if (GameData.keyGrave)
                        {
                            SlotTexts[GameData.keyGraveIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.keyGraveIndex].text = GameData.keyGraveAmount.ToString();
                        }
                        else
                        {
                            GameData.keyGrave = true;
                            GameData.keyGraveIndex = i;
                            SlotTexts[GameData.keyGraveIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.keyGraveIndex].text = GameData.keyGraveAmount.ToString();
                            var obj = Instantiate(inventoryScritableObjects.GraveKey, InventorySlots[i].transform.position, Quaternion.identity);
                            obj.gameObject.transform.parent = InventorySlots[i].transform;
                            InventorySlots[i].SetActive(true);


                        }
                        break;

                    case (int)ItemType.GoldBone:
                        GameData.goldBoneAmount++;
                        if (GameData.goldBone)
                        {
                            SlotTexts[GameData.goldBoneIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.goldBoneIndex].text = GameData.goldBoneAmount.ToString();
                        }
                        else
                        {
                            GameData.goldBone = true;
                            GameData.goldBoneIndex = i;
                            SlotTexts[GameData.goldBoneIndex].gameObject.SetActive(true);
                            SlotTexts[GameData.goldBoneIndex].text = GameData.goldBoneAmount.ToString();
                            var obj = Instantiate(inventoryScritableObjects.GoldBone, InventorySlots[i].transform.position, Quaternion.identity);
                            obj.gameObject.transform.parent = InventorySlots[i].transform;
                            InventorySlots[i].SetActive(true);


                        }
                        break;
                }
                //string json = JsonUtility.ToJson(GameData);
               // File.WriteAllText(Application.dataPath + "/gameData.json", json);
                AudioManager.instance.PlaySound(AudioManager.instance.audioClips.InventoryPickup);
                return;            
            }
            else if (i == 66)
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

    public void RemoveInventoryItem(int item)
    {
        Destroy(InventorySlots[item].transform.GetChild(0).gameObject);
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
    


}


   
