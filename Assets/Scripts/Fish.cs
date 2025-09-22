using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int rotateSpeed;
    [SerializeField] private Transform[] wayPoints;
    private int selectedWaypoint;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            selectedWaypoint = Random.Range(0, wayPoints.Length);
            timer = Random.Range(2, 10);
        }
        Vector3 move = Vector3.MoveTowards(transform.position, wayPoints[selectedWaypoint].position, speed * Time.deltaTime);
        //Transform target = ;
        transform.position = move;
        //Vector3 direction = transform.forward;
        Quaternion lookDirection = Quaternion.LookRotation(wayPoints[selectedWaypoint].position - transform.position);
        lookDirection = Quaternion.Euler(0, lookDirection.eulerAngles.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, rotateSpeed * Time.deltaTime);
        RaycastHit hit;

        // direction += new Vector3(Random.Range(-BulletSpread.x, BulletSpread.x), Random.Range(-BulletSpread.y, BulletSpread.y), Random.Range(-BulletSpread.z, BulletSpread.z));
        //if (Physics.Raycast(transform.position, direction, out hit, 5.0f))
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
        {
            if (hit.collider.tag == "Ground")
            {
                Debug.Log("Hit Wall");
                // hitpoint.transform.parent = hit.transform;
            }
        }
    }
}
