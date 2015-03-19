using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public AudioClip Boom;
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameMaster gameMaster;
	[System.Serializable]
	public class EnemyStats {
	public int Health = 100;
	}
	public GameObject bomb;

	public EnemyStats stats = new EnemyStats();
	
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
			DamageEnemy (9999999);
	}

	//If enemy takes enough damage, it will add a point and get destroyed
	public void DamageEnemy (int damage) {
		stats.Health -= damage;
		if (stats.Health <= 0) {
		
			gameMaster.AddScore (scoreValue);
			DestroyObject(gameObject);

		}
	}


	//If Enemy collides with cat, it will cause an explosion, play a sound, destroy the cat and cause "Game Over"
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !gameMaster.invincible) {

			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			AudioSource.PlayClipAtPoint (Boom, transform.position);
			Destroy (other.gameObject);
			gameMaster.GameOver ();
					}
		//Enemy collidges with Barricade
		else if (other.tag == "Barricade") {
			gameMaster.AddScore (scoreValue * 3);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			AudioSource.PlayClipAtPoint (Boom, transform.position);
			Destroy (gameObject);
		}
		//Eney collides with Bomb
		else if (other.tag == "Bomb") {
			gameMaster.AddScore (scoreValue * 3);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			AudioSource.PlayClipAtPoint (Boom, transform.position);
			Destroy (gameObject);
			Destroy (other.transform.parent.gameObject);
	}
		//gun shots?
		else if (other.tag == "Weapon") {
			gameMaster.AddScore (scoreValue * 3);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			AudioSource.PlayClipAtPoint (Boom, transform.position);
			Destroy (gameObject);
			Destroy (other.transform.parent.gameObject);
		}

	
}
}
