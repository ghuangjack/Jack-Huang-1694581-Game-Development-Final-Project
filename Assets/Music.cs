using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    bool lv50 = false;
    bool lv3 = false;
    bool lv2 = false;
    void Update () {
        if (Point.point <= 50 && lv50 == false)
        {
            GetComponents<AudioSource>()[0].Stop();
            GetComponents<AudioSource>()[1].Play();
            GetComponents<AudioSource>()[1].loop = GetComponents<AudioSource>()[1].isPlaying;
            lv50 = true;
        }
        if (Point.point <= 15 && lv3 == false)
        {
            GetComponents<AudioSource>()[1].Stop();
            GetComponents<AudioSource>()[2].Play();
            GetComponents<AudioSource>()[2].loop = GetComponents<AudioSource>()[2].isPlaying;
            lv3 = true;
        }
        if (Point.point <= 10 && lv2 == false)
        {
            GetComponents<AudioSource>()[2].Stop();
            GetComponents<AudioSource>()[3].Play();
            GetComponents<AudioSource>()[3].loop = GetComponents<AudioSource>()[3].isPlaying;
            lv2 = true;
        }
    }
}
