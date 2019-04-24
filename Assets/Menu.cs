using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Menu : MonoBehaviour
{
    GameObject UIon,startmenu,EXITON;
    public void Startbutton()
    {
        UIon = GameObject.Find("UIVuf");
        startmenu = GameObject.Find("menu");
        EXITON = GameObject.Find("exitbutton");
        startmenu.SetActive(false);
        EXITON.SetActive(true);
        UIon.SetActive(true);
    }
}