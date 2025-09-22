using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PotionDisplayManager potionManager;
    [SerializeField] private PowerupType powerupType;
    [SerializeField] private AudioClips audioClips;
    [SerializeField] private GameObject PickUpEffect;
    [SerializeField] private Animator Big = null;
    [SerializeField] private Animator Small = null;
    private controller playerController;

    private void Update()
    {
        transform.Rotate(0, 200 * Time.deltaTime, 0, Space.Self);
        Vector3 p = transform.position;
        p.y = .1f * Mathf.Cos(Time.time * 3.5f);
        transform.position = p;
    }

    private void OnTriggerEnter(Collider hitbox)
    {
        if (hitbox.CompareTag("Player"))
        {
            PickUp(hitbox);
        }
    }

    private void PickUp(Collider player)
    {
        //PickUpEffect.transform.position = transform.position;
        AudioManager.instance.PlaySound(audioClips.GetPowerUp);
        Instantiate(PickUpEffect, transform.position, Quaternion.identity);
        playerController = player.GetComponent<controller>();
        switch (powerupType)
        {
            case PowerupType.Big:
                Big.Play("Big", 0, 0.0f);
                potionManager.PowerUpCommand("Big");
                break;
            case PowerupType.Small:
                Small.Play("Small", 0, 0.0f);
                potionManager.PowerUpCommand("Small");
                break;
            case PowerupType.Heavy:
                playerController.ChangePlayerSpeed(3, 10f);
                potionManager.PowerUpCommand("Heavy");
                break;
            case PowerupType.Light:
                playerController.ChangePlayerWeight();
                potionManager.PowerUpCommand("Light");
                break;
            case PowerupType.Metal:
                potionManager.PowerUpCommand("Metal");
                break;
        }
        Destroy(gameObject);
    }

    public enum PowerupType
        {
            Big,
            Small,
            Heavy,
            Light,
            Metal, 
            Subterain,
        }
}
