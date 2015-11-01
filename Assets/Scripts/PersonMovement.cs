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

		if (!init){
			init = true;
			player = GameObject.FindGameObjectWithTag("Player").transform;


		}

		ps = GetComponentInParent<PersonStats>();
		p = ps.partner.GetComponentInChildren<Transform>().transform;

		nav.SetDestination(p.position);


	}
}
