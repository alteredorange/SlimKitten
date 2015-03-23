using UnityEngine;
using System.Collections;

public class DestroyPlease: MonoBehaviour
{

	public GameObject playerExplosion;
	private GameMaster gameMaster;
	public int scoreValue = 1; 
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


	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		gameMaster.AddScore (scoreValue * 3);
		Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		AudioSource.PlayClipAtPoint (Boom, transform.position);
		Destroy(other.gameObject);
		Destroy (transform.parent.gameObject);
	}
}