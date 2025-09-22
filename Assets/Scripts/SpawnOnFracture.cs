using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnFracture : MonoBehaviour
{
    [SerializeField] private GameObject coinObject;
    private ParticleSystem ps;
    private Vector3 offset = new Vector3(4,4,0);

    private void Start()
    {
        ps = coinObject.GetComponent<ParticleSystem>();
    }
    public void SpawnObject() 
    {
        coinObject.transform.position = transform.position + offset;
        Debug.Log("Spawned Coins!");
        ps.Play();
    }

}
