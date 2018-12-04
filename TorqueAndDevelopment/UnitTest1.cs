using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace TorqueAndDevelopment
{
  
    class Solution
    {
        class City
        {
            public List<City> Neighbors = new List<City>();
            public int ComponentId;
        }

        public static long RoadsAndLibraries(long n, long libraryCost, long roadCost, int[][] cities)
        {
            if (libraryCost < roadCost)
                return n * libraryCost;

            if (cities.Length >= n - 1)
                return (n - 1) * roadCost + libraryCost;

            if (cities.Length == 0)
                return n * libraryCost;

            var cityWithNeighbors = new City[n];
            for (int i = 0; i < n; i++)
                cityWithNeighbors[i] = new City();

            for (int i = 0; i < cities.Length; i++)
            {
                cityWithNeighbors[cities[i][0] - 1].Neighbors.Add(cityWithNeighbors[cities[i][1] - 1]);
                cityWithNeighbors[cities[i][1] - 1].Neighbors.Add(cityWithNeighbors[cities[i][0] - 1]);
            }

            int componentId = 0;
            for (int i = 0; i < cityWithNeighbors.Length; i++)
            {
                if (cityWithNeighbors[i].ComponentId == 0)
                {
                    componentId++;
                    cityWithNeighbors[i].ComponentId = componentId;
                    var citiesToVisit = new Queue<City>();
                    citiesToVisit.Enqueue(cityWithNeighbors[i]);
                    while (citiesToVisit.Any())
                    {
                        var currentCity = citiesToVisit.Dequeue();
                        foreach (var neighbor in currentCity.Neighbors.Where(x => x.ComponentId == 0))
                        {
                            neighbor.ComponentId = componentId;
                            citiesToVisit.Enqueue(neighbor);
                        }
                    }
                }
            }

            long c1 = componentId * libraryCost + (cityWithNeighbors.Count() - componentId) * roadCost;
            long c2 = cityWithNeighbors.Count() * libraryCost;
            return Math.Min(c1, c2);
        }
    }

    public class UnitTest1
    {
        [Fact]
        public void ReadFileTest()
        {
            var input = File.ReadAllLines("input05.txt");
            var output = File.ReadAllLines("output05.txt");
            var nOfTests = Convert.ToInt32(input[0]);
            int index = 1;
            for (int i = 0; i < nOfTests; i++)
            {
                var fstLine = input[index].Split(" ");
                var cities = Convert.ToInt32(fstLine[0]);
                var roads = Convert.ToInt32(fstLine[1]);
                var libCost = Convert.ToInt32(fstLine[2]);
                var roadCost = Convert.ToInt32(fstLine[3]);
                var cityRoads = new int[roads][];
                for (int j = 0; j < roads; j++)
                {
                    index++;
                    var values = input[index].Split(" ");
                    cityRoads[j] = new int[2];
                    cityRoads[j][0] = Convert.ToInt32(values[0]);
                    cityRoads[j][1] = Convert.ToInt32(values[1]);
                }

                Assert.Equal(Convert.ToInt64(output[i]), Solution.RoadsAndLibraries(cities, libCost, roadCost, cityRoads));
                index++;
            }
        }

        [Fact]
        public void Given5Cities_When3AreConnected_thenReturns15()
        {
            var cities = new int[2][];
            cities[0] = new[]
            {
                1, 2
            };
            cities[1] = new[]
            {
                3, 4
            };
            Assert.Equal(20, Solution.RoadsAndLibraries(5, 6, 1, cities));
        }


        [Fact]
        public void GivenRoadsAndLibraries_WhenRoadsEqualCitiesMinusOne_ThenBuildOneLibraryAndRecoverCitiesMinusOneRoad()
        {
            var cities = new int[3][];
            cities[0] = new[]
            {
                1, 2
            };
            cities[1] = new[]
            {
                2, 3
            };
            cities[2] = new int[0];
            Assert.Equal(4, Solution.RoadsAndLibraries(3, 2, 1, cities));
        }

        [Fact]
        public void GivenRoadsAndLibraries_WhenRoadsAreCheaper_And_NotAllCitiesAreConnected_ThenDoComplexCalculation()
        {
            var cities = new int[3][];
            cities[0] = new[]
            {
                1, 2
            };
            cities[1] = new[]
            {
                3, 1
            };
            cities[2] = new[]
            {
                2, 3
            };
            Assert.Equal(8, Solution.RoadsAndLibraries(5, 2, 1, cities));
        }

        [Fact]
        public void GivenRoadsAndLibraries_WhenRoadsEqualCities_ThenBuildOneLibraryAndRecoverCitiesMinusOneRoad()
        {
            var cities = new int[3][];
            cities[0] = new[]
            {
                1, 2
            };
            cities[1] = new[]
            {
                3, 1
            };
            cities[2] = new[]
            {
                2, 3
            };
            Assert.Equal(4, Solution.RoadsAndLibraries(3, 2, 1, cities));
        }

        [Fact]
        public void GivenRoadsAndLibraries_WhenLibraryIsCheaperThanRoad_ThenJustCreateLibraries()
        {
            var cities = new int[6][];
            cities[0] = new[]
            {
                1, 3
            };
            cities[1] = new[]
            {
                3, 4
            };
            cities[2] = new[]
            {
                2, 4
            };
            cities[3] = new[]
            {
                1, 2
            };
            cities[4] = new[]
            {
                2, 3
            };
            cities[5] = new[]
            {
                5, 6
            };
            Assert.Equal(12, Solution.RoadsAndLibraries(6, 2, 5, cities));
        }
    }
}