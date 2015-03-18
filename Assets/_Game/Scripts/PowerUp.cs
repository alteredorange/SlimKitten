using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour {
	public string Name;
	public float duration;
	public bool enabled;

	public void setUp(string name)
	{
		Name = name;

	}

	

	public void Add(List<PowerUp> @powerList)
	{
		powerList.Add (this);
	}

	public void Remove(List<PowerUp> @powerList)
	{
		powerList.Remove (this);
	}


}
