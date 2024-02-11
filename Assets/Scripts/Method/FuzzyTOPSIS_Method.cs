using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyTOPSIS_Method : MonoBehaviour
{
    // Kriteria dan alternatif
    private int jumlahKriteria = 5;
    private int jumlahAlternatif = 5;

    // Matrix keputusan (nilai keanggotaan)
    private double[,,] matrixKeputusan = new double[5, 5, 3] {
        {
            {1, 1, 3},
            {1, 3, 5},
            {1, 3, 5},
            {5, 7, 9},
            {5, 7, 9}
        },
        {
            {1, 1, 3},
            {3, 5, 7},
            {5, 7, 9},
            {3, 5, 7},
            {1, 1, 3}
        },
        {
            {3, 5, 7},
            {5, 7, 9},
            {7, 9, 9},
            {3, 5, 7},
            {3, 5, 7}
        },
        {
            {5, 7, 9},
            {1, 3, 5},
            {1, 1, 3},
            {1, 1, 3},
            {7, 9, 9}
        },
        {
            {7, 9, 9},
            {7, 9, 9},
            {1, 1, 3},
            {1, 3, 5},
            {1, 1, 3}
        },
        // Isi nilai keanggotaan untuk kriteria lainnya
    };

    // Bobot kriteria (triangular fuzzy number)
    private double[,] bobotKriteria = new double[5, 3] {
        {1, 1, 3},
        {1, 3, 5},
        {1, 1, 3},
        {7, 9, 9},
        {1, 3, 5}
    };

    // Nilai normalisasi
    private double[] nilaiNormalisasi = new double[5];

    // Nilai bobot terbobot
    private double[,] nilaiBobotTerbobot = new double[5, 5];

    // Solusi ideal positif dan negatif
    private double[] solusiIdealPositif = new double[5];
    private double[] solusiIdealNegatif = new double[5];

    // Jarak alternatif terhadap solusi ideal positif dan negatif
    private double[] jarakSolusiIdealPositif = new double[5];
    private double[] jarakSolusiIdealNegatif = new double[5];

    // Skor relatif alternatif
    private double[] skorRelatif = new double[5];

    void Start()
    {
        HitungNilaiNormalisasi();
        HitungNilaiBobotTerbobot();
        HitungSolusiIdeal();
        HitungJarakSolusiIdeal();
        HitungSkorRelatif();
        PrintHasilTOPSIS();
    }

    void HitungNilaiNormalisasi()
    {
        for (int i = 0; i < jumlahKriteria; i++)
        {
            double sum = 0;
            for (int j = 0; j < jumlahAlternatif; j++)
            {
                double a = matrixKeputusan[i, j, 0];
                double b = matrixKeputusan[i, j, 1];
                double c = matrixKeputusan[i, j, 2];

                // Menggunakan nilai puncak sebagai nilai keanggotaan untuk triangular fuzzy number
                double nilaiKeanggotaan = b;
                sum += Math.Sqrt(nilaiKeanggotaan); // Menggunakan akar kuadrat dari nilai keanggotaan
            }
            nilaiNormalisasi[i] = sum;
        }
    }

    void HitungNilaiBobotTerbobot()
    {
        for (int i = 0; i < jumlahKriteria; i++)
        {
            double a = bobotKriteria[i, 0];
            double b = bobotKriteria[i, 1];
            double c = bobotKriteria[i, 2];

            // Menggunakan nilai puncak sebagai nilai keanggotaan untuk triangular fuzzy number
            double nilaiKeanggotaan = b;

            for (int j = 0; j < jumlahAlternatif; j++)
            {
                if (nilaiNormalisasi[i] != 0) // Menambahkan penanganan ketika nilai normalisasi tidak sama dengan 0
                {
                    double x = nilaiKeanggotaan / nilaiNormalisasi[i];
                    nilaiBobotTerbobot[i, j] = (x - a) / (c - a);
                }
                else
                {
                    nilaiBobotTerbobot[i, j] = 0; // Menetapkan nilai bobot terbobot menjadi 0 jika terjadi pembagian oleh 0
                }
            }
        }
    }

    void HitungSolusiIdeal()
    {
        for (int i = 0; i < jumlahKriteria; i++)
        {
            solusiIdealPositif[i] = double.MinValue;
            solusiIdealNegatif[i] = double.MaxValue;

            for (int j = 0; j < jumlahAlternatif; j++)
            {
                if (nilaiBobotTerbobot[i, j] > solusiIdealPositif[i])
                    solusiIdealPositif[i] = nilaiBobotTerbobot[i, j];

                if (nilaiBobotTerbobot[i, j] < solusiIdealNegatif[i])
                    solusiIdealNegatif[i] = nilaiBobotTerbobot[i, j];
            }
        }
    }

    void HitungJarakSolusiIdeal()
    {
        for (int j = 0; j < jumlahAlternatif; j++)
        {
            double sumPositif = 0;
            double sumNegatif = 0;

            for (int i = 0; i < jumlahKriteria; i++)
            {
                sumPositif += Math.Pow(nilaiBobotTerbobot[i, j] - solusiIdealPositif[i], 2);
                sumNegatif += Math.Pow(nilaiBobotTerbobot[i, j] - solusiIdealNegatif[i], 2);
            }

            jarakSolusiIdealPositif[j] = Math.Sqrt(sumPositif);
            jarakSolusiIdealNegatif[j] = Math.Sqrt(sumNegatif);
        }
    }

    void HitungSkorRelatif()
    {
        for (int j = 0; j < jumlahAlternatif; j++)
        {
            skorRelatif[j] = jarakSolusiIdealNegatif[j] / (jarakSolusiIdealNegatif[j] + jarakSolusiIdealPositif[j]);
        }
    }

    void PrintHasilTOPSIS()
    {
        Debug.Log("Skor Relatif: ");
        for (int j = 0; j < jumlahAlternatif; j++)
        {
            Debug.Log("Alternatif " + (j + 1) + ": " + skorRelatif[j]);
        }
    }
}
