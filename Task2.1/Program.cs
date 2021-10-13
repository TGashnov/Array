using System;
using System.Linq;

namespace Task2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Input(out int[] scopeOfDelivery);
            Solve(scopeOfDelivery, out int[][] gasStations);
            SourceTable(out int[,] sourceTable, out int[] maxPurchaseVolume, out double[] purchasePrice);
            Cost(purchasePrice, gasStations, out double[] cost);
            CostWithDelivery(purchasePrice, gasStations, sourceTable, out double[] costWithDelivery);
            Print(gasStations, cost, costWithDelivery);
        }

        private static void SourceTable(out int[,] sourceTable, out int[] maxPurchaseVolume, out double[] purchasePrice)
        {
            sourceTable = new int[6, 4]
            {
                { 803, 952, 997, 931},
                { 967, 1012, 848, 1200},
                { 825, 945, 777, 848},
                { 1024, 1800, 931, 999},
                { 754, 817, 531, 628},
                { 911, 668, 865, 1526}
            };
            maxPurchaseVolume = new int[6] { 600, 420, 360, 250, 700, 390 };
            purchasePrice = new double[6] { 5.2, 4.5, 6.1, 3.8, 6.4, 5.6 };
        }

        private static void Input(out int[] scopeOfDelivery)
        {
            scopeOfDelivery = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Введите объем поставки для {0} АЗС", i + 1);
                while (!int.TryParse(Console.ReadLine(), out scopeOfDelivery[i]) || scopeOfDelivery[i] < 0)
                {
                    Console.WriteLine("Вводите только целые неотрицательные числа");
                    Console.WriteLine("Попробуйте ввести число еще раз");
                }
            }
        }

        private static void Solve(int[] scopeOfDelivery, out int[][] gasStations)
        {
            SourceTable(out int[,] sourceTable, out int[] maxPurchaseVolume, out double[] purchasePrice);
            gasStations = GasStation();
            int row = RowMinPurchaseValue(purchasePrice, maxPurchaseVolume);
            int column = ColumnMinDeliveryValue(sourceTable, row);

            int sum = 0;
            for (int i = 0; i < 4; i++)
            {
                sum += scopeOfDelivery[i];
            }

            while (sum != 0)
            {
                if (scopeOfDelivery[column] > maxPurchaseVolume[row])
                {
                    sum -= maxPurchaseVolume[row];
                    scopeOfDelivery[column] -= maxPurchaseVolume[row];
                    gasStations[column][row] = maxPurchaseVolume[row];
                    maxPurchaseVolume[row] = 0;
                    row = RowMinPurchaseValue(purchasePrice, maxPurchaseVolume);
                    column = ColumnMinDeliveryValue(sourceTable, row);
                }
                else
                {
                    sum -= scopeOfDelivery[column];
                    maxPurchaseVolume[row] -= scopeOfDelivery[column];
                    gasStations[column][row] = scopeOfDelivery[column];
                    sourceTable[row, column] = 0;
                    column = ColumnMinDeliveryValue(sourceTable, row);
                }
            }
        }

        private static int[][] GasStation()
        {
            int[][] gasStations = new int[4][];
            for (int i = 0; i < 4; i++)
            {
                gasStations[i] = new int[6];
            }
            return gasStations;
        }

        private static int RowMinPurchaseValue(double[] purchasePrice, int[] maxPurchaseVolume)
        {
            int row = 0;
            int minPurchaseValue = int.MaxValue;
            for (int i = 0; i < 6; i++)
            {
                if (maxPurchaseVolume[i] != 0)
                {
                    if (purchasePrice[i] < minPurchaseValue)
                    {
                        minPurchaseValue = (int)purchasePrice[i];
                        row = i;
                    }
                }
            }
            return row;
        }

        private static int ColumnMinDeliveryValue(int[,] sourceTable, int row)
        {
            int column = 2;
            int minDeliveryValue = int.MaxValue;
            for (int j = 0; j < 4; j++)
            {
                if (sourceTable[row, j] != 0)
                {
                    if (sourceTable[row, j] < minDeliveryValue)
                    {
                        minDeliveryValue = (int)sourceTable[row, j];
                        column = j;
                    }
                }
            }
            return column;
        }

        private static void Cost(double[] purchasePrice, int[][] gasStations, out double[] cost)
        {
            cost = new double[6];
            for (int i = 0; i < 6; i++)
            {
                double sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    sum += gasStations[j][i];
                }
                cost[i] = sum * purchasePrice[i];
            }
        }

        private static void CostWithDelivery(double[] purchasePrice, int[][] gasStations, int[,] sourceTable, out double[] costWithDelivery)
        {
            costWithDelivery = new double[6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gasStations[j][i] == 0) continue;
                    costWithDelivery[i] += gasStations[j][i] * purchasePrice[i] + sourceTable[i, j];
                }
            }
        }

        private static double Sum(double[] costWithDelivery)
        {
            return costWithDelivery.Sum();
        }

        private static void Print(int[][] gasStations, double[] cost, double[] costWithDelivery)
        {
            Console.WriteLine("Поставщики     \tАЗС А\t\tАЗС Б\t\tАЗС В\t\tАЗС Г\t\tСтоимость\tС учетом");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t закупки\tдоставки ");
            Console.WriteLine();
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0, 9}", (i + 1));
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0, 12} \t", gasStations[j][i]);
                }
                Console.Write("{0, 16:F2}", cost[i]);
                Console.Write("{0, 16:F2}", costWithDelivery[i]);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("ИТОГО: {0:F2}", Sum(costWithDelivery));
        }
    }
}