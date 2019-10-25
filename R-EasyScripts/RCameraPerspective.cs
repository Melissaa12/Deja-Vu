using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCameraPerspective : MonoBehaviour
{
    // Start is called before the first frame update
    RCharacter scriptInstance = null;
    RNewBehaviourScript scriptCantouch = null;
    public bool isTouched = false;
    int code;

    void Start()
    {
        GameObject tempObj = GameObject.Find("Character");
        scriptInstance = tempObj.GetComponent<RCharacter>();
        GameObject tempObj2 = GameObject.Find("Sphere");
        scriptCantouch = tempObj2.GetComponent<RNewBehaviourScript>();

    }

    // Update is called once per frame
    void Update()
    {

        if (scriptCantouch.canMove == true)
        {
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) && (scriptInstance.touchytouchy == true))
            {

                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if (raycastHit.collider.gameObject.name == "Cube" && code != 1)
                    {

                        scriptInstance.xtile = 0;
                        scriptInstance.ztile = 0;
                        Debug.Log("one");
                        code = 1;

                        isTouched = true;
                    }
                    if (raycastHit.collider.gameObject.name == "Cube2" && code != 2)
                    {

                        scriptInstance.xtile = 0;
                        scriptInstance.ztile = 1;
                        Debug.Log("two");
                        code = 2;

                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube3" && code != 3)
                    {

                        scriptInstance.xtile = 0;
                        scriptInstance.ztile = 2;
                        Debug.Log("three");
                        code = 3;

                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube4" && code != 4)
                    {

                        scriptInstance.xtile = 1;
                        scriptInstance.ztile = 0;
                        Debug.Log("four");
                        code = 4;

                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube5" && code != 5)
                    {

                        scriptInstance.xtile = 1;
                        scriptInstance.ztile = 1;
                        Debug.Log("five");
                        code = 5;

                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube6" && code != 6)
                    {

                        scriptInstance.xtile = 1;
                        scriptInstance.ztile = 2;
                        Debug.Log("six");
                        code = 6;

                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube7" && code != 7)
                    {

                        scriptInstance.xtile = 2;
                        scriptInstance.ztile = 0;
                        isTouched = true;
                        Debug.Log("seven");
                        code = 7;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube8" && code != 8)
                    {

                        scriptInstance.xtile = 2;
                        scriptInstance.ztile = 1;
                        Debug.Log("eight");
                        code = 8;

                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube9" && code != 9)
                    {

                        scriptInstance.xtile = 2;
                        scriptInstance.ztile = 2;
                        Debug.Log("nine");
                        code = 9;

                        isTouched = true;

                    }
                }
            }
            else
            {
                isTouched = false;

            }
        }

    }
}