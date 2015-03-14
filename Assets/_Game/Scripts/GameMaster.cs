using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GUIText scoreText;
	public GameObject cars;
	public GUIText restartText;
	public GUIText gameOverText;
	public Vector3 spawnValues;
	public Quaternion rotationValues;
	public int carsInWaveCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private bool gameOver;
	private bool restart;
	private int score;


	// Use this for initialization
	void Start () {
	
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());

	}

	void Update ()
	{
		if (restart)
		{
			if (Input.touchCount > 0)
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves () 
		{
		yield return new WaitForSeconds (startWait);

		while (true)
		{
			for (int i = 0; i < carsInWaveCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w);
				Instantiate (cars, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) 
			{
				restartText.text = "Tap Anywhere To Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver () {
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}


}
