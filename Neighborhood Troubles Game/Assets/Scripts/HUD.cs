using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] heartSprites;

    public Image heartsUI;

    private keyboardController player;
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<keyboardController>();
	}
	
	// Update is called once per frame
	void Update () {

        heartsUI.sprite = heartSprites[player.currentHealth];

	}
}
