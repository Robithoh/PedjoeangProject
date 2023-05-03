using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Method : MonoBehaviour
{
    public float attackWeight;
    public float defenseWeight;
    public float speedWeight;
    public float maxAttack;
    public float maxDefense;
    public float maxSpeed;
    public float[] archerRanking = new float[] { 80f, 70f, 90f }; // Archer memiliki ranking 80 pada attack, 70 pada defense, dan 90 pada speed
    public float[] swordsmanRanking = new float[] { 60f, 90f, 80f }; // Swordsman memiliki ranking 60 pada attack, 90 pada defense, dan 80 pada speed
    public float[] wizardRanking = new float[] { 90f, 80f, 70f }; // Wizard memiliki ranking 90 pada attack, 80 pada defense, dan 70 pada speed

    void Start()
    {
        // Normalisasi bobot kriteria
        float totalWeight = attackWeight + defenseWeight + speedWeight;
        attackWeight = attackWeight / totalWeight;
        defenseWeight = defenseWeight / totalWeight;
        speedWeight = speedWeight / totalWeight;

        // Perhitungan peringkat setiap alternatif berdasarkan kriteria
        float archerAttackRank = archerRanking[0] / maxAttack;
        float archerDefenseRank = archerRanking[1] / maxDefense;
        float archerSpeedRank = archerRanking[2] / maxSpeed;

        float swordsmanAttackRank = swordsmanRanking[0] / maxAttack;
        float swordsmanDefenseRank = swordsmanRanking[1] / maxDefense;
        float swordsmanSpeedRank = swordsmanRanking[2] / maxSpeed;

        float wizardAttackRank = wizardRanking[0] / maxAttack;
        float wizardDefenseRank = wizardRanking[1] / maxDefense;
        float wizardSpeedRank = wizardRanking[2] / maxSpeed;

        // Perhitungan nilai alternatif untuk setiap alternatif
        float archerValue = archerAttackRank * attackWeight +
                            archerDefenseRank * defenseWeight +
                            archerSpeedRank * speedWeight;

        float swordsmanValue = swordsmanAttackRank * attackWeight +
                               swordsmanDefenseRank * defenseWeight +
                               swordsmanSpeedRank * speedWeight;

        float wizardValue = wizardAttackRank * attackWeight +
                            wizardDefenseRank * defenseWeight +
                            wizardSpeedRank * speedWeight;

        // Bandingkan nilai alternatif dan pilih alternatif terbaik
        if (archerValue > swordsmanValue && archerValue > wizardValue)
        {
            Debug.Log("Pilih Skill 1");
            // Lakukan aksi untuk memilih skill Archer
        }
        else if (swordsmanValue > archerValue && swordsmanValue > wizardValue)
        {
            Debug.Log("Pilih Skill 2");
            // Lakukan aksi untuk memilih skill Swordsman
        }
        else
        {
            Debug.Log("Pilih Skill 3");
            // Lakukan aksi untuk memilih skill Wizard
        }
    }
}
