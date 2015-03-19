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
		public int deactivateTime;
		Weapon script;
		public GameObject bombPrefab;
		private Vector3 bombway;
		public Component gravityCar;
		public Quaternion bombQuat;

	

		void start ()
		{
			Enemy = GameObject.FindGameObjectWithTag ("Enemy");
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
				Enemy.GetComponent<Rigidbody2D> ().gravityScale = 3.0f;
				
				Invoke ("disable", deactivateTime);
				
			}
			//Gun Button code
			else if (buttonType == button.Gun) {

				script = weaponThing.GetComponent<Weapon> ();
				script.enabled = true;
				Invoke ("disable", deactivateTime);
		
			}
			//Barricade Button Code
			else if (buttonType == button.Roadblock) {


				if (PowerButtons.barrier == 0 && Completed == false) {
					way = player.transform.position;
					Instantiate (barrierPrefab, way = new Vector3 (way.x, way.y + 10, way.z), new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w));
					Completed = true;

				}
			} 
			//Lives Button Code
			else if (buttonType == button.Lives) {
			
				script = weaponThing.GetComponent<Weapon> ();
				script.enabled = true;
				Invoke ("disable", deactivateTime);
			
			
			}
		//Bomb Button Code

				else if (buttonType == button.Bomb) {
					if (PowerButtons.barrier == 0 && Completed == false) {
						bombway = player.transform.position;
						Instantiate (bombPrefab, bombway = new Vector3 (bombway.x, bombway.y + 20, bombway.z), bombQuat = new Quaternion (bombQuat.x, bombQuat.y, bombQuat.z, bombQuat.w));
						Completed = true;
						Invoke ("disable", deactivateTime);
					}
					
				}
		//Gravity Button Code
		 else if (buttonType == button.Gravity) {
			
				Enemy.GetComponent<Rigidbody2D> ().gravityScale = 3.0f;
				Invoke ("disableGravity", deactivateTime);
			}
		}


	void disableGravity () {
			Enemy.GetComponent<Rigidbody2D> ().gravityScale = 15.0f;
		}

	void disable()
	{
			script.enabled = false;
			Completed = false;
			
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
					Enemy.GetComponent<Rigidbody2D> ().gravityScale = 3.0f;
					
					Invoke ("disable", deactivateTime);
					
				}
				//Gun Button code
				else if (buttonType == button.Gun) {
					
					script = weaponThing.GetComponent<Weapon> ();
					script.enabled = true;
					Invoke ("disable", deactivateTime);
					
				}
				//Barricade Button Code
				else if (buttonType == button.Roadblock) {
					
					
					if (PowerButtons.barrier == 0 && Completed == false) {
						way = player.transform.position;
						Instantiate (barrierPrefab, way = new Vector3 (way.x, way.y + 10, way.z), new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w));
						Completed = true;
					Invoke ("disable", deactivateTime);
					}
				} 
				//Lives Button Code
				else if (buttonType == button.Lives) {
					
					script = weaponThing.GetComponent<Weapon> ();
					script.enabled = true;
					Invoke ("disable", deactivateTime);
					
					
				}
				//Bomb Button Code
				else if (buttonType == button.Bomb) {
					if (PowerButtons.barrier == 0 && Completed == false) {
					bombway = player.transform.position;
					Instantiate (bombPrefab, bombway = new Vector3 (bombway.x, bombway.y + 20, bombway.z), bombQuat = new Quaternion (bombQuat.x, bombQuat.y, bombQuat.z, bombQuat.w));
					Completed = true;
					Invoke ("disable", deactivateTime);
					}
				
				}
				//Gravity Button Code
				else if (buttonType == button.Gravity) {
					
					Enemy.GetComponent<Rigidbody2D> ().gravityScale = 3.0f;
					Invoke ("disableGravity", deactivateTime);
				}
			}


}
}
	


	
