using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

private void FixedUpdate()
{
    transform.LookAt(target);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
