using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private AudioClip projectileLaunchClip;
    [SerializeField] private float TimeBetweenSpawns = 3;
    [SerializeField] private int spawnAmount;
    [SerializeField] private float spawnForce;
    [SerializeField] private GameObject[] prefabs;
    private bool TimerEnabled = true;
    private List<GameObject> Parent = new List<GameObject>();

    void Update()
    {
        if(TimerEnabled)
        { 
            if (TimeBetweenSpawns > 0)
            {
                TimeBetweenSpawns -= Time.deltaTime;
            }
            else
            {
                TimerEnabled = false;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0, 1f);

    }
    public void SpawnObject(GameObject obj)
    {

        spawnAmount++;
        AudioManager.instance.PlaySound(projectileLaunchClip);
        var projectile = Instantiate(obj, spawnLocation.position, obj.transform.rotation);
        projectile.GetComponent<Rigidbody>().linearVelocity = spawnLocation.up * spawnForce;
        Parent.Add(projectile);
        if (spawnAmount >= 5)
        {
            CancelInvoke();
            TimeBetweenSpawns = 3f;
            TimerEnabled = true;
            spawnAmount = 0;
            //Invoke("CleanList", 1);
        }
    }

    public void CleanList()
    {
        for (int i = 0; i < Parent.Count; i++)
        {
            Destroy(Parent[i].gameObject);
        }
        Parent.Clear();
        //TimeRunning = false;
    }
}
