using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNewBehaviourScript : MonoBehaviour
{
    private float movementDuration = 1.5f; // the lower the faster
    private bool hasArrived = false;
    public bool canMove = false;
    public bool secondround = false;
    public bool endParticle = true;

    public ParticleSystem VenomSpell;
    public ParticleSystem ParticleSystem;

    public ArrayList arrayList2x = new ArrayList();
    public ArrayList arrayList2z = new ArrayList();
    private float EscapeLoop = 0;
    public float moves123 = 3.0f;
    public Vector3 currentPosition;
    float i = 0f;
    public static int m = 0;
    public ArrayList arrayList = new ArrayList();
    public ArrayList arrayList2 = new ArrayList();
    public ArrayList arrayListx = new ArrayList();
    public ArrayList arrayListz = new ArrayList();
    public ArrayList xcoord = new ArrayList();
    public ArrayList zcoord = new ArrayList();
    public Renderer rend;
    public int x = 0;
    public int lastitem = 2;
    //private bool isFinished = false;
    private float timer = 0f;
    private float timerMax = 0.1f; //seconds before character can move
    RCharacter script2Instance = null;

    private float randomO = 1;
    private bool vertical = true;


    void Start()
    {
        VenomSpell.Stop();
        ParticleSystem.Stop();

        moves123 = PlayerPrefs.GetFloat("moves123");
        movementDuration = PlayerPrefs.GetFloat("movementDuration");

    }
    private void Update()
    {

        //if moveontonextround=true then i=0 
        GameObject tempObj = GameObject.Find("Character");
        script2Instance = tempObj.GetComponent<RCharacter>();
        if (script2Instance.MoveOnToNextRound == true)
        {
            i = 0.0f;
            x = 0;
            m = 0;
            hasArrived = false;
            canMove = false;
            secondround = true;
            timer = 0f;
            moves123 += 0.2f;

            movementDuration -= 0.05f;
            if (movementDuration <= 1.1f)
            {
                movementDuration = 1.1f;
            }
            VenomSpell.Stop();
            endParticle = true;
            if (moves123 < 0)
            {
                randomO = 1;
                vertical = true;
                Debug.Log(randomO);
            }
            if (moves123 >= 5)
            {
                randomO = Random.Range(0, 2);
                Debug.Log(randomO);
                GameObject PlaneObj = GameObject.Find("Plane");

                if (randomO == 1) //vertical
                {
                    if (vertical == false)
                    {
                        PlaneObj.transform.Rotate(0, 90, 0, Space.World);
                        vertical = true;
                    }
                    else
                    {
                        PlaneObj.transform.Rotate(0, 0, 0, Space.World);
                        vertical = true;

                    }
                }
                if (randomO == 0) //horizontal
                {
                    if (vertical == false)
                    {
                        PlaneObj.transform.Rotate(0, 0, 0, Space.World);
                        vertical = false;
                    }
                    else
                    {
                        PlaneObj.transform.Rotate(0, 90, 0, Space.World);
                        vertical = false;

                    }
                }
            }

            script2Instance.MoveOnToNextRound = false;

        }
        if (!hasArrived && i == 0.0f)  //1st round 1st move, not origin, 2nd round 2nd move, not same
        {
            gameObject.GetComponent<Renderer>().enabled = true;

            //gameObject.GetComponent<Renderer>().material.color = new Color(147, 176, 145, 255);
            // make ball original colour
            hasArrived = true;
            {


                float randX = Random.Range(0, 3);
                float randZ = Random.Range(0, 3);
                if (secondround == false && randX == 0 && randZ == 0)
                {
                    randX = Random.Range(1, 3);
                    randZ = Random.Range(0, 3);

                }

                if (secondround == true)
                {
                    while (EscapeLoop == 0)
                    {
                        arrayList2x.Add(randX);
                        arrayList2z.Add(randZ);
                        if (arrayList2x[0].Equals(arrayListx[arrayListx.Count - 1]) && (arrayList2z[0].Equals(arrayListz[arrayListz.Count - 1]))) //change depending on moves
                        {

                            arrayList2x.RemoveAt(arrayList2x.Count - 1); //???
                            arrayList2z.RemoveAt(arrayList2z.Count - 1); //???
                            randX = Random.Range(1, 3);
                            randZ = Random.Range(0, 3);

                            //arrayList2x.Clear();
                            //arrayList2z.Clear();
                            EscapeLoop = 0;
                        }

                        else
                        {



                            EscapeLoop = 1;

                        }
                    }
                }
                arrayList2x.Clear();
                arrayList2z.Clear();
                arrayListx.Clear();
                arrayListz.Clear();
                arrayListx.Add(randX);
                arrayListz.Add(randZ);

                //change move to teleport
                //StartCoroutine(MoveToPoint(new Vector3(randX, 0, randZ)));
                VenomSpell.Play();
                ParticleSystem.Play();
                StartCoroutine(Wait());

                transform.position = new Vector3(randX, 0, randZ);


                if (randomO == 0)
                {
                    Vector3 newPosition;
                    newPosition = gameObject.transform.position;
                    newPosition[2] = 2 - newPosition[2];   //convert to negative coordinates

                    arrayList.Add(newPosition);
                }
                if (randomO == 1)
                {
                    Vector3 newPosition;
                    newPosition = gameObject.transform.position;
                    newPosition[0] = 2 - newPosition[0];   //convert to negative coordinates

                    arrayList.Add(newPosition);
                }


            }
        }
        if (!hasArrived && i >= 1.0f && i < Mathf.Floor(moves123))  //2nd move onwards,no repeat
        {
            hasArrived = true;
            {
                float randX = Random.Range(0, 3);
                float randZ = Random.Range(0, 3);
                arrayListx.Add(randX);
                arrayListz.Add(randZ);
                //Debug.Log(arrayListx[x]);
                //Debug.Log(arrayListx[x + 1]);
                //Debug.Log(arrayListz[x]);
                //Debug.Log(arrayListz[x + 1]);

                while (EscapeLoop == 0)
                {



                    if (arrayListx[x].Equals(arrayListx[x + 1]) && (arrayListz[x].Equals(arrayListz[x + 1])))
                    {


                        //HAVE TO REMOVE THE ADDED X AND Z
                        //generate a new random 
                        arrayListx.RemoveAt(arrayListx.Count - 1);
                        arrayListz.RemoveAt(arrayListz.Count - 1);
                        randX = Random.Range(1, 3);
                        randZ = Random.Range(0, 3);
                        arrayListx.Add(randX);
                        arrayListz.Add(randZ);
                        EscapeLoop = 0;

                    }
                    else
                    {
                        x += 1;
                        EscapeLoop = 1;

                    }
                }
                StartCoroutine(MoveToPoint(new Vector3(randX, 0, randZ)));

            }

        }
        if (!hasArrived && i == Mathf.Floor(moves123)) //change depending on number of moves
        {//have to change previous if i value also
            script2Instance.touchytouchy = true;
            timer += Time.deltaTime;
            if (timer < timerMax && endParticle == true)
            {
                gameObject.GetComponent<Renderer>().enabled = false;

                endParticle = false;

            }

            if (timer >= timerMax)
            {
                canMove = true;
                //gameObject.GetComponent<Renderer>().material.color = new Color(147, 176, 145, 0);
                //make ball transparent
                hasArrived = true;

            }

        }



    }
    private IEnumerator MoveToPoint(Vector3 targetPos)
    {


        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }
        VenomSpell.Play();
        yield return new WaitForSeconds(0.5f);


        if (randomO == 0)
        {
            Vector3 newPosition;
            newPosition = gameObject.transform.position;
            newPosition[2] = 2 - newPosition[2];   //convert to negative coordinates

            arrayList.Add(newPosition);
        }
        if (randomO == 1)
        {
            Vector3 newPosition;
            newPosition = gameObject.transform.position;
            newPosition[0] = 2 - newPosition[0];   //convert to negative coordinates

            arrayList.Add(newPosition);
        }

        m = 3;
        i += 1.0f;
        hasArrived = false;
        EscapeLoop = 0;
        secondround = true;

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        VenomSpell.Stop();
        m = 3;
        i += 1.0f;
        hasArrived = false;
        EscapeLoop = 0;
        secondround = true;

    }
}