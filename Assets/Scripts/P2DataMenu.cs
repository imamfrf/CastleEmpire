using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class P2DataMenu : MonoBehaviour {
	 public Text hpValue;
	 public Player2Model player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        hpValue.text = player.hp.ToString();
		
	}
}
