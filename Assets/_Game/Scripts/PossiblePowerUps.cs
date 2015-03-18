using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PossiblePowerUps : PowerUp {

	public Dictionary<string, GameObject> possiblePowerUps;
	//PowerUp invincibility;
	public GameObject invincibility;
	// Use this for initialization
	void Start () {
		//Make new power ups here like shown below 
		possiblePowerUps = new Dictionary<string, GameObject>();

		invincibility = GameObject.FindGameObjectWithTag ("Invinc");


		if (invincibility .GetComponent<PowerUp> () == null)
			invincibility .AddComponent<PowerUp> ();


		possiblePowerUps.Add ("Invincible", invincibility);
		possiblePowerUps["Invincible"].GetComponent<PowerUp> ().Name = "Test";



	}

	//Function to disable a powerUp
	void disable ()
	{
		enabled = false;
	}

	//Write functions for various power ups here
	void SetInvincible ()
	{
		if(enabled == false)
		{
			enabled = true;
			Invoke("disable", 5);
		}
	}






	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.L))
		{

						
					
		


			
		}

	}
}
