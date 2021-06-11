using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dialogue : MonoBehaviour
{
    public List<string> playerDialougeList;

    public List<string> shopkeeperDialougeList;

    public GameObject player;
    public GameObject shopkeeper;

    public GameObject next;

    public Text playerTb;
    public Text shopkeeperTb;

    private int dialougeCount=0;

    // Start is called before the first frame update
    void Start()
    {
        next.SetActive(false);
    }

    public void startDialouge()
    {
        dialougeCount = 0;
        next.SetActive(true);
        shopkeeperTb.text = shopkeeperDialougeList[0];
        shopkeeper.SetActive(true);
        dialougeCount++;
    }
    public void nextDialouge()
    {
        switch (dialougeCount)
        {
            case 1:

                shopkeeperTb.text = shopkeeperDialougeList[1];
                player.SetActive(true);
                shopkeeper.SetActive(false);
                dialougeCount++;

                break;
            case 2:

                playerTb.text = playerDialougeList[0];
                shopkeeper.SetActive(true);
                player.SetActive(false);
                dialougeCount++;

                break;
            case 3:

                playerTb.text = playerDialougeList[1];
                player.SetActive(true);
                shopkeeper.SetActive(false);
                dialougeCount++;

                break;
            default:
                next.SetActive(false);
                shopkeeper.SetActive(false);
                player.SetActive(false);
                break;
        }
    }
}
