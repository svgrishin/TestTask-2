using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesstTask_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Matrix m = new Matrix();
            m.Move();
            foreach (int i in m.resultMatrix)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

        }
    }

    public class Matrix
    {
        public int[,] matrixArray = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
        //public int[,] matrixArray = new int[3, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 } };

        public int[] resultMatrix;

        public int row, col;

        public int counter;

        public int frame;

        public Matrix()
        {
            GetCounter();
            Array.Resize(ref resultMatrix, matrixArray.GetLength(0) * matrixArray.GetLength(1));
        }

        public void GetCounter()
        {
            counter = (matrixArray.GetLength(0) - frame * 2) * 2 + (matrixArray.GetLength(1) - frame * 2) * 2 - 4;
        }

        public void Move()
        {
            for (int i = 0; i < matrixArray.Length; i++)
            {
                resultMatrix[i] = matrixArray[row, col];
                counter--;

                if (counter != 0)
                {
                    if (row < matrixArray.GetLength(0) - 1 - frame && col == 0 + frame) MoveDown();
                    else
                    if (row == matrixArray.GetLength(0) - 1 - frame && col < matrixArray.GetLength(1) - 1 - frame) MoveRight();
                    else
                    if (row > 0 - frame && col == matrixArray.GetLength(1) - 1 - frame) MoveUp();
                    else
                        //if (row == 0 + frame && col == matrixArray.GetLength(1) - 1 - frame) MoveLeft();
                        MoveLeft();
                }
                else
                {
                    frame++;
                    GetCounter();
                    row = frame;
                    col = frame;
                }

            }
        }

        public void MoveDown()
        {
            row++;
        }

        public void MoveRight()
        {
            col++;
        }

        public void MoveUp()
        {
            row--;
        }

        public void MoveLeft()
        {
            col--;
        }

        //public void ShowMatrix()
        //{
        //    foreach(int i in matrixArray)
        //    {
        //        Console.Write(i);
        //    }
        //}
    }
}
