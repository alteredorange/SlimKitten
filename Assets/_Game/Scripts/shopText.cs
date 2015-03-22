using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shopText : MonoBehaviour {


	public Text invincText;
	public Text gunText;
	public Text barText;
	public Text healthText;
	public Text bombText;
	public Text slowText;

	public GameMaster gm;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("Coins"))
		{
			gm.coins = PlayerPrefs.GetInt("Coins");
		}
		invincText.text = gm.invincCost.ToString();
		gunText.text = gm.gunCost.ToString();
		barText.text = gm.barCost.ToString();
		healthText.text = gm.lifeCost.ToString();
		bombText.text = gm.bombCost.ToString();
		slowText.text = gm.slowCost.ToString();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
