using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour {
    public GameObject cage,dark;
	// Use this for initialization
	void Start () {
        cage.GetComponent<GameObject>();
        dark.GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Game.defense == false)
        {
            DestroyImmediate(cage);
        }
	}
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.layer == LayerMask.NameToLayer("dark")&& Game.defense == true)
        {
            Destroy(dark);
        }
    }
}
