using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortAlgorithm : MonoBehaviour
{
    void Start()
    {
        int[] array = new int[10000];
        for (int i = 0; i < 10000; i++)
        {
            array[i] = Random.Range(0, 10000);
        }
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        SelectSort(array);
        stopwatch.Stop();
        Debug.Log("SelectSort Time Used: " + stopwatch.Elapsed.Milliseconds + " ms.");

        for (int i = 0; i < 10000; i++)
        {
            array[i] = Random.Range(0, 10000);
        }
        stopwatch.Start();
        QuickSort(array, 5000, 9999);
        stopwatch.Stop();
        Debug.Log("QuickSort Time Used: " + stopwatch.Elapsed.Milliseconds + " ms.");

        for (int i = 0; i < 10000; i++)
        {
            array[i] = Random.Range(0, 10000);
        }
        stopwatch.Start();
        BubbleSort(array);
        stopwatch.Stop();
        Debug.Log("BubbleSort Time Used: " + stopwatch.Elapsed.Milliseconds + " ms.");

        for (int i = 0; i < 10000; i++)
        {
            array[i] = Random.Range(0, 10000);
        }
        stopwatch.Start();
        InsertSort(array);
        stopwatch.Stop();
        Debug.Log("InsertSort Time Used: " + stopwatch.Elapsed.Milliseconds + " ms.");

        for (int i = 0; i < 10000; i++)
        {
            array[i] = Random.Range(0, 10000);
        }
        stopwatch.Start();
        HeapSort(array);
        stopwatch.Stop();
        Debug.Log("HeapSort Time Used: " + stopwatch.Elapsed.Milliseconds + " ms.");
    }

    #region 排序算法
    /// <summary>
    /// 直接插入排序.稳定的，最好O(n),最坏O(n*n),平均O(n*n),空间O(1).
    /// </summary>
    /// <param name="array">Array.</param>
    void InsertSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int temp = array[i];
            int j = i - 1;
            while (j > 0 && temp < array[j])
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = temp;
        }
    }


    /// <summary>
    /// 冒泡排序.稳定的，最好O(n),最坏O(n*n),平均O(n*n),空间O(1).
    /// </summary>
    /// <param name="array">Array.</param>
    void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = array.Length - 1; j > i; j--)
            {
                if (array[j] < array[j - 1])
                {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
            }
        }
    }

    /// <summary>
    /// 快速排序.不稳定，最好O(nlog2n),最坏O(n*n),平均O(nlog2n),空间O(nlog2n)
    /// </summary>
    /// <param name="array">Array.</param>
    /// <param name="s">S.</param>
    /// <param name="t">T.</param>
    void QuickSort(int[] array, int s, int t)
    {
        int i = s;
        int j = t;
        int temp;
        if (i < j)
        {
            temp = array[s];
            while (i != j)
            {
                while (j > i && array[j] > temp)
                {
                    j--;
                }
                if (i < j)
                {
                    array[i] = array[j];
                    i++;
                }

                while (i < j && array[i] < temp)
                {
                    i++;
                }
                if (i < j)
                {
                    array[j] = array[i];
                    j--;
                }
            }

            array[i] = temp;
            QuickSort(array, s, i - 1);
            QuickSort(array, i + 1, t);
        }
    }

    /// <summary>
    /// 选择排序.不稳定,最好O(n*n),最坏O(n*n),平均O(n*n),空间O(1)
    /// </summary>
    /// <param name="array">Array.</param>
    void SelectSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int k = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[k])
                {
                    k = j;
                }
            }
            if (k != i)
            {
                int temp = array[i];
                array[i] = array[k];
                array[k] = temp;
            }
        }
    }

    /// <summary>
    /// 堆排序.不稳定,最好O(nlog2n),最坏O(nlog2n),平均O(nlog2n),空间O(1)
    /// </summary>
    /// <param name="array">Array.</param>
    void HeapSort(int[] array)
    {
        for (int i = (array.Length / 2) - 1; i >= 0; i--)
        {
            AdjustHeap(array, i, array.Length - 1);
        }

        for (int i = array.Length - 1; i >= 1; i--)
        {
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;
            AdjustHeap(array, 0, i - 1);
        }
    }
    void AdjustHeap(int[] array, int s, int e)
    {
        int i = s, j = 2 * i + 1, temp;
        temp = array[i];
        while (j <= e)
        {
            if (j < e && array[j] < array[j + 1])
            {
                j++;
            }
            if (array[j] > temp)
            {
                array[i] = array[j];
                i = j;
                j = 2 * i + 1;
            }
            else
            {
                break;
            }
        }
        array[i] = temp;
    }
    #endregion
}
