using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2CardsController : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
    public Sprite cardBack, cardFace, card;
    public static int cardCount = 0; 
    public int att, def;
    public string cat;
    public bool isAttack, isDefence;
    public GameManager theGameManager;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cardCount == 5)
        {
            theGameManager.isFullp2 = true;
            Debug.Log("tes");
        }
        else
        {
            theGameManager.isFullp2 = false;
        }
    }

    public void storeCard(Sprite cardFace, int att, int def)
    {
        spriteRenderer.sprite = cardFace;
        this.att = att;
        this.def = def;
        this.cardFace = cardFace;
        cardCount++;
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (isAttack)
        { }
                cardCount--;
                Debug.Log("Card 2" + cardCount);
                theGameManager.cardAttack(cardFace, att, def);
                spriteRenderer.sprite = null;
                this.att = 0;
                this.def = 0;
                this.cardFace = null;
        }
    }

