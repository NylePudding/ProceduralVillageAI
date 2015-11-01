using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour {

	PersonStats ps;

	bool init = false;
	Transform player;
	Transform p;

	//PlayerHealth playerHealth;
	//EnemyHealth enemyHealth;
	NavMeshAgent nav;


	void Awake(){
		//player = GameObject.FindGameObjectWithTag("Player").transform;






		//playerHealth = player.GetComponent <PlayerHealth>();
		//enemyHealth = GetComponent <EnemyHealth()>();
		nav = GetComponent <NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

		ps = GetComponentInParent<PersonStats>();

		if (!init){
			init = true;

			if (ps.partner != null){
				p = ps.partner.transform.FindChild("Body");
			}
			else if (ps.mother != null) {
				p = ps.mother.transform.FindChild("Body");
			}
			else {
				p = GameObject.FindGameObjectWithTag("Player").transform;
			}
		}

		nav.SetDestination(p.position);
	}
}
