using UnityEngine;
using System.Collections;


namespace UnityStandardAssets._2D
{
public class KeyboardBindings : PowerButtons {

		public int deactivateTime;
		private Vector3 way;

		bool Completed = false;
		Weapon script;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
			//Keyboard Presses for Powerup Buttons
			if (Input.GetKeyDown (KeyCode.R)) {
				if (PowerButtons.barrier == 0 && Completed == false) {
					way = player.transform.position;
					Instantiate (barrierPrefab, way = new Vector3 (way.x, way.y + 10, way.z), new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w));
					Completed = true;
				
				}
			}


			if (Input.GetKeyDown (KeyCode.T)) {

				script = weaponThing.GetComponent<Weapon>();
				script.enabled = true;
				Invoke("disable", deactivateTime);


		}

			if (Input.GetKeyDown (KeyCode.Y)) {
				Enemy.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
				Invoke("disableGravity", deactivateTime);
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
	

}
}