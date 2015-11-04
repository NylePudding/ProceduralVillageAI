using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour {

	PersonStats ps;

	bool init = false;
	Transform player;
	Transform p;

	NavMeshAgent nav;


	void Awake(){
		nav = GetComponent <NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {


		if (!init){
			init = true;
			ps = GetComponentInParent<PersonStats>();
		}

        //transform.localScale.Set(0.7f, 0.7f, 0.7f);

        Renderer rend = GetComponent<Renderer>();

        if (ps.gender == 'f') {
            rend.material.color = Color.red;
        }
        else {
            rend.material.color = Color.blue;
        }


		if (ps.age <= 18){
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
		}
		else {
            transform.localScale = new Vector3(1f, 1f, 1f);
		}

        if (ps.alive)
        {
            if (ps.partner != null)
            {
                p = ps.partner.transform.FindChild("Body");
            }
            else if (ps.mother != null)
            {
                p = ps.mother.transform.FindChild("Body");
            }
            else
            {
                p = GameObject.FindGameObjectWithTag("Player").transform;
            }
            nav.SetDestination(p.position);
        }
	}
}
