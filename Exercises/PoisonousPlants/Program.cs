﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace PoisonousPlants
{
    class MainClass
    {
        public static void Main()
        {
            TestPoisonousPlants(1, new int[] { 6, 5, 8, 4, 7, 10, 9 }, 2);
            TestPoisonousPlants(1, new int[] { 3, 6, 2, 7, 5 }, 2);
            Console.WriteLine("Test Complete");
        }


        public static void TestPoisonousPlants(int testIdentifier, int[] input, int expectedResult, bool exceptionExpected = false)
        {
            try
            {
                int actualResult = PoisonousPlants(input);

                if (actualResult.Equals(expectedResult))
                    return;
            }
            catch
            {
                if (exceptionExpected)
                    return;
            }

            Console.WriteLine(string.Format("Test Case {0} failed.", testIdentifier));
        }

        public static int PoisonousPlants(int[] input)
        {
            int plantStopDying = 0;
            int[] currentArray = input;
  
            do
            {
                List<int> nextArray = new List<int>(currentArray.Length);
                Stack<int> valuesInStack = new Stack<int>(1);

                nextArray.Add(currentArray[0]);
                valuesInStack.Push(currentArray[0]);
                bool noMoreDeaths = false;

                for (int index = 1; index < currentArray.Length; index++)
                {
                    int leftValue = valuesInStack.Pop();
                    int value = currentArray[index];

                    if (value > leftValue == false)
                        nextArray.Add(value);
                    else
                        noMoreDeaths = true;

                    valuesInStack.Push(value);
                }

                if (!noMoreDeaths)
                    break;

                plantStopDying = plantStopDying + 1;
                currentArray = nextArray.ToArray();

            } while (true);
          
            return plantStopDying;
        }
    }
}
