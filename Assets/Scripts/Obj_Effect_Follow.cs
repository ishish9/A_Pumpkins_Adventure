using UnityEngine;

public class Obj_Effect_Follow : MonoBehaviour
{
    public Transform targetToFollow;
    [SerializeField] private float MoveWarp;
 
    private void Update()
    {
        transform.position = new Vector3(targetToFollow.transform.position.x, targetToFollow.transform.position.y, targetToFollow.transform.position.z + MoveWarp);
    }
}
