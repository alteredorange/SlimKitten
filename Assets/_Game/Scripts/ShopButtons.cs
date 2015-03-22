using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

namespace UnityStandardAssets._2D
{

	public class ShopButtons : TouchManager {

			public enum button{ShopOne, ShopTwo, ShopThree, ShopFour};
			public button buttonType;
			public ParticleSystem Explosion1;
			public AudioClip Meow;
			
					
	void Start () {
			Advertisement.Initialize ("26283");
		}

		// Update is called once per frame
			void Update () {
				
				TouchInput ();
				
			}
			
		public void StartGame () {
		Application.LoadLevel ("Shop");
	}
		public void loadEasyLevel () {
			Application.LoadLevel ("Easy");
		}
		public void loadStartScreen () {
			Application.LoadLevel ("Start");
		}
		public void loadCreditsScreen () {
			Application.LoadLevel ("Credits");
		}

		public void loadNormalLevel () {
			Application.LoadLevel ("Normal");
		}

		public void loadInsaneLevel () {
			Application.LoadLevel ("Insane");
		}

		public void ReloadLevel () {
			Application.LoadLevel (Application.loadedLevel);
		}
			
			
			void OnFirstTouchBegan ()
			{
				if (buttonType == button.ShopOne) {
				Application.LoadLevel ("Shop"); 
			} else if (buttonType == button.ShopTwo) {
			
				if(Advertisement.isReady()){ Advertisement.Show( null, new ShowOptions {
						resultCallback = result => {
				Debug.Log(result.ToString());
						}
					});
					}

			} else if (buttonType == button.ShopThree) {


			} else if (buttonType == button.ShopFour) {
					

				}
			}
			
			
			
			
			//just a copy of the OnFirstTouch settings so that it will register two touches
			void OnSecondTouchBegan ()
		{
			if (buttonType == button.ShopOne) {
				Application.LoadLevel ("Shop"); 
			} else if (buttonType == button.ShopTwo) {
				
				
			} else if (buttonType == button.ShopThree) {
				
				
			} else if (buttonType == button.ShopFour) {
				
				
			}
		}
			
		}
	}
