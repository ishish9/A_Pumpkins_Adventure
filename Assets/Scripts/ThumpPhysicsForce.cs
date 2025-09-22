using UnityEngine;

public class ThumpPhysicsForce : MonoBehaviour
{
    [SerializeField] private float impactRange;
    [SerializeField] private float force;

    public void EmitForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, impactRange, 9);
        foreach (Collider target in colliders)
        {
            Rigidbody rb = target.GetComponent<Rigidbody>();
            if (rb != null) 
            {
                rb.AddExplosionForce(force, transform.position, impactRange);
            }
        }
    }
}
