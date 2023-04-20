using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMain : MonoBehaviour
{
    private Animator animenemy;
    public GameObject myTarget;
    public NavMeshAgent myAgent;

    // Start is called before the first frame update
    void Start()
    {
        animenemy = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myTarget != null)
        {
            animenemy.SetBool("isMoving", true);
            myAgent.destination = myTarget.transform.position;
        }
        else
        {
            animenemy.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            myTarget = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            myTarget = null;
        }
    }
}