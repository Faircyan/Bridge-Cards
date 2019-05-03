using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

    public GameObject cardHand;
    public GameObject cardBack;
    private bool isTurnBack = false;
    private bool isTurnHand = false;

    private void Start()
    {
        cardBack.transform.localScale = new Vector3(0, 1, 1);
    }


    void Update () {

        if (isTurnBack && cardHand.transform.localScale.x > 0f)
            cardHand.transform.localScale -= new Vector3(0.1f, 0, 0);

        else if (isTurnBack && cardBack.transform.localScale.x <= 1f)
        {
            cardBack.transform.localScale += new Vector3(0.1f, 0, 0);
            cardHand.transform.localScale = new Vector3(0, 1f, 1f);
        }

        else if (isTurnBack && cardBack.transform.localScale.x >= 1f)
        {
            cardBack.transform.localScale = new Vector3(1f, 1f, 1f);
            isTurnBack = false;
        }

        else if (isTurnHand && cardBack.transform.localScale.x > 0f)
            cardBack.transform.localScale -= new Vector3(0.1f, 0, 0);

        else if (isTurnHand && cardHand.transform.localScale.x <= 1f)
        {
            cardHand.transform.localScale += new Vector3(0.1f, 0, 0);
            cardBack.transform.localScale = new Vector3(0, 1f, 1f);
        }

        else if (isTurnHand && cardHand.transform.localScale.x >= 1f)
        {
            isTurnHand = false;
            cardHand.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        }


    public void TurnBack()
    {
        isTurnBack = true;
    }

    public void TurnHand()
    {
        isTurnHand = true;
    }
   
}
