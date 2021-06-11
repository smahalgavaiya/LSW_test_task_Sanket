using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class interactionTrialRoom : MonoBehaviour
{
    public GameObject trialRoomInteractTb;
    // Start is called before the first frame update
    void Start()
    {
        trialRoomInteractTb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && trialRoomInteractTb.activeInHierarchy)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trialRoomInteractTb.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trialRoomInteractTb.SetActive(false);
        }

    }
}
