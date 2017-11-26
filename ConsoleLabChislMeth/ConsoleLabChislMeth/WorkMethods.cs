using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLabChislMeth
{
    public class WorkMethods
    {
        private int[] q;
        private int countOperations = 0;

        public int getCountOperations()
        {
            return countOperations;
        }

        public void countOperationsPlus()
        {
            countOperations++;
        }

        public decimal[,] createULJordan(decimal[,] mas, int size)
        {
            q = new int[size];
            for (int i = 0; i < size; i++)
            {
                q[i] = i;
            }

            for (int k = 0; k < size; k++)
            {

                //выбираем главный элемент по СТРОКЕ
                decimal max = Math.Abs(mas[k, q[k]]);
                int jMax = k;
                for (int j = k + 1; j < size; j++)
                {
                    if (Math.Abs(mas[k, q[j]]) > max)
                    {
                        max = Math.Abs(mas[k, q[j]]);
                        jMax = j;
                    }
                }

                if (jMax != k)
                {
                    int a = q[k];
                    q[k] = q[jMax];
                    q[jMax] = a;
                }


                //нормируем 1 строку матрицы

                for (int j = k + 1; j < size; j++)
                {                    
                    mas[k, q[j]] /= mas[k, q[k]];        
                    countOperationsPlus();
                }

                for (int i = 0; i < k; i++)
                {
                    //вычитаем верхние строки строку матрицы
                    for (int j = k + 1; j < size; j++)
                    {                     
                        mas[i, q[j]] -= mas[i, q[k]] * mas[k, q[j]];
                        countOperationsPlus();
                    }

                }
                for (int i = k + 1; i < size; i++)
                {
                    //вычитаем нижние строки матрицы
                    for (int j = k + 1; j < size; j++)
                    {                       
                        mas[i, q[j]] -= mas[i, q[k]] * mas[k, q[j]];
                        countOperationsPlus();
                    }
                }

            }

            //вносим минусы
            for (int i = 0; i < size-1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    mas[i, q[j]] = -mas[i, q[j]];
                }
            }

            return mas;
        }

        private decimal[] solutionOfTheSystemStep1(decimal[,] mas, decimal[] b)
        {
            decimal[] x = new decimal[b.Length];
            
            for(int i = 0; i < b.Length; i++)
            {
                decimal sum = 0;
                for(int j = 0; j < i; j++)
                {
                    sum += mas[i, q[j]] * x[j];
                    countOperationsPlus();
                }

                x[i] = (b[i] - sum) / mas[i, q[i]];
                countOperationsPlus();

            }
            return x;
        }


        public decimal[] solutionOfTheSystem(decimal[,] mas, decimal[] b)
        {
            b = solutionOfTheSystemStep1(mas, b);
            decimal[] x = new decimal[b.Length];

            for (int i = 0; i < b.Length; i++)
            {
                x[i] = 0;
                for (int j = i+1; j < b.Length; j++)
                {
                    x[i] += mas[i, q[j]] * b[j];
                    countOperationsPlus();
                }
                x[i] += b[i];

            }
            x = correctX(x);
            return x;
        }

        public decimal[] matrixCompositionResultVector(decimal[,] mas1, decimal[] mas2)
        {
            decimal[] result = new decimal[mas2.Length];

            for(int i = 0; i < mas2.Length; i++)
            {
                result[i] = 0;
                for(int j = 0; j < mas2.Length; j++)
                {
                    result[i] += mas1[i, j] * mas2[j];
                    countOperationsPlus();
                }
            }

            return result;
        }

        private decimal[,] matrixCompositionResultMatrix(decimal[,] mas1, decimal[,] mas2)
        {
            int size = (int)Math.Sqrt(mas2.Length);
            decimal[,] result = new decimal[size, size];

            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < size; k++)
                    {
                        result[i, j] += mas1[i, k] * mas2[k, j];
                        countOperationsPlus();
                    }
                }

            }

            return result;
        }

        public decimal[] correctX(decimal[] y)
        {
            decimal[] x = new decimal[y.Length];
            for(int i = 0; i < y.Length; i++)
            {
                x[q[i]] = y[i];
            }
            return x;
        }

        private decimal[,] createInverseMatrix(decimal[,] masLU)
        {
            int size = (int)Math.Sqrt(masLU.Length);
            decimal[,] inverse = new decimal[size, size];
            for(int j = 0; j < size; j++)
            {
                decimal[] b = new decimal[size];
                for(int k = 0; k <size; k++)
                {
                    b[k] = 0;
                    if (k == j)
                    {
                        b[k] = 1;
                    }
                }
                decimal[] x = solutionOfTheSystem(masLU, b);
                for(int i = 0; i < size; i++)
                {
                    inverse[i, j] = x[i];
                }
            }
            
            return inverse;
        }

        public decimal findMaxDifferenceX(decimal[] x, decimal[] x2)
        {
            decimal maxDifference = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (maxDifference < Math.Abs(x[i] - x2[i]))
                {
                    maxDifference = Math.Abs(x[i] - x2[i]);
                }
            }
            return maxDifference;
        }

        private decimal findNormMatrix(decimal[,] mas)
        {
            int size = (int)Math.Sqrt(mas.Length);
            decimal normMatrix = 0;
            decimal sum;

            for(int i = 0; i < size; i++)
            {
                sum = 0;
                for(int j = 0; j < size; j++)
                {
                    sum += mas[i, j];
                }

                if(i == 0)
                {
                    normMatrix = sum;
                }
                else
                {
                    if (normMatrix < sum)
                    {
                        normMatrix = sum;
                    }
                }
            }

            return normMatrix;
        }

        public decimal findMaxDifferenceInverseMatrix(decimal[,] startMas, decimal[,] masLU)
        {
            int size = (int)Math.Sqrt(startMas.Length);
            decimal normI = 0;
            decimal normA = 0;
            decimal[,] IMatrix = new decimal[size,size];
            try
            {
                masLU = matrixCompositionResultMatrix(startMas, createInverseMatrix(masLU));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 404;
            }

            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        IMatrix[i, i] = 1;
                    }
                    else
                    {
                        IMatrix[i, j] = 0;
                    }
                    IMatrix[i, j] -=masLU[i,j];
                }
            }

            normI = findNormMatrix(IMatrix);
            normA = findNormMatrix(startMas);
            return normI / normA;

        }
    }
}
