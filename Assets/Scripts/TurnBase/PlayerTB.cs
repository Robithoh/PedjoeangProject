using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTB : MonoBehaviour
{
    [Header("Player Stats")]
    public float maxHP;
    public float HP;
    public float DEF;
    public float energy;
    public float maxenergy;
    private float ATK;
    private float ATK2;
    private float ATK3;
    private float dmgMulti;
    
    public GameObject panelLose;
    public GameObject BambuRuncing;
    public GameObject Keris;
    public GameObject Bayonet;
    public GameObject Pistol;
    public GameObject PedangAnggar;
    public Image HealthBar;
    public Image EnergyBar;
    private Animator anim;

    public Button[] attackButtons;


    void Start()
    {
        panelLose.SetActive(false);
        anim = GetComponent<Animator>();
        UpdateHealthBar(HP, maxHP);
        UpdateEnergyBar(energy, maxenergy);
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
        ATK = 7;
        ATK2 = 6;
        ATK3 = 7;
        if (SceneManager.GetActiveScene().name == "TurnBased1")
        {
            dmgMulti = 2f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2")
        {
            dmgMulti = 2.2f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3")
        {
            dmgMulti = 1.7f;
        }
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
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
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
        ATK = 10;
        ATK2 = 4;
        ATK3 = 6;
        if (SceneManager.GetActiveScene().name == "TurnBased1")
        {
            dmgMulti = 3.1f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2")
        {
            dmgMulti = 2.2f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3")
        {
            dmgMulti = 1.9f;
        }
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
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
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
        ATK = 5;
        ATK2 = 9;
        ATK3 = 6;
        if (SceneManager.GetActiveScene().name == "TurnBased1")
        {
            dmgMulti = 2f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2")
        {
            dmgMulti = 3.1f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3")
        {
            dmgMulti = 1.7f;
        }
        Bayonet.SetActive(true);
        //transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isRifle", true);
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
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                //transform.position = new Vector3(14.969f, 0f, 6.585823f);
                Bayonet.SetActive(false);
                anim.SetBool("isRifle", false);
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
        ATK = 4;
        ATK2 = 7;
        ATK3 = 9;
        if (SceneManager.GetActiveScene().name == "TurnBased1")
        {
            dmgMulti = 1.8f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2")
        {
            dmgMulti = 2.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3")
        {
            dmgMulti = 3.1f;
        }
        Pistol.SetActive(true);
        //transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isShoot", true);
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
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                //transform.position = new Vector3(14.969f, 0f, 6.585823f);
                Pistol.SetActive(false);
                anim.SetBool("isShoot", false);
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
        ATK = 6;
        ATK2 = 7;
        ATK3 = 7;
        if (SceneManager.GetActiveScene().name == "TurnBased1")
        {
            dmgMulti = 2f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2")
        {
            dmgMulti = 2.6f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3")
        {
            dmgMulti = 1.5f;
        }
        PedangAnggar.SetActive(true);
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
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                transform.position = new Vector3(14.969f, 0f, 6.585823f);
                PedangAnggar.SetActive(false);
                anim.SetBool("isSlash", false);
            }
        }
    }

    // =============== Skill Cast =============== //

    public GameObject Skill1;
    public GameObject Skill2;
    public GameObject Skill3;
    public GameObject Skill4;
    public GameObject Skill5;
    public GameObject Skill6;
    public float energyCost_Skill1;
    public float energyCost_Skill2;
    public float energyCost_Skill3;
    public float energyCost_Skill4;
    public float energyCost_Skill5;
    public float energyCost_Skill6;

    public void UpdateEnergyBar(float CurrentEnergy, float MaxEnergy)
    {
        EnergyBar.fillAmount = CurrentEnergy / MaxEnergy;
    }
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
        ATK = 7;
        ATK2 = 6;
        ATK3 = 7;
        energy -= energyCost_Skill1;
        UpdateEnergyBar(energy,maxenergy);
        if (SceneManager.GetActiveScene().name == "TurnBased1_OWA")
        {
            dmgMulti = 1.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2_OWA")
        {
            dmgMulti = 1.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3_OWA")
        {
            dmgMulti = 3.5f;
        }
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
        yield return new WaitForSeconds(1f);
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
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
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
        ATK = 10;
        ATK2 = 4;
        ATK3 = 6;
        energy -= energyCost_Skill2;
        UpdateEnergyBar(energy,maxenergy);
        if (SceneManager.GetActiveScene().name == "TurnBased1_OWA")
        {
            dmgMulti = 3.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2_OWA")
        {
            dmgMulti = 1.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3_OWA")
        {
            dmgMulti = 1.5f;
        }
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
        yield return new WaitForSeconds(1f);
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
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
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
        ATK = 5;
        ATK2 = 9;
        ATK3 = 6;
        energy -= energyCost_Skill3;
        UpdateEnergyBar(energy,maxenergy);
        if (SceneManager.GetActiveScene().name == "TurnBased1_OWA")
        {
            dmgMulti = 1.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2_OWA")
        {
            dmgMulti = 1.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3_OWA")
        {
            dmgMulti = 2.3f;
        }
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
        yield return new WaitForSeconds(1f);
        Skill3.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        // Implementasi serangan player ke musuh
        // Mengurangi HP musuh sejumlah ATK player
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyTB enemyScript = enemy.GetComponent<EnemyTB>();
            if (enemyScript != null)
            {
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                Skill3.SetActive(false);
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
        ATK = 4;
        ATK2 = 7;
        ATK3 = 9;
        energy -= energyCost_Skill4;
        UpdateEnergyBar(energy,maxenergy);
        if (SceneManager.GetActiveScene().name == "TurnBased1_OWA")
        {
            dmgMulti = 2.3f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2_OWA")
        {
            dmgMulti = 1.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3_OWA")
        {
            dmgMulti = 1.5f;
        }
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
        yield return new WaitForSeconds(1f);
        Skill4.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        // Implementasi serangan player ke musuh
        // Mengurangi HP musuh sejumlah ATK player
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyTB enemyScript = enemy.GetComponent<EnemyTB>();
            if (enemyScript != null)
            {
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                Skill4.SetActive(false);
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
        ATK = 6;
        ATK2 = 7;
        ATK3 = 7;
        energy -= energyCost_Skill5;
        UpdateEnergyBar(energy,maxenergy);
        if (SceneManager.GetActiveScene().name == "TurnBased1_OWA")
        {
            dmgMulti = 1.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2_OWA")
        {
            dmgMulti = 3.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3_OWA")
        {
            dmgMulti = 1.5f;
        }
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
        yield return new WaitForSeconds(1f);
        Skill5.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        // Implementasi serangan player ke musuh
        // Mengurangi HP musuh sejumlah ATK player
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyTB enemyScript = enemy.GetComponent<EnemyTB>();
            if (enemyScript != null)
            {
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                Skill5.SetActive(false);
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
        ATK = 7;
        ATK2 = 7;
        ATK3 = 6;
        energy -= energyCost_Skill6;
        UpdateEnergyBar(energy,maxenergy);
        if (SceneManager.GetActiveScene().name == "TurnBased1_OWA")
        {
            dmgMulti = 1.5f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2_OWA")
        {
            dmgMulti = 2.3f;
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3_OWA")
        {
            dmgMulti = 1.5f;
        }
        // transform.position = new Vector3(17.139f, 0f, 7.741f);
        anim.SetBool("isCast", true);
        yield return new WaitForSeconds(1f);
        Skill6.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        // Implementasi serangan player ke musuh
        // Mengurangi HP musuh sejumlah ATK player
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyTB enemyScript = enemy.GetComponent<EnemyTB>();
            if (enemyScript != null)
            {
                float damageDealt = (ATK + ATK2 + ATK3) * dmgMulti - enemyScript.DEF;
                damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
                enemyScript.TakeDamage(damageDealt);
                Skill6.SetActive(false);
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
