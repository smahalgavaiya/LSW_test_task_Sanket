using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionShopkeeper : MonoBehaviour
{
    public GameObject shopkeeperInteractTb;

    public dialogue dialogues;
    // Start is called before the first frame update
    void Start()
    {
        shopkeeperInteractTb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && shopkeeperInteractTb.activeInHierarchy)
        {
            shopkeeperInteractTb.SetActive(false);
            dialogues.startDialouge();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopkeeperInteractTb.SetActive(true);
        }  

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopkeeperInteractTb.SetActive(false);
        }

    }
}
