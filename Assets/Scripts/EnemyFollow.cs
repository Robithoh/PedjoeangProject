using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private Animator animenemy;
    public GameObject myTarget;
    public NavMeshAgent myAgent;
    public int range;

    // Start is called before the first frame update
    void Start()
    {
        animenemy = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, myTarget.transform.position);

        if (dist < range)
        {
            animenemy.SetBool("isMoving", true);
            myAgent.destination = myTarget.transform.position;
        }
        else
        {
            animenemy.SetBool("isMoving", false);
        }
    }
}
