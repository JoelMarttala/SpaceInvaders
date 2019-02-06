using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Handler : MonoBehaviour {

    float timeLeft;
    public Button button;
  

	// Use this for initialization
    void Start () {
        button.onClick.AddListener(Change);
    
	}
	
	// Update is called once per frame
	void Update () {
      
        
	}
    public void Change()
    {   
        string scene = gameObject.name;
        switch(scene)
        {
            case ("Retry"):
                SceneManager.LoadScene("Level1");
                break;
            case ("Menu"):
                SceneManager.LoadScene("Menu");
                break;
            case ("Start"):
                SceneManager.LoadScene("Level1");
                break;
            case ("Quit"):
                Application.Quit();
                break;
           
        }
    }
  
}
