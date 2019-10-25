using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManager3 : MonoBehaviour
{
    public static int score = 2;        // The player's score.
    public int highscore;

    public Sprite bronzeStar;
    public Sprite silverStar;
    public Sprite goldStar;
    public Sprite platStar;
    GameObject yourimage;

    Text text;                      // Reference to the Text component.

    public Image image;
    public Image image2;

    float pongTime = 0.25f;
    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore3", highscore);
        yourimage = GameObject.Find("MedalImage"); // You can find that refference in any way you want, its just example.

    }


    void Update()
    {
        image2.transform.localScale = new Vector3(Mathf.PingPong(Time.time * pongTime, 0.25f) + 0.1f, Mathf.PingPong(Time.time * pongTime, 0.25f) + 0.1f, Mathf.PingPong(Time.time * pongTime, 0.25f) + 0.1f);
        image.transform.localScale = new Vector3(Mathf.PingPong(Time.time * pongTime, 0.25f) + 0.1f, Mathf.PingPong(Time.time * pongTime, 0.25f) + 0.1f, Mathf.PingPong(Time.time * pongTime, 0.25f) + 0.1f);
        text.text = text.text = "Score " + score + "\r\nBest " + highscore;
        PlayerPrefs.SetInt("ContScore", score);

        // Set the displayed text to be the word "Score" followed by the score value.
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("starsscore", score);

            PlayerPrefs.SetInt("highscore3", highscore);

        }
        if (highscore > 0)
        {
            yourimage.GetComponent<Image>().sprite = bronzeStar;

        }
        if (highscore > 10)
        {
            yourimage.GetComponent<Image>().sprite = silverStar;

        }
        if (highscore > 50)
        {
            yourimage.GetComponent<Image>().sprite = goldStar;

        }
        if (highscore > 100)
        {
            yourimage.GetComponent<Image>().sprite = platStar;
        }
    }
}
