using UnityEngine;
using UnityEngine.AI;



public class RatAi_V2 : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 offset = new Vector3(0,0,0);
    [SerializeField] private float timeRemaining = 5;
    [SerializeField] private Animator hit = null;
    [SerializeField] private Animator die = null;
    private controller playerController;
    private Transform startPosition;
    private bool grounded = false;
    private int hitCount;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = gameObject.transform;
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
            //agent.ResetPath();
            Vector3 offset2 = startPosition.position + new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4));
            agent.SetDestination(new Vector3(offset2.x, 0, offset2.z));
            timeRemaining = Random.Range(0, 2);
        }
    }
    void OnEnable()
    {
        controller.OnCheckGrounded += SetGrounded;
    }

    void OnDisable()
    {
        controller.OnCheckGrounded -= SetGrounded;
    }

    private void SetGrounded(bool b)
    {
        grounded = b;
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && !grounded)
        {
            hitCount++;
            hit.Play("rat_Hit", 0, 0.0f);
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.Rat_Hit);
            if (hitCount >= 3)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.audioClips.Rat_Death);
                die.Play("rat_Die", 0, 0.0f);
                Invoke("Death", 2);
            }
        }
    }
    public void Death()
    {
        gameObject.SetActive(false);
    }
}
