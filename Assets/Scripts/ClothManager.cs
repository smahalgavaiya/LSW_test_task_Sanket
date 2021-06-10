using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothManager : MonoBehaviour
{
    //Used for storing all shirts game object
    public List<GameObject> AllShirts;

    //Used for storing all pant game object
    public List<GameObject> AllPants;

    private GameObject currentPant, currentShirt;

    // Start is called before the first frame update
    void Start()
    {
        currentPant= currentShirt = null;

        foreach (GameObject gameObject in AllShirts)
        {
            gameObject.SetActive(false);
        }

        foreach (GameObject gameObject in AllPants)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextShirt()
    {
        if (currentShirt == null)
        {
            currentShirt = AllShirts[0];
            AllShirts[0].SetActive(true);
        }
        else if (currentShirt == AllShirts[0])
        {
            currentShirt = AllShirts[1];
            AllShirts[0].SetActive(false);
            AllShirts[1].SetActive(true);
        }

        else 
        {
            currentShirt = null;
            AllShirts[0].SetActive(false);
            AllShirts[1].SetActive(false);
        }

    }

    public void PreviousShirt()
    {
        if (currentShirt == null)
        {
            currentShirt = AllShirts[1];
            AllShirts[1].SetActive(true);
        }
        else if (currentShirt == AllShirts[0])
        {
            currentShirt = null;
            AllShirts[0].SetActive(false);
            AllShirts[1].SetActive(false);
        }

        else
        {
            currentShirt = AllShirts[0];
            AllShirts[0].SetActive(true);
            AllShirts[1].SetActive(false);
        }
    }

    public void NextPant()
    {
        if (currentPant == null)
        {
            currentPant = AllPants[0];
            AllPants[0].SetActive(true);
        }
        else if (currentPant == AllPants[0])
        {
            currentPant = AllPants[1];
            AllPants[0].SetActive(false);
            AllPants[1].SetActive(true);
        }

        else
        {
            currentPant = null;
            AllPants[0].SetActive(false);
            AllPants[1].SetActive(false);
        }
    }

    public void PreviousPant()
    {
        if (currentPant == null)
        {
            currentPant = AllPants[1];
            AllPants[1].SetActive(true);
        }
        else if (currentPant == AllPants[0])
        {
            currentPant = null;
            AllPants[0].SetActive(false);
            AllPants[1].SetActive(false);
        }

        else
        {
            currentPant = AllPants[0];
            AllPants[0].SetActive(true);
            AllPants[1].SetActive(false);
        }
    }
}
