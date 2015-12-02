using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    static public int score = 10;

    void Awake()
    { // 1
      // If the ApplePickerHighScore already exists, read it
        if (PlayerPrefs.HasKey("MaxCoinsCollected"))
        { // 2
            score = PlayerPrefs.GetInt("MaxCoinsCollected");
        }
        // Assign the high score to ApplePickerHighScore
        PlayerPrefs.SetInt("MaxCoinsCollected", score); // 3
    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        // Update ApplePickerHighScore in PlayerPrefs if necessary
        if (score > PlayerPrefs.GetInt("MaxCoinsCollected"))
        { // 4
            PlayerPrefs.SetInt("MaxCoinsCollected", score);
        }
    }
}
