using UnityEngine;
using System.Collections;

public class RobotFollow : MonoBehaviour {

    public GameObject destination;
    Camera cam;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        cam = Camera.main;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }

        if (Vector3.Distance(transform.position, navMeshAgent.destination) <= 1f)
        {
            navMeshAgent.SetDestination(destination.transform.position);
        }

        if(navMeshAgent.remainingDistance < 0.05f)
            animator.SetBool("isMoving", false);
        else
            animator.SetBool("isMoving", true);
    }
}
