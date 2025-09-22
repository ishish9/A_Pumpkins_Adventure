using UnityEngine;

public class CoinMultiple : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public delegate void ScoreEvent(int gold);
    public static event ScoreEvent OnScore;
    [SerializeField] private int goldAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            OnScore(goldAmount);
            Destroy(gameObject);                       
        }
    }
}
