using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class CatLives : MonoBehaviour {

	public static float TotalLives = 1.0f;
	public static float TotalBombs = 10.0f;
	public static float TotalSlows = 10.0f;
	public static float TotalInvinc = 10.0f;
	public static float TotalGuns = 10.0f;
	public static float TotalBarriers = 10.0f;


	public float var_TotalLives = 5.0f;
	public float var_TotalBombs = 5.0f;
	public float var_TotalSlows = 5.0f;
	public float var_TotalInvinc = 5.0f;
	public float var_TotalGuns = 3.0f;
	public float var_TotalBarriers = 5.0f;

	// Use this for initialization
	void Start () {
		var_TotalLives = TotalLives;
		var_TotalBombs = TotalBombs;
		var_TotalSlows = TotalSlows;
		var_TotalInvinc = TotalInvinc;
		var_TotalGuns = TotalGuns;
		var_TotalBarriers = TotalBarriers;

		Advertisement.Initialize ("26283");
		}
		
		

	
	// Update is called once per frame
	void Update () {
	
		var_TotalLives = TotalLives;
		var_TotalBombs = TotalBombs;
		var_TotalSlows = TotalSlows;
		var_TotalInvinc = TotalInvinc;
		var_TotalGuns = TotalGuns;
		var_TotalBarriers = TotalBarriers;
	}


	public void buyLives (){
		TotalLives += 1.0f;
	}

	public void buyInvinc (){
		TotalInvinc += 1.0f;
	}
	public void buyGuns (){
		TotalGuns += 1.0f;
	}
	public void buyBarries (){
		TotalBarriers += 1.0f;
	}
	public void buyBombs (){
		TotalBombs += 1.0f;
	}
	public void buySlows (){
		TotalSlows += 1.0f;
	}

	public void freeCoins (){
		if (Advertisement.isReady ()) {
			Advertisement.Show (null, new ShowOptions {
			resultCallback = result => {
				Debug.Log(result.ToString());
			}
		});
		}
	}


}



