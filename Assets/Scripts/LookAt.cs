using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform target, idleTarget;
    [SerializeField] private int lookSpeed;
    [SerializeField] private int beginLookingDistance;

    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        Quaternion lookDirection = Quaternion.LookRotation(target.position - transform.position);
        Quaternion lookDirection2 = Quaternion.LookRotation(idleTarget.position - transform.position);             
        if (dist < beginLookingDistance)
        {
            lookDirection = Quaternion.Euler(0, lookDirection.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, lookSpeed * Time.deltaTime);
        }
        else if (dist > beginLookingDistance)
        {
            lookDirection2 = Quaternion.Euler(0, lookDirection2.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection2, lookSpeed * Time.deltaTime);
        }             
    }
}
