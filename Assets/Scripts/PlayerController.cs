using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    float xInput;
    float yInput;
    int score = 0;
    public int winScore;
    public GameObject winText;
    public Transform player;
    public Vector3 offset;
    
    // Add this reference to your joystick
    public FixedJoystick joystick;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(transform.position.y < -5f)
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void FixedUpdate()
    {
        // Get input from joystick if assigned, otherwise use keyboard
        if (joystick != null)
        {
            xInput = joystick.Horizontal;
            yInput = joystick.Vertical;
            
            // Debug to see if joystick is working
            if (Mathf.Abs(xInput) > 0.1f || Mathf.Abs(yInput) > 0.1f)
            {
                Debug.Log($"Joystick Input: X={xInput:F2}, Y={yInput:F2}");
            }
        }
        else
        {
            // Fallback to keyboard
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
        }
        
        rb.AddForce(xInput * speed * 3, 0, yInput * speed * 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            score++;
            if (score >= winScore)
            {
                winText.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
