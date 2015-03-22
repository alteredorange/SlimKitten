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
		bool invicButtonBool = false;

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
		//Destroy (barrierPrefab);
		}
		





	void OnFirstTouchBegan ()
		{
			
			//Invincibility Button Code
			if (buttonType == button.Invincible) {
				if (invicButtonBool == false) {
				if (GameMaster.TotalInvinc > 0) {
					
					invincibilityVFX.GetComponent<ParticleSystem>().Play();
					gameMaster.GetComponent<GameMaster> ().invincible = true;
					GameMaster.TotalInvinc -= 1;
					Invoke ("invincibleDisable", deactivateTime);
					invicButtonBool = true;

				}
				else {
					AudioSource.PlayClipAtPoint (Meow, transform.position);
				}
				}
			}


			
			//Gun Button code
			else if (buttonType == button.Gun) {
				
				script = weaponThing.GetComponent<shootingShots> ();
				if (gunButtonBool == false) {

					if (GameMaster.TotalGuns > 0) {

						script.enabled = true;
						Invoke ("gunDisable", deactivateTime);
						GameMaster.TotalGuns -= 1;
						gunButtonBool = true;

					} else {
					
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
				//Barricade Button Code
				else if (buttonType == button.Roadblock) {

				if (barricadeButtonBool == false) {
					if (GameMaster.TotalBarriers > 0) {			
		
						way = player.transform.position;
						Instantiate (barrierPrefab, way = new Vector3 (way.x, way.y + 10, way.z), new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w));
						GameMaster.TotalBarriers -= 1;
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
					if (GameMaster.TotalBombs > 0) {

						bombway = player.transform.position;
						Instantiate (bombPrefab, bombway = new Vector3 (bombway.x, bombway.y + 25, bombway.z), bombQuat = new Quaternion (bombQuat.x, bombQuat.y, bombQuat.z, bombQuat.w));
						Invoke ("bombDisable", deactivateTime);
						GameMaster.TotalBombs -= 1;
						bombButtonBool = true;
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
				//Gravity Button Code
				else if (buttonType == button.Gravity) {
				if (gravityButtonBool == false) {
					if (GameMaster.TotalSlows > 0) {
						Enemy.GetComponent<Rigidbody2D> ().gravityScale = 1.0f;
						gameMaster.GetComponent<GameMaster> ().spawnWait = 1.5f;
						Invoke ("gravityDisable", deactivateTime);
						GameMaster.TotalSlows -= 1;
						gravityButtonBool = true;
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
		}

	void invincibleDisable () {
			gameMaster.GetComponent<GameMaster> ().invincible = false;
			invicButtonBool = false;
		}

	void gravityDisable () {
			gameMaster.GetComponent<GameMaster> ().spawnWait = .25f;
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
				if (invicButtonBool == false) {
					if (GameMaster.TotalInvinc > 0) {
						
						invincibilityVFX.GetComponent<ParticleSystem>().Play();
						gameMaster.GetComponent<GameMaster> ().invincible = true;
						GameMaster.TotalInvinc -= 1;
						Invoke ("invincibleDisable", deactivateTime);
						invicButtonBool = true;
						
					}
					else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
			
			
			
			//Gun Button code
			else if (buttonType == button.Gun) {
				
				script = weaponThing.GetComponent<shootingShots> ();
				if (gunButtonBool == false) {
					
					if (GameMaster.TotalGuns > 0) {
						
						script.enabled = true;
						Invoke ("gunDisable", deactivateTime);
						GameMaster.TotalGuns -= 1;
						gunButtonBool = true;
						
					} else {
						
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
			//Barricade Button Code
			else if (buttonType == button.Roadblock) {
				
				if (barricadeButtonBool == false) {
					if (GameMaster.TotalBarriers > 0) {			
						
						way = player.transform.position;
						Instantiate (barrierPrefab, way = new Vector3 (way.x, way.y + 10, way.z), new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w));
						GameMaster.TotalBarriers -= 1;
						barricadeButtonBool = true;
						Invoke ("barricadeDisable", deactivateTime);
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
			//Lives Button Code
			else if (buttonType == button.Lives) {
				
				return;
			}
			//Bomb Button Code
			
			else if (buttonType == button.Bomb) {
				if (bombButtonBool == false) {
					if (GameMaster.TotalBombs > 0) {
						
						bombway = player.transform.position;
						Instantiate (bombPrefab, bombway = new Vector3 (bombway.x, bombway.y + 25, bombway.z), bombQuat = new Quaternion (bombQuat.x, bombQuat.y, bombQuat.z, bombQuat.w));
						Invoke ("bombDisable", deactivateTime);
						GameMaster.TotalBombs -= 1;
						bombButtonBool = true;
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
			//Gravity Button Code
			else if (buttonType == button.Gravity) {
				if (gravityButtonBool == false) {
					if (GameMaster.TotalSlows > 0) {
						Enemy.GetComponent<Rigidbody2D> ().gravityScale = 1.0f;
						gameMaster.GetComponent<GameMaster> ().spawnWait = 1.5f;
						Invoke ("gravityDisable", deactivateTime);
						GameMaster.TotalSlows -= 1;
						gravityButtonBool = true;
					} else {
						AudioSource.PlayClipAtPoint (Meow, transform.position);
					}
				}
			}
		}


}
}
	


	
