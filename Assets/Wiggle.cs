using UnityEngine;
using System.Collections;

public class Wiggle : MonoBehaviour {
	
	public AnimationCurve curve;
	public Vector3 distance;
	public float speed;
	public float waitTime;
	private Vector3 startPos, toPos;
	private float timeStart;

	private bool spinning = false;
	public float turnTime = 5f;

	void randomToPos() {
		toPos = startPos;
		toPos.x += Random.Range(-1.0f, +1.0f) * distance.x;
		toPos.y += Random.Range(-1.0f, +1.0f) * distance.y;
		toPos.z += Random.Range(-1.0f, +1.0f) * distance.z;
		timeStart = Time.time;
	}


	void Update(){
		if (!spinning)
			StartCoroutine( Spin() );
	}


	IEnumerator Spin () {
		spinning = true;
		var time = 0;
		//var turnIncrement = new Vector3( 0 , 0 , turnSpeed * Time.deltaTime);
		//Turn towards the side.
		while ( time < turnTime ) {
			float d = (Time.time - timeStart) / speed, m = curve.Evaluate(d);
			if (d > 1) {
				randomToPos();
			} else if (d < 0.5) {
				transform.position = Vector3.Lerp(startPos, toPos, m * 2.0f);
			} else {
				transform.position = Vector3.Lerp(toPos, startPos, (m - 0.5f) * 2.0f);
			}
			yield return null;
		}

		spinning = false;
	}



	// Use this for initialization
//	void Start () {
//		startPos = transform.position;
//		randomToPos();
//	}
	
	// Update is called once per frame
//	void Update () {
//		Invoke ("WiggleThing", waitTime);
//
//	}

//	void WiggleThing () {
//
//	float d = (Time.time - timeStart) / speed, m = curve.Evaluate(d);
//	if (d > 1) {
//		randomToPos();
//	} else if (d < 0.5) {
//		transform.position = Vector3.Lerp(startPos, toPos, m * 2.0f);
//	} else {
//		transform.position = Vector3.Lerp(toPos, startPos, (m - 0.5f) * 2.0f);
//	}
//		return;
//	}



}

