using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    public static int Coin = 0;
    public TextMeshProUGUI coinText;

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Coin")
        {
            Coin++;
            coinText.text = "Coin: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject);
        }
    }
}
