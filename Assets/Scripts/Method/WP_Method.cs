using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WP_Method : MonoBehaviour
{
    // Alternatif
    public float attackWeight;
    public float defenseWeight;
    public float healthWeight;
    // Bobot
    public float maxAttack;
    public float maxDefense;
    public float maxhealth;
    // Kriteria
    public float[] skill1Ranking = new float[] { 80f, 70f, 90f }; // skill1 memiliki ranking 80 pada attack, 70 pada defense, dan 90 pada health
    public float[] skill2Ranking = new float[] { 60f, 90f, 80f }; // skill2 memiliki ranking 60 pada attack, 90 pada defense, dan 80 pada health
    public float[] skill3Ranking = new float[] { 90f, 80f, 70f }; // skill3 memiliki ranking 90 pada attack, 80 pada defense, dan 70 pada health

    // Untuk Menampilkan pada Canvas Text
    public Text teks;

    void Start()
    {
        // Normalisasi bobot kriteria
        float totalWeight = attackWeight + defenseWeight + healthWeight;
        attackWeight = attackWeight / totalWeight;
        defenseWeight = defenseWeight / totalWeight;
        healthWeight = healthWeight / totalWeight;

        // Perhitungan peringkat setiap alternatif berdasarkan kriteria
        float skill1AttackRank = skill1Ranking[0] / maxAttack;
        float skill1DefenseRank = skill1Ranking[1] / maxDefense;
        float skill1healthRank = skill1Ranking[2] / maxhealth;

        float skill2AttackRank = skill2Ranking[0] / maxAttack;
        float skill2DefenseRank = skill2Ranking[1] / maxDefense;
        float skill2healthRank = skill2Ranking[2] / maxhealth;

        float skill3AttackRank = skill3Ranking[0] / maxAttack;
        float skill3DefenseRank = skill3Ranking[1] / maxDefense;
        float skill3healthRank = skill3Ranking[2] / maxhealth;

        // Perhitungan nilai alternatif untuk setiap alternatif
        float skill1Value = skill1AttackRank * attackWeight +
                            skill1DefenseRank * defenseWeight +
                            skill1healthRank * healthWeight;

        float skill2Value = skill2AttackRank * attackWeight +
                               skill2DefenseRank * defenseWeight +
                               skill2healthRank * healthWeight;

        float skill3Value = skill3AttackRank * attackWeight +
                            skill3DefenseRank * defenseWeight +
                            skill3healthRank * healthWeight;

        // Bandingkan nilai alternatif dan pilih alternatif terbaik
        if (skill1Value > skill2Value && skill1Value > skill3Value)
        {
            Debug.Log("Pilih Skill 1");
            teks.text = "Karena Musuhnya Portugese Lieutenant maka lebih efektif menggunakan Skill 1";
            // Lakukan aksi untuk memilih skill skill1
        }
        else if (skill2Value > skill1Value && skill2Value > skill3Value)
        {
            Debug.Log("Pilih Skill 2");
            teks.text = "Karena Musuhnya Portugese Corporal maka lebih efektif menggunakan Skill 2";
            // Lakukan aksi untuk memilih skill skill2
        }
        else
        {
            Debug.Log("Pilih Skill 3");
            teks.text = "Karena Musuhnya Portugese Captain maka lebih efektif menggunakan Skill 3";
            // Lakukan aksi untuk memilih skill skill3
        }
    }
}
