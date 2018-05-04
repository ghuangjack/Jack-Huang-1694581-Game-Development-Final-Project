using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Point : MonoBehaviour {
    public static int point = 100;
    public Text text;
    public string ChangeNum(int point)
    {
        string realPoint = point.ToString();
        return realPoint;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = ChangeNum(point);
        if (point <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
