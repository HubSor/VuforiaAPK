using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject ui;
    public Text kawalekuizciekawostka;
    public Touch Firsttouch;

    public void Wyswietlciekwersjaostateczna()
    {
        var temp = GameObject.FindGameObjectsWithTag("Przedmiot");
        if (temp.Any(x => x.GetComponent<Renderer>().enabled))
        {
            kawalekuizciekawostka.gameObject.SetActive(!kawalekuizciekawostka.gameObject.activeInHierarchy);
        }
    }

    private void FixedUpdate()
    {
        var temp = GameObject.FindGameObjectsWithTag("Przedmiot");
        if (temp.Any(x => x.GetComponent<Renderer>().enabled))
        {
            ui.SetActive(true);
            var t = temp.First(x => x.GetComponent<Renderer>().enabled);
            kawalekuizciekawostka.text = t.GetComponent<text>().tekstciekawostki;
        }
        else
        {
            ui.SetActive(false);
            kawalekuizciekawostka.gameObject.SetActive(false);
        }
        // If there are two touches on the device...
#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        //Check if Input has registered more than zero touches
        if (Input.touchCount == 1)
        {
            //Store the first touch detected.
            Touch myTouch = Input.touches[0];

            //Check if the phase of that touch equals Began
            if (myTouch.phase == TouchPhase.Began)
            {
                //If so, set touchOrigin to the position of that touch
                Firsttouch = myTouch;
            }

            //If the touch phase is not Began :
            else if (myTouch.phase == TouchPhase.Moved && myTouch.phase != TouchPhase.Stationary)
            {
                //Set touchEnd to equal the position of this touch
                Vector2 delta = Firsttouch.position - myTouch.position;

                delta.Normalize();
                delta = delta * 2;
                //delta = camera.InverseTransformDirection (delta);
                temp.FirstOrDefault(x => x.GetComponent<Renderer>().enabled).transform.Rotate(-delta * 6);
                Firsttouch = myTouch;
            }
        }
        if (Input.touchCount >= 2)
        {

            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);


            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            deltaMagnitudeDiff = deltaMagnitudeDiff / 150;

            temp.FirstOrDefault(x => x.GetComponent<Renderer>().enabled).transform.localScale += new Vector3(1, 1, 1)* deltaMagnitudeDiff;


        }
#endif
    }
}
