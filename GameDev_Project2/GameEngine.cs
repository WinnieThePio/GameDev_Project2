﻿using System;

namespace GameDev_Project2
{
    public class GameEngine
    {
        public Map map;
        private bool PlayerMoves , Enemymoves;
     
        public GameEngine()
        {

            map = new Map(10, 9, 7);
            
        }

        //If a move is possible this moves the player object and changes the tile types of both the new and old positions

        public bool MovePlayer(Character C, Character.Movement m)
        {

            PlayerMoves = true;
            //Moves the player if able to
            
            switch (m)
            {
                
                case Character.Movement.NoMovement:
                    PlayerMoves = false;
                    break;
                    Item i;
                case Character.Movement.Up:

                    if (map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Hero)
                    {
                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetY(C.GetY() - 1);





                         i = map.GetItemAtPosition(C.GetX(), C.GetY());

                        if (i != null)
                        {
                            C.PickUp(i);

                        }
                    }
                    break;

                case Character.Movement.Down:

                    if (map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Hero)
                    {

                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetY(C.GetY() + 1);



                        i = map.GetItemAtPosition(C.GetX(), C.GetY());

                        if (i != null)
                        {
                            C.PickUp(i);

                        }
                    }
                    break;

                case Character.Movement.Left:

                    if (map.GetXY(C.GetX() - 1, C.GetY() ).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX() - 1, C.GetY() ).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX() - 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Hero)
                    {

                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetX(C.GetX() - 1);
                    }


                   
                  

                    i = map.GetItemAtPosition(C.GetX(), C.GetY());

                    if (i != null)
                    {
                        C.PickUp(i);
                    }
                    break;

                case Character.Movement.Right:

                    if (map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Border && map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Hero)
                    {
                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetX(C.GetX() + 1);


                        i = map.GetItemAtPosition(C.GetX(), C.GetY());

                        if (i != null)
                        {
                            C.PickUp(i);

                        }
                    }
                    break;

                   
                default:
                    break;
            }
            //Fills the players new position by setting the tile type
            map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Hero);
            return PlayerMoves;
        }
        public bool MoveEnemy(Character C, Character.Movement m)
        {

            Enemymoves = true;
            //Moves the player if able

            switch (m)
            {

                case Character.Movement.Up:
                    if (map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX(), C.GetY() - 1).GetCurrentTileType() != Tile.TileType.Border)
                    {
                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetY(C.GetY() - 1);
                    }
                    break;

                case Character.Movement.Down:
                    if (map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX(), C.GetY() + 1).GetCurrentTileType() != Tile.TileType.Border)
                    {

                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetY(C.GetY() + 1);
                    }
                    break;

                case Character.Movement.Left:
                    if (map.GetXY(C.GetX() - 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX() - 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Border)
                    {

                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetX(C.GetX() - 1);
                    }

                    break;

                case Character.Movement.Right:
                    if (map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Enemy && map.GetXY(C.GetX() + 1, C.GetY()).GetCurrentTileType() != Tile.TileType.Border)
                    {
                        map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Empty);
                        C.SetX(C.GetX() + 1);
                    }
                    break;


                default:
                    break;
            }
            //Fills the enemies new position by setting the tile type
            map.GetXY(C.GetX(), C.GetY()).SetCurrentTileType(Tile.TileType.Enemy);
            return Enemymoves;
        }

        public string ShowMap()
        {
            string DisplayMap = Convert.ToString(map.MapArray);
            return string.Format(DisplayMap);
        }


        public void MoveEnemies(Character h)
        {
            Random random = new Random();
            int move;
           
            Tile[] pTile = new Tile[map.enemies.Length - 1];
            //creates a random number for the specific enemy which creates a movies
            for (int i = 0; i < map.enemies.Length; i++)
            {
              move = random.Next(0, 5);
               
                switch (move)
                {
                    case 0:
                        MoveEnemy(map.enemies[i], Character.Movement.NoMovement);
                        break;

                    case 1:
                   
                            MoveEnemy(map.enemies[i], Character.Movement.Up);
                        
                      
                        break;

                    case 2:
                 
                            MoveEnemy(map.enemies[i], Character.Movement.Down);
                        
                      
                        break;

                    case 3:
                    
                            MoveEnemy(map.enemies[i], Character.Movement.Left);
                      
                      
                          
                        break;

                    case 4:
                       

                            MoveEnemy(map.enemies[i], Character.Movement.Right);
                    
                        break;

                    default:

                        break;
                }

            }

        
            
            EnemyAttacks();
        }

        //still in progress
        public void EnemyAttacks() 
        {
            for (int i = 0; i < map.enemies.Length; i++)
            {
            
                if (map.enemies[i].CheckRange(map.enemies[i], map.hero) == true)
                {
                    map.enemies[i].Attack(map.hero);
                }
          
            }
        }


        
    }
}
