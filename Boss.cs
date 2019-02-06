using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
   
    public float health;
    float spawnHealth;
    public int rate;

    public GameObject enemyAmmo;
    public GameObject enemyAmmoSpawn;
    public GameObject spawnSpawn;
    public GameObject flock;

    private bool canShoot;
    private bool canSpawn;


    // Use this for initialization
    void Start () {
        spawnHealth = health;
        MoveRight();

    }

    // Update is called once per frame
    void Update () {

        Search();
        CheckSpawn();


    }
    void OnCollisionEnter2D(Collision2D touch)
    {   
        string obj = touch.gameObject.tag;
        switch(obj) 
        {   
            case ("RightBorder"):  
                MoveLeft();
                break;
            case ("LeftBorder"):
                MoveRight();
                break;
            case ("PlayerAmmo"):
                health = health - 1;
                if (health == 0)
                {   
                    Destroy(gameObject, 0);
                }
                break;

        }
    }
    void Search()
    {
        Debug.DrawRay(enemyAmmoSpawn.transform.position, -Vector2.up * 30);
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
    void CheckSpawn()
    {
        if (health == spawnHealth / 2)
        {   
            GameObject[] count;
            count = GameObject.FindGameObjectsWithTag("Enemy");
            if (count.Length == 1)
            {
                canSpawn = true;
            }
            Spawn();
            spawnHealth = health;
            canSpawn = false;
        }
    }

    void Spawn()
    {
        if (canSpawn == true)
        {
            GameObject spawnInstance = Instantiate(flock, spawnSpawn.transform.position, Quaternion.identity);
        }
    }




 
    void MoveRight()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
    void MoveLeft()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);

    }
}