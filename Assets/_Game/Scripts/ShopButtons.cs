using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{

	public class ShopButtons : TouchManager {

			public enum button{ShopOne, ShopTwo, ShopThree, ShopFour};
			public button buttonType;
			public ParticleSystem Explosion1;
			public AudioClip Meow;
			
					
			// Update is called once per frame
			void Update () {
				
				TouchInput ();
				
			}
			
			
			
			void OnFirstTouch ()
			{
				if (buttonType == button.ShopOne) {
				Application.LoadLevel ("TestLevel"); 
			} else if (buttonType == button.ShopTwo) {
			
					
			} else if (buttonType == button.ShopThree) {


			} else if (buttonType == button.ShopFour) {
					

				}
			}
			
			
			
			
			//just a copy of the OnFirstTouch settings so that it will register two touches
			void OnSecondTouch ()
		{
			if (buttonType == button.ShopOne) {
				Application.LoadLevel ("TestLevel"); 
			} else if (buttonType == button.ShopTwo) {
				
				
			} else if (buttonType == button.ShopThree) {
				
				
			} else if (buttonType == button.ShopFour) {
				
				
			}
		}
			
		}
	}
