using UnityEngine;
using System.Collections;

public class CatLives : MonoBehaviour {

	public static float TotalLives = 1.0f;
	public static float TotalBombs = 1.0f;
	public static float TotalSlows = 1.0f;
	public static float TotalInvinc = 1.0f;
	public static float TotalGuns = 1.0f;
	public static float TotalBarriers = 1.0f;


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
}
