using System.Collections;
using UnityEngine;
using TMPro;

public class PotionDisplayManager : MonoBehaviour
{
    string powerupType;
    [SerializeField] private TextMeshProUGUI PotionDisplay;
    [SerializeField] private PowerUp powerUp;


    public void PowerUpCommand(string powerupType)
    {
        switch (powerupType)
        {
            case "Big":
                PotionDisplay.text = "<fade><wave>Big Potion<wave><fade>";
                StartCoroutine(potionDisplay1());

                IEnumerator potionDisplay1()
                {
                    yield return new WaitForSeconds(5);
                    PotionDisplay.text = "";
                }
                break;
            case "Small":
                PotionDisplay.text = "<fade><wave>Small Potion<wave><fade>";
                StartCoroutine(potionDisplay2());

                IEnumerator potionDisplay2()
                {
                    yield return new WaitForSeconds(5);
                    PotionDisplay.text = "";
                }
                break;
            case "Heavy":
                //playerController.ChangePlayerSpeed(3, 10f);
                PotionDisplay.text = "<fade><wave>Heavy Potion<wave><fade>";
                StartCoroutine(potionDisplay3());

                IEnumerator potionDisplay3()
                {
                    yield return new WaitForSeconds(5);
                    PotionDisplay.text = "";
                }
                break;
            case "Light":
                //playerController.ChangePlayerWeight();
                PotionDisplay.text = "<fade><wave>Light Potion<wave><fade>";
                StartCoroutine(potionDisplay4());

                IEnumerator potionDisplay4()
                {
                    yield return new WaitForSeconds(5);
                    PotionDisplay.text = "";
                }
                break;
            case "Metal":
                PotionDisplay.text = "<fade><wave>Metal Potion<wave><fade>";
                StartCoroutine(potionDisplay5());

                IEnumerator potionDisplay5()
                {
                    yield return new WaitForSeconds(5);
                    PotionDisplay.text = "";
                }

                break;
        }
    }
}
