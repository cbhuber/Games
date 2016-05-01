using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class door : MonoBehaviour {

    public int loadToLevel;

    public Text doorText;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            doorText.text = ("[N] to Enter");
            if (Input.GetKeyDown("n"))
            {
                Application.LoadLevel(loadToLevel);
            }
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            doorText.text = ("[N] to Enter");
            if (Input.GetKeyDown("n"))
            {
                Application.LoadLevel(loadToLevel);
            }
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            doorText.text = (" ");
        }

    }

}
