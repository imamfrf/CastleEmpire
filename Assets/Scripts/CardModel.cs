using UnityEngine;
using System.Collections;

public class CardModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite[] faces;
    public Sprite cardBack;
    public int cardIndex, atk, def;// e.g. faces[cardIndex];
    public string cat;
    float scale = 3.243042f;


    public GameManager theGameManager;
    bool isShowFace;
    //int count;

    public void ToggleFace(bool showFace)
    {
        //count = 0;

        if (cardIndex != 6)
        {
            if (showFace)
            {
                spriteRenderer.sprite = faces[0];
                this.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            }
            else
            {
                spriteRenderer.sprite = cardBack;
                this.transform.localScale = new Vector3(scale, scale, scale);

            }
            isShowFace = showFace;
        }
        else
        {
            cardIndex = UnityEngine.Random.Range(0, 5);

            if (showFace)
            {
                spriteRenderer.sprite = faces[cardIndex];
                this.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);

            }
            else
            {
                spriteRenderer.sprite = cardBack;
                this.transform.localScale = new Vector3(scale, scale, scale);

            }
            isShowFace = showFace;
        }
        

    }

    void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (cardIndex)
        {
            case 0:
                {
                    atk = 10;
                    def = 10;
                    break;
                }
            case 1:
                {
                    atk = 20;
                    def = 20;
                    break;
                }
            case 3:
                {
                    atk = 60;
                    def = 40;
                    break;
                }
            case 4:
                {
                    atk = 30;
                    def = 20;
                    break;
                }
            case 5:
                {
                    atk = 100;
                    def = 50;
                    break;
                }
        }
        //theGameManager = GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if (isShowFace)
        {
            if (cardIndex != 6)
            {
                theGameManager.grabCard(faces[0], atk, def);
                //p1cards.storeCard(faces[cardIndex]);
                spriteRenderer.sprite = cardBack;
                //count++;
            }
            else
            {
                theGameManager.grabCard(faces[cardIndex], atk, def);
                //p1cards.storeCard(faces[cardIndex]);
                spriteRenderer.sprite = cardBack;
                //count++;
            }
            this.transform.localScale = new Vector3(scale, scale, scale);


        }


    }

}
