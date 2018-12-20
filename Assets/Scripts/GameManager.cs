using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    public Dice dice;
    CardModel cardModel1, cardModel2, cardModel3, cardModel4, cardModel5, cardModel6;
    public GameObject card1, card2, card3, card4, card5, card6, bt_pause;
    public GameObject p1card1, p1card2, p1card3, p1card4, p1card5, p1cards, p2card1, p2card2, p2card3, p2card4, p2card5, p2cards;
    P1CardsController p1c1, p1c2, p1c3, p1c4, p1c5;
    P2CardsController p2c1, p2c2, p2c3, p2c4, p2c5;
    public PlayMenu thePlayMenu;
    public bool isFullp1, p1turn, isFullp2, isAttack;
    public Player1Model p1;
    public Player2Model p2;
    public P1DataMenu p1Menu;
    public P2DataMenu p2Menu;
    public AtkMenu atkMenu;
    public WinMenu winMenu;
    public GameObject[] p1cardsp2, p2cardsp1;
    public Sprite p1cp2, p2cp1;


    // Use this for initialization
    void Start () {
        //card tengah
        cardModel1 = card1.GetComponent<CardModel>();
        cardModel2 = card2.GetComponent<CardModel>();
        cardModel3 = card3.GetComponent<CardModel>();
        cardModel4 = card4.GetComponent<CardModel>();
        cardModel5 = card5.GetComponent<CardModel>();
        cardModel6 = card6.GetComponent<CardModel>();

        //card p1
        p1c1 = p1card1.GetComponent<P1CardsController>();
        p1c2 = p1card2.GetComponent<P1CardsController>();
        p1c3 = p1card3.GetComponent<P1CardsController>();
        p1c4 = p1card4.GetComponent<P1CardsController>();
        p1c5 = p1card5.GetComponent<P1CardsController>();

        //card p2
        p2c1 = p2card1.GetComponent<P2CardsController>();
        p2c2 = p2card2.GetComponent<P2CardsController>();
        p2c3 = p2card3.GetComponent<P2CardsController>();
        p2c4 = p2card4.GetComponent<P2CardsController>();
        p2c5 = p2card5.GetComponent<P2CardsController>();
        p1turn = true;
        p1Menu.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update () {
        attacking();
       // defence();
        if (p1turn){
            p2cards.gameObject.SetActive(false);
            p1cards.gameObject.SetActive(true);
            p1Menu.gameObject.SetActive(true);
            p2Menu.gameObject.SetActive(false);

            for (int i = 0; i < p2cardsp1.Length; i++)
            {
                p2cardsp1[i].gameObject.SetActive(true);
                p1cardsp2[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < P2CardsController.cardCount; i++)
            {
                p2cardsp1[i].GetComponent<SpriteRenderer>().sprite = p1cp2;
              //  Debug.Log("masuk");
            }

        }
        else{
            p2cards.gameObject.SetActive(true);
            p1cards.gameObject.SetActive(false);
            p2Menu.gameObject.SetActive(true);
            p1Menu.gameObject.SetActive(false);

            for (int i = 0; i < p1cardsp2.Length; i++)
            {
                p1cardsp2[i].gameObject.SetActive(true);
                p2cardsp1[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < P1CardsController.cardCount; i++)
            {
                p1cardsp2[i].GetComponent<SpriteRenderer>().sprite = p2cp1;
              //  Debug.Log("masuk2");
            }

        }

        //susun urutan kartu p1 setelah dipake
        if (p1c1.cardFace == null && p1c2.cardFace != null)
        {
            P1CardsController temp;
            temp = p1c1;
            p1c1 = p1c2;
            p1c2 = temp;
        }

        if (p1c2.cardFace == null && p1c3.cardFace != null)
        {
            P1CardsController temp;
            temp = p1c2;
            p1c2 = p1c3;
            p1c3 = temp;
        }

        if (p1c3.cardFace == null && p1c4.cardFace != null)
        {
            P1CardsController temp;
            temp = p1c3;
            p1c3 = p1c4;
            p1c4 = temp;
        }

        if (p1c4.cardFace == null && p1c5.cardFace != null)
        {
            P1CardsController temp;
            temp = p1c4;
            p1c4 = p1c5;
            p1c5 = temp;
        }

        //susun urutan kartu p2 setelah dipake
        if (p2c1.cardFace == null && p2c2.cardFace != null)
        {
            P2CardsController temp;
            temp = p2c1;
            p2c1 = p2c2;
            p2c2 = temp;
        }

        if (p2c2.cardFace == null && p2c3.cardFace != null)
        {
            P2CardsController temp;
            temp = p2c2;
            p2c2 = p2c3;
            p2c3 = temp;
        }

        if (p2c3.cardFace == null && p2c4.cardFace != null)
        {
            P2CardsController temp;
            temp = p2c3;
            p2c3 = p2c4;
            p2c4 = temp;
        }

        if (p2c4.cardFace == null && p2c5.cardFace != null)
        {
            P2CardsController temp;
            temp = p2c4;
            p2c4 = p2c5;
            p2c5 = temp;
        }

        //cek hp
        if (p1.hp  <= 0)
        {
            winMenu.player.text = "2";
            bt_pause.SetActive(false);
            winMenu.gameObject.SetActive(true);
        }

        if (p2.hp <= 0)
        {
            winMenu.player.text = "1";
            bt_pause.SetActive(false);

            winMenu.gameObject.SetActive(true);
        }


    }

    //kartu muncul sesuai dg angka dadu
    public void pickCard(int diceResult)
    {
        cardModel1.ToggleFace(false);
        cardModel2.ToggleFace(false);
        cardModel3.ToggleFace(false);
        cardModel4.ToggleFace(false);
        cardModel5.ToggleFace(false);
        cardModel6.ToggleFace(false);


        switch (diceResult)
        {
            case 1:
                    cardModel1.cardIndex = diceResult;
                    cardModel1.ToggleFace(true);
                    break;
            case 2:
                    cardModel2.cardIndex = diceResult;
                    cardModel2.ToggleFace(true);
                    break;
            case 3:
                    cardModel3.cardIndex = diceResult;
                    cardModel3.ToggleFace(true);
                    break;
            case 4:
                    cardModel4.cardIndex = diceResult;
                    cardModel4.ToggleFace(true);
                    break;
            case 5:
                    cardModel5.cardIndex = diceResult;
                    cardModel5.ToggleFace(true);
                    break;
            case 6:
                    cardModel6.cardIndex = diceResult;
                    cardModel6.ToggleFace(true);
                    break;
        }
        dice.clickable = false;
    }

    //ambil kartu yang muncul
    public void grabCard(Sprite playerCard, int att, int def)
    {
        if(p1turn){
             switch (P1CardsController.cardCount)
        {
            case 0:
                {
                    p1c1.storeCard(playerCard, att, def);
                    break;
                }
            case 1:
                {
                    p1c2.storeCard(playerCard, att, def);
                    break;
                }
            case 2:
                {
                    p1c3.storeCard(playerCard, att, def);
                    break;
                }
            case 3:
                {
                    p1c4.storeCard(playerCard, att, def);
                    break;
                }
            case 4:
                {
                    p1c5.storeCard(playerCard, att, def);
                    break;
                }

        }
            p1.attack += att;
            p1.hp += def;
        thePlayMenu.gameObject.SetActive(true);
        }
        else{
             switch (P2CardsController.cardCount)
        {
            case 0:
                {
                    p2c1.storeCard(playerCard, att, def);
                    break;
                }
            case 1:
                {
                    p2c2.storeCard(playerCard, att, def);
                    break;
                }
            case 2:
                {
                    p2c3.storeCard(playerCard, att, def);
                    break;
                }
            case 3:
                {
                    p2c4.storeCard(playerCard, att, def);
                    break;
                }
            case 4:
                {
                    p2c5.storeCard(playerCard, att, def);
                    break;
                }

        }
            p2.attack += att;
            p2.hp += def;

            thePlayMenu.gameObject.SetActive(true);
        }
       
        
    }

    //set attacking state
    public void attacking()
    {
        if (p1turn)
        {
            p1c1.isAttack = p1c2.isAttack = p1c3.isAttack = p1c4.isAttack = p1c5.isAttack = isAttack;
        }
        else
        {
            p2c1.isAttack = p2c2.isAttack = p2c3.isAttack = p2c4.isAttack = p2c5.isAttack = isAttack;

        }
        if (isAttack)
        {
            atkMenu.gameObject.SetActive(true);

        }
        else
        {
            atkMenu.gameObject.SetActive(false);
        }

    }

    int cnt = 0;
    //pilih kartu yg dipake utk attack
    public void cardAttack(Sprite img, int atkVal, int defVal)
    {
        atkMenu.cardImg[cnt] = img;
        atkMenu.atk[cnt] = atkVal;
        atkMenu.def[cnt] = defVal;
        cnt++;
    }

    //commit attack to other player
    public void commitAttack()
    {
        if (p1turn)
        {
            int atk = atkMenu.val;
            p2.hp -= atk;
        }
        else
        {
            int atk = atkMenu.val;
            p1.hp -= atk;
        }

        Array.Clear(atkMenu.cardImg, 0, atkMenu.cardImg.Length);
        Array.Clear(atkMenu.atk, 0, atkMenu.atk.Length);
        cnt = 0;
    }

    public void cancelAtt()
    {
            for (int i = 0; i < atkMenu.cardImg.Length; i++)
            {
                if (atkMenu.cardImg[i] != null)
                {
                    grabCard(atkMenu.cardImg[i], atkMenu.atk[i], atkMenu.def[i]);
                    Debug.Log("cancel");
                }
            }
        Array.Clear(atkMenu.cardImg, 0, atkMenu.cardImg.Length);
        Array.Clear(atkMenu.atk, 0, atkMenu.atk.Length);
        Array.Clear(atkMenu.def, 0, atkMenu.def.Length);

        cnt = 0;
    }


    public void Reset()
    {
        P1CardsController.cardCount = 0;
        P2CardsController.cardCount = 0;

        p1.attack = 0;
        p1.hp = 100;

        p2.attack = 0;
        p2.hp = 100;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
