using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TOPSIS_FUZZY : MonoBehaviour
{
    public Text teks;

    //public float[] bobot1;

    //public float[] bobot2;
    //public float[] bobot3;
    //public float[] bobot4;
    //public float[] bobot5;


    // Function: Rank 
    void Ranking(float[,] flow)
    {
        //int rowCount = flow.GetLength(0);
        //for (int i = 0; i < rowCount; i++)
        //{
        //    // Modify this according to your Unity UI text placement
        //    Debug.Log("a" + flow[i, 0] + ": " + flow[i, 1]);
        //}

        int rowCount = flow.GetLength(0);
        // Insertion sort
        for (int i = 1; i < rowCount; i++)
        {
            float currentFlow = flow[i, 1];
            float currentLabel = flow[i, 0];
            int j = i - 1;
            while (j >= 0 && flow[j, 1] < currentFlow)
            {
                flow[j + 1, 1] = flow[j, 1];
                flow[j + 1, 0] = flow[j, 0];
                j--;
            }
            flow[j + 1, 1] = currentFlow;
            flow[j + 1, 0] = currentLabel;
        }

        // Print the sorted values
        for (int i = 0; i < rowCount; i++)
        {
            // Modify this according to your Unity UI text placement
            Debug.Log("a" + flow[i, 0] + ": " + flow[i, 1]);
        }
    }

    // Function: Fuzzy TOPSIS
    float[] FuzzyTOPSIS(float[,,] dataset, float[,,] weights, string[] criterionType, bool graph = true, bool verbose = true)
    {
        int rowCount = dataset.GetLength(0);
        int colCount = dataset.GetLength(1);

        float[,,] r_ij = new float[rowCount, colCount, 3];
        float[,,] v_ij = new float[rowCount, colCount, 3];
        float[,] p_ideal_A = new float[1, colCount];
        float[,] n_ideal_A = new float[1, colCount];
        float[,] dist_p = new float[rowCount, colCount];
        float[,] dist_n = new float[rowCount, colCount];

        for (int j = 0; j < colCount; j++)
        {
            float c_star = float.NegativeInfinity;
            float a_minus = float.PositiveInfinity;
            for (int i = 0; i < rowCount; i++)
            {
                float a = dataset[i, j, 0];
                float b = dataset[i, j, 1];
                float c = dataset[i, j, 2];

                if (c >= c_star && criterionType[j] == "max")
                    c_star = c;

                if (a <= a_minus && criterionType[j] == "min")
                    a_minus = a;
            }

            if (criterionType[j] == "max")
            {
                for (int i = 0; i < rowCount; i++)
                {
                    float a = dataset[i, j, 0];
                    float b = dataset[i, j, 1];
                    float c = dataset[i, j, 2];
                    r_ij[i, j, 0] = a / c_star;
                    r_ij[i, j, 1] = b / c_star;
                    r_ij[i, j, 2] = c / c_star;
                }
            }
            else
            {
                for (int i = 0; i < rowCount; i++)
                {
                    float a = dataset[i, j, 0];
                    float b = dataset[i, j, 1];
                    float c = dataset[i, j, 2];
                    r_ij[i, j, 0] = a_minus / c;
                    r_ij[i, j, 1] = a_minus / b;
                    r_ij[i, j, 2] = a_minus / a;
                }
            }

            for (int i = 0; i < rowCount; i++)
            {
                float a = r_ij[i, j, 0];
                float b = r_ij[i, j, 1];
                float c = r_ij[i, j, 2];
                float d = weights[0, j, 0];
                float e = weights[0, j, 1];
                float f = weights[0, j, 2];
                v_ij[i, j, 0] = a * d;
                v_ij[i, j, 1] = b * e;
                v_ij[i, j, 2] = c * f;
            }

            float d_max = v_ij[0, j, 0];
            float e_max = v_ij[0, j, 1];
            float f_max = v_ij[0, j, 2];
            float x_min = v_ij[0, j, 0];
            float y_min = v_ij[0, j, 1];
            float z_min = v_ij[0, j, 2];

            for (int i = 0; i < rowCount; i++)
            {
                float a = v_ij[i, j, 0];
                float b = v_ij[i, j, 1];
                float c = v_ij[i, j, 2];

                if (a > d_max)
                    d_max = a;
                if (b > e_max)
                    e_max = b;
                if (c > f_max)
                    f_max = c;

                if (a < x_min)
                    x_min = a;
                if (b < y_min)
                    y_min = b;
                if (c < z_min)
                    z_min = c;
            }

            p_ideal_A[0, j] = d_max;
            p_ideal_A[0, j] = e_max;
            p_ideal_A[0, j] = f_max;

            n_ideal_A[0, j] = x_min;
            n_ideal_A[0, j] = y_min;
            n_ideal_A[0, j] = z_min;
        }

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                float a = v_ij[i, j, 0];
                float b = v_ij[i, j, 1];
                float c = v_ij[i, j, 2];

                float x = p_ideal_A[0, j];
                float y = p_ideal_A[0, j];
                float z = p_ideal_A[0, j];

                float d = n_ideal_A[0, j];
                float e = n_ideal_A[0, j];
                float f = n_ideal_A[0, j];

                dist_p[i, j] = Mathf.Sqrt((1.0f / colCount) * ((a - x) * (a - x) + (b - y) * (b - y) + (c - z) * (c - z)));
                dist_n[i, j] = Mathf.Sqrt((1.0f / colCount) * ((a - d) * (a - d) + (b - e) * (b - e) + (c - f) * (c - f)));
            }
        }

        float[] d_plus = new float[rowCount];
        float[] d_minus = new float[rowCount];
        float[] c_i = new float[rowCount];

        for (int i = 0; i < rowCount; i++)
        {
            d_plus[i] = 0;
            d_minus[i] = 0;
            for (int j = 0; j < colCount; j++)
            {
                d_plus[i] += dist_p[i, j];
                d_minus[i] += dist_n[i, j];
            }
            c_i[i] = d_minus[i] / (d_minus[i] + d_plus[i]);
            if (verbose)
            {
                //Debug.Log("a" + (i + 1) + ": " + c_i[i]);
            }
        }

        if (graph)
        {
            float[,] flow = new float[rowCount, 2];
            for (int i = 0; i < rowCount; i++)
            {
                flow[i, 0] = i + 1;
                flow[i, 1] = c_i[i];
            }
            // Call the visualization function
            Ranking(flow);
        }

        return c_i;
    }

    void RankScene1()
    {
        // Data Input
        // Kriteria Bobot Alternatif

        //float[,,] weights = new float[,,] { { { bobot1[0], bobot1[1], bobot3[2] }, { bobot2[0], bobot2[1], bobot2[2] }, { bobot3[0], bobot3[1], bobot3[2] }, { bobot4[0],
        //            bobot4[1], bobot4[2] }, { bobot5[0], bobot5[1], bobot5[2] } } };
        float[,,] weights = new float[,,] { { { 1, 1, 3 }, { 1, 3, 5 }, { 7, 9, 9 }, { 3, 5, 7 }, { 5, 7, 9 } } };

        // Matriks Keputusan

        float[,,] dataset = new float[,,] //Diubah setiap kriteria nya
        {
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 5, 7, 9 }, { 3, 5, 7 }, { 5, 7, 9 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 7, 9, 9 }, { 1, 3, 5 }, { 3, 5, 7 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 3, 5, 7 }, { 7, 9, 9 }, { 3, 5, 7 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 1, 3, 5 }, { 5, 7, 9 }, { 7, 9, 9 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 3, 5, 7 }, { 5, 7, 9 }, { 5, 7, 9 }
            }
        };

        // Tipe Kriteria (min/max)
        string[] criterionType = { "min", "min", "max", "max", "max" };

        // Panggil Fungsi Fuzzy TOPSIS
        FuzzyTOPSIS(dataset, weights, criterionType);
    }

    void RankScene2()
    {
        // Data Input
        // Kriteria Bobot Alternatif
        //float[,,] weights = new float[,,] { { { bobot1[0], bobot1[1], bobot3[2] }, { bobot2[0], bobot2[1], bobot2[2] }, { bobot3[0], bobot3[1], bobot3[2] }, { bobot4[0],
        //            bobot4[1], bobot4[2] }, { bobot5[0], bobot5[1], bobot5[2] } } };
        float[,,] weights = new float[,,] { { { 1, 1, 3 }, { 1, 3, 5 }, { 3, 5, 7 }, { 7, 9, 9 }, { 5, 7, 9 } } };

        // Matriks Keputusan

        float[,,] dataset = new float[,,]
        {
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 5, 7, 9 }, { 3, 5, 7 }, { 5, 7, 9 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 7, 9, 9 }, { 1, 3, 5 }, { 3, 5, 7 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 3, 5, 7 }, { 7, 9, 9 }, { 3, 5, 7 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 1, 3, 5 }, { 5, 7, 9 }, { 7, 9, 9 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 3, 5, 7 }, { 5, 7, 9 }, { 5, 7, 9 }
            }
        };

        // Tipe Kriteria (min/max)
        string[] criterionType = { "min", "min", "max", "max", "max" };

        // Panggil Fungsi Fuzzy TOPSIS
        FuzzyTOPSIS(dataset, weights, criterionType);
    }

    void RankScene3()
    {
        // Data Input
        // Kriteria Bobot Alternatif

        //float[,,] weights = new float[,,] { { { bobot1[0], bobot1[1], bobot3[2] }, { bobot2[0], bobot2[1], bobot2[2] }, { bobot3[0], bobot3[1], bobot3[2] }, { bobot4[0],
        //            bobot4[1], bobot4[2] }, { bobot5[0], bobot5[1], bobot5[2] } } };
        float[,,] weights = new float[,,] { { { 3, 5, 7 }, { 5, 7, 9 }, { 1, 1, 3 }, { 1, 3, 5 }, { 7, 9, 9 } } };

        // Matriks Keputusan

        float[,,] dataset = new float[,,]
        {
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 5, 7, 9 }, { 3, 5, 7 }, { 5, 7, 9 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 7, 9, 9 }, { 1, 3, 5 }, { 3, 5, 7 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 3, 5, 7 }, { 7, 9, 9 }, { 3, 5, 7 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 1, 3, 5 }, { 5, 7, 9 }, { 7, 9, 9 }
            },
            {
                { 1, 1, 3 }, { 1, 1, 3 }, { 3, 5, 7 }, { 5, 7, 9 }, { 5, 7, 9 }
            }
        };

        // Tipe Kriteria (min/max)
        string[] criterionType = { "min", "min", "max", "max", "max" };

        // Panggil Fungsi Fuzzy TOPSIS
        FuzzyTOPSIS(dataset, weights, criterionType);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TurnBased1")
        {
            RankScene1();
            teks.text = "Musuh yang kamu lawan adalah seorang Jendral dengan Pedangnya, maka gunakan Keris untuk melawannya";
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased2")
        {
            RankScene2();
            teks.text = "Musuh yang kamu lawan adalah Prajurit Merah, maka gunakan Senjata 3 untuk melawannya";
        }
        else if (SceneManager.GetActiveScene().name == "TurnBased3")
        {
            RankScene3();
            teks.text = "Musuh yang kamu lawan adalah Prajurit Hijau, maka gunakan Senjata 4 untuk melawannya";
        }
    }
}

