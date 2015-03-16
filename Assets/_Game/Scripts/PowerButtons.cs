﻿using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
public class PowerButtons : TouchManager {
	
		public GameObject weaponThing;
	public enum button{ButtonOne, ButtonTwo, ButtonThree};
	public button buttonType;
		public ParticleSystem Explosion1;
		public AudioClip Meow;

	// Update is called once per frame
	void Update () {
	
		TouchInput ();

		}
		



	void OnFirstTouch ()
	{
		if (buttonType == button.ButtonOne) {
				Explosion1.Play ();
		} else if (buttonType == button.ButtonTwo) {
				Weapon script;
				script = weaponThing.GetComponent<Weapon>();
				script.enabled = true;
		} else if (buttonType == button.ButtonThree) {

		}
	}

	//just a copy of the OnFirstTouch settings so that it will register two touches
	void OnSecondTouch ()
	{
		if (buttonType == button.ButtonOne) {
				Explosion1.Play ();
		} else if (buttonType == button.ButtonTwo) {
				Weapon script;
				script = weaponThing.GetComponent<Weapon>();
				script.enabled = true;
		} else if (buttonType == button.ButtonThree) {

			}
	}

	}
}