using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
public class PowerButtons : TouchManager {
	
		public GameObject weaponThing;
		public enum button{Invincible, Gun, Roadblock, Lives, Bomb, Gravity};
		public button buttonType;
		public ParticleSystem Explosion1;
		public AudioClip Meow;
		public GameObject barrierPrefab;
		public GameObject player;
		public Quaternion rotationValues;
		bool Completed = false;
		public static int barrier = 0;
		private Vector3 way;
		public GameObject Enemy; 
		public float deactivateTime;
		shootingShots script;
		public GameObject bombPrefab;
		private Vector3 bombway;
		public Component gravityCar;
		public Quaternion bombQuat;

		public GameObject invincibilityVFX;

		bool gunButtonBool = false;
		bool bombButtonBool = false;
		bool barricadeButtonBool = false;
		bool gravityButtonBool = false;

		public GameMaster gameMaster;

		GameMaster script1;

		void start ()
		{
			Enemy = GameObject.FindGameObjectWithTag ("Enemy");


			GameObject gameMasterObject = GameObject.FindWithTag ("GameController");
			if (gameMasterObject != null) {
				gameMaster = gameMasterObject.GetComponent <GameMaster>();
			}
			if (gameMaster == null) {
				Debug.Log ("cannot find GameMaster Script");
			}
		}


		// Update is called once per frame
	void Update () {
		TouchInput ();
		Destroy (barrierPrefab);
		}
		





	void OnFirstTouch ()
		{
			
			//Invincibility Button Code
			if (buttonType == button.Invincible) {
				if (CatLives.TotalInvinc > 0f) {
					
					gameMaster.GetComponent<GameMaster> ().invincible = true;
					invincibilityVFX.GetComponent<ParticleSystem>().Play();

				} else {
					AudioSource.PlayClipAtPoint (Meow, transform.position);
				}
			}
			//Gun Button code
			else if (buttonType == button.Gun) {
				
				script = weaponThing.GetComponent<shootingShots> ();
				if (gunButtonBool == false) {

					if (CatLives.TotalGuns > 0f) {

						script.enabled = true;
						Invoke ("gunDisable", deactivateTime);
						CatLives.TotalGuns -= 1f;
						gunButtonBool = true;

					} else {
					
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
				//Barricade Button Code
				else if (buttonType == button.Roadblock) {

				if (barricadeButtonBool == false) {
					if (CatLives.TotalBarriers > 0f) {			
		
						way = player.transform.position;
						Instantiate (barrierPrefab, way = new Vector3 (way.x, way.y + 10, way.z), new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w));
						CatLives.TotalBarriers -= 1f;
						barricadeButtonBool = true;
						Invoke ("barricadeDisable", deactivateTime);
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
					}
			}
				//Lives Button Code
				else if (buttonType == button.Lives) {
					
			}
				//Bomb Button Code
				
				else if (buttonType == button.Bomb) {
				if (bombButtonBool == false) {
					if (CatLives.TotalBombs > 0f) {

						bombway = player.transform.position;
						Instantiate (bombPrefab, bombway = new Vector3 (bombway.x, bombway.y + 20, bombway.z), bombQuat = new Quaternion (bombQuat.x, bombQuat.y, bombQuat.z, bombQuat.w));
						Invoke ("bombDisable", deactivateTime);
						CatLives.TotalBombs -= 1f;
						bombButtonBool = true;
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
				//Gravity Button Code
				else if (buttonType == button.Gravity) {
				if (gravityButtonBool == false) {
					if (CatLives.TotalSlows > 0f) {
						Enemy.GetComponent<Rigidbody2D> ().gravityScale = 3.0f;
						gameMaster.GetComponent<GameMaster> ().spawnWait = 1.0f;
						Invoke ("gravityDisable", deactivateTime);
						CatLives.TotalSlows -= 1f;
						gravityButtonBool = true;
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
		}

	void gravityDisable () {
			gameMaster.GetComponent<GameMaster> ().spawnWait = .25f;
			//gameMaster.GetComponent<GameMaster> ().spawnWait = 0.25f;
			Enemy.GetComponent<Rigidbody2D> ().gravityScale = 15.0f;
				gravityButtonBool = false;
		}



	void gunDisable()
	{
		script = weaponThing.GetComponent<shootingShots> ();
		gunButtonBool = false;
		script.enabled = false;
	}
	
	void bombDisable()
	{
		bombButtonBool = false;
	}

	void barricadeDisable()
		{
			barricadeButtonBool = false;
		}

	void toggle()
	{
			Completed = !Completed;
	}
	//just a copy of the OnFirstTouch settings so that it will register two touches
	void OnSecondTouch ()
		{
			
			//Invincibility Button Code
			if (buttonType == button.Invincible) {
				if (CatLives.TotalInvinc > 0f) {
				
				gameMaster.GetComponent<GameMaster> ().invincible = true;
				
				Invoke ("disable", deactivateTime);
				} else {
					AudioSource.PlayClipAtPoint (Meow, transform.position);
				}
			}
			//Gun Button code
			else if (buttonType == button.Gun) {
				
				script = weaponThing.GetComponent<shootingShots> ();
				if (gunButtonBool == false) {
					
					if (CatLives.TotalGuns > 0f) {
						
						script.enabled = true;
						Invoke ("gunDisable", deactivateTime);
						CatLives.TotalGuns -= 1f;
						gunButtonBool = true;
						
					} else {
						
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
			//Barricade Button Code
			else if (buttonType == button.Roadblock) {
				
				if (barricadeButtonBool == false) {
					if (CatLives.TotalBarriers > 0f) {			
						
						way = player.transform.position;
						Instantiate (barrierPrefab, way = new Vector3 (way.x, way.y + 10, way.z), new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w));
						CatLives.TotalBarriers -= 1f;
						barricadeButtonBool = true;
						Invoke ("barricadeDisable", deactivateTime);
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
			//Lives Button Code
			else if (buttonType == button.Lives) {
				
			}
			//Bomb Button Code
			
			else if (buttonType == button.Bomb) {
				if (bombButtonBool == false) {
					if (CatLives.TotalBombs > 0f) {
						
						bombway = player.transform.position;
						Instantiate (bombPrefab, bombway = new Vector3 (bombway.x, bombway.y + 20, bombway.z), bombQuat = new Quaternion (bombQuat.x, bombQuat.y, bombQuat.z, bombQuat.w));
						Invoke ("bombDisable", deactivateTime);
						CatLives.TotalBombs -= 1f;
						bombButtonBool = true;
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
			//Gravity Button Code
			else if (buttonType == button.Gravity) {
				if (gravityButtonBool == false) {
					if (CatLives.TotalSlows > 0f) {
						Enemy.GetComponent<Rigidbody2D> ().gravityScale = 3.0f;
						gameMaster.GetComponent<GameMaster> ().spawnWait = 1.0f;
						Invoke ("gravityDisable", deactivateTime);
						CatLives.TotalSlows -= 1f;
						gravityButtonBool = true;
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
		}


}
}
	


	
