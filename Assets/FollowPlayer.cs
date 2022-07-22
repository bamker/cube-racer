using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()   // called once per frame
    {
        transform.position = player.position + offset;
    }
}
