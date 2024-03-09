using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class OWA : MonoBehaviour
{
    public Text teks;
    void Start()
    {
        // Contoh data, gantilah dengan data sesuai kebutuhan Anda
        double[,] data = {
            {102, 22, 7, 6, 7},
            {101, 21, 10, 6, 4},
            {101, 21, 6, 4, 10},
            {101, 21, 4, 10, 6},
            {102, 22, 8, 6, 6},
            {102, 22, 7, 7, 6}
        };

        // Definisikan kriteria sebagai kriteria keuntungan atau biaya 1 untuk keuntungan 2 untuk biaya
        int[] crit = { 2, 2, 1, 1, 1 };

        // Menghitung TOPSIS
        double[] cc, SPIS, SNIS;
        topsissimowa(data, crit, out cc, out SPIS, out SNIS);

        // Menghitung normalisasi matriks 'a'
        double[,] a = NormalizeMatrix(data);

        // Menampilkan matriks keputusan yang dinormalisasi
        Debug.Log("Matriks Keputusan yang Dinormalisasi:");
        PrintMatrix(a);

        // Menampilkan SPIS dan SNIS
        Debug.Log("SPIS dan SNIS:");
        PrintArray("SPIS", SPIS);
        PrintArray("SNIS", SNIS);

        // Menampilkan Koefisien Kedekatan (cc)
        Debug.Log("Closenest Coefficient (cc):");
        for (int i = 0; i < cc.Length; i++)
        {
            Debug.Log($"A{i + 1}: {cc[i]}");
        }

        // Mendapatkan peringkat alternatif (dimulai dari 1)
        int[] ranking = ArrayUtils.GetSortedIndicesDescending(cc);

        // Menampilkan peringkat
        PrintArray("Peringkat Alternatif", ArrayUtils.AddOneToIndices(ranking));

        if (ranking[0] == 2)
        {
            teks.text = "Saudara sedang menghadapi Jendral DeKock, disarankan untuk menggunakan skill 2";
        }
    }

    void PrintArray(string label, int[] array)
    {
        string result = $"{label}: ";
        for (int i = 0; i < array.Length; i++)
        {
            result += $"{array[i]} ";
        }
        Debug.Log(result);
    }

    // Fungsi topsissimowa untuk menghitung metode TOPSIS dengan similarity-based OWA
    void topsissimowa(double[,] data, int[] crit, out double[] cc, out double[] SPIS, out double[] SNIS)
    {
        int m = data.GetLength(0);
        int n = data.GetLength(1);

        double[] w = { 0.1, 0.1, 0.4, 0.2, 0.2 };

        // Normalisasi matriks keputusan
        double[,] a = NormalizeMatrix(data);
        double[,] r = new double[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                r[i, j] = w[j] * a[i, j];
            }
        }

        double[] PIS = new double[n];
        double[] NIS = new double[n];

        for (int j = 0; j < n; j++)
        {
            if (crit[j] == 1)
            {
                PIS[j] = ArrayUtils.MaxColumn(r, j);
                NIS[j] = ArrayUtils.MinColumn(r, j);
            }
            else
            {
                PIS[j] = ArrayUtils.MinColumn(r, j);
                NIS[j] = ArrayUtils.MaxColumn(r, j);
            }
        }

        // Menghitung Similarity to Positive Ideal Solution (SPIS) dan Similarity to Negative Ideal Solution (SNIS)
        SPIS = simLPowa(PIS, r, 1, 2);
        SNIS = simLPowa(NIS, r, 1, 0.1);

        // Menghitung Closeness Coefficients (cc)
        cc = new double[m];
        for (int i = 0; i < m; i++)
        {
            cc[i] = SPIS[i] / (SPIS[i] + SNIS[i]);
        }
    }

    // Fungsi simLPowa untuk menghitung similarity value untuk setiap atribut
    double[] simLPowa(double[] center, double[,] data, double p, double alpha)
    {
        int m = data.GetLength(0);

        // Menghitung matriks similarity (simM)
        double[,] simM = new double[m, center.Length];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < center.Length; j++)
            {
                simM[i, j] = 1 - Math.Pow(Math.Abs(Math.Pow(data[i, j], p) - Math.Pow(center[j], p)), 1 / p);
            }
        }

        // Menghasilkan bobot untuk OWA menggunakan RIM quantifier
        double[] w = Rim1(center.Length, alpha);

        // Mengagregasi matriks similarity menggunakan OWA
        double[] totsim = owamatrix(simM, w);

        return totsim;
    }

    // Fungsi Rim1 untuk menghasilkan weighting vector dengan RIM quantifier
    double[] Rim1(int n, double m)
    {
        double[] re = new double[n];
        for (int h = 1; h <= n; h++)
        {
            re[h - 1] = Math.Pow((double)h / n, m) - Math.Pow(((double)h - 1) / n, m);
        }
        return re;
    }

    // Fungsi owamatrix untuk mengagregasi matriks ke dalam vektor menggunakan OWA
    double[] owamatrix(double[,] A, double[] w)
    {
        int n = A.GetLength(0);
        double[] h = new double[n];

        for (int i = 0; i < n; i++)
        {
            double[] apu = ArrayUtils.GetRow(A, i);
            double[] sortedArray = apu.OrderByDescending(x => x).ToArray(); // Sort in descending order
            h[i] = ArrayUtils.Sum(ArrayUtils.Multiply(sortedArray, w));
        }

        return h;
    }

    // Fungsi NormalizeMatrix untuk normalisasi matriks keputusan
    double[,] NormalizeMatrix(double[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        double[,] normalizedMatrix = new double[m, n];

        for (int j = 0; j < n; j++)
        {
            double min = ArrayUtils.MinColumn(matrix, j);
            double max = ArrayUtils.MaxColumn(matrix, j);

            for (int i = 0; i < m; i++)
            {
                normalizedMatrix[i, j] = (matrix[i, j] - min) / (max - min);
            }
        }
        return normalizedMatrix;
    }
    void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string row = "";
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                row += matrix[i, j] + " ";
            }
            Debug.Log(row);
        }
    }

    // Fungsi PrintArray untuk mencetak array ke konsol Unity
    void PrintArray(string label, double[] array)
    {
        string result = $"{label}: ";
        for (int i = 0; i < array.Length; i++)
        {
            result += $"{array[i]} ";
        }
        Debug.Log(result);
    }
}

