using UnityEngine;
using System.Collections;

public class powerScript : MonoBehaviour {

	private GameMaster gameMaster;
	//private CatLives catLives;
	
	[System.Serializable]
	public class EnemyStats {
		public int Health = 100;
	}

	
	private GameObject player;
	
	public EnemyStats stats = new EnemyStats();
	
	public float lives = 2f;
	
	
	public int fallBoundary = -25;
	
	public static int TotalLives;
	
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
			DestroyObject (gameObject);
		}
	}
	
	
	//If Enemy collides with cat, it will cause an explosion, play a sound, destroy the cat and cause "Game Over"
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			
			//gameMaster.GetComponent<GameMaster> ().spawnWait = 1f;
			if(gameObject.tag.Equals("BombPow"))
			{
				DestroyObject (gameObject);
				GameMaster.TotalBombs += 1;
			}
			else if(gameObject.tag.Equals("LifePow"))
			{
				DestroyObject (gameObject);
				GameMaster.TotalLives += 1;
			}
			else if(gameObject.tag.Equals("GunPow"))
			{
				DestroyObject (gameObject);
				GameMaster.TotalGuns += 1;
			}
			else if(gameObject.tag.Equals("BarPow"))
			{
				DestroyObject (gameObject);
				GameMaster.TotalBarriers += 1;
			}
			else if(gameObject.tag.Equals("SlowPow"))
			{
				DestroyObject (gameObject);
				GameMaster.TotalSlows += 1;
			}
			else if(gameObject.tag.Equals("InvincPow"))
			{
				DestroyObject (gameObject);
				GameMaster.TotalInvinc += 1;
			}
		}
		
	}
}
