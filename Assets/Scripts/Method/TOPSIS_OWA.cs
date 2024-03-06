using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class TOPSIS_OWA : MonoBehaviour
{
    // Serialized fields to allow input from the Unity inspector

    [SerializeField]
    private int[] criteria;

    public Text teks;

    private void Start()
    {
        // Example data, replace with your own data
        double[,] data = new double[,]
        {
            {101, 21, 7, 6, 7},
            {102, 22, 10, 6, 4},
            {102, 22, 4, 10, 6},
            {102, 22, 6, 4, 10},
            {101, 21, 8, 6, 6},
            {101, 21, 7, 7, 6}
        };

        // Ensure criteria and customWeights are not null
        if (criteria == null)
        {
            Debug.LogError("Criteria is not set. Please assign values in the Unity inspector.");
            return;
        }

        int m = data.GetLength(0);
        int n = data.GetLength(1);

        // Ensure the criteria length matches the number of columns in the data
        if (criteria.Length != n)
        {
            Debug.LogError("Number of criteria should match the number of columns in the data.");
            return;
        }

        // Array for alternative descriptions
        string[] alternativeDescriptions = new string[]
        {
            "Alternative 1",
            "Alternative 2",
            "Alternative 3",
            "Alternative 4",
            "Alternative 5",
            "Alternative 6"
        };

        // Calculate TOPSIS with custom weights
        Tuple<double[], double[], double[]> result = Topsissimowa(data, criteria);

        // Display results (you can customize this part based on your Unity project)
        Debug.Log("Closeness Coefficients (cc): " + string.Join(", ", result.Item1));
        Debug.Log("SPIS: " + string.Join(", ", result.Item2));
        Debug.Log("SNIS: " + string.Join(", ", result.Item3));

        // Get ranking
        int[] ranking = GetRanking(result.Item1);

        // Display ranking with alternative descriptions
        for (int i = 0; i < ranking.Length; i++)
        {
            Debug.Log($"Rank {i + 1}: {alternativeDescriptions[ranking[i]]}");
        }

        // Check if the first element in the ranking is 1
        if (ranking.Length > 0 && ranking[0] == 2)
        {
            teks.text = "Gunakan Skill 2";
        }
        else if (ranking.Length > 0 && ranking[0] == 3)
        {
            teks.text = "Gunakan Skill 3";
        }
        else if (ranking.Length > 0 && ranking[0] == 4)
        {
            teks.text = "Gunakan Skill 4";
        }
    }

    // Function to calculate TOPSIS with similarity-based OWA
    public Tuple<double[], double[], double[]> Topsissimowa(double[,] data, int[] crit, double p = 1, double alpha1 = 2, double alpha2 = 0.1, double[] w = null)
    {
        int m = data.GetLength(0);
        int n = data.GetLength(1);

        
        w = new double[] { 0.1, 0.1, 0.1, 0.6, 0.1 };
        

        // Normalization of decision matrix
        double[,] a = new double[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                a[i, j] = (data[i, j] - GetMinColumn(data, j)) / (GetMaxColumn(data, j) - GetMinColumn(data, j));
            }
        }

        double[] PIS = new double[n];
        double[] NIS = new double[n];

        for (int j = 0; j < n; j++)
        {
            if (crit[j] == 1)
            {
                PIS[j] = GetMaxColumn(a, j);
                NIS[j] = GetMinColumn(a, j);
            }
            else
            {
                PIS[j] = GetMinColumn(a, j);
                NIS[j] = GetMaxColumn(a, j);
            }
        }

        // Calculate Similarity to Positive Ideal Solution (SPIS) and Similarity to Negative Ideal Solution (SNIS)
        double[] SPIS = SimLPowa(PIS, a, p, alpha1);
        double[] SNIS = SimLPowa(NIS, a, p, alpha2);

        // Calculate Closeness Coefficients (cc)
        double[] cc = SPIS.Select((x, index) => x / (x + SNIS[index])).ToArray();

        return Tuple.Create(cc, SPIS, SNIS);
    }

    // Function to calculate similarity value for each attribute
    private double[] SimLPowa(double[] center, double[,] data, double p, double alpha)
    {
        int m = data.GetLength(0);

        // Calculate Ideal matrix
        double[,] Ideal = new double[m, center.Length];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < center.Length; j++)
            {
                Ideal[i, j] = center[j];
            }
        }

        // Calculate similarity matrix (simM)
        double[,] simM = new double[m, center.Length];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < center.Length; j++)
            {
                simM[i, j] = 1 - Math.Abs(Math.Pow(data[i, j], p) - Math.Pow(Ideal[i, j], p)) / Math.Pow(p, 1 / p);
            }
        }

        // Aggregate similarity matrix using OWA with RIM1 weights
        double[] rim1Weights = Rim1(center.Length, alpha);
        double[] totsim = OwaMatrix(simM, rim1Weights);

        return totsim;
    }

    // Function to calculate weighting vector with RIM quantifier
    private double[] Rim1(int n, double m)
    {
        List<double> re = new List<double>();
        for (int h = 1; h <= n; h++)
        {
            re.Add(Math.Pow((double)h / n, m) - Math.Pow((double)(h - 1) / n, m));
        }
        return re.ToArray();
    }

    // Function to aggregate matrix into a vector using OWA
    private double[] OwaMatrix(double[,] A, double[] w)
    {
        int n = A.GetLength(0);
        double[] h = new double[n];
        for (int i = 0; i < n; i++)
        {
            double[] apu = new double[A.GetLength(1)];
            for (int j = 0; j < A.GetLength(1); j++)
            {
                apu[j] = A[i, j];
            }
            Array.Sort(apu);
            Array.Reverse(apu);
            h[i] = apu.Select((x, index) => x * w[index]).Sum();
        }
        return h;
    }

    // Function to get the minimum value in a column
    private double GetMinColumn(double[,] matrix, int columnIndex)
    {
        int rowCount = matrix.GetLength(0);
        double min = matrix[0, columnIndex];

        for (int i = 1; i < rowCount; i++)
        {
            if (matrix[i, columnIndex] < min)
            {
                min = matrix[i, columnIndex];
            }
        }

        return min;
    }

    // Function to get the maximum value in a column
    private double GetMaxColumn(double[,] matrix, int columnIndex)
    {
        int rowCount = matrix.GetLength(0);
        double max = matrix[0, columnIndex];

        for (int i = 1; i < rowCount; i++)
        {
            if (matrix[i, columnIndex] > max)
            {
                max = matrix[i, columnIndex];
            }
        }

        return max;
    }

    // Function to get the ranking based on closeness coefficients
    private int[] GetRanking(double[] cc)
    {
        int[] ranking = cc.Select((value, index) => new { Value = value, Index = index + 1 })
                         .OrderByDescending(item => item.Value)
                         .Select(item => item.Index)
                         .ToArray();

        for (int i = 0; i < ranking.Length; i++)
        {
            ranking[i] -= 1;
        }

        return ranking;
    }
}