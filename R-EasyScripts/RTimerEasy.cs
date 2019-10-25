using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTimerEasy : MonoBehaviour
{
    public Image image2;
    float t = 0f;
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    public float x;

    public bool isOver = false;
    RNewBehaviourScript scriptInstance6 = null;
    RCharacter scriptInstance5 = null;

    //music
    private bool runOnce = true;
    public AudioClip clip4;
    public AudioSource MusicSource4;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 1.0f);

        GameObject tempObj = GameObject.Find("Sphere");
        scriptInstance6 = tempObj.GetComponent<RNewBehaviourScript>();
        GameObject tempObj2 = GameObject.Find("Character");
        scriptInstance5 = tempObj2.GetComponent<RCharacter>();
        MusicSource4.clip = clip4;

    }

    // Update is called once per frame
    void Update()
    {
        if (scriptInstance5.isOver == false && scriptInstance6.canMove == true && scriptInstance5.timerstop == false)
        {

            image2.transform.localScale = new Vector3(Mathf.Lerp(1, 0, t), 1, 1);
            t += (1 / (scriptInstance6.moves123 * 2)) * Time.deltaTime; // no. seconds = 1 divided by (time) 
            x = image2.GetComponent<Transform>().localScale.x;
            if (x < 0.3f && runOnce == true)
            {
                runOnce = false;
                MusicSource4.Play();

            }
            if (scriptInstance5.MoveOnToNextRound == true)
            {
                MusicSource4.Stop();
            }
            if (x == 0)
            {
                MusicSource4.Stop();

                isOver = true;
            }

        }
        if (scriptInstance6.canMove == false)
        {
            image2.transform.localScale = new Vector3(1, 1, 1);

            t = 0f;

            runOnce = true;

        }
        if (scriptInstance5.isOver == true)
        {
            MusicSource4.Stop();

        }


    }
}
//PROBLEM
//varied time for different no.moves