using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour {


    public int durability;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D hits)
    {
      
        if (hits.gameObject.tag == "EnemyAmmo" || hits.gameObject.tag == "PlayerAmmo")
        {

            durability = durability -1;

            if (durability <= 0)
            {   

                Destroy(gameObject, 0);

            }


        }
        if (hits.gameObject.tag == "Flock")
        {
           
            Destroy(gameObject, 0);
        }
    }
}
