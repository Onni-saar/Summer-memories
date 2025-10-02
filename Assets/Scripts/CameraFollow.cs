using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothTime = 0.2f;
    private Rigidbody playerRb;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // Always follow behind the sphere's local forward direction
        Vector3 behindDirection = -player.forward;
        Vector3 desiredPosition = player.position + behindDirection * offset.z + Vector3.up * offset.y + player.right * offset.x;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.LookAt(player.position, Vector3.up);
    }
}