using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;
    private Vector3 previousPosition;
    private Quaternion targetRotation;
    private Vector3 targetPosition;
    private Vector3 currentVelocity;
    private float currentRotVel;

    // Start is called before the first frame update
    private void Start()
    {
        previousPosition = player.position;
        offset = transform.position - previousPosition * 2f;
        
        // Add height to the camera offset
        offset.y += 4f; // Adjust this value to control how much higher the camera should be
        offset.z += -2f;
        targetRotation = transform.rotation;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        var position = player.position;
        // direction is simply the delta between last and this frame positions
        var direction = position - previousPosition;
        previousPosition = position;

        if (direction != Vector3.zero)
        {
            // look in move direction
            targetRotation = Quaternion.LookRotation(direction);
            // apply offset in move direction
            targetPosition = position + targetRotation * offset;
        }

        // [optional] smoothly move into position and rotation
        transform.rotation = QuaternionUtils.SmoothDamp(transform.rotation, targetRotation, ref currentRotVel, 0.5f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 0.5f);
    }
}

// little helper for a SmoothDamp equivalent for Quaternion
public static class QuaternionUtils
{
    public static Quaternion SmoothDamp(Quaternion from, Quaternion to, ref float currentAngularVelocity, float smoothTime)
    {
        var delta = Quaternion.Angle(from, to);
        if (delta > 0f)
        {
            var t = Mathf.SmoothDampAngle(delta, 0.0f, ref currentAngularVelocity, smoothTime);
            t = 1.0f - t / delta;
            return Quaternion.Slerp(from, to, t);
        }

        return to;
    }
}