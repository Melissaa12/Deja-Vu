using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverManager2 : MonoBehaviour
{
    public GameObject CanvasObject;
    public GameObject CanvasGameObject;
    public bool gameOver = false;

    public bool isShowing = false;
    Character2 scriptInstance8 = null;
    TimerHard scriptInstance7 = null;

    //music
    private bool runOnce = true;
    public AudioClip clip3;
    public AudioSource MusicSource3;
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 1.0f);

        CanvasObject.GetComponent<Canvas>().enabled = false;
        GameObject tempObj = GameObject.Find("Character");
        scriptInstance8 = tempObj.GetComponent<Character2>();
        GameObject tempObj2 = GameObject.Find("Timer");
        scriptInstance7 = tempObj2.GetComponent<TimerHard>();
        MusicSource3.clip = clip3;

    }

    // Update is called once per frame
    void Update()
    {
        if (scriptInstance8.isOver == true || scriptInstance7.isOver == true) 
        {
            CanvasObject.GetComponent<Canvas>().enabled = true;
            gameOver = true;
            if (runOnce == true)
            {
                Debug.Log("game is over");
                MusicSource3.Play();
                runOnce = false;
            }
        }
    }
}
