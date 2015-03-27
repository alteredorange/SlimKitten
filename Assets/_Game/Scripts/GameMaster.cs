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

	//Set this to the percent chance for an item to spawn
	public int spawnChance = 5;
	public int carSpawnChance = 95;


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

	public static int TotalLives = 1;
	public static int TotalBombs = 1;
	public static int TotalSlows = 1;
	public static int TotalInvinc = 1;
	public static int TotalGuns = 1;
	public static int TotalBarriers = 1;
	
	
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
	public Button insaneLevelButton;

	//public Text hsText;
	public GameObject cars;

	public Vector3 spawnValues;
	public Quaternion rotationValues;
	public int carsInWaveCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private GameObject allEnemy;

	public bool gameOver;
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
	public int insaneCost = 10000;

	public GameObject lifePow;
	public GameObject invincPow;
	public GameObject gunPow;
	public GameObject barPow;
	public GameObject bombPow;
	public GameObject slowPow;

	public GameObject caprise;
	public GameObject dirtyvan;
	public GameObject hotrod;
	public GameObject lolvo;
	public GameObject passied;
	public GameObject suv;
	public GameObject taxi;
	public GameObject van;


	//Name of the file that will hold the highscore
	private string fileName = "test.txt";

	//Filestream we can write the highscore to
	private StreamWriter sw;

	//Variable ot test if the score is higher than the current highscore
	public int highScoreTest;
	public int highScoreEasy;
	public int highScoreNormal;
	public int highScoreInsane;

	public bool invincible;
	private int i = 0;
	private int nextNum;
	public float carSpawnTime = 1;



	Vector3 lastPosition = new Vector3(0,0,0);
	Vector3 offsetVector = new Vector3(5,0,0);
	public int posOffset =10;
	public int negOffset = 10;

	public bool hasInsane = false;
	public GameObject buyInsaneObj;
	public static bool invokeSpawn = false;


	void Awake()
	{



		if(PlayerPrefs.HasKey("hasInsane"))
		{
			hasInsane = (PlayerPrefs.GetInt("hasInsane") != 0);
		}

		if(PlayerPrefs.HasKey("easyHighScore"))
		{
			highScoreEasy = PlayerPrefs.GetInt("easyHighScore");
		}

		if(PlayerPrefs.HasKey("normalHighScore"))
		{
			highScoreNormal = PlayerPrefs.GetInt("normalHighScore");
		}
		if(PlayerPrefs.HasKey("insaneHighScore"))
		{
			highScoreInsane = PlayerPrefs.GetInt("insaneHighScore");
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
			TotalGuns = PlayerPrefs.GetInt ("Guns");
		
		if (PlayerPrefs.HasKey ("Invinc"))
			TotalInvinc = PlayerPrefs.GetInt ("Invinc");
		
		if (PlayerPrefs.HasKey ("Barriers"))
			TotalBarriers = PlayerPrefs.GetInt ("Barriers");
		
		var_TotalLives = TotalLives;
		var_TotalBombs = TotalBombs;
		var_TotalSlows = TotalSlows;
		var_TotalInvinc = TotalInvinc;
		var_TotalGuns = TotalGuns;
		var_TotalBarriers = TotalBarriers;


	}

	//Fuynction that will later be called every second
	void randomNum()
	{
		//gets a random number from 1-100 including 100
		int canSpawn = UnityEngine.Random.Range (1, 101);
		if (canSpawn <= spawnChance)
		{
			int randomPow = UnityEngine.Random.Range (1, 7);
			switch(randomPow)
			{
			case 1:
				Debug.Log("Spawned invincibility");
				spawnPower(invincPow);
				break;
			case 2:
				Debug.Log("Spawned gun");
				spawnPower(gunPow);
				break;
			case 3:
				Debug.Log("Spawned bomb");
				spawnPower(bombPow);
				break;
			case 4:
				Debug.Log("Spawned life");
				spawnPower(lifePow);
				break;
			case 5:
				Debug.Log("Spawned slow");
				spawnPower(slowPow);
				break;
			case 6:
				Debug.Log("Spawned barrier");
				spawnPower(barPow);
				break;
			}
		}

	}



	void spawnPower(GameObject powerup)
	{
		Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, -1);
		Quaternion spawnRotation = new Quaternion (0, rotationValues.y, rotationValues.z, rotationValues.w);
		Instantiate (powerup, spawnPosition, spawnRotation);
	}

	public void sCars()
	{
		CancelInvoke("randomCars");
		InvokeRepeating ("randomCars", 0, carSpawnTime);
	}

	public void randomCars()
	{
		//gets a random number from 1-100 including 100
		int cancarSpawn = UnityEngine.Random.Range (1, 101);
		if (cancarSpawn <= carSpawnChance) {
			int randomCar = UnityEngine.Random.Range (1, 9);
			switch (randomCar) {
			case 1:
				Debug.Log ("Spawned caprise");
				spawnCar(caprise);
				break;
			case 2:
				Debug.Log ("Spawned dirtyvan");
				spawnCar(dirtyvan);
				break;
			case 3:
				Debug.Log ("Spawned hotrod");
				spawnCar(hotrod);
				break;
			case 4:
				Debug.Log ("Spawned lolvo");
				spawnCar(lolvo);
				break;
			case 5:
				Debug.Log ("Spawned passied");
				spawnCar(passied);
				break;
			case 6:
				Debug.Log ("Spawned suv");
				spawnCar(suv);
				break;
			case 7:
				Debug.Log ("Spawned taxi");
				spawnCar(taxi);
				break;
			case 8:
				Debug.Log ("Spawned van");
				spawnCar(van);
				break;
			}
		}
	}


	void spawnCar(GameObject car)
	{
	retry:
		Vector3 CarspawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), 40, 0);
		if (CarspawnPosition.x <= lastPosition.x - negOffset || CarspawnPosition.x >= lastPosition.x + posOffset) {
			Quaternion CarspawnRotation = new Quaternion (90, 0, 0, -90);
			Instantiate (car, CarspawnPosition, CarspawnRotation);
			lastPosition = CarspawnPosition;
			Debug.Log (lastPosition.x.ToString ());
		}
		else
		{
			goto retry;
		}
		 
	}



	
	void Start () {
		//Setting High Scores
		if(PlayerPrefs.HasKey("easyHighScore"))
		{
			highScoreEasy = PlayerPrefs.GetInt("easyHighScore");
		}
		
		if(PlayerPrefs.HasKey("normalHighScore"))
		{
			highScoreNormal = PlayerPrefs.GetInt("normalHighScore");
		}
		if(PlayerPrefs.HasKey("insaneHighScore"))
		{
			highScoreInsane = PlayerPrefs.GetInt("insaneHighScore");
		}

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



		if(!hasInsane)
		{
			insaneLevelButton.interactable = false;
			if(!buyInsaneObj.activeSelf)
			{
				buyInsaneObj.SetActive(true);
			}
		}
		else if(hasInsane)
		{
			insaneLevelButton.interactable = true;
			if(buyInsaneObj.activeSelf)
			{
				buyInsaneObj.SetActive(false);
			}
		}
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

		InvokeRepeating ("randomNum", 0, 1);
		InvokeRepeating ("randomCars", 0, carSpawnTime);
		while (true)
		{
			if(!gameOver)
			{
				//for (int i = 0; i < carsInWaveCount; i++) {
					//Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0);
					//Quaternion spawnRotation = new Quaternion (rotationValues.x, rotationValues.y, rotationValues.z, rotationValues.w);
					//Instantiate (cars, spawnPosition, spawnRotation);

					//yield return new WaitForSeconds (spawnWait);
				//}
				yield return new WaitForSeconds (waveWait);
			}

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

		CancelInvoke ("randomNum");
		CancelInvoke ("randomCars");

		GameObject[] allEnemy = GameObject.FindGameObjectsWithTag ("Enemy") as GameObject[];
		
		for (int i = 0; i < allEnemy.Length; i++)
		{
			Destroy(allEnemy[i]);
		}

		GameObject[] pow1 = GameObject.FindGameObjectsWithTag ("BombPow") as GameObject[];
		for (int i = 0; i < pow1.Length; i++)
		{
			Destroy(pow1[i]);
		}

		GameObject[] pow2 = GameObject.FindGameObjectsWithTag ("GunPow") as GameObject[];
		for (int i = 0; i < pow2.Length; i++)
		{
			Destroy(pow2[i]);
		}

		GameObject[] pow3 = GameObject.FindGameObjectsWithTag ("LifePow") as GameObject[];
		for (int i = 0; i < pow3.Length; i++)
		{
			Destroy(pow3[i]);
		}

		GameObject[] pow4 = GameObject.FindGameObjectsWithTag ("InvincPow") as GameObject[];
		for (int i = 0; i < pow4.Length; i++)
		{
			Destroy(pow4[i]);
		}

		GameObject[] pow5 = GameObject.FindGameObjectsWithTag ("BlockPow") as GameObject[];
		for (int i = 0; i < pow5.Length; i++)
		{
			Destroy(pow5[i]);
		}

		GameObject[] pow6 = GameObject.FindGameObjectsWithTag ("SlowPow") as GameObject[];
		for (int i = 0; i < pow6.Length; i++)
		{
			Destroy(pow6[i]);
		}


		coins += score;

		if(easy)
		{

			if (PlayerPrefs.HasKey("easyHighScore")) {
				if(score > highScoreEasy)
				{
					easyHighScore = score;
					
				}
				else
				{
					easyHighScore = highScoreEasy;
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
				if(score > highScoreNormal)
				{
					normalHighScore = score;
					
				}
				else
				{
					normalHighScore = highScoreNormal;
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
				if(score > highScoreInsane)
				{
					insaneHighScore = score;
					
				}
				else
				{
					insaneHighScore = highScoreInsane;
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

	public void buyInsane (){
		if(coins >= insaneCost && !hasInsane)
		{
			coins -= insaneCost;
			hasInsane = true;
			buyInsaneObj.SetActive(false);
			insaneLevelButton.interactable = true;
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.SetInt ("hasInsane", (1));
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
						coins += 200;
						PlayerPrefs.SetInt ("Coins", coins);
						PlayerPrefs.Save();
						Debug.Log(result.ToString());
					} else if (result.ToString () == "Skipped") {
						coins += 20;
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
