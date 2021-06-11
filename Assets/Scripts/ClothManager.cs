using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClothManager : MonoBehaviour
{
    //Used for storing all shirts game object
    public List<GameObject> AllShirts;

    //Used for storing all pant game object
    public List<GameObject> AllPants;

    public Text  priceTb, colorTb, isPurchasedTb,coinsTb;

    private GameObject currentPant, currentShirt;

    private int coins=14;


    // Start is called before the first frame update
    void Start()
    {
        currentPant= currentShirt = null;

        coinsTb.text= "Coins:" + coins;

        foreach (GameObject gameObject in AllShirts)
        {
            gameObject.SetActive(false);
        }

        foreach (GameObject gameObject in AllPants)
        {
            gameObject.SetActive(false);
        }

        priceTb.text = "";
        colorTb.text = "";
        isPurchasedTb.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        if (coins != 0)
        {
                if (currentPant != null && ! currentPant.GetComponent<ClothDescription>().isPurchased)
            {
                coins -= int.Parse(currentPant.GetComponent<ClothDescription>().price);
                coinsTb.text = "Price:" + coins;
                currentPant.GetComponent<ClothDescription>().isPurchased = true;
                isPurchasedTb.text = "Is Purchased:" + true;
            }
            if (currentShirt != null && ! currentShirt.GetComponent<ClothDescription>().isPurchased)
            {
                coins -= int.Parse(currentShirt.GetComponent<ClothDescription>().price);
                coinsTb.text = "Price:" + coins;
                currentShirt.GetComponent<ClothDescription>().isPurchased = true;
                isPurchasedTb.text = "Is Purchased:" + true;
            }
        }
        else
        {
            coinsTb.text = "0 coins,Please sell";
        }
    }
    public void Sell()
    {
        if (currentPant != null && currentPant.GetComponent<ClothDescription>().isPurchased)
        {
            coins += int.Parse(currentPant.GetComponent<ClothDescription>().price);
            coinsTb.text = "Price:" + coins;
            currentPant.GetComponent<ClothDescription>().isPurchased = false;
            isPurchasedTb.text = "Is Purchased:" + false;
        }
        if (currentShirt != null && currentShirt.GetComponent<ClothDescription>().isPurchased)
        {
            coins += int.Parse(currentShirt.GetComponent<ClothDescription>().price);
            coinsTb.text = "Price:" + coins;
            currentShirt.GetComponent<ClothDescription>().isPurchased = false;
            isPurchasedTb.text = "Is Purchased:" + false;
        }
    }

    public void loadShopScene()
    {
        SceneManager.LoadScene(0);
    }

    public void NextShirt()
    {
        if (currentShirt == null)
        {
            currentShirt = AllShirts[0];
            AllShirts[0].SetActive(true);

            if(currentPant == null)
                priceTb.text = "Price:" + AllShirts[0].GetComponent<ClothDescription>().price;
            else
                priceTb.text = "Price:" +(int.Parse(AllShirts[0].GetComponent<ClothDescription>().price) 
                                        + int.Parse(currentPant.GetComponent<ClothDescription>().price));

            colorTb.text = "Color:" + AllShirts[0].GetComponent<ClothDescription>().color;
            isPurchasedTb.text = "Is Purchased:" + AllShirts[0].GetComponent<ClothDescription>().isPurchased + "";
        }
        else if (currentShirt == AllShirts[0])
        {
            currentShirt = AllShirts[1];
            AllShirts[0].SetActive(false);
            AllShirts[1].SetActive(true);


            if (currentPant == null)
                priceTb.text = "Price:" + AllShirts[1].GetComponent<ClothDescription>().price;
            else
                priceTb.text = "Price:" + (int.Parse(AllShirts[1].GetComponent<ClothDescription>().price)
                                        + int.Parse(currentPant.GetComponent<ClothDescription>().price));

            colorTb.text = "Color:" + AllShirts[1].GetComponent<ClothDescription>().color;
            isPurchasedTb.text = "Is Purchased:" + AllShirts[1].GetComponent<ClothDescription>().isPurchased + "";
        }

        else 
        {
            currentShirt = null;
            AllShirts[0].SetActive(false);
            AllShirts[1].SetActive(false);

            priceTb.text = "";
            colorTb.text = "";
            isPurchasedTb.text = "";
        }

    }

    public void PreviousShirt()
    {
        if (currentShirt == null)
        {
            currentShirt = AllShirts[1];
            AllShirts[1].SetActive(true);

            if (currentPant == null)
                priceTb.text = "Price:" + AllShirts[1].GetComponent<ClothDescription>().price;
            else
                priceTb.text = "Price:" + (int.Parse(AllShirts[1].GetComponent<ClothDescription>().price)
                                        + int.Parse(currentPant.GetComponent<ClothDescription>().price));

            colorTb.text = "Color:" + AllShirts[1].GetComponent<ClothDescription>().color;
            isPurchasedTb.text = "Is Purchased:" + AllShirts[1].GetComponent<ClothDescription>().isPurchased + "";
        }
        else if (currentShirt == AllShirts[0])
        {
            currentShirt = null;
            AllShirts[0].SetActive(false);
            AllShirts[1].SetActive(false);


            priceTb.text = "";
            colorTb.text = "";
            isPurchasedTb.text = "";
        }

        else
        {
            currentShirt = AllShirts[0];
            AllShirts[0].SetActive(true);
            AllShirts[1].SetActive(false);

            if (currentPant == null)
                priceTb.text = "Price:" + AllShirts[0].GetComponent<ClothDescription>().price;
            else
                priceTb.text = "Price:" + (int.Parse(AllShirts[0].GetComponent<ClothDescription>().price)
                                        + int.Parse(currentPant.GetComponent<ClothDescription>().price));

            colorTb.text = "Color:" + AllShirts[0].GetComponent<ClothDescription>().color;
            isPurchasedTb.text = "Is Purchased:" + AllShirts[0].GetComponent<ClothDescription>().isPurchased + "";
        }
    }

    public void NextPant()
    {
        if (currentPant == null)
        {
            currentPant = AllPants[0];
            AllPants[0].SetActive(true);

            if (currentShirt == null)
                priceTb.text = "Price:" + AllPants[0].GetComponent<ClothDescription>().price;
            else
                priceTb.text = "Price:" + (int.Parse(AllPants[0].GetComponent<ClothDescription>().price)
                                        + int.Parse(currentShirt.GetComponent<ClothDescription>().price));

            colorTb.text = "Color:" + AllPants[0].GetComponent<ClothDescription>().color;
            isPurchasedTb.text = "Is Purchased:" + AllPants[0].GetComponent<ClothDescription>().isPurchased + "";
        }
        else if (currentPant == AllPants[0])
        {
            currentPant = AllPants[1];
            AllPants[0].SetActive(false);
            AllPants[1].SetActive(true);


            if (currentShirt == null)
                priceTb.text = "Price:" + AllPants[1].GetComponent<ClothDescription>().price;
            else
                priceTb.text = "Price:" + (int.Parse(AllPants[1].GetComponent<ClothDescription>().price)
                                        + int.Parse(currentShirt.GetComponent<ClothDescription>().price));

            colorTb.text = "Color:" + AllPants[1].GetComponent<ClothDescription>().color;
            isPurchasedTb.text = "Is Purchased:" + AllPants[1].GetComponent<ClothDescription>().isPurchased + "";
        }

        else
        {
            currentPant = null;
            AllPants[0].SetActive(false);
            AllPants[1].SetActive(false);

            priceTb.text = "";
            colorTb.text = "";
            isPurchasedTb.text = "";
        }
    }

    public void PreviousPant()
    {
        if (currentPant == null)
        {
            currentPant = AllPants[1];
            AllPants[1].SetActive(true);

            if (currentShirt == null)
                priceTb.text = "Price:" + AllPants[1].GetComponent<ClothDescription>().price;
            else
                priceTb.text = "Price:" + (int.Parse(AllPants[1].GetComponent<ClothDescription>().price)
                                        + int.Parse(currentShirt.GetComponent<ClothDescription>().price));

            colorTb.text = "Color:" + AllPants[1].GetComponent<ClothDescription>().color;
            isPurchasedTb.text = "Is Purchased:" + AllPants[1].GetComponent<ClothDescription>().isPurchased + "";
        }
        else if (currentPant == AllPants[0])
        {
            currentPant = null;
            AllPants[0].SetActive(false);
            AllPants[1].SetActive(false);

            priceTb.text = "";
            colorTb.text = "";
            isPurchasedTb.text = "";
        }

        else
        {
            currentPant = AllPants[0];
            AllPants[0].SetActive(true);
            AllPants[1].SetActive(false);

            if (currentShirt == null)
                priceTb.text = "Price:" + AllPants[0].GetComponent<ClothDescription>().price;
            else
                priceTb.text = "Price:" + (int.Parse(AllPants[0].GetComponent<ClothDescription>().price)
                                        + int.Parse(currentShirt.GetComponent<ClothDescription>().price));

            colorTb.text = "Color:" + AllPants[0].GetComponent<ClothDescription>().color;
            isPurchasedTb.text = "Is Purchased:" + AllPants[0].GetComponent<ClothDescription>().isPurchased + "";

        }
    }
}
