using Module8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS3110Module8GroupGold
{
    internal class SmartPlayer : IPlayer
    {
        private int _gridSize;
        private static List<List<AttackResult>> enemyResultsLists = new List<List<AttackResult>>();
        
        // TODO: Finish StartNewGame
        public void StartNewGame(int playerIndex, int gridSize, Ships ships)
        {
            _gridSize = gridSize;
        }

        public String Name { get; }

        public int Index { get; }

        public Position GetAttackPosition()
        {
            // TODO: Add logic for sunk ships


            var rand = new Random();
            // For each to go through each players result list checking if last attack was a hit
            foreach (var resultList in enemyResultsLists)
            {
                var LastEnemyResult = resultList[resultList.Count];
                if (LastEnemyResult.ResultType == AttackResultType.Hit)
                {
                    // The last attacks neighboring positions 
                    var neighborSpots = new List<Position>
                    {
                        new Position(LastEnemyResult.Position.X+1, LastEnemyResult.Position.Y),
                        new Position(LastEnemyResult.Position.X-1, LastEnemyResult.Position.Y),
                        new Position(LastEnemyResult.Position.X, LastEnemyResult.Position.Y+1),
                        new Position(LastEnemyResult.Position.X, LastEnemyResult.Position.Y-1),
                    };
                    // Loop through each neigboring positions looking for a hit
                    for (int i = 0; i < neighborSpots.Count; i++)
                    {
                        var neighborSpot = neighborSpots[i];
                        var neigborResult = resultList?.FirstOrDefault(x => x.Position == neighborSpot);
                        if (neigborResult.HasValue)
                        {
                            if (neigborResult.Value.ResultType == AttackResultType.Hit)
                            {
                                // If a hit is found in neighboring spot use that to continue in same direction 
                                // because that is most likely where the ship is  
                                switch (i)
                                {
                                    // for each case we check if the postition is clear before returning
                                    case 0:
                                        if (PosClear(LastEnemyResult.PlayerIndex, neighborSpot.X + 1, neighborSpot.Y))
                                            return new Position(neighborSpot.X + 1, neighborSpot.Y);
                                        else
                                            break;
                                    case 1:
                                        if (PosClear(LastEnemyResult.PlayerIndex, neighborSpot.X - 1, neighborSpot.Y))
                                            return new Position(neighborSpot.X - 1, neighborSpot.Y);
                                        else
                                            break;
                                    case 2:
                                        if (PosClear(LastEnemyResult.PlayerIndex, neighborSpot.X , neighborSpot.Y+1))
                                            return new Position(neighborSpot.X, neighborSpot.Y+1);
                                        else
                                            break;
                                    case 3:
                                        if (PosClear(LastEnemyResult.PlayerIndex, neighborSpot.X, neighborSpot.Y-1))
                                            return new Position(neighborSpot.X, neighborSpot.Y-1);
                                        else
                                            break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    // If none of the nieghboring spots have results, than randomly choose a neighboring position
                    foreach (var spot in neighborSpots)
                    {
                        if (PosClear(0, spot.X, spot.Y))
                        {
                            return spot;
                        }
                    }

                }
            }

            var randX = 0;
            var randY = 0;
            do
            {
                randX = rand.Next(_gridSize);
                randY = rand.Next(_gridSize);
            }
            while (!PosClear(0, randX, randY));

            return new Position(randX, randY);
        }

        // Returns true if postion is clear
        public bool PosClear(int enemyIndex,int x, int y)
        {
            foreach (var result in enemyResultsLists[enemyIndex])
            {
                if(result.Position.X == x && result.Position.Y == y)
                {
                    return false;
                }
            }
            return true;
        }

        // Puts results for each attack into the corrospoding list in enemyResults list
        // Example player at index 1: hit , then add that result to enemyResultsLists at index 1
        public void SetAttackResults(List<AttackResult> results)
        {
            foreach (var result in results)
            {
                enemyResultsLists[result.PlayerIndex].Add(result);
            }
        }
    }
}
