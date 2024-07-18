//
// Gold Group - Dillon Rodgers, Hocine Mockbel, Maddison Kiefer
// CS3110 C# Programming
// M7 - Preliminary Game
// 12 - 09 - 2023
//

using Module8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3110Module8GroupGold
{
    internal class SmartPlayer : IPlayer
    {
        private int _gridSize;
        private int _playerIndex;
        public int TotalPlayers;
        private static Random random = new Random();
        private static List<List<AttackResult>> enemyResultsLists = new List<List<AttackResult>>();
        private List<Ship> playerShips = new List<Ship>();

        public SmartPlayer(string name, int totalPlayers)
        {
            Name = name;
            TotalPlayers = totalPlayers;
        }

        // Adding to StartNewGame method
        public void StartNewGame(int playerIndex, int gridSize, Ships ships)
        {
            _gridSize = gridSize;
            _playerIndex = playerIndex;

            // Initializing / resetting any data structures
            enemyResultsLists.Clear();
            for (int i = 0; i < TotalPlayers; i++)
            {
                enemyResultsLists.Add(new List<AttackResult>());
            }

            // Placing ships on the grid
            PlaceShips(playerIndex, ships);
        }

        // Additions to the ship placement
        private void PlaceShips(int playerIndex, Ships ships)
        {
            playerShips.Clear();

            int y = 0;
            foreach (var ship in ships._ships)
            {
                ship.Place(new Position(0, y++), Direction.Horizontal);
            }


            //foreach (var ship in ships._ships)
            //{
            //    // Randomly placing each ship
            //    var randomX = random.Next(_gridSize);
            //    var randomY = random.Next(_gridSize);
            //    var position = new Position(randomX, randomY);
            //    playerShips.Add(ship);
            //    //ship.Place(position, Direction.Horizontal);

            //    //if (ship is AircraftCarrier aircraftCarrier)
            //    //{
            //    //    var newShip2 = new AircraftCarrier();
            //    //    newShip2..place
            //    //    playerShips.Add(newShip2);
            //    //}

            //    //if (ship is Battleship battleShip)
            //    //{
            //    //    var newShip1 = new Battleship();
            //    //    playerShips.Add(newShip1);
            //    //}

            //    //if (ship is Destroyer destroyer)
            //    //{
            //    //    var newShip3 = new AircraftCarrier();
            //    //    playerShips.Add(newShip3);
            //    //}

            //    //if (ship is PatrolBoat patrolBoat)
            //    //{
            //    //    var newShip4 = new PatrolBoat();
            //    //    playerShips.Add(newShip4);
            //    //}

            //    //if (ship is Submarine submarine)
            //    //{
            //    //    var newShip5 = new Submarine();
            //    //    playerShips.Add(newShip5);
            //    //}
            //}
        }

        // Checking if all ships are sunk
        private bool AreAllShipsSunk()
        {
            return playerShips.All(ship => ship.Sunk);
        }


        

        public Position GetAttackPosition()
        {
            // For each to go through each player's result list checking if the last attack was a hit
            foreach (var resultList in enemyResultsLists)
            {
                
                var lastEnemyResult = resultList.LastOrDefault();
                if(lastEnemyResult.PlayerIndex != _playerIndex)
                {
                    if (!EqualityComparer<AttackResult>.Default.Equals(lastEnemyResult, default) && lastEnemyResult.ResultType == AttackResultType.Hit)
                    {
                        // The last attack's neighboring positions 
                        var neighborSpots = new List<Position>
                    {
                        new Position(lastEnemyResult.Position.X + 1, lastEnemyResult.Position.Y),
                        new Position(lastEnemyResult.Position.X - 1, lastEnemyResult.Position.Y),
                        new Position(lastEnemyResult.Position.X, lastEnemyResult.Position.Y + 1),
                        new Position(lastEnemyResult.Position.X, lastEnemyResult.Position.Y - 1),
                    };

                        // Loop through each neighboring position looking for a hit
                        for (int i = 0; i < neighborSpots.Count; i++)
                        {
                            var neighborSpot = neighborSpots[i];
                            var neighborResult = resultList.FirstOrDefault(x => x.Position == neighborSpot);
                            if (!EqualityComparer<AttackResult>.Default.Equals(neighborResult, default) && neighborResult.ResultType == AttackResultType.Hit)
                            {
                                // If a hit is found in the neighboring spot, use that to continue in the same direction 
                                // because that is most likely where the ship is  
                                switch (i)
                                {
                                    // for each case, check if the position is clear before returning
                                    case 0:
                                        if (PosClear(lastEnemyResult.PlayerIndex, neighborSpot.X + 1, neighborSpot.Y))
                                            return new Position(neighborSpot.X + 1, neighborSpot.Y);
                                        break;
                                    case 1:
                                        if (PosClear(lastEnemyResult.PlayerIndex, neighborSpot.X - 1, neighborSpot.Y))
                                            return new Position(neighborSpot.X - 1, neighborSpot.Y);
                                        break;
                                    case 2:
                                        if (PosClear(lastEnemyResult.PlayerIndex, neighborSpot.X, neighborSpot.Y + 1))
                                            return new Position(neighborSpot.X, neighborSpot.Y + 1);
                                        break;
                                    case 3:
                                        if (PosClear(lastEnemyResult.PlayerIndex, neighborSpot.X, neighborSpot.Y - 1))
                                            return new Position(neighborSpot.X, neighborSpot.Y - 1);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        // If none of the neighboring spots have results, then randomly choose a neighboring position
                        foreach (var spot in neighborSpots)
                        {
                            if (PosClear(0, spot.X, spot.Y))
                            {
                                return spot;
                            }
                        }
                    }
                }
               
            }

            var randX = 0;
            var randY = 0;
            do
            {
                randX = random.Next(_gridSize);
                randY = random.Next(_gridSize);
            }
            while (!PosClear(0, randX, randY));

            return new Position(randX, randY);
        }

        // Updating ship status based on attack result
        private void UpdateShipStatus(AttackResult result)
        {
            foreach (var ship in playerShips)
            {
                if (!ship.Sunk)
                {
                    // Checking if the ship is hit
                    if (ship.Positions.Contains(result.Position))
                    {
                        ship.Attack(result.Position);

                        // Checking if the ship is sunk after the hit
                        if (ship.Sunk)
                        {
                            Console.WriteLine($"Player {result.PlayerIndex}'s ship is sunk!");
                            UpdateSunkShipPositions(result.PlayerIndex, ship);
                        }
                    }
                }
            }
        }

        // Updating the positions of a sunken ship
        private void UpdateSunkShipPositions(int playerIndex, Ship sunkShip)
        {
            foreach (var pos in sunkShip.Positions)
            {
                enemyResultsLists[playerIndex].Add(new AttackResult
                {
                    PlayerIndex = playerIndex,
                    Position = pos,
                    ResultType = AttackResultType.Sank     // Marking the ship as sunk in the results
                });
            }
        }

        // Returning true if the position is clear
        public bool PosClear(int enemyIndex, int x, int y)
        {
            if( y > _gridSize - 1 || y < 0 || x > _gridSize - 1 || x < 0)
            {
                return false;
            }
            else
            {
                foreach (var result in enemyResultsLists[enemyIndex])
                {
                    if (result.Position.X == x && result.Position.Y == y)
                    {
                        return false;
                    }
                }
                return true;
            }
                
            
        }

        // Puts results for each attack into the corresponding list in enemyResults list
        // Example: player at index 1: hit, then add that result to enemyResultsLists at index 1
        public void SetAttackResults(List<AttackResult> results)
        {
            foreach (var result in results)
            {
                enemyResultsLists[result.PlayerIndex].Add(result);
            }
        }

        // Getting the total number of players
        //private int GetTotalPlayers()
        //{
        //    // I added this for future, we might have more than 2 players. For now it will read only 2 players 
        //    return 2;
        //}

        public String Name { get; }
        public int Index { get; }
    } 
}

