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
    public GameObject BambuRuncing;
    public GameObject Keris;
    public GameObject Bayonet;
    public Image HealthBar;
    private Animator anim;


    void Start()
    {
        panelLose.SetActive(false);
        anim = GetComponent<Animator>();
        UpdateHealthBar(HP, maxHP);
        BambuRuncing.SetActive(false);
        Keris.SetActive(false);
        Bayonet.SetActive(false);
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
        ATK = 25;
        MATK = 5;
        CRIT = 15;
        BambuRuncing.SetActive(true);
        transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isStab", true);
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
                float damageDealt = ATK + MATK + CRIT - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                BambuRuncing.SetActive(false);
                anim.SetBool("isStab", false);
            }
        }
    }

    public void Attack2OnClick()
    {
        StartCoroutine(AttackSkill2());
    }

    IEnumerator AttackSkill2()
    {
        ATK = 25;
        MATK = 7;
        CRIT = 5;
        Keris.SetActive(true);
        transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isSlash", true);
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
                float damageDealt = ATK + MATK + CRIT - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                Keris.SetActive(false);
                anim.SetBool("isSlash", false);
            }
        }
    }

    public void Attack3OnClick()
    {
        StartCoroutine(AttackSkill3());
    }

    IEnumerator AttackSkill3()
    {
        ATK = 2;
        MATK = 30;
        CRIT = 11;
        Bayonet.SetActive(true);
        transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isStab", true);
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
                float damageDealt = ATK + MATK + CRIT - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                Bayonet.SetActive(false);
                anim.SetBool("isStab", false);
            }
        }
    }

    public void Attack4OnClick()
    {
        StartCoroutine(AttackSkill4());
    }

    IEnumerator AttackSkill4()
    {
        ATK = 22;
        MATK = 10;
        CRIT = 8;
        transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isBambu", true);
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
                float damageDealt = ATK + MATK + CRIT - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                anim.SetBool("isBambu", false);
            }
        }
    }
    public void Attack5OnClick()
    {
        StartCoroutine(AttackSkill5());
    }

    IEnumerator AttackSkill5()
    {
        ATK = 15;
        MATK = 12;
        CRIT = 15;
        transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isBambu", true);
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
                float damageDealt = ATK + MATK + CRIT - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                anim.SetBool("isBambu", false);
            }
        }
    }
}
