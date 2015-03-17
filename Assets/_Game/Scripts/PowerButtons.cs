using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
public class PowerButtons : TouchManager {
	
		public GameObject weaponThing;
	public enum button{ButtonOne, ButtonTwo, ButtonThree};
	public button buttonType;
		public ParticleSystem Explosion1;
		public AudioClip Meow;
		public GameObject barrierPrefab;
		public GameObject player;
		public Quaternion rotationValues;
		bool Completed = false;
		public static int barrier = 0;
		private Vector3 way;

		public int deactivateTime;
		Weapon script;

	// Update is called once per frame
	void Update () {
		TouchInput ();
		Destroy (barrierPrefab);



		}
		





	void OnFirstTouch ()
	{
		
			//Invincibility Button And Code
			if (buttonType == button.ButtonOne) {
				Explosion1.Play ();
		
			//Gun Button and code
			} else if (buttonType == button.ButtonTwo) {

				script = weaponThing.GetComponent<Weapon>();
				script.enabled = true;
				Invoke("disable", deactivateTime);
		
			//Barricade Button and Code
			} else if (buttonType == button.ButtonThree) {


				if (PowerButtons.barrier == 0 && Completed == false ) 

				{
					way = player.transform.position;
					Instantiate(barrierPrefab, way = new Vector3 (way.x, way.y + 10, way.z), new Quaternion(rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w));
					Completed = true;

				}
		}
	}




	void disable()
	{
			script.enabled = false;
			Completed = false;
	}
	//just a copy of the OnFirstTouch settings so that it will register two touches
	void OnSecondTouch ()
		{
			if (buttonType == button.ButtonOne) {
				Explosion1.Play ();
			} else if (buttonType == button.ButtonTwo) {
				
				script = weaponThing.GetComponent<Weapon>();
				script.enabled = true;
				Invoke("disable", deactivateTime);
			} else if (buttonType == button.ButtonThree) {
				
				
				if (PowerButtons.barrier == 0 && Completed == false ) 
					
				{
					
					Instantiate(barrierPrefab, player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 10, player.transform.position.z), new Quaternion(rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w));
					Completed = true;
					Destroy(barrierPrefab, 3.0f);
				}
			}
		}

}
}


	
