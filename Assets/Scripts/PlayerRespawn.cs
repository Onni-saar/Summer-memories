using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
   public float threshold;
   public static int lives = 3;
   public TextMeshProUGUI livesText;

   public TextMeshProUGUI coinText;

   public TextMeshProUGUI YouLoseText;

   void FixedUpdate()
   {
      if (transform.position.y < threshold)
      {
         lives--;
         transform.position = new Vector3(0.22f, 4.32f, 1.25f);
         livesText.text = "Lives: " + lives.ToString();
         Debug.Log(lives);
         if (lives <= 0)
         {
            Debug.Log("Game Over");
            CoinCollection.Coin = 0;
            coinText.text = "Coin: " + CoinCollection.Coin.ToString();
            Debug.Log(CoinCollection.Coin);
            YouLoseText.gameObject.SetActive(true);
            lives = 3;
            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }  
      }
   }
}
