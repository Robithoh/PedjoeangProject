using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTB : MonoBehaviour
{
    [Header("Player Stats")]
    public float maxHP;
    public float HP;
    public float DEF;
    private float ATK;
    private float MATK;
    private float CRIT;

    public GameObject panelLose;
    public GameObject Knife;
    public Image HealthBar;
    private Animator anim;


    void Start()
    {
        panelLose.SetActive(false);
        anim = GetComponent<Animator>();
        UpdateHealthBar(HP, maxHP);
        Knife.SetActive(false);
    }

    public void UpdateHealthBar(float CurrentHealth, float MaxHealth)
    {
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Implementasi pengurangan HP musuh saat diserang
        HP -= damage;
        UpdateHealthBar(HP, maxHP);
        if (HP <= 0)
        {
            // Musuh mati atau implementasikan logika kematian musuh
            Destroy(gameObject);
            panelLose.SetActive(true);
        }
    }

    public void Attack1OnClick()
    {
        StartCoroutine(AttackSkill1());
    }

    IEnumerator AttackSkill1()
    {
        ATK = 5;
        Knife.SetActive(true);
        transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(1.5f);

        // Implementasi serangan player ke musuh
        // Mengurangi HP musuh sejumlah ATK player
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyTB enemyScript = enemy.GetComponent<EnemyTB>();
            if (enemyScript != null)
            {
                Debug.Log("Player Menyerang");
                float damageDealt = ATK - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                Knife.SetActive(false);
                anim.SetBool("isAttack", false);
            }
        }
    }

    public void Attack2OnClick()
    {
        StartCoroutine(AttackSkill2());
    }

    IEnumerator AttackSkill2()
    {
        ATK = 50;
        transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(1.5f);

        // Implementasi serangan player ke musuh
        // Mengurangi HP musuh sejumlah ATK player
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyTB enemyScript = enemy.GetComponent<EnemyTB>();
            if (enemyScript != null)
            {
                Debug.Log("Player Menyerang");
                float damageDealt = ATK - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                anim.SetBool("isAttack", false);
            }
        }
    }

    public void Attack3OnClick()
    {
        StartCoroutine(AttackSkill3());
    }

    IEnumerator AttackSkill3()
    {
        ATK = 35;
        transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(1.5f);

        // Implementasi serangan player ke musuh
        // Mengurangi HP musuh sejumlah ATK player
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyTB enemyScript = enemy.GetComponent<EnemyTB>();
            if (enemyScript != null)
            {
                Debug.Log("Player Menyerang");
                float damageDealt = ATK - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                anim.SetBool("isAttack", false);
            }
        }
    }
}
