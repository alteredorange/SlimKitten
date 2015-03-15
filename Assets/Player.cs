using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	

	public GameObject explosion;
	public GameObject playerExplosion;

	public int scoreValue;
	private GameMaster gameMaster;
	[System.Serializable]
	public class PlayerStats {
		public int Health = 100;
	}
	
	public PlayerStats playerStats = new PlayerStats();
	
	public int fallBoundary = -20;


	void Start () {
		
		GameObject gameMasterObject = GameObject.FindWithTag ("GameController");
		if (gameMasterObject != null) {
			gameMaster = gameMasterObject.GetComponent <GameMaster>();
		}
		if (gameMaster == null) {
			Debug.Log ("cannot find GameMaster Script");
		}
	}


	void Update () {
		if (transform.position.y <= fallBoundary)
			DamagePlayer (9999999);
	}
	
	public void DamagePlayer (int damage) {
		playerStats.Health -= damage;
		if (playerStats.Health <= 0) {
			gameMaster.AddScore (scoreValue);
			DestroyObject(gameObject);
		}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Destroy(other.gameObject);
			
			gameMaster.GameOver ();
		}
	}


	
}
