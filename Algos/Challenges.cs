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
        public static int FisherySimulator(List<FishInfo> fishInfo)
        {
            // 4 base pre reqs
            // < 1 1% chance
            // 1-2 10% chance
            // 3-100 25% chance
            // breed yearly, above 5 yr only. One pair can produce 200 offsprings

            // loop for 5 years
            int year = 1;
            while (year <= 5)
            {
                int fishCount = 0;

                for (int i = 0; i < fishInfo.Count; i++)
                {
                    int fishRemain = 0;
                    if (fishInfo[i].Age == 0)
                    {
                        // 1%
                        fishRemain = fishInfo[i].Count / 100;
                        fishInfo[i].Count = fishRemain;
                        fishCount += fishRemain; 
                    }
                    else if (fishInfo[i].Age >= 1 && fishInfo[i].Age < 3)
                    {
                        // 10%
                        fishRemain += fishInfo[i].Count / 10;
                        fishInfo[i].Count = fishRemain;
                        fishCount += fishRemain;
                    }
                    else if (fishInfo[i].Age >= 3 && fishInfo[i].Age < 100)
                    {
                        // 25%
                        fishRemain += fishInfo[i].Count / 4;
                        fishInfo[i].Count = fishRemain;
                        fishCount += fishRemain;
                    }
                }

                // count new born
                int newBorns = CountNewBorn(fishInfo);
                fishCount += newBorns;
                
                // update new fish years
                fishInfo = UpdateFishYearly(fishInfo, newBorns);

                // remove fish over or equal to 100
                fishInfo = RemoveAgedFish(fishInfo);

                year++;
                if (year == 6)
                {
                    return fishCount;
                }
            }

            return 0;
        }


        static int CountNewBorn(List<FishInfo> fishInfo)
        {
            int fish = 0;
            fishInfo.Where(x => x.Age >= 5 && x.Age < 100).ToList().ForEach(x => { fish += x.Count; } );
            
            // one pair produces 200 offsprings
            return (fish / 2) * 200;
        }

        static List<FishInfo> UpdateFishYearly(List<FishInfo> fishInfo, int newBorn)
        {
            // increment present fish year
            fishInfo.ForEach(x => x.Age++);

            // add newborn
            fishInfo.Add(new FishInfo { Age = 0, Count = newBorn });

            return fishInfo;
        }

        static List<FishInfo> RemoveAgedFish(List<FishInfo> fishInfo)
        {
            return fishInfo.Where(x => x.Age < 100).ToList();
        }

        public static void Main2(string[] args)
        {
            List<FishInfo> fishInfo = new List<FishInfo>()
            {
                new FishInfo()
                {
                    Age = 0,
                    Count = 200,
                },
                new FishInfo()
                {
                    Age = 1,
                    Count = 180,
                },
                new FishInfo()
                {
                    Age = 3,
                    Count = 100,
                },
                new FishInfo()
                {
                    Age = 5,
                    Count = 100,
                },
                new FishInfo()
                {
                    Age = 10,
                    Count = 100,
                },
                new FishInfo()
                {
                    Age = 100,
                    Count = 100,
                }
            };

            int totalFish = FisherySimulator(fishInfo);
            Console.WriteLine(totalFish);
        }
    }
}
