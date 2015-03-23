using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {



	private GameMaster gameMaster;
	public GameObject playerExplosion;
	public int scoreValue;
	public AudioClip Boom;

	void Start () {
		
		GameObject gameMasterObject = GameObject.FindWithTag ("GameController");
		if (gameMasterObject != null) {
			gameMaster = gameMasterObject.GetComponent <GameMaster>();
		}
		if (gameMaster == null) {
			Debug.Log ("cannot find GameMaster Script");
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void OnTriggerEnter2D(Collider2D other) {

	if (other.tag == "Bomb") {
		gameMaster.AddScore (scoreValue * 3);
		Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		AudioSource.PlayClipAtPoint (Boom, transform.position);
		Destroy (gameObject);
		

		}

}

}
