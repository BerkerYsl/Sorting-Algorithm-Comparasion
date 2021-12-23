using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmaSort
{
    public partial class Form1 : Form
    {
        int[] sayilar, merge, quick, insertion;

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(quick, 0, quick.Length - 1); stopwatch.Stop(); MessageBox.Show("Çalışma zamanı" + stopwatch.ElapsedMilliseconds);
        }
        public static void QuickSort(int[] A,int p,int r)
        {
            if (p<r)
            {
                int q = Partition(A, p, r);
                QuickSort(A, p, q - 1);
                QuickSort(A, q + 1, r);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch mtime = new Stopwatch();
            mtime.Start();
            MergeSort(merge, 0, merge.Length - 1);
            mtime.Stop();
            MessageBox.Show("Çalışma zamanı : " + mtime.ElapsedMilliseconds);
        }
         static void MergeSort(int[] A, int p, int r)
        {
            if (p<r)
            {
                int q = (p + r) / 2;
                MergeSort(A,p,q);
                MergeSort(A,q+1,r);
                Merge(A, p, q, r);
            }
        }
        public static void Merge(int[] A, int p, int q,int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1 + 1];
            int[] R = new int[n2+1];
            for (int i = 0; i < n1; i++)
            {
                L[i] = A[p + i];
            }
            for (int j = 0; j < n2; j++)
            {
                R[j] = A[q + j + 1];
            }
            L[n1] = Int32.MaxValue;
            R[n2] = Int32.MaxValue;
            int x = 0, y = 0;
            for (int k = p; k <=r ; k++)
            {
                if (L[x]<=R[y])
                {
                    A[k] = L[x];
                    x++;
                }
                else
                {
                    A[k] = R[y];
                    y++;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch intime = new Stopwatch();
            intime.Start();
            Insertion_Sort(insertion);
            intime.Stop();
            MessageBox.Show("Çalışma zamanı : " + intime.ElapsedMilliseconds);
        }
        public void Insertion_Sort(int[] dizi)
        {
            for (int j = 1; j < dizi.Length; j++)
            {
                int key = dizi[j];
                int i = j - 1;
                while (i>=0 && dizi[i]>key)
                {
                    dizi[i + 1] = dizi[i];
                    i = i - 1;
                }
                dizi[i + 1] = key;
            }
        }

        public static int Partition(int[] A, int p, int r)
        {
            int x = A[r];
            int i = p - 1;
            for (int j = p; j <= r-1; j++)
            {
                if (A[j]<=x)
                {
                    i =i+ 1;
                    int temp1 = A[i];
                    A[i] = A[j];
                    A[j] = temp1;
                }
            }
            int temp2 = A[i + 1];
            A[i + 1] = A[r];
            A[r] = temp2;
            return i+1;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int adet = Convert.ToInt32(textBox1.Text);
            sayilar = new int[adet]; quick = new int[adet]; merge = new int[adet]; insertion = new int[adet];
            Random rastgele = new Random();
            for (int i = 0; i <adet; i++)
            {
                sayilar[i] = rastgele.Next(0, 100);
            }
            int sayac = 0;
            foreach (int item in sayilar)
            {
                quick[sayac] = item;
                merge[sayac] = item;
                insertion[sayac] = item;
                sayac+=1;
            }


        }
    }
}
