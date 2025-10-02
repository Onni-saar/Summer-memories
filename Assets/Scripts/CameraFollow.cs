using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        Vector3 moveDirection = playerRb.linearVelocity;
        if (moveDirection.sqrMagnitude > 0.1f)
        {
            moveDirection.y = 0; // Ignore vertical movement
            moveDirection.Normalize();
            Vector3 desiredPosition = player.position - moveDirection * offset.z + Vector3.up * offset.y;
            transform.position = desiredPosition;
            transform.LookAt(player.position, Vector3.up);
        }
        else
        {
            // If not moving, stay at default offset behind player
            transform.position = player.position - player.forward * offset.z + Vector3.up * offset.y;
            transform.LookAt(player.position, Vector3.up);
        }
    }
}