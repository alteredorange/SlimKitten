using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.Advertisements;



public class GameMaster : MonoBehaviour {


	public bool easy;
	public bool normal;
	public bool insane;


	public void setEasy()
	{
		easy = true;
		normal = false;
		insane = false;

	}
	public void setNormal()
	{
		easy = false;
		normal = true;
		insane = false;
		
	}
	public void setInsane()
	{
		easy = false;
		normal = false;
		insane = true;
		
	}

//GUI Stuff
	public Text scoreText;
	public Text gameOverText;
	public GUIText InvincCountText;
	public GUIText GunCountText;
	public GUIText BombCountText;
	public GUIText SlowCountText;
	public GUIText LivesCountText;
	public GUIText BarrierCountText;
	public GUIText CoinCountText;
	public Text PlusCoinsText;

//Powerups

	public static int TotalLives = 0;
	public static int TotalBombs = 0;
	public static int TotalSlows = 0;
	public static int TotalInvinc = 0;
	public static int TotalGuns = 0;
	public static int TotalBarriers = 0;
	
	
	public int var_TotalLives = 5;
	public int var_TotalBombs = 5;
	public int var_TotalSlows = 5;
	public int var_TotalInvinc = 5;
	public int var_TotalGuns = 3;
	public int var_TotalBarriers = 5;

//something


	public GameObject shop;
	public GameObject restartButton;
	public GameObject plusCoinButton;

	//public Text hsText;
	public GameObject cars;

	public Vector3 spawnValues;
	public Quaternion rotationValues;
	public int carsInWaveCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private GameObject allEnemy;

	private bool gameOver;
	private bool restart;
	private bool shopButtonBool;

	private int score;
	private int easyHighScore;
	private int normalHighScore;
	private int insaneHighScore;

	//Int for money and cost
	public int coins;
	public int lifeCost = 100;
	public int invincCost = 100;
	public int gunCost = 100;
	public int barCost = 100;
	public int bombCost = 100;
	public int slowCost = 100;


	//Name of the file that will hold the highscore
	private string fileName = "test.txt";

	//Filestream we can write the highscore to
	private StreamWriter sw;

	//Variable ot test if the score is higher than the current highscore
	public int highScoreTest;

	public bool invincible;
	private int i = 0;
	private int nextNum;

	void Start () {
		//To see if powerups are updating correctly in editor, can remove at launch
		var_TotalLives = TotalLives;
		var_TotalBombs = TotalBombs;
		var_TotalSlows = TotalSlows;
		var_TotalInvinc = TotalInvinc;
		var_TotalGuns = TotalGuns;
		var_TotalBarriers = TotalBarriers;

		//To enable unity ads
		Advertisement.Initialize ("26283");
		nextNum = 0;
		gameOver = false;
		restart = false;
		shopButtonBool = false;
		gameOverText.text = "";

		shop.SetActive (false);
		restartButton.SetActive (false);
		plusCoinButton.SetActive (false);

		//hsText.text = "";
		score = 0;
		//invincible = false;

		//If the file exist we set highScoreTest to the highscore held on the file

		if(PlayerPrefs.HasKey("easyHighScore"))
		{
			highScoreTest = PlayerPrefs.GetInt("easyHighScore");
		}
		if(PlayerPrefs.HasKey("normalHighScore"))
		{
			highScoreTest = PlayerPrefs.GetInt("normalHighScore");
		}
		if(PlayerPrefs.HasKey("insaneHighScore"))
		{
			highScoreTest = PlayerPrefs.GetInt("insaneHighScore");
		}
		if(PlayerPrefs.HasKey("Coins"))
		{
			coins = PlayerPrefs.GetInt("Coins");
		}
		if (PlayerPrefs.HasKey ("Lives"))
			TotalLives = PlayerPrefs.GetInt ("Lives");

		if (PlayerPrefs.HasKey ("Bombs"))
			TotalBombs= PlayerPrefs.GetInt ("Bombs");

		if (PlayerPrefs.HasKey ("Slow"))
			TotalSlows = PlayerPrefs.GetInt ("Slow");

		if (PlayerPrefs.HasKey ("Guns"))
			TotalLives = PlayerPrefs.GetInt ("Guns");

		if (PlayerPrefs.HasKey ("Invinc"))
			TotalInvinc = PlayerPrefs.GetInt ("Invinc");

		if (PlayerPrefs.HasKey ("Barriers"))
			TotalBarriers = PlayerPrefs.GetInt ("Barriers");



	

		UpdateScore ();
		StartCoroutine (SpawnWaves ());

	}

