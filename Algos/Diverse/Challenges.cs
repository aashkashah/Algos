using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    class Challenges
    {
        public class FishInfo
        {
            public int Age;
            public int Count;
        }

        // calculates the number of fish that remain after a 5 year span
        // with pre req conditions
        public static int FishMortalityCalculator(List<FishInfo> fishInfo)
        {
            // 4 base pre reqs
            // < 1 1% chance
            // 1-2 10% chance
            // 3-100 25% chance
            // breed yearly, above 5 yr only. One pair can produce 200 offsprings

            // loop for 5 years
            int year = 1;
            int yearlyFishCount = 0;
            while (year <= 5)
            {   
                yearlyFishCount = 0;

                for (int i = 0; i < fishInfo.Count; i++)
                {   
                    if (fishInfo[i].Age >= 100)
                    {
                        continue;
                    }
                    else
                    {
                        int fishRemain = FindRemainingFish(fishInfo[i]);

                        fishInfo[i].Count = fishRemain;
                        yearlyFishCount += fishRemain;
                    }
                }

                // count new born
                int newBorns = CountNewBorn(fishInfo);
                yearlyFishCount += newBorns;
                
                // increment fish year
                fishInfo = IncrementFishAge(fishInfo);

                 // add new born fish
                fishInfo = AddNewBorn(fishInfo, newBorns);

                // remove fish over or equal to 100
                fishInfo = RemoveAgedFish(fishInfo);

                year++;
            }

            return yearlyFishCount;
        }

        /// <summary>
        // Finds remaining fish based on the mortality percentage 
        // Fish age < 1, 1% chance of survival
        // Fish age between 1-2, 10% chance of survival
        // Fish age between 3-99, 25% chance of survival
        /// </summary>
        /// <param name="fishInfo">Fish age and count passed as FishInfo object</param>
        /// <returns>Percentage of remaining fish in that age bracket</returns>
        static int FindRemainingFish(FishInfo fishInfo)
        {
            int fishRemain = 0;

            if (fishInfo.Age == 0)
            {
                // 1%
                fishRemain = fishInfo.Count / 100;
            }
            else if (fishInfo.Age >= 1 && fishInfo.Age < 3)
            {
                // 10%
                fishRemain = fishInfo.Count / 10;
            }
            else if (fishInfo.Age >= 3 && fishInfo.Age < 100)
            {
                // 25%
                fishRemain = fishInfo.Count / 4;
            }

            return fishRemain;
        }
        
        /// <summary>
        /// Counts the total number of new born in a year 
        /// </summary>
        /// <param name="fishInfo">List of fish Info (Age and Count) </param>
        /// <returns>Returns total number of fish born in a year as an Integer</returns>
        static int CountNewBorn(List<FishInfo> fishInfo)
        {
            int fish = 0;
            fishInfo.Where(x => x.Age >= 5 && x.Age < 100).ToList().ForEach(x => { fish += x.Count; } );
            
            // one pair produces 200 offsprings
            return (fish / 2) * 200;
        }

        /// <summary>
        /// Adds new born fish to the original list of fishInfo
        /// </summary>
        /// <param name="fishInfo">List of fish Info (Age and Count) </param>
        /// <param name="newBorn">Number of new born fish</param>
        /// <returns>Updated list with new born fish values</returns>
        static List<FishInfo> AddNewBorn(List<FishInfo> fishInfo, int newBorn)
        {
            // add newborn
            fishInfo.Add(new FishInfo { Age = 0, Count = newBorn });

            return fishInfo;
        }

        /// <summary>
        /// Increments the age of all fish in list provided
        /// </summary>
        /// <param name="fishInfo">List of fish Info (Age and Count) </param>
        /// <returns>Updated list with fish age incremented</returns>
        static List<FishInfo> IncrementFishAge(List<FishInfo> fishInfo)
        {
            // increment present fish year
            fishInfo.ForEach(x => x.Age++);
            
            return fishInfo;
        }

        /// <summary>
        /// Removes fish from list with age equal or above 100
        /// </summary>
        /// <param name="fishInfo">List of fish Info (Age and Count) </param>
        /// <returns>Updated list with fish equal or above 100 removed</returns>
        static List<FishInfo> RemoveAgedFish(List<FishInfo> fishInfo)
        {
            return fishInfo.Where(x => x.Age < 100).ToList();
        }
        
        static List<List<int>> ClosestXdestinations(int numDestinations, int[,] allLocations, int numDeliveries)
        {
            List<List<int>> allLocationsList = new List<List<int>>(); 
            for (int i = 0; i < allLocations.Length; i++)
            {
                allLocationsList.Add( new List<int> { allLocations[i, 0], allLocations[i, 1] });
            }
            
            List<List<int>> deliveryMap = new List<List<int>>();
            double currLocation = 0;

            for (int i = 0; i < numDeliveries; i++)
            {
                var closestLocation = FindClostestLocation(ref numDestinations, ref allLocationsList, currLocation);
                deliveryMap.Add(closestLocation);
                currLocation = Math.Sqrt(closestLocation[0] + closestLocation[1]);
            }

            return deliveryMap;
        }

        static List<int> FindClostestLocation(ref int numDestinations, ref List<List<int>> allLocations, double startLocation)
        {   
            List<double> distances = new List<double>();

            // loop and find all distances
            for (int i = 0; i < numDestinations; i++)
            {
                int x = allLocations[i][0];
                int y = allLocations[i][1];
                double distance = Math.Sqrt(x * x + y * y);

                distances.Add(Math.Abs(startLocation - distance));
            }

            double currMin = distances[0];
            int minIndex = 0;
            for (int i = 1; i < distances.Count; i++)
            {
                if (distances[i] < currMin)
                {
                    minIndex = i;
                    currMin = distances[i];
                }
            }

            List<int> result = new List<int> { allLocations[minIndex][0], allLocations[minIndex][1] };

            allLocations.RemoveAt(minIndex);
            numDestinations--;

            return result;
        }

        public void Main()
        {
            int[,] arr = new int[,] 
            {
                
                { 3, 6 },
                { 2, 4 },
                { 5, 3 },
                { 2, 7 },
                { 1, 8 },
                { 7, 9 }
            };

            //var temp = ClosestXdestinations(6, arr, 3);


            List<FishInfo> fishInfo = new List<FishInfo>()
            {
                new FishInfo()
                {
                    Age = 0,
                    Count = 2000,
                },
                new FishInfo()
                {
                    Age = 1,
                    Count = 1800,
                },
                new FishInfo()
                {
                    Age = 3,
                    Count = 100,
                },
                new FishInfo()
                {
                    Age = 5,
                    Count = 2500,
                },
                new FishInfo()
                {
                    Age = 10,
                    Count = 2000,
                },
                new FishInfo()
                {
                    Age = 100,
                    Count = 100,
                }
            };

            int totalFish = FishMortalityCalculator(fishInfo);
            Console.WriteLine(totalFish);
        }
    }
}
