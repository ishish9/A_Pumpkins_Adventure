using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public delegate void Collect(int type);
    public static event Collect OnInventoryItemCollect;
    public ItemType itemtype;
    [SerializeField] private bool CustomRotation = false;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnInventoryItemCollect((int)itemtype);
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (CustomRotation)
        {
            transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Rotate(0, 200 * Time.deltaTime, 0, Space.Self);
        }
    }
}
