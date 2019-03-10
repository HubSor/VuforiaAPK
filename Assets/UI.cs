using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	public Touch[] Touches; 
    public GameObject ui;
	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f; // The rate of change of the orthographic size in orthographic mode.
    public Text kawalekuizciekawostka;
 
    public void Wyswietlciekwersjaostateczna()
    {
        kawalekuizciekawostka.gameObject.SetActive(!kawalekuizciekawostka.gameObject.activeInHierarchy);
    }
    
    

    public void RotateRight()
	{
		GameObject.FindGameObjectWithTag("Przedmiot")?.transform?.Rotate(new Vector3(0, 45));
	}

	public void RotateLeft()
	{
		GameObject.FindGameObjectWithTag("Przedmiot")?.transform?.Rotate(new Vector3(0,-45));
	}

	public Camera camera;

    private void FixedUpdate()
    {
		Touches=Input.touches;
        if (GameObject.FindGameObjectWithTag("Przedmiot") != null)
        {
            ui.SetActive(true);
            kawalekuizciekawostka.text = GameObject.FindGameObjectWithTag("Przedmiot").GetComponent<text>().tekstciekawostki;
        }
        else ui.SetActive(false);
		// If there are two touches on the device...
		if (Input.touchCount == 2)
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

			// If the camera is orthographic...
			if (camera.orthographic)
			{
				// ... change the orthographic size based on the change in distance between the touches.
				camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

				// Make sure the orthographic size never drops below zero.
				camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
			}
			else
			{
				// Otherwise change the field of view based on the change in distance between the touches.
				camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

				// Clamp the field of view to make sure it's between 0 and 180.
				camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
			}
		}

	}
	


}
