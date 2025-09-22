using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    public delegate void Score(int seed);
    public static event Score OnScore;

    void Update()
    {
        transform.Rotate(0f, 200f * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter()
    {
        OnScore(1);
        Instantiate(Prefab, transform.position, transform.rotation);     
        gameObject.SetActive(false);
    }
}
