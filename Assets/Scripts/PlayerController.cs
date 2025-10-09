using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

public float speed;

Rigidbody rb;

float xInput;

float yInput;

int score =0;

public int winScore;
public GameObject winText;
public Transform player;
public Vector3 offset;
public FixedJoystick fixedJoystick;
private void Awake()
{
    rb = GetComponent<Rigidbody>();
}
    // Update is called once per frame
    void Update()
    {
      if(transform.position.y < -5f)
      {
        SceneManager.LoadScene("Game");
      }
    }
    private void FixedUpdate()
    {
     xInput = Input.GetAxis("Horizontal");
     yInput = Input.GetAxis("Vertical");
     rb.AddForce(xInput * speed*3, 0, yInput* speed* 3);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            score++;
            if (score >= winScore)
            {
                //gamewin
                winText.SetActive(true);
                  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    void LateUpdate()
{
    transform.position = player.position + offset;
}

}
