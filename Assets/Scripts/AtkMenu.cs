using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtkMenu : MonoBehaviour {
    public Image[] cards;
    public Sprite[] cardImg;
    public int[] atk, def;
    public GameManager theGameManager;
    public Text attValue;
    public int val = 0;
    public Button bt_attack;
    // Use this for initialization
    void Start() {
        cards = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update() {
        for (int i = 1; i < 6; i++)
        {
            cards[i].sprite = cardImg[i - 1];
        }


        if (cardImg[0] == null)
        {
            bt_attack.gameObject.SetActive(false);
        }
        else
        {
            bt_attack.gameObject.SetActive(true);

        }

        val = atk[0] + atk[1] + atk[2] + atk[3] + atk[4];
        attValue.text = val.ToString();
    }

    public void tes()
    {
        theGameManager.isAttack = false;
    }

    public void attack()
    {
        theGameManager.commitAttack();
        theGameManager.isAttack = false;
        theGameManager.thePlayMenu.attacked = true;
    }

    public void cancel()
    {
        theGameManager.cancelAtt();

        theGameManager.isAttack = false;
    }
}
