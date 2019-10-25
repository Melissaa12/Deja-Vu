using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;        // The player's score.
    public int highscore;
    Text text;                      // Reference to the Text component.



    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
        //highscore = PlayerPrefs.GetInt("highscore", highscore);
    }


    void Update()
    {
        text.text = text.text = "" + score; //+ "\r\nHighscore: " + highscore;

 

    }
}
