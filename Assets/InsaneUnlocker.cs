using UnityEngine;
using System.Collections;

public class InsaneUnlocker : MonoBehaviour {

	public GameObject insaneLevelButton;



	// Use this for initialization
	void Start () {
	


	}

	
	// Update is called once per frame
	void Update () {
	
		insaneLevelButton.transform.Rotate (0, 0.5f, 0);

	}
}
