using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OccupationConstructor : MonoBehaviour {

	public GameObject boss;
	public List<GameObject> fullTime;
	public List<GameObject> partTime;
	public int capacity;
	public int ageLowerBound;
	public int ageUpperBound;
	public List<GameObject> exEmployees;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Initialise (int capacity, int ageLowerBound, int ageUpperBound, GameObject boss) {

		this.capacity = capacity;
		this.ageLowerBound = ageLowerBound;
		this.ageUpperBound = ageUpperBound;
		this.boss = boss;

		fullTime = new List<GameObject>();
		partTime = new List<GameObject>();
		exEmployees = new List<GameObject>();
	}
}
