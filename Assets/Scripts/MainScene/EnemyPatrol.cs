using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    private Animator animepatrol;
    public GameObject myTarget;
    public int range;
    NavMeshAgent myAgent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        animepatrol = GetComponent<Animator>();
        myAgent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, myTarget.transform.position);

        if (Vector3.Distance(transform.position, target) < 1)
        {
            animepatrol.SetBool("isMoving", true);
            IterateWaypointIndex();
            UpdateDestination();
        }
        else if (dist < range)
        {
            animepatrol.SetBool("isMoving", true);
            myAgent.destination = myTarget.transform.position;
        }
        else
        {
            animepatrol.SetBool("isMoving", true);
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        myAgent.SetDestination(target);
    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("TurnBasedScene");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}