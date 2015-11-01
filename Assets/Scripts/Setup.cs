using UnityEngine;
using System.Collections;

public class Setup : MonoBehaviour {

	public int startingCouples;
	public GameObject person;





	void Start(){
		setup();
	}

	void setup(){

		for(int i=0; i<startingCouples; i++){


			float x1 = Random.Range(-100f,100f);
			float z1 = Random.Range(-100f,100f);
			float x2 = Random.Range(-100f,100f);
			float z2 = Random.Range(-100f,100f);


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
}
