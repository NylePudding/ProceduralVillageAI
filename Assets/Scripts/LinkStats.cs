using UnityEngine;
using System.Collections;

public class LinkStats : MonoBehaviour {

	public GameObject link1;
	public GameObject link2;
	public int strength;

	public void Initialise(GameObject link1, GameObject link2, int strength){
		this.link1 = link1;
		this.link2 = link2;
		this.strength = strength;

		transform.parent = GameObject.Find("Relationships").transform;
	}
	
}
