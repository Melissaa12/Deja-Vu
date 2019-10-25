using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCrazy : MonoBehaviour
{
    public Image image2;
    float t = 0f;
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    public float x;

    public bool isOver = false;
    NewBehaviourScript3 scriptInstance6 = null;
    Character3 scriptInstance5 = null;

    //music
    private bool runOnce = true;
    public AudioClip clip4;
    public AudioSource MusicSource4;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 1.0f);

        GameObject tempObj = GameObject.Find("Sphere");
        scriptInstance6 = tempObj.GetComponent<NewBehaviourScript3>();
        GameObject tempObj2 = GameObject.Find("Character");
        scriptInstance5 = tempObj2.GetComponent<Character3>();
        MusicSource4.clip = clip4;

    }

    // Update is called once per frame
    void Update()
    {

        if (scriptInstance5.isOver == false && scriptInstance6.canMove == true && scriptInstance5.timerstop == false)
        {

            image2.transform.localScale = new Vector3(Mathf.Lerp(1, 0, t), 1, 1);
            t += (1 / (scriptInstance6.moves123 * 1.2f)) * Time.deltaTime; // no. seconds = 1 divided by (time) 
            x = image2.GetComponent<Transform>().localScale.x;
            Debug.Log(scriptInstance5.MoveOnToNextRound);
            if (x < 0.3f && runOnce == true)
            {
                runOnce = false;
                MusicSource4.Play();

            }

            if (x == 0)
            {
                MusicSource4.Stop();

                isOver = true;
                Debug.Log("times up");
            }
        }
        if (scriptInstance6.canMove == false)
        {
            image2.transform.localScale = new Vector3(1, 1, 1);
            MusicSource4.Stop();

            t = 0f;

            runOnce = true;
        }
        if (scriptInstance5.isOver == true)
        {
            Debug.Log("reach here");
            MusicSource4.Stop();

        }


    }

}
