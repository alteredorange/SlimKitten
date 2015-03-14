using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
public class score : MonoBehaviour {
	

	public int scoreValue;
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



	//timeout destroy object
		[SerializeField] private float m_TimeOut = 1.0f;
		[SerializeField] private bool m_DetachChildren = false;
		
		
		private void Awake()
		{
			Invoke("DestroyNow", m_TimeOut);
		}
		
		
		private void DestroyNow()
		{
			if (m_DetachChildren)
			{
				transform.DetachChildren();
			}	
		gameMaster.AddScore (scoreValue);	
		DestroyObject(gameObject);

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
