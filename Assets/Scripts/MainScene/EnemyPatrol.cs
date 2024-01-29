using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static SceneInfo;

public class EnemyPatrol : MonoBehaviour
{
    private Animator animepatrol;
    public GameObject myTarget;
    public int range;
    NavMeshAgent myAgent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    public SceneInfo sceneInfo;

    public bool newScene = true;



    // Start is called before the first frame update
    void Start()
    {
        animepatrol = GetComponent<Animator>();
        myAgent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        DestroyEnemy();
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
        Vector3 savedPos = myTarget.transform.position;

        if (other.tag == "Player")
        {
            if(gameObject.tag == "DeKock")
            {
                //sceneInfo.listEnemy[0] = true;
                if (sceneInfo != null)
                {
                    sceneInfo.SaveCharPos(savedPos);
                    sceneInfo.isNextScene = newScene;
                }
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                string deKock = sceneInfo.listScene[0];
                SceneManager.LoadScene(deKock);
            }
        }
    }

    public void DestroyEnemy()
    {
        if (sceneInfo.isNextScene == true)
        {
            GameObject gameObjectWithTag = GameObject.FindGameObjectWithTag("DeKock");
            gameObjectWithTag.transform.position = new Vector3(gameObjectWithTag.transform.position.x, -0.58f, gameObjectWithTag.transform.position.z);
            Destroy(gameObjectWithTag);
        }
    }
}