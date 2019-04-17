using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Menu : MonoBehaviour
{
    GameObject UIon,startmenu;
    public void Startbutton()
    {
        UIon = GameObject.Find("UIVuf");
        startmenu = GameObject.Find("menu");
        startmenu.SetActive(false);
        UIon.SetActive(true);
    }
}