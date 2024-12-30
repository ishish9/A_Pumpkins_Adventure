using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public GameObject xuit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            xuit.gameObject.SetActive(true);
        }
        
    }
    public void quitApplication()
    {
        Application.Quit();
    }
}
