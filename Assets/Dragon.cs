using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragon : MonoBehaviour {
    Animator animator;
    float speed;
    float duration = 2.0f;
    public float time=3.5f;
    float timer = 0,duri=0;
    int count = 0;
    public GameObject dragon;
    public GameObject dark;
    bool finAttack=false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        GameObject dragonShoot;
        if (timer >= time)
        {
            dragonShoot = Instantiate(dark, transform.position, Quaternion.identity);
            dragonShoot.GetComponent<ShootInfo>().SetDirection(Vector2.left);
            timer = 0;
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            if (PlayerPrefs.GetString("MagicStyle") == "Flame")
            {
                count++;
                if (count >= 10)
                {
                    dragonLoses();
                }
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Water")
            {
                count++;
                if (count >= 15)
                {
                    dragonLoses();
                }
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Wind")
            {
                count++;
                if (count >= 12)
                {
                    dragonLoses();
                }
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Land")
            {

                count++;
                if (count >= 4)
                {
                    dragonLoses();
                }
            }
        }

    }
    
    
    public void dragonLoses()
    {
        if (Point.point > 0)
        {
            Destroy(dragon);
            SceneManager.LoadScene("Win");
        }
    }
}
