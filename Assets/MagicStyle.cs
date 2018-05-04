using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicStyle : MonoBehaviour {

    public Button start;
    void Start()
    {
        start.enabled = false;
    }
    public void magicStyle(Dropdown style)
    {
        
        if (style.value != 0)
        {
            start.enabled = true;
            if (style.value == 1)
            {
                PlayerPrefs.SetString("MagicStyle", "Flame");
            }else if (style.value == 2)
            {
                PlayerPrefs.SetString("MagicStyle", "Water");
            }
            else if (style.value == 3)
            {
                PlayerPrefs.SetString("MagicStyle", "Wind");
            }
            else if (style.value == 4)
            {
                PlayerPrefs.SetString("MagicStyle", "Land");
            }

        }
        else
        {
            start.enabled = false;
        }
    }
}
