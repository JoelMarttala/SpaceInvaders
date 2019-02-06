using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    public static float speed;

    public float increase;
    public float drop;
    public GameObject enemy;
    public float health;
    public int rate;
   
    public GameObject enemyAmmo;
    public GameObject enemyAmmoSpawn;
    public GameObject flock;
   
    private bool canShoot;


	// Use this for initialization
	void Start () {
        speed = 0.4f;
        MoveRight();

	}
	
	// Update is called once per frame
	void Update () {

        Search();

		
	}
    void OnCollisionEnter2D(Collision2D touch)
    {   
        string obj = touch.gameObject.tag;
        switch(obj) 
        {   
            case ("RightBorder"):
                MoveDown();
                speed = speed + increase;
                MoveLeft();
                break;
            case ("LeftBorder"):
                MoveDown();
                speed = speed + increase;
                MoveRight();
                break;
            case ("PlayerAmmo"):
                health = health - 1;
                if (health == 0)
                {   
                    Destroy(gameObject, 0);
                }
                break;

            case ("Obstacle"):
                Destroy(gameObject, 0.01f);
                break;
            case ("Player"):
                Destroy(gameObject, 0);
                break;
            case("Ground"):
                SceneManager.LoadScene("Retry");
                break;
        }
    }
    void Search()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(enemyAmmoSpawn.transform.position, -Vector2.up*30);
        if (hit.collider.tag != "Enemy")
        {     
            canShoot = true;
            Shoot();
            canShoot = false;
        }

    }
    void Shoot()
    {   
        if(canShoot == true)
        {
            float random = Random.Range(0, rate);

            if (random == 10)
            {
                GameObject enemyAmmoInstance = Instantiate(enemyAmmo, enemyAmmoSpawn.transform.position, Quaternion.identity);

                enemyAmmoInstance.GetComponent<Rigidbody2D>().AddForce(-enemyAmmoSpawn.transform.up * 5, ForceMode2D.Impulse);
            }
        }
    }


    void MoveDown()
    {
        flock.GetComponent<Rigidbody2D>().transform.Translate(0, -drop, 0);
    }
    void MoveRight()
    {
        flock.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
    void MoveLeft()
    {
        flock.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);

    }
}
