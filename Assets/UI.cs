using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public GameObject ui;

    public Camera c;

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Piotruś") != null) ui.SetActive(true);
        else ui.SetActive(false);
            

    }
    public void Zoomin()
    {
        c.fieldOfView = 35;
    }


}
