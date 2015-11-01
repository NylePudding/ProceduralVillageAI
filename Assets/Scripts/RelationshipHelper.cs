using UnityEngine;
using System.Collections;

public class RelationshipHelper : MonoBehaviour {

	public GameObject link;


	public void createLink(GameObject person1, GameObject person2, int strength){

		Vector3 pos = new Vector3(0.0f,0.0f,0.0f);

		GameObject newLink = (GameObject) Instantiate(link,pos,Quaternion.identity);
		LinkStats ls = newLink.GetComponent<LinkStats>();
		ls.Initialise(person1, person2, strength);



	}


	bool isDuplicate(GameObject person1, GameObject person2){

		bool duplicateFound = false;

		LinkStats[] allLinks = GetComponentsInChildren<LinkStats>();



		foreach (LinkStats child in allLinks) {

			if ((person1 == child.link1 && person2 == child.link2) || (person1 == child.link2 && person2 == child.link1)){

				duplicateFound = true;
				break;
			}
		}
		return duplicateFound;
	}
}
