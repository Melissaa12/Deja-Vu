using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RScoreManager : MonoBehaviour
{
    public static int score = 0;        // The player's score.
    public int highscore;
    Text text;                      // Reference to the Text component.



    void Awake()
    {
        text = GetComponent<Text>();
        score = PlayerPrefs.GetInt("ContScore");

        //highscore = PlayerPrefs.GetInt("highscore", highscore);
    }


    void Update()
    {
        text.text = text.text = "" + score; //+ "\r\nHighscore: " + highscore;



    }
}
