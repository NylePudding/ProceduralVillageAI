using UnityEngine;
using System.Collections;

public class Setup : MonoBehaviour {

	public int startingCouples;
	public GameObject person;
	public int birthChance;
	public int newPartnerChance;
	public int year;
	
	void Start(){
		setup();
	}

	public void setup(){

		year = 0;

		for(int i=0; i<startingCouples; i++){


			float x1 = Random.Range(-50f,50f);
			float z1 = Random.Range(-50f,50f);
			float x2 = Random.Range(-50f,50f);
			float z2 = Random.Range(-50f,50f);


			Vector3 pos1 = new Vector3(x1,0.5f,z1);
			Vector3 pos2 = new Vector3(x2,0.5f,z2);

			GameObject partner1 =  (GameObject) Instantiate(person, pos1, Quaternion.identity);
			GameObject partner2 =  (GameObject) Instantiate(person, pos2, Quaternion.identity);



			PersonStats ps1 = partner1.GetComponent<PersonStats>();
			PersonStats ps2 = partner2.GetComponent<PersonStats>();

			ps1.InitialiseSetupPartner('m',false);
			ps2.InitialiseSetupPartner('f',false);

			ps1.partner = partner2;
			ps2.partner = partner1;

			RelationshipHelper rh = GameObject.Find("Relationships").GetComponent<RelationshipHelper>();

			rh.createLink(partner1, partner2, 75);
		}

	}

	public void yearCycle(){

		year++;



		processBirths();

		processNewPartners();

		ageLiving();

	}

	void ageLiving(){

		PersonStats[] people = GameObject.Find("People").GetComponentsInChildren<PersonStats>();

		foreach (PersonStats p in people){
			if (p.alive){
				p.age++;
			}
		}
	}

	void processBirths(){

		PersonStats[] people = GameObject.Find("People").GetComponentsInChildren<PersonStats>();
		
		foreach (PersonStats p in people){
			
			int rand = Random.Range(0,100);
			
			if (p.partner != null){
				
				if (rand < birthChance){
					
					GameObject baby = (GameObject) Instantiate(person, p.GetComponentInChildren<Transform>().transform.position, Quaternion.identity);
					
					PersonStats bs = baby.GetComponent<PersonStats>();
					
					if (p.gender == 'm'){
						bs.InitialiseBaby(p.partner,p.gameObject);
					}
					else {
						bs.InitialiseBaby(p.gameObject,p.partner);
					}
					
					RelationshipHelper rh = GameObject.Find("Relationships").GetComponent<RelationshipHelper>();
					
					rh.createLink(p.gameObject,baby,100);
					rh.createLink(p.partner,baby,100);
					
				}
			}
		}
	}

    void processDeaths(){

        PersonStats[] people = GameObject.Find("People").GetComponentsInChildren<PersonStats>();

        foreach (PersonStats p in people){

            int rand;

            if (p.age <= 4){
                rand = Random.Range(0, 4386);
            }
            else if (p.age <= 14){
                rand = Random.Range(0, 8333);
            }
            else if (p.age <= 24){
                rand = Random.Range(0, 1908);
            }
            else if (p.age <= 34){
                rand = Random.Range(0, 1215);
            }
            else if (p.age <= 44){
                rand = Random.Range(0, 663);
            }
            else if (p.age <= 54){
                rand = Random.Range(0, 279);
            }
            else if (p.age <= 64){
                rand = Random.Range(0, 112);
            }
            else if (p.age <= 74){
                rand = Random.Range(0, 42);
            }
            else if (p.age <= 84){
                rand = Random.Range(0, 15);
            }
            else {
                rand = Random.Range(0, 6);
            }

        }

    }

	void processNewPartners(){

		PersonStats[] people = GameObject.Find("People").GetComponentsInChildren<PersonStats>();
		PersonStats[] otherPeople = GameObject.Find("People").GetComponentsInChildren<PersonStats>();

		foreach (PersonStats p in people){

			if (p.partner == null){

				if (p.age >= 18){

					foreach (PersonStats op in otherPeople){

						if (p.gameObject != op.gameObject){	//IF NOT ME

							if (op.partner == null){

								if (op.age >= 18){

									int rand = Random.Range(0,100);

									bool applicable = false;

									if ((p.gender == op.gender) && (p.homosexual) && (op.homosexual)){
										applicable = true;
									}
									else if ((p.gender != op.gender) && (!p.homosexual) && (!op.homosexual)){
										applicable = true;
									}

									if (applicable){
										if (rand < newPartnerChance){

											RelationshipHelper rh = GameObject.Find("Relationships").GetComponent<RelationshipHelper>();

											p.partner = op.gameObject;
											op.partner = p.gameObject;

											if (!rh.isDuplicate(p.gameObject,op.gameObject)){
												rh.createLink(p.gameObject, op.gameObject,75);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
