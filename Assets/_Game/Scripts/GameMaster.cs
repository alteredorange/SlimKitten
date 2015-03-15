using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;



public class GameMaster : MonoBehaviour {

	public Text scoreText;
	public Text gameOverText;
	//public Text hsText;
	public GameObject cars;

	public Vector3 spawnValues;
	public Quaternion rotationValues;
	public int carsInWaveCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private bool gameOver;
	private bool restart;
	private int score;
	private int highScore;

	//Name of the file that will hold the highscore
	private string fileName = "test.txt";

	//Filestream we can write the highscore to
	private StreamWriter sw;

	//Variable ot test if the score is higher than the current highscore
	public int highScoreTest;

	public bool invincible;

	private int nextNum;

	void Start () {
		nextNum = 0;
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		//hsText.text = "";
		score = 0;
		invincible = false;

		//If the file exist we set highScoreTest to the highscore held on the file

		if(PlayerPrefs.HasKey("HighScore"))
		{
			highScoreTest = PlayerPrefs.GetInt("HighScore");
		}



		UpdateScore ();
		StartCoroutine (SpawnWaves ());

	}

	//This runs as you might have guessed when the game is quit 

	//Note this WILL NOT WORK FOR IOS but I can make it compatible if needed
	void OnApplicationQuit()
	{
		//If the file already exist we test if the score is higher than the current highscore if so we rewrite the file to hold that number


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
				Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w);
				Instantiate (cars, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) 
			{
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
		gameOverText.text = "Game Over" + Environment.NewLine + "High Score: " + highScoreTest + Environment.NewLine + "Tap Anywhere to Restart";
		//hsText.text = "High Score: " + highScoreTest;
		if (PlayerPrefs.HasKey("HighScore")) {
			if(score > highScoreTest)
			{
				highScore = score;
				
			}
			else
			{
				highScore = highScoreTest;
			}
			
			PlayerPrefs.SetInt ("HighScore", highScore);
			
		}
		//If the file doesnt exist then this would be the first time running the game so it sets the highscore to score
		else
		{
			PlayerPrefs.SetInt ("HighScore", score);
			
		}
		
		PlayerPrefs.Save ();
		gameOver = true;
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}




}
