using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour {
    public GameManager theGameManager;
    public GameObject bt_end, bt_attack;
    int count;
    public bool attacked;

    // Update is called once per frame
    void Update()
    {
        if (theGameManager.p1turn)
        {
            if (theGameManager.isFullp1)
            {
                bt_end.SetActive(false);
            }
            else
            {
                bt_end.SetActive(true);
            }
        }
        else
        {
            if (theGameManager.isFullp2)
            {
                bt_end.SetActive(false);
            }
            else
            {
                bt_end.SetActive(true);
            }
        }

        if (count == 0 || count == 1 ||attacked)
        {
            bt_attack.SetActive(false); 
        }
        
        
    }
    public void endTurn()
    {
        theGameManager.dice.clickable = true;
        if(count % 2 == 0){
            theGameManager.p1turn = false;
        }
        else{
            theGameManager.p1turn = true;
        }
        theGameManager.isAttack = false;
        count++;

        bt_attack.gameObject.SetActive(true);

        attacked = false;
    }

    public void attack()
    {
        theGameManager.isAttack = true;
        theGameManager.attacking();
    }
}
