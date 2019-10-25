using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Character3 : MonoBehaviour
{
    public ArrayList arrayList2 = new ArrayList();
    public int moves = 0;
    public bool flag = true;
    public bool MoveOnToNextRound = false;
    public bool isTouched = false;

    public ParticleSystem VenomSpell2;
    public ParticleSystem Ring;

    public int xtile = 0;
    public int ztile = 0;

    private static int n;
    public int ClearMeter = 0; //clearmeter depends on number of moves. if moves = 3 then 3/3 to clear
    NewBehaviourScript3 scriptInstance = null;
    CameraPerspective3 scriptInstance2 = null;
    GameoverManager3 scriptInstanceGameOver = null;

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
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 1.0f);

        VenomSpell2.Stop();
        MusicSource.clip = clip1;
        MusicSource2.clip = clip2;


    }
    void Update()
    {
        n = NewBehaviourScript3.m;
        if (n == 3 && flag == true)
        {
            GameObject tempObj = GameObject.Find("Sphere");
            scriptInstance = tempObj.GetComponent<NewBehaviourScript3>();
            GameObject tempObj2 = GameObject.Find("Main Camera");
            scriptInstance2 = tempObj2.GetComponent<CameraPerspective3>();
            GameObject tempObj3 = GameObject.Find("Canvas");
            scriptInstanceGameOver = tempObj3.GetComponent<GameoverManager3>();
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
                    gameObject.GetComponent<Light>().enabled = true;

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
                ScoreManager.score += (int)(1);
                ScoreboardManager3.score += (int)(1);
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
        gameObject.GetComponent<Light>().enabled = false;

        MoveOnToNextRound = true;
        timerstop = false;


    }


}