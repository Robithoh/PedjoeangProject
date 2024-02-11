using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyTB : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float maxHP;
    public float HP;
    public float DEF;
    public float ATK;
    public float MATK;
    public float CRIT;

    public Image HealthBar;
    public GameObject PedangAnggar;
    public GameObject panelWin;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        panelWin.SetActive(false);
        UpdateHealthBar(HP, maxHP);
        PedangAnggar.SetActive(false);
    }

    public void UpdateHealthBar(float CurrentHealth, float MaxHealth)
    {
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }

    private void EnemyAttackRoutine()
    {
        StartCoroutine(EnemyAttack());
    }

    IEnumerator EnemyAttack()
    {
        PedangAnggar.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        transform.position = new Vector3(15.509f, -0.0084f, 6.464f);
        anim.SetBool("isAttack", true);

        yield return new WaitForSeconds(2.033f);
        PlayerTB playerScript = FindObjectOfType<PlayerTB>();
        if (playerScript != null)
        {
            Debug.Log("Nyerang");
            float damageDealt = ATK + MATK + CRIT - playerScript.DEF;
            damageDealt = Mathf.Max(0, damageDealt); // Pastikan damage tidak negatif
            playerScript.TakeDamage(damageDealt);
            transform.position = new Vector3(17.69f, -0.0084f, 7.741f);
            PedangAnggar.SetActive(false);
            anim.SetBool("isAttack", false);
        }
    }

    public void TakeDamage(float damage)
    {
        String currentScene = SceneManager.GetActiveScene().name;
        // Implementasi pengurangan HP musuh saat diserang
        HP -= damage;
        UpdateHealthBar(HP, maxHP);
        if (HP <= 0)
        {
            // Musuh mati atau implementasikan logika kematian musuh
            Destroy(gameObject);
            if (currentScene == "TurnBased1")
            {
                panelWin.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("MainScene");
            }
        }
        else
        {
            EnemyAttackRoutine();
        }
    }
}
