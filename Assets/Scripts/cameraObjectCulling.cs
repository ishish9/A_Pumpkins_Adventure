using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraObjectCulling : MonoBehaviour
{
    private Transform Camera;
    
    void Start()
    {
        Camera = transform;     
    }

    void Update()
    {
        RaycastHit hit;
        RaycastHit hitObject;
        int layerMask = 1<<8;
        layerMask = ~layerMask;

        Vector3 direction = transform.forward;
        //direction += new Vector3(Random.Range(-BulletSpread.x, BulletSpread.x), Random.Range(-BulletSpread.y, BulletSpread.y), Random.Range(-BulletSpread.z, BulletSpread.z));
        if (Physics.Raycast(transform.position, direction, out hit, 9500.0f))
        {
            Physics.Raycast(transform.position, direction, out hitObject, 9500.0f, 3);

            var rayHit = hit.collider.gameObject.GetComponent<MeshRenderer>();
            var rayHitObject = hitObject.collider.gameObject.GetComponent<MeshRenderer>();

            if (hit.collider.tag == "Player")
            {
                Debug.Log("I can See Player");
                rayHitObject.enabled = true;

            }
            else
            {

                rayHitObject.enabled = false;

            }
               
                //rayHit.gameObject.SetActive(true);

                //var hitpoint = Instantiate(HitPrefab, hit.point, SpawnLocation.rotation);
                //hitpoint.transform.parent = hit.transform;
 
        }
    }
}
