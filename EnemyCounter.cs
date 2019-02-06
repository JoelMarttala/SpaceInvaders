using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour {
    GameObject scenes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Enemies();
        if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
		
	}
    public void Enemies()
    {
        GameObject[] count;
        count = GameObject.FindGameObjectsWithTag("Enemy");
        if (count.Length == 0)
        {
            if (gameObject.tag == "1")
            {
                SceneManager.LoadScene("Level2");

            }
            else if (gameObject.tag == "2")
            {
                SceneManager.LoadScene("Level3");

            }
            else if (gameObject.tag == "3")
            {
                SceneManager.LoadScene("Victory");
            }

        }

    }
    }
   

