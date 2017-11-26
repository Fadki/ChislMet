using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLabChislMeth
{
    public class CreateMatrix
    {
        private int size;
        private decimal[,] mas;
        private decimal[] x;
        private decimal[] b;
        private decimal[] x2;
        private Random r = new Random();
        private decimal[,] startMas;

        public decimal[] getX
        {
            get
            {
                return x;
            }
        }

        public decimal[] getX2
        {
            get
            {
                return x2;
            }
        }

        public decimal[] setX2
        {
            set
            {
                x2 = value;
            }
        }

        public decimal[,] getMas
        {
            get { return mas; }
        }

        public decimal[] getB
        {
            get { return b; }
        }


        public decimal[,] setMas
        {
            set { mas = value; }
        }

        public int getSize
        {
            get { return size; }
        }

        private string createMatrix(string[] sMas)
        {

            for (int i = 0; i < size; i++)
            {
                x[i] = i+1;
                string[] s;
                try
                {
                    sMas[i] = sMas[i].TrimEnd(new char[] { '\r', ' ' });
                    s = sMas[i].Split(' ');
                }
                catch (Exception e)
                {
                    return ("Некорректно введена числовая строка");

                }
                for (int j = 0; j < size; j++)
                {
                    try
                    {
                        mas[i, j] = decimal.Parse(s[j]);
                    }
                    catch (Exception e)
                    {
                        return "Значение введено некорректно";
                    }

                }
            }
            return "Матрица составлена";
        }

        public string readMatrixElements(string s)
        {

            s = s.TrimEnd(new char[] { '\r', '\n', ' '});
            string[] sMas = s.Split('\n');
            size = sMas.Length;
            mas = new decimal[size, size];
            x = new decimal[size];
            string result = createMatrix(sMas);
            return result;

        }

        public string getMatrix()
        {
            string s = "Составленная матрица: " + Environment.NewLine;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    s += mas[i, j].ToString() + "; ";
                }
                s += Environment.NewLine;
            }
            return s;
        }

        public string getVector(decimal[] v, string name)
        {
            string s = "Вектор " + name;
            for (int i = 0; i < size; i++)
            {
                s += v[i].ToString() + "; ";
            }
            s += Environment.NewLine;
            return s;
        }

        public void CreateCustomMatrix1(int size)
        {
            mas = new decimal[size, size];
            x = new decimal[size];
            for (int i = 0; i < size; i++)
            {
                x[i] = i + 1;
                for (int j = 0; j < size; j++)
                {
                    mas[i, j] = 1;
                    mas[i, j] /= (i + j + 1);
                }
            }
        }

        public void CreateRandomMatrix(int size)
        {
            mas = new decimal[size, size];
            x = new decimal[size];
            for (int i = 0; i < size; i++)
            {
                x[i] = i+1;
                for (int j = 0; j < size; j++)
                {
                    mas[i, j] = (decimal)r.NextDouble();
                }
            }
        }

        public Result Work(int size)
        {
            startMas = new decimal[size, size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j <size; j++)
                {
                    startMas[i, j] = mas[i,j];
                }
            }
                createB();

                WorkMethods wm = new WorkMethods();

                setMas = wm.createULJordan(getMas, size);
                setX2 = wm.solutionOfTheSystem(getMas, getB);
            int count = wm.getCountOperations();
            decimal maxDifference = wm.findMaxDifferenceX(x, x2);
            decimal maxNorm = wm.findMaxDifferenceInverseMatrix(startMas, mas);
            return new Result(size, maxDifference, count, maxNorm);
                

           
        }

        private void createB()
        {
            WorkMethods wm = new WorkMethods();
            b = wm.matrixCompositionResultVector(mas, x);
        }

    }
}
