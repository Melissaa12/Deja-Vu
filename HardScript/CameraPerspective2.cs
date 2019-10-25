using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspective2 : MonoBehaviour
{
    // Start is called before the first frame update
    Character2 scriptInstance = null;
    NewBehaviourScript2 scriptCantouch = null;

    public bool isTouched = false;
    int code;

    void Start()
    {
        GameObject tempObj = GameObject.Find("Character");
        scriptInstance = tempObj.GetComponent<Character2>();
        GameObject tempObj2 = GameObject.Find("Sphere");
        scriptCantouch = tempObj2.GetComponent<NewBehaviourScript2>();

    }

    // Update is called once per frame
    void Update()
    {
        if (scriptCantouch.canMove == true)
        {
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)&&(scriptInstance.touchytouchy == true))
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if (raycastHit.collider.gameObject.name == "Cube" && code != 1)
                    {

                        scriptInstance.xtile = 0;
                        scriptInstance.ztile = 0;
                        code = 1;
                        isTouched = true;
                    }
                    if (raycastHit.collider.gameObject.name == "Cube2" && code != 2)
                    {

                        scriptInstance.xtile = 0;
                        scriptInstance.ztile = 1;
                        code = 2;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube3" && code != 3)
                    {

                        scriptInstance.xtile = 0;
                        scriptInstance.ztile = 2;
                        code = 3;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube4" && code != 4)
                    {

                        scriptInstance.xtile = 1;
                        scriptInstance.ztile = 0;
                        code = 4;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube5" && code != 5)
                    {

                        scriptInstance.xtile = 1;
                        scriptInstance.ztile = 1;
                        code = 5;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube6" && code != 6)
                    {

                        scriptInstance.xtile = 1;
                        scriptInstance.ztile = 2;
                        code = 6;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube7" && code != 7)
                    {

                        scriptInstance.xtile = 2;
                        scriptInstance.ztile = 0;
                        isTouched = true;
                        code = 7;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube8" && code != 8)
                    {

                        scriptInstance.xtile = 2;
                        scriptInstance.ztile = 1;
                        code = 8;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube9" && code != 9)
                    {

                        scriptInstance.xtile = 2;
                        scriptInstance.ztile = 2;
                        code = 9;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube10" && code != 10)
                    {

                        scriptInstance.xtile = 0;
                        scriptInstance.ztile = 3;
                        code = 10;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube11" && code != 11)
                    {

                        scriptInstance.xtile = 1;
                        scriptInstance.ztile = 3;
                        code = 11;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube12" && code != 12)
                    {

                        scriptInstance.xtile = 2;
                        scriptInstance.ztile = 3;
                        code = 12;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube15" && code != 13)
                    {

                        scriptInstance.xtile = 3;
                        scriptInstance.ztile = 1;
                        code = 13;

                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube14" && code != 14)
                    {

                        scriptInstance.xtile = 3;
                        scriptInstance.ztile = 2;
                        code = 14;

                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube13" && code != 15)
                    {

                        scriptInstance.xtile = 3;
                        scriptInstance.ztile = 3;
                        code = 15;
                        isTouched = true;

                    }
                    if (raycastHit.collider.gameObject.name == "Cube16" && code != 16)
                    {

                        scriptInstance.xtile = 3;
                        scriptInstance.ztile = 0;
                        code = 16;
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