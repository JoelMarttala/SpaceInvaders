using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    public GameObject player;
    public float speed;
    public GameObject ammoSpawn;
    public GameObject ammo;
    public int health;

    public float cooldown;
    float canFire;



    // Use this for initialization
    void Start () {
        canFire = 0;

    }

    // Update is called once per frame
    void Update () {
        float movement = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(movement, 0) * speed;

        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }

    
    }
    void OnCollisionEnter2D(Collision2D damage)
    {

        if (damage.gameObject.tag == "EnemyAmmo")
        {
            
            health = health -1;

            if (health == 0)
            {   

                Die();
            }

        }
        if (damage.gameObject.tag == "Flock")
        {
            Die();
        }



    }
    void Die()
    {
        Destroy(gameObject, 0);
        SceneManager.LoadScene("Retry");

    }
    void Shoot()
    {
        if (Time.time > canFire)
        {
            canFire = Time.time + cooldown;
            GameObject ammoInstance = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);

            ammoInstance.GetComponent<Rigidbody2D>().AddForce(ammoSpawn.transform.up * 5, ForceMode2D.Impulse);
        }
    }
   

       


    }
   



