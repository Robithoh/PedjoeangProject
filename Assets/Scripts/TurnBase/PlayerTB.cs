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

    public Button[] attackButtons;


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
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(AttackSkill1());
        StartCoroutine(DelayButton());
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
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(AttackSkill2());
        StartCoroutine(DelayButton());
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
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(AttackSkill3());
        StartCoroutine(DelayButton());
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
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(AttackSkill4());
        StartCoroutine(DelayButton());
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
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(AttackSkill5());
        StartCoroutine(DelayButton());
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

    // =============== Skill Cast =============== //

    public GameObject Skill1;
    public GameObject Skill2;

    public void Cast1OnClick()
    {
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(CastSkill1());
        StartCoroutine(DelayButton());

    }

    IEnumerator CastSkill1()
    {
        ATK = 15;
        MATK = 12;
        CRIT = 15;
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
        Skill1.SetActive(true);
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
                Skill1.SetActive(false);
                anim.SetBool("isCast", false);
            }
        }
    }
    public void Cast2OnClick()
    {
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(CastSkill2());
        StartCoroutine(DelayButton());
    }

    IEnumerator CastSkill2()
    {
        ATK = 15;
        MATK = 12;
        CRIT = 15;
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
        Skill2.SetActive(true);
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
                Skill2.SetActive(false);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                anim.SetBool("isCast", false);
            }
        }
    }
    public void Cast3OnClick()
    {
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(CastSkill3());
        StartCoroutine(DelayButton());
    }

    IEnumerator CastSkill3()
    {
        ATK = 15;
        MATK = 12;
        CRIT = 15;
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
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
                anim.SetBool("isCast", false);
            }
        }
    }
    public void Cast4OnClick()
    {
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(CastSkill4());
        StartCoroutine(DelayButton());
    }

    IEnumerator CastSkill4()
    {
        ATK = 15;
        MATK = 12;
        CRIT = 15;
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
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
                anim.SetBool("isCast", false);
            }
        }
    }
    public void Cast5OnClick()
    {
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(CastSkill5());
        StartCoroutine(DelayButton());
    }

    IEnumerator CastSkill5()
    {
        ATK = 15;
        MATK = 12;
        CRIT = 15;
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
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
                anim.SetBool("isCast", false);
            }
        }
    }
    public void Cast6OnClick()
    {
        foreach (Button button in attackButtons)
        {
            button.interactable = false;
        }
        StartCoroutine(CastSkill6());
        StartCoroutine(DelayButton());
    }

    IEnumerator CastSkill6()
    {
        ATK = 15;
        MATK = 12;
        CRIT = 15;
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
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
                anim.SetBool("isCast", false);
            }
        }
    }

    IEnumerator DelayButton()
    {
        yield return new WaitForSeconds(7f);

        foreach (Button button in attackButtons)
        {
            button.interactable = true;
        }
    }
}