	//This runs as you might have guessed when the game is quit 



	IEnumerable invincibleOff()
	{
		yield return new WaitForSeconds (1);
		invincible = false;
		//CancelInvoke ("invincibleOff");
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.touchCount > 1)
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
		//to check powerup count in editor, can be removed at launch
		var_TotalLives = TotalLives;
		var_TotalBombs = TotalBombs;
		var_TotalSlows = TotalSlows;
		var_TotalInvinc = TotalInvinc;
		var_TotalGuns = TotalGuns;
		var_TotalBarriers = TotalBarriers;


		//Updating Powerup Counts on GUI		
		InvincCountText.text = TotalInvinc.ToString();
		GunCountText.text = TotalGuns.ToString();
		BombCountText.text = TotalBombs.ToString();
		SlowCountText.text = TotalSlows.ToString();
		LivesCountText.text = TotalLives.ToString();
		BarrierCountText.text = TotalBarriers.ToString();
		CoinCountText.text = coins.ToString ();
		PlusCoinsText.text = "+" + score.ToString() + " Coins";

		//if(invincible)
		//{
			//InvokeRepeating("invincibleOff", 0, 1);
		//}
	}

	IEnumerator SpawnWaves () 
		{
		yield return new WaitForSeconds (startWait);

		while (true)
		{
			for (int i = 0; i < carsInWaveCount; i++) {
				Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0);
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

		//GameObject[] allEnemy = GameObject.FindGameObjectsWithTag ("Enemy");
	
		//foreach(GameObject item in allEnemy)
		//{
		//	Destroy(allEnemy);
		//}



		GameObject[] allEnemy = GameObject.FindGameObjectsWithTag ("Enemy") as GameObject[];
		
		for (int i = 0; i < allEnemy.Length; i++)
		{
			Destroy(allEnemy[i]);
		}


		coins += score;

		if(easy)
		{

			if (PlayerPrefs.HasKey("easyHighScore")) {
				if(score > highScoreTest)
				{
					easyHighScore = score;
					
				}
				else
				{
					easyHighScore = highScoreTest;
				}
				
				PlayerPrefs.SetInt ("easyHighScore", easyHighScore);

				
			}
			//If the file doesnt exist then this would be the first time running the game so it sets the highscore to score
			else
			{
				PlayerPrefs.SetInt ("easyHighScore", score);
				
			}
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("Lives", TotalLives);
			PlayerPrefs.SetInt ("Bombs", TotalBombs);
			PlayerPrefs.SetInt ("Slow", TotalSlows);
			PlayerPrefs.SetInt ("Guns", TotalGuns);
			PlayerPrefs.SetInt ("Invinc", TotalInvinc);
			PlayerPrefs.SetInt ("Barriers", TotalBarriers);
			
			PlayerPrefs.Save ();
			gameOverText.text = "Game Over" + Environment.NewLine + "Easy High Score: " + easyHighScore;
			//hsText.text = "High Score: " + highScoreTest;
			
			shop.SetActive (true);
			restartButton.SetActive (true);
			plusCoinButton.SetActive (true);
			gameOver = true;
		}
		else if(normal)
		{
			if (PlayerPrefs.HasKey("normalHighScore")) {
				if(score > highScoreTest)
				{
					normalHighScore = score;
					
				}
				else
				{
					normalHighScore = highScoreTest;
				}
				
				PlayerPrefs.SetInt ("normalHighScore", normalHighScore);
				
			}
			//If the file doesnt exist then this would be the first time running the game so it sets the highscore to score
			else
			{
				PlayerPrefs.SetInt ("normalHighScore", score);
				
			}
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("Lives", TotalLives);
			PlayerPrefs.SetInt ("Bombs", TotalBombs);
			PlayerPrefs.SetInt ("Slow", TotalSlows);
			PlayerPrefs.SetInt ("Guns", TotalGuns);
			PlayerPrefs.SetInt ("Invinc", TotalInvinc);
			PlayerPrefs.SetInt ("Barriers", TotalBarriers);
			
			PlayerPrefs.Save ();
			gameOverText.text = "Game Over" + Environment.NewLine + "Normal High Score: " + normalHighScore;
			//hsText.text = "High Score: " + highScoreTest;
			
			shop.SetActive (true);
			restartButton.SetActive (true);
			plusCoinButton.SetActive (true);
			gameOver = true;
		}
		else if(insane)
		{
			if (PlayerPrefs.HasKey("insaneHighScore")) {
				if(score > highScoreTest)
				{
					insaneHighScore = score;
					
				}
				else
				{
					insaneHighScore = highScoreTest;
				}
				
				PlayerPrefs.SetInt ("insaneHighScore", insaneHighScore);
				
			}
			//If the file doesnt exist then this would be the first time running the game so it sets the highscore to score
			else
			{
				PlayerPrefs.SetInt ("insaneHighScore", score);
				
			}
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("Lives", TotalLives);
			PlayerPrefs.SetInt ("Bombs", TotalBombs);
			PlayerPrefs.SetInt ("Slow", TotalSlows);
			PlayerPrefs.SetInt ("Guns", TotalGuns);
			PlayerPrefs.SetInt ("Invinc", TotalInvinc);
			PlayerPrefs.SetInt ("Barriers", TotalBarriers);
			
			PlayerPrefs.Save ();
			gameOverText.text = "Game Over" + Environment.NewLine + "Insane High Score: " + insaneHighScore;
			//hsText.text = "High Score: " + highScoreTest;
			
			shop.SetActive (true);
			restartButton.SetActive (true);
			plusCoinButton.SetActive (true);
			gameOver = true;
		}

	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}


	//Buying powerups
	public void buyLives (){
		if(coins >= lifeCost)
		{
			coins -= lifeCost;
			TotalLives += 1;
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("Lives", TotalLives);
			PlayerPrefs.Save();

		}
	}
	
	public void buyInvinc (){
		if(coins >= invincCost)
		{
			coins -= invincCost;
			TotalInvinc += 1;
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("Invinc", TotalInvinc);
			PlayerPrefs.Save();

		}
	}
	public void buyGuns (){
		if(coins >= gunCost)
		{
			coins -= gunCost;
			TotalGuns += 1;
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("Guns", TotalGuns);
			PlayerPrefs.Save();

		}
	}
	public void buyBarries (){
		if(coins >=  barCost)
		{
			coins -= barCost;
			TotalBarriers += 1;
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("Barriers", TotalBarriers);
			PlayerPrefs.Save();

		}
	}
	public void buyBombs (){
		if(coins >= bombCost)
		{
			coins -= bombCost;
			TotalBombs += 1;
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("Bombs", TotalBombs);
			PlayerPrefs.Save();

		}
	}
	public void buySlows (){
		if(coins >= slowCost)
		{
			coins -= slowCost;
			TotalSlows += 1;
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("Slow", TotalSlows);
			PlayerPrefs.Save();

		}
	}
	
	public void freeCoins (){
		if (Advertisement.isReady ()) {
			Advertisement.Show (null, new ShowOptions {
				resultCallback = result => {
					if (result.ToString() == "Finished") {
						coins += 100;
						PlayerPrefs.SetInt ("Coins", coins);
						PlayerPrefs.Save();
						Debug.Log(result.ToString());
					} else if (result.ToString () == "Skipped") {
						coins += 10;
						PlayerPrefs.SetInt ("Coins", coins);
						PlayerPrefs.Save();
						Debug.Log(result.ToString());
					} else { 
						Debug.Log(result.ToString());
						return;
						}
				}
			});
		}
	}



}
