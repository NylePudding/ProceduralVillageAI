using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonStats : MonoBehaviour {

    private GameObject helper;
    private NameGenerator nameGenerator;

	public string forename;
	public string surname;
	public float age;
	public char gender;
	public bool alive;
    public bool homosexual;
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


        helper = GameObject.Find("_helper");

        nameGenerator = helper.GetComponent<NameGenerator>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitialiseGeneric (string forename, string surname, float age, char gender, bool alive, bool homosexual, 
	                 int stress, int confidence, int happiness, int temper, GameObject mother, GameObject father, GameObject partner) {

		this.forename = forename;
		this.surname = surname;
		this.age = age;
		this.gender = gender;
		this.alive = alive;
        this.homosexual = homosexual;
		this.stress = stress;
		this.confidence = confidence;
		this.happiness = happiness;
		this.temper = temper;
		this.mother = mother;
		this.father = father;
        this.partner = partner;

		afairs = new List<GameObject>();
		divorces = new List<GameObject>();
		occupations = new List<GameObject>();
		contacts = new List<GameObject>();
		jobHistory = new List<string>();
	}

    void InitialiseBaby(GameObject mother, GameObject father){

        int rand = Random.Range(0, 1);

        if (rand == 0) gender = 'm';
        else gender = 'f';

        forename = nameGenerator.newForename(gender);
        surname = nameGenerator.newSurname(gender);

        this.mother = mother;
        this.father = father;
        partner = null;

        age = 0;
        alive = true;

        rand = Random.Range(0, 1);
        if (rand == 0) homosexual = false;
        else homosexual = true;

        stress = 0;
        confidence = 0;
        happiness = 100;
        temper = 100;

        afairs = new List<GameObject>();
        divorces = new List<GameObject>();
        occupations = new List<GameObject>();
        contacts = new List<GameObject>();
        jobHistory = new List<string>();
        
    }

    void InitialiseOutsiderPartner(GameObject partner){

        PersonStats partnerStats = partner.GetComponent<PersonStats>();


        if (partnerStats.homosexual) {
            gender = partnerStats.gender;
            homosexual = true;
        }
        else {
            homosexual = false;
            if (partnerStats.gender = 'm')
            {
                gender = 'f';
                forename = nameGenerator.newForename(gender);
                surname = partnerStats.surname;
            }
            else
            {
                gender = 'm';
                forename = nameGenerator.newForename(gender);
                surname = nameGenerator.newSurname();
                partnerStats.surname = surname;
            }
        }

        mother = null;
        father = null;


        age = Random.Range(18, 100);
        alive = true;
        this.partner = partner;
        
        stress = Random.Range(0,100);
        confidence = Random.Range(0, 100);
        happiness = Random.Range(0, 100);
        temper = Random.Range(0, 100);


        afairs = new List<GameObject>();
        divorces = new List<GameObject>();
        occupations = new List<GameObject>();
        contacts = new List<GameObject>();
        jobHistory = new List<string>();
    }
}
