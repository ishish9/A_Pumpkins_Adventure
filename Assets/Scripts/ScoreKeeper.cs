using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ScoreKeeper : MonoBehaviour
{
    GameData gameData;
    [SerializeField] private AudioClips audioClip;
    [SerializeField] private TextMeshProUGUI CoinDisplay;
    [SerializeField] private TextMeshProUGUI SeedDisplay;
    [SerializeField] private TextMeshProUGUI coinDisplayInventory;
    [SerializeField] private TextMeshProUGUI seedDisplayInventory;
    [SerializeField] private GameObject seedDisplay;
    [SerializeField] private GameObject coinDisplay;
    public delegate void ScoreEvent(int s);
    public static event ScoreEvent OnScoreChange;
    private static int coins = 0;
    private static int seeds = 0;

    private void Awake()
    {
        gameData = new GameData();
        
    }

    private void Start()
    {
        //string json = File.ReadAllText(Application.dataPath + "/gameData.json");
       // gameData = JsonUtility.FromJson<GameData>(json);
        // Populate gold and seeds amount from saved json file.
        // Gold
        coins += GameData.gold;
        CoinDisplay.text = coins.ToString();
        coinDisplayInventory.text = coins.ToString();
        // Seeds
        seeds += GameData.seeds;
        SeedDisplay.text = seeds.ToString();
        seedDisplayInventory.text = seeds.ToString();
    }

    void OnEnable()
    {
        CoinTrigger.OnScore += CoinAdd;
        Seed.OnScore += SeedAdd;
        CoinMultiple.OnScore += CoinMultipleAdd;
    }

    void OnDisable()
    {
        CoinTrigger.OnScore -= CoinAdd;
        Seed.OnScore -= SeedAdd;
        CoinMultiple.OnScore -= CoinMultipleAdd;
    }
    public void CoinAdd(int AddAmount)
    {      
        int waitDisplay = 4;
        AudioManager.instance.PlaySound(audioClip.CollectCoin);
        coinDisplay.SetActive(true);
        StartCoroutine(updateCoinScore());

        IEnumerator updateCoinScore()
        {
            yield return new WaitForSeconds(.2f);
            coins += AddAmount;
            CoinDisplay.text = coins.ToString();
            coinDisplayInventory.text = coins.ToString();
            yield return new WaitForSeconds(waitDisplay);
            coinDisplay.SetActive(false);
            StopCoroutine(updateCoinScore());
        }
        GameData.gold++;
        SaveData();
    }
    public void CoinMultipleAdd(int AddAmount)
    {
        coinDisplay.SetActive(true);

        StartCoroutine(multiScoreSound());

        IEnumerator multiScoreSound()
        {
            for (int i = 0; i < AddAmount; i++)
            {
                AudioManager.instance.PlaySound(audioClip.CollectCoin);
                coins++;
                CoinDisplay.text = coins.ToString();
                coinDisplayInventory.text = coins.ToString();

                yield return new WaitForSeconds(.01f);

            }
            StartCoroutine(updateCoinScore());
        }

        IEnumerator updateCoinScore()
        {
            yield return new WaitForSeconds(4);
            coinDisplay.SetActive(false);
        }
        GameData.gold += AddAmount;
        SaveData();
    }

    public void SeedAdd(int AddAmount)
    {
        AudioManager.instance.PlaySound(audioClip.CollectSeed);
        seedDisplay.SetActive(true);
        seeds += AddAmount;
        SeedDisplay.text = seeds.ToString();
        seedDisplayInventory.text = seeds.ToString();
        StartCoroutine(updateSeedScore());

        IEnumerator updateSeedScore()
        {
            yield return new WaitForSeconds(4);
            seedDisplay.SetActive(false);
        }
        GameData.seeds++;
        SaveData();
    }

    public void ResetCoinScore()
    {
        coins = 0;
        CoinDisplay.text = coins.ToString();
        coinDisplayInventory.text = coins.ToString();
    }

    public int GetCoinScore()
    {
        return coins;
    }

    public void SaveData()
    {
        //string json = JsonUtility.ToJson(gameData);
       // File.WriteAllText(Application.dataPath + "/gameData.json", json);
    }
}
