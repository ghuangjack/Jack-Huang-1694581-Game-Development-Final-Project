using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour {
    public GameObject dark;
	// Use this for initialization
	void Start () {
        dark = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            if (PlayerPrefs.GetString("MagicStyle") == "Flame")
            {
                Point.point -= 2;
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Water")
            {
                Point.point -= 3;
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Wind")
            {
                Point.point -= 4;
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Land")
            {
                Point.point -= 1;
            }
            Destroy(otherObject.gameObject);
        }else if(otherObject.gameObject.layer == LayerMask.NameToLayer("Cage") && Game.defense == true)
        {
            Destroy(dark);
        }
    }
}
