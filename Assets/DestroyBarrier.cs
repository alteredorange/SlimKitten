using UnityEngine;
using System.Collections;

public class DestroyBarrier : MonoBehaviour {

	public int barrierTime = 5;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, barrierTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
