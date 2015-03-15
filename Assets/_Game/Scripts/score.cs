using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
public class score : MonoBehaviour {
	

	
	private GameMaster gameMaster;
	public GameObject explosion;
	public GameObject playerExplosion;


	// Use this for initialization
	void Start () {
		
		GameObject gameMasterObject = GameObject.FindWithTag ("GameController");
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
			Destroy(other.gameObject);
			
			gameMaster.GameOver ();
		}
	}



	}


}
