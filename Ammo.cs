using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       

		
	}


    void OnCollisionEnter2D(Collision2D hit)
    {
        string tag = hit.gameObject.tag;

        switch(tag)
        {
            case ("Obstacle"):
                Destroy(gameObject, 0);
                break;
            case ("Enemy"):
                Destroy(gameObject, 0);
                break;
            case ("Flock"):
                Destroy(gameObject, 0);
                break;
            case ("Player"):
                Destroy(gameObject, 0);
                break;
            case ("Ground"):
                Destroy(gameObject, 0);
                break;
            case ("EnemyAmmo"):
                Destroy(gameObject, 0);
                break;
            case ("PlayerAmmo"):
                Destroy(gameObject, 0);
                break;
        }
    }
}