public static class ArrayUtils
{
    // Method to get the maximum value in a column of a 2D array
    public static double MaxColumn(double[,] array, int columnIndex)
    {
        int rows = array.GetLength(0);
        double max = array[0, columnIndex];
        for (int i = 1; i < rows; i++)
        {
            double value = array[i, columnIndex];
            if (value > max)
            {
                max = value;
            }
        }
        return max;
    }

    // Method to get the minimum value in a column of a 2D array
    public static double MinColumn(double[,] array, int columnIndex)
    {
        int rows = array.GetLength(0);
        double min = array[0, columnIndex];
        for (int i = 1; i < rows; i++)
        {
            double value = array[i, columnIndex];
            if (value < min)
            {
                min = value;
            }
        }
        return min;
    }

    // Method to get the sum of an array
    public static double Sum(double[] array)
    {
        double sum = 0;
        foreach (var value in array)
        {
            sum += value;
        }
        return sum;
    }

    // Method to sort an array in descending order and return the indices
    public static int[] GetSortedIndicesDescending(double[] array)
    {
        int[] indices = new int[array.Length];
        for (int i = 0; i < indices.Length; i++)
        {
            indices[i] = i;
        }

        Array.Sort(indices, (a, b) => array[b].CompareTo(array[a]));
        return indices;
    }

    // Method to add 1 to each element of an array
    public static int[] AddOneToIndices(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] += 1;
        }
        return array;
    }

    // Method to get a specific row from a 2D array
    public static double[] GetRow(double[,] array, int rowIndex)
    {
        int cols = array.GetLength(1);
        double[] row = new double[cols];
        for (int j = 0; j < cols; j++)
        {
            row[j] = array[rowIndex, j];
        }
        return row;
    }

    public static double[] Multiply(double[] array, double[] multiplier)
    {
        double[] result = new double[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = array[i] * multiplier[i];
        }
        return result;
    }

}

