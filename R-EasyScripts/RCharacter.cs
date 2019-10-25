using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RCharacter : MonoBehaviour
{
    public ArrayList arrayList2 = new ArrayList();
    public int moves = 0;
    public bool flag = true;
    public bool MoveOnToNextRound = false;
    public bool isTouched = false;
    public ParticleSystem Rain;
    public ParticleSystem Snow;
    public ParticleSystem VenomSpell2;
    public ParticleSystem Ring;

    public int xtile = 0;
    public int ztile = 0;

    private static int n;
    public int ClearMeter = 0; //clearmeter depends on number of moves. if moves = 3 then 3/3 to clear
    RNewBehaviourScript scriptInstance = null;
    RCameraPerspective scriptInstance2 = null;
    RGameoverManager scriptInstanceGameOver = null;

    public bool isOver = false;
    public bool timerstop = false;


    //music
    public AudioClip clip1;
    public AudioSource MusicSource;
    public AudioClip clip2;
    public AudioSource MusicSource2;
    public bool touchytouchy;
    void Start()
    {
        VenomSpell2.Stop();
        MusicSource.clip = clip1;
        MusicSource2.clip = clip2;
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 1.0f);

    }
    void Update()
    {
        n = RNewBehaviourScript.m;
        if (n == 3 && flag == true)
        {
            GameObject tempObj = GameObject.Find("Sphere");
            scriptInstance = tempObj.GetComponent<RNewBehaviourScript>();
            GameObject tempObj2 = GameObject.Find("Main Camera");
            scriptInstance2 = tempObj2.GetComponent<RCameraPerspective>();
            GameObject tempObj3 = GameObject.Find("Canvas");
            scriptInstanceGameOver = tempObj3.GetComponent<RGameoverManager>();
            //Access playerScore variable from ScriptA

            flag = false;
        }

    }
    private void LateUpdate() //ADD in a move counter to loop
    {
        if (scriptInstance == null)
        {
            Debug.Log("Its null");
        }
        else
        {

            if (ClearMeter < Mathf.Floor(scriptInstance.moves123))
            {

                if (scriptInstance2.isTouched == true && scriptInstance.canMove == true && scriptInstanceGameOver.gameOver == false)
                {
                    gameObject.GetComponent<Renderer>().enabled = true;
                    transform.position = new Vector3(xtile, 0, ztile);
                    Vector3 newPosition;
                    newPosition = gameObject.transform.position;
                    arrayList2.Add(newPosition);


                    if ((arrayList2[moves].Equals(scriptInstance.arrayList[moves])))
                    {
                        Debug.Log("same");
                        ClearMeter += 1;
                        Ring.Play();
                        MusicSource2.Play();

                    }
                    else
                    {
                        Debug.Log("nope");
                        isOver = true;
                       

                    }
                    moves += 1;
                }

            }
            if (ClearMeter > Mathf.Floor(scriptInstance.moves123 - 1)) // get number of moves for that round
            {
                touchytouchy = false;
                timerstop = true;
                MusicSource.Play();
                RScoreManager.score += (int)(1);
                RScoreboardManager.score += (int)(1);
                starscount.score += (int)(1);
                ClearMeter = 0;
                VenomSpell2.Play();
                StartCoroutine(Example());


            }

        }
        //if (ScoreManager.score >= 0 && ScoreManager.score < 1)
        //{
        //Debug.Log("score is 0 ");
        //}
        //if (ScoreManager.score >= 1 && ScoreManager.score < 10)
        //{
        //Debug.Log("score is 1");

        //}
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(1.2f);
        gameObject.GetComponent<Renderer>().enabled = false;
        MoveOnToNextRound = true;
        timerstop = false;
        Debug.Log("ring ring");

    }


}