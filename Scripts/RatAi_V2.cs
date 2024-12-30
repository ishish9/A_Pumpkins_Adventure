using UnityEngine;
using UnityEngine.AI;



public class RatAi_V2 : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 offset = new Vector3(0,0,0);
    [SerializeField] private float timeRemaining = 5;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.SetDestination(transform.position + offset);
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            agent.ResetPath();
            Vector3 offset2 = transform.position + new Vector3(Random.Range(2, 3), 0, Random.Range(2, 3));
            agent.SetDestination(new Vector3(offset2.x, 0, offset2.z));
            timeRemaining = Random.Range(1, 4);
        }
    }
}
