using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private ChestType chestType;
    [SerializeField] private int ObjSpawnAmount;
    [SerializeField] private float DelayBetweenObjSpawn;
    [SerializeField] private int spawnForce;
    private int spawnCount;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private GameObject light;
    [SerializeField] private ParticleSystem ParticlePrefab;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private Animator Chest_Open = null;
    [SerializeField] private Animator ChestUnlock = null;
    [SerializeField] private Animator ChestFullyOpen = null;
    [SerializeField] private AudioClips audioClipObject;
    private bool ChestUnopened = true;
    [SerializeField] private Vector3 Spread = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 offset = new Vector3(0, 6, 0);


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && ChestUnopened == true)
        {
            switch (chestType)
            {
                case ChestType.Coins:
                    ChestUnopened = false;
                    AudioManager.instance.PlaySound(audioClipObject.ChestOpen);
                    Chest_Open.Play("Chest_Open", 0, 0.0f);

                    StartCoroutine(openChest());

                    IEnumerator openChest()
                    {
                        yield return new WaitForSeconds(1);
                        light.SetActive(true);
                        AudioManager.instance.PlaySound(audioClipObject.TaDa);
                        //Instantiate(Prefab, transform.position + offset, Quaternion.identity);
                        ParticlePrefab.Play();
                        //InvokeRepeating("SpawnObject", 0, DelayBetweenObjSpawn);
                        //SpawnObject();
                        
                    }
                    break;
                    ///
                case ChestType.Key:
                    ChestUnopened = false;
                    AudioManager.instance.PlaySound(audioClipObject.ChestOpen);
                    Chest_Open.Play("Chest_Open", 0, 0.0f);

                    StartCoroutine(openChest0());

                    IEnumerator openChest0()
                    {
                        yield return new WaitForSeconds(1);
                        light.SetActive(true);

                        AudioManager.instance.PlaySound(audioClipObject.TaDa);
                        Instantiate(keyPrefab, transform.position + new Vector3(0, 3, 0), Quaternion.EulerRotation(0,0,90));
                    }
                    break;
                    ///
                case ChestType.Mystery:
                    ChestUnopened = false;
                    AudioManager.instance.PlaySound(audioClipObject.ChestOpen);
                    Chest_Open.Play("Chest_Open", 0, 0.0f);

                    StartCoroutine(openChest1());

                    IEnumerator openChest1()
                    {
                        yield return new WaitForSeconds(1);
                        light.SetActive(true);

                        AudioManager.instance.PlaySound(audioClipObject.TaDa);
                    }
                    break;
                    ///
                case ChestType.Empty:
                    ChestUnopened = false;
                    AudioManager.instance.PlaySound(audioClipObject.ChestOpen);
                    Chest_Open.Play("Chest_Open", 0, 0.0f);

                    StartCoroutine(openChest2());

                    IEnumerator openChest2()
                    {
                        yield return new WaitForSeconds(1);
                        light.SetActive(true);

                        AudioManager.instance.PlaySound(audioClipObject.TaDaBad);
                    }
                    break;
                    ///
                case ChestType.Crystal:
                    ChestUnopened = false;
                    AudioManager.instance.PlaySound(audioClipObject.ChestOpen);
                    Chest_Open.Play("Chest_Open", 0, 0.0f);

                    StartCoroutine(openChest3());

                    IEnumerator openChest3()
                    {
                        yield return new WaitForSeconds(1);
                        light.SetActive(true);

                        AudioManager.instance.PlaySound(audioClipObject.TaDa);
                    }
                    break;
                    ///
                case ChestType.Enemy:
                    ChestUnopened = false;

                    print("Why hello there good sir! Let me teach you about Trigonometry!");
                    break;
            }
        }
    }

    private void SpawnObject()
    {        
        spawnCount++;
        Vector3 direction = transform.up;
        direction += new Vector3(Random.insideUnitSphere.x, Random.insideUnitSphere.y, Random.insideUnitSphere.z);

        //direction += new Vector3(Random.Range(-Spread.x, Spread.x), Random.Range(-Spread.y, Spread.y), Random.Range(-Spread.z, Spread.z));
        //direction.Normalize();
        GameObject obj = Instantiate(Prefab, spawnLocation.position, Prefab.transform.rotation);

        obj.GetComponent<Rigidbody>().linearVelocity = direction * 45 ;
        if (spawnCount >= ObjSpawnAmount)
        {
            CancelInvoke();
            spawnCount = 0;
        }            
    }

    public enum ChestType
    {
        Coins,
        Key,
        Mystery,
        Empty,
        Crystal,
        Enemy
    }
}
