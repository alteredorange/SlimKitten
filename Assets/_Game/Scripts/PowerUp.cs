using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	private GameObject gameMasterObject;
	private GameMaster gameMaster;
	public GameObject Player;
	// Use this for initialization
	void Start () {

		gameMasterObject = GameObject.FindWithTag ("GameController");
		if (gameMasterObject != null) {
			gameMaster = gameMasterObject.GetComponent <GameMaster>();
		}
		if (gameMaster == null) {
			Debug.Log ("cannot find GameMaster Script");
		}


	
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{

			Invincibility();
			Destroy(gameObject);
		}
	}
	void Invincibility()
	{
		gameMaster.invincible = true;


	}
	// Update is called once per frame
	void Update () {
	
	}
}
