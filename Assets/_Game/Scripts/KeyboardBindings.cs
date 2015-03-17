using UnityEngine;
using System.Collections;


namespace UnityStandardAssets._2D
{
public class KeyboardBindings : PowerButtons {


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
}

		void disable()
		{
			script.enabled = false;
			Completed = false;
		}

}
}