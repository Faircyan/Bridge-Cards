using UnityEngine;

public class CardScript : MonoBehaviour {

    public GameObject cardHand;
    public GameObject cardBack;
    private bool isTurnBack = false;
    private bool isOpened = false;
    private bool isTurnHand = false;
    public int counter = 14;

  
    private void Start()
    {
        cardHand.transform.localScale = new Vector3(0, 1, 1);
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
            isOpened = false;
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
            isOpened = true;
        }
        }


    public void TurnBack()
    {
        isTurnBack = true;
        GameObject.Find("Random").GetComponent<CardScript>().IncreaseCounter();
    }

    public void TurnHand()
    {
        isTurnHand = true;
        GameObject.Find("Random").GetComponent<CardScript>().DecreaseCounter();

    }
  
    public bool getIsOpened()
    {
        return isOpened;
    }

    private void DecreaseCounter()
    {
        counter--;

        if (counter == 0)
            GameObject.Find("Random").SetActive(false);
    }

    public void IncreaseCounter()
    {
        counter++;
    }

    public void TurnRandomCard()
    {
        System.Random random = new System.Random();
        bool result = true;
        GameObject card = new GameObject();
        while (result)
        {
            int index = random.Next(2, 16);
            card = GameObject.Find("Card" + index.ToString());
            result = card.GetComponentInChildren<CardScript>().getIsOpened();
        }
        card.GetComponentInChildren<CardScript>().TurnHand();
        Destroy(GameObject.Find("New Game Object"));
    }
}
