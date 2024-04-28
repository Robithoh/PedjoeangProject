using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static SceneInfo;
using UnityEngine.UI;

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
    public Animator transiton;
    public Text teks;
    public GameObject[] enemy_sprite;
    public GameObject panel_transition;

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

    private IEnumerator DelayedSceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(4f); // Menunda selama 2 detik

        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 savedPos = myTarget.transform.position;

        if (other.tag == "Player")
        {
            if (gameObject.tag == "DeKock")
            {
                sceneInfo.listEnemy[0] = true;
                if (sceneInfo != null)
                {
                    sceneInfo.SaveCharPos(savedPos);
                    sceneInfo.isNextScene = newScene;
                }
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                // MusicManager.Instance.ChangeMusic();
                string sceneBattle = sceneInfo.listScene[0];
                transiton.SetTrigger("Start");
                panel_transition.SetActive(true);
                enemy_sprite[0].SetActive(true);
                teks.text = "Jendral De Kock (Boss)";
                transiton.SetBool("isStart", true);
                StartCoroutine(DelayedSceneLoad(sceneBattle));
            }
            else if (gameObject.tag == "PrajuritMerah")
            {
                sceneInfo.listEnemy[1] = true;
                if (sceneInfo != null)
                {
                    sceneInfo.SaveCharPos(savedPos);
                    sceneInfo.isNextScene = newScene;
                }
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                // MusicManager.Instance.ChangeMusic();
                string sceneBattle = sceneInfo.listScene[1];
                transiton.SetTrigger("Start");
                panel_transition.SetActive(true);
                enemy_sprite[1].SetActive(true);
                teks.text = "Prajurit Merah";
                transiton.SetBool("isStart", true);
                StartCoroutine(DelayedSceneLoad(sceneBattle));
            }
            else if (gameObject.tag == "PrajuritHijau")
            {
                sceneInfo.listEnemy[2] = true;
                if (sceneInfo != null)
                {
                    sceneInfo.SaveCharPos(savedPos);
                    sceneInfo.isNextScene = newScene;
                }
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                // MusicManager.Instance.ChangeMusic();
                
                string sceneBattle = sceneInfo.listScene[2];
                
                panel_transition.SetActive(true);
                enemy_sprite[2].SetActive(true);
                teks.text = "Prajurit Hijau";
                transiton.SetBool("isStart", true);
                StartCoroutine(DelayedSceneLoad(sceneBattle));
            }
        }
    }

    public void DestroyEnemy()
    {
        if (sceneInfo.isNextScene == true && sceneInfo.listEnemy[0] == true)
        {
            GameObject gameObjectWithTag = GameObject.FindGameObjectWithTag("DeKock");
            gameObjectWithTag.transform.position = new Vector3(gameObjectWithTag.transform.position.x, -0.58f, gameObjectWithTag.transform.position.z);
            Destroy(gameObjectWithTag);
        }
        if (sceneInfo.isNextScene == true && sceneInfo.listEnemy[1] == true)
        {
            GameObject gameObjectWithTag = GameObject.FindGameObjectWithTag("PrajuritMerah");
            gameObjectWithTag.transform.position = new Vector3(gameObjectWithTag.transform.position.x, -0.58f, gameObjectWithTag.transform.position.z);
            Destroy(gameObjectWithTag);
        }
        if (sceneInfo.isNextScene == true && sceneInfo.listEnemy[2] == true)
        {
            GameObject gameObjectWithTag = GameObject.FindGameObjectWithTag("PrajuritHijau");
            gameObjectWithTag.transform.position = new Vector3(gameObjectWithTag.transform.position.x, -0.58f, gameObjectWithTag.transform.position.z);
            Destroy(gameObjectWithTag);
        }
    }
}