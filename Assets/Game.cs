using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public float jumpSpeed = 500;
    bool slashAttack=false;
    float shootDuration = 0.3f, timer = 0;
    public float duri = 2.5f;
    float time;
    float jumpDuri = 0f;
    public GameObject player;
    public GameObject flameAttack;
    public GameObject waterAttack;
    public GameObject windAttack;
    public GameObject landAttack;
    public GameObject flameFin;
    public GameObject waterFin;
    public GameObject windFin;
    public GameObject landFin;
    public GameObject dark;
    public GameObject dragon;
    public GameObject cage;
    bool walk;
    bool slash;
    bool finAttack;
    bool Grounded;
    Animator Animator;
    Animator transAnimator;
    Rigidbody2D rigidBody2d;
    int getHit = 0;
    public static bool defense=false;

    // Use this for initialization
    void Start()
    {
        rigidBody2d = player.GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        transAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (defense == false)
        {
            moving();
            attack();
            Animator.SetBool("Walk", walk);
            Animator.SetBool("Slash", slash);
            Animator.SetBool("FinalAttack", finAttack);
        }
    }
    private void moving()
    {
        walk = Input.GetButton("Walk");
        float walking = Input.GetAxisRaw("Walk");
        if (Input.GetButton("Walk"))
        {
            if (PlayerPrefs.GetString("MagicStyle") == "Flame")
            {
                transform.position += new Vector3(60, 0, 0) * Time.deltaTime;
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Water")
            {
                transform.position += new Vector3(100, 0, 0) * Time.deltaTime;
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Wind")
            {
                transform.position += new Vector3(120, 0, 0) * Time.deltaTime;
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Land")
            {
                transform.position += new Vector3(40, 0, 0) * Time.deltaTime;
            }
        }
    }
    private void attack()
    {
        if (Input.GetButtonDown("Slash"))
        {
            float ing = Input.GetAxisRaw("Slash");
            if (PlayerPrefs.GetString("MagicStyle") == "Flame")
                {
                    GameObject shoot = Instantiate(flameAttack, transform.position, Quaternion.identity);
                    shoot.GetComponent<ShootInfo>().SetDirection(Vector2.right);
                    slashAttack = true;
                    transAnimator.SetBool("Slash", slash);
                    time = 0.0f;
                    if (slashAttack == true)
                    {
                        time += Time.deltaTime;
                        if (time > 3.0)
                        {
                            slashAttack = false;
                        }
                    }
                    transAnimator.SetBool("Slash", slash);
                }
                else if (PlayerPrefs.GetString("MagicStyle") == "Water")
                {
                    GameObject shoot = Instantiate(waterAttack, transform.position, Quaternion.identity);
                    shoot.GetComponent<ShootInfo>().SetDirection(Vector2.right);
                    slashAttack = true;
                    transAnimator.SetBool("Slash", slash);
                    time = 0.0f;
                    if (slashAttack == true)
                    {
                        time += Time.deltaTime;
                        if (time > 1.5)
                        {
                            slashAttack = false;
                        }
                    }
                    
                }
                else if (PlayerPrefs.GetString("MagicStyle") == "Wind")
                {
                    GameObject shoot = Instantiate(windAttack, transform.position, Quaternion.identity);
                    shoot.GetComponent<ShootInfo>().SetDirection(Vector2.right);
                    slashAttack = true;
                    transAnimator.SetBool("Slash", slash);
                    time = 0.0f;
                    if (slashAttack == true)
                    {
                        time += Time.deltaTime;
                        if (time > 2.0)
                        {
                            slashAttack = false;
                        }
                    }
                    
                }
                else if (PlayerPrefs.GetString("MagicStyle") == "Land")
                {
                    GameObject shoot = Instantiate(landAttack, transform.position, Quaternion.identity);
                    shoot.GetComponent<ShootInfo>().SetDirection(Vector2.right);
                    slashAttack = true;
                    transAnimator.SetBool("Slash", slash);
                    time = 0.0f;
                    if (slashAttack == true)
                    {
                        time += Time.deltaTime;
                        if (time > 5.0)
                        {
                            slashAttack = false;
                        }
                    }
                }
            }
        
        if (Input.GetButtonDown("FinalAttack"))
        {
            float ing = Input.GetAxisRaw("FinalAttack");
            if (PlayerPrefs.GetString("MagicStyle") == "Flame")
            {
                GameObject shoot = Instantiate(flameFin, transform.position, Quaternion.identity);
                shoot.GetComponent<ShootInfo>().SetDirection(Vector2.right);
                Point.point -= 5;
                finUpdater(shoot);
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Water")
            {
                GameObject shoot = Instantiate(waterFin, transform.position, Quaternion.identity);
                shoot.GetComponent<ShootInfo>().SetDirection(Vector2.right);
                Point.point -= 2;
                finUpdater(shoot);
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Wind")
            {
                GameObject shoot = Instantiate(windFin, transform.position, Quaternion.identity);
                shoot.GetComponent<ShootInfo>().SetDirection(Vector2.right);
                Point.point -= 3;
                finUpdater(shoot);
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Land")
            {
                GameObject shoot = Instantiate(landFin, transform.position, Quaternion.identity);
                shoot.GetComponent<ShootInfo>().SetDirection(Vector2.right);
                Point.point -= 7;
                finUpdater(shoot);
            }
        }
        if (Input.GetButtonDown("Defend"))
        {
            defense = true;
            if (PlayerPrefs.GetString("MagicStyle") == "Flame")
            {
                Point.point -= 5;
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
                Point.point -= 7;
            }
            Cage(cage);
        }
    }
    
    void finUpdater(GameObject shoot)
    {
        float time2 = 0;
        transAnimator.SetBool("FinalAttack", finAttack);
        time2 += Time.deltaTime;
        if (time2 > duri)
        {
            Destroy(shoot);
        }
    }
    void Cage(GameObject cage)
    {
        float time3 = 0.0f;
        if (defense == true)
        {
            GameObject shield = Instantiate(cage);
            shield.transform.position = player.transform.position;
            transform.position += new Vector3(0, 0, 0);
            time3 += Time.deltaTime;
            if (time3 >= 4.2)
            {
                defense = false;
                Destroy(shield);
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
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.layer == LayerMask.NameToLayer("dark"))
        {
            if (PlayerPrefs.GetString("MagicStyle") == "Flame")
            {
                if (defense == true)
                {
                    shield();
                }
                else
                {
                    Point.point -= 5;
                }
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Water")
            {
                if(defense == true)
                {
                    shield();
                }
                else
                {
                    Point.point -= 7;
                }
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Wind")
            {
                if (defense == true)
                {
                    shield();
                }
                else
                {
                    Point.point -= 8;
                }
            }
            else if (PlayerPrefs.GetString("MagicStyle") == "Land")
            {
                if (defense == true)
                {
                    shield();
                }
                else
                {
                    Point.point -= 3;
                }
            }
            Destroy(otherObject.gameObject);
        }
    }
    public void shield()
    {
        Point.point -= 0;
        getHit++;
        if (getHit >= 3 || defense == false)
        {
            defense = false;
        }
    }
}
        


        //void OnCollisionEnter2D(Collision2D otherObject)
        //{
        //    Debug.Log("HIT SOMETHING");
        //    if (otherObject.gameObject.layer == LayerMask.NameToLayer("dark"))
        //    {
        //        Debug.Log("DARK");
        //        if (PlayerPrefs.GetString("MagicStyle") == "Flame")
        //        {
        //            Point.point -= 3;
        //        }
        //        else if (PlayerPrefs.GetString("MagicStyle") == "Water")
        //        {
        //            Point.point -= 4;
        //        }
        //        else if (PlayerPrefs.GetString("MagicStyle") == "Wind")
        //        {
        //            Point.point -= 5;
        //        }
        //        else if (PlayerPrefs.GetString("MagicStyle") == "Land")
        //        {
        //            Point.point -= 1;
        //        }
        //    }
        //}
    
