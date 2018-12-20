using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class WinMenu : MonoBehaviour {
    public Text player;
    public Button bt_restart, bt_main;
    public GameManager theGameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playAgain()
    {
        theGameManager.Reset();
    }

    public void quitMain()
    {
        SceneManager.LoadScene(0);
    }
}
