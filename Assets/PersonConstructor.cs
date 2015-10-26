using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonConstructor : MonoBehaviour {


	public string forename;
	public string surname;
	public float age;
	public char gender;
	public bool alive;
	public bool femaleAttraction;
	public bool maleAttraction;
	public int stress;
	public int confidence;
	public int happiness;
	public int temper;
	public GameObject mother;
	public GameObject father;
	public GameObject partner;
	public List<GameObject> afairs;
	public List<GameObject> divorces;
	public List<GameObject> occupations;
	public List<GameObject> contacts;
	public List<string> jobHistory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Initialise (string forename, string surname, float age, char gender, bool alive, bool maleAttraction, bool femaleAttraction, 
	                 int stress, int confidence, int happiness, int temper, GameObject mother, GameObject father, GameObject partner) {

		this.forename = forename;
		this.surname = surname;
		this.age = age;
		this.gender = gender;
		this.alive = alive;
		this.maleAttraction = maleAttraction;
		this.femaleAttraction = femaleAttraction;
		this.stress = stress;
		this.confidence = confidence;
		this.happiness = happiness;
		this.temper = temper;
		this.mother = mother;
		this.father = father;

		afairs = new List<GameObject>();
		divorces = new List<GameObject>();
		occupations = new List<GameObject>();
		contacts = new List<GameObject>();
		jobHistory = new List<string>();
	}
}
