//Tìm số lớn nhất trong int[].
//Tính tổng các phần tử của mảng.
//Đảo ngược int[].
//Đếm số chẵn và số lẻ trong mảng.
//Sắp xếp mảng tăng dần.

using System;

public class Array
{
    static void Main()
    {
        int[] number = { 87, 125, 67, 54, 983, 55, 88, 90 };

        Console.WriteLine("Array: " + string.Join(", ", number));

        Console.WriteLine("So lon nhat: " + soLonNhat(number));
        Console.WriteLine("Tong phan tu: " + tongMang(number));
        daoNguocMang(number);
        demChanLe(number);
        sapXepTangDan(number);
    }

    static int soLonNhat(int[]a)
    {
        int max = a[0];
        foreach (int i in a)
        {
            if (i > max) {
                max = i;
            }
        }
        return max;
    }

    static int tongMang(int[] a)
    {
        int sum = 0;
        foreach (int i in a)
        {
            sum += i;
        }
        return sum;
    }

    static void daoNguocMang(int []a)
    {
        int n = a.Length;
        for ( int i = 0; i < n /2; i++ )
        {
            int temp = a[i];
            a[i] = a[n - 1 - i];
            a[n - 1] = temp;
        }

        Console.WriteLine("Mang dao nguoc: " + string.Join(", ", a));

    }

    static void demChanLe(int[] a)
    {
        int countEven = 0, countOdd = 0;
        foreach (int num in a)
        {
            if (num % 2 == 0) countEven++;
            else countOdd++;
        }
        Console.WriteLine($"So chan: {countEven}, So le: {countOdd}");
    }

    static void sapXepTangDan(int[] a)
    {
        int n = a.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Mang tang dan: " + string.Join(", ", a));
    }
}