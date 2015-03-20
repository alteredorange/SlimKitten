using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	public static bool guiTouch = false;



	public void TouchInput ()
	{

		if (Input.touchCount > 0) {

			//GUI TEXTURES ONLY!!!
			if (GetComponent<GUITexture> () != null) {
				if (this.GetComponent<GUITexture> ().HitTest (Input.GetTouch (0).position)) {
					guiTouch = true;
				
					switch (Input.GetTouch (0).phase) {
					case TouchPhase.Began:
						SendMessage ("OnFirstTouchBegan");
						SendMessage ("OnFirstTouch");
						break;
					case TouchPhase.Moved:
						SendMessage ("OnFirstTouchMoved");
						SendMessage ("OnFirstTouch");
						break;
					case TouchPhase.Stationary:
						SendMessage ("OnFirstTouchStayed");
						SendMessage ("OnFirstTouch");
						break;
					case TouchPhase.Ended:
						SendMessage ("OnFirstTouchEnded");
						guiTouch = false;
						break;
					}
				}
			}
		}
			 else if (Input.touchCount > 1) {
				if (this.GetComponent<GUITexture> ().HitTest (Input.GetTouch (1).position)) {
					guiTouch = true;
				
					switch (Input.GetTouch (1).phase) {
					case TouchPhase.Began:
						SendMessage ("OnSecondTouchBegan");
						SendMessage ("OnSecondTouch");
						break;
					case TouchPhase.Moved:
						SendMessage ("OnSecondTouchMoved");
						SendMessage ("OnSecondTouch");
						break;
					case TouchPhase.Stationary:
						SendMessage ("OnSecondTouchStayed");
						SendMessage ("OnSecondTouch");
						break;
					case TouchPhase.Ended:
						SendMessage ("OnSecondTouchEnded");
						guiTouch = false;
						break;
					}
				}
			}
		}
	}
	

