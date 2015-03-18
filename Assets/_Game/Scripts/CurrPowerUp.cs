using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurrPowerUp : PossiblePowerUps {

	//List that stores the players current powerups
	public List<PowerUp> curPowerUps;



	
	// Update is called once per frame
	void Update () {


		//Add function for collision with obj here


		if(Input.GetKeyDown(KeyCode.K))
		{
			//This is how to add a powerup to the players "inventory"
			if(possiblePowerUps != null)
			{
				//This is how to add a powerup to the players "inventory"
				curPowerUps.Add (possiblePowerUps ["Invincible"].GetComponent<PowerUp>());

			}

		}
	

	}
}
