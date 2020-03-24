using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.DataLayer
{
    public class GameData
    {
      
        public static Player PlayerData()
        {
            return new Player()
            {
                _id = 1,
                Name = "Jon",
                Army = Player.ArmyName.Stark.ToString(),
                HouseType = Character.House.Stark.ToString(),
                Health = 85,
                Lives = 3,
                ExperiencePoints = 5,
                Locationid = 85,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002), 3),
                    new GameItemQuantity(GameItemById(2001), 2),
                    new GameItemQuantity(GameItemById(1010), 1),
                }

            };
        }
        public static string InitialMessages()
        {
            return  "Winter is coming! The Night King is making his way to the wall!"+
                "Make your way through Westeros to gather supplies and allies!"+
                "And remember: Valar Morghulis!";
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {

            int rows = 7;
            int columns = 3;

            Map gameMap = new Map(rows, columns);

            gameMap.MapLocation[0, 0] = new Location()
            {
                id = 1,
                name = "Not Accessible Location",
                accessible = false,
                modifyExperientsPoints = 10,
                Message = "This location is not accessible"
            };
            gameMap.MapLocation[0, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            //
            // row 2
            //
            gameMap.MapLocation[0, 2] = new Location()
            {
                id = 3,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };
            gameMap.MapLocation[1, 0] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,

               
                modifyExperientsPoints = 50,
                modifyLives = -1,
                requiredExperientsPoints = 40
            };

            //
            // row 3
            //
            gameMap.MapLocation[1, 1] = new Location()
            {
                id = 5,
                name = "Dreadfort",
                description = "House Bolton, chance to gather supplies or allies",
                accessible = false,
                modifyExperientsPoints = 20,
                ModifyHealth = 50,
                Message = "Traveler, our telemetry places you at the Xantoria Market. We have reports of local health potions.",
                 GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(3001), 1),
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(4001), 1)
                },
            };
            gameMap.MapLocation[1, 2] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[2, 0] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[2, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[2, 2] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[3, 0] = new Location()
            {
                id = 2,
                name = "Winterfell",
                description = "This is House Stark",
                accessible = true,
                modifyExperientsPoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(4002), 1),
                                        new GameItemQuantity(GameItemById(01), 10),
                                                            new GameItemQuantity(GameItemById(23), 10)


                },
            };

            gameMap.MapLocation[3, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                
            };

            gameMap.MapLocation[3, 2] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                
            };

            gameMap.MapLocation[4, 0] = new Location()
            {
                id = 2,
                name = "Location Not Accessible",
                description = "This location is not accessible",
                accessible = false,
             
            };


            gameMap.MapLocation[4, 1] = new Location()
            {
                id = 2,
                name = "The Twins",
                description = "House Frey, you have to pay to pass",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[4, 2] = new Location()
            {
                id = 2,
                name = "Location Not Accessible",
                description = "This location is not accessible",
                accessible = false,

            };

            gameMap.MapLocation[5, 0] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[5, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
               
            };

            gameMap.MapLocation[5, 2] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                
            };

            gameMap.MapLocation[6, 0] = new Location()
            {
                id = 2,
                name = "Casterly Rock",
                description = "House Lannister, Gather supplies or allies",
                accessible = true,
                modifyExperientsPoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(3001), 1),
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(4001), 1)
                },
            };

            gameMap.MapLocation[6, 1] = new Location()
            {
                id = 2,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(3001), 1),
                                        new GameItemQuantity(GameItemById(24), 10)

                },
            };

            gameMap.MapLocation[6, 2] = new Location()
            {
                id = 2,
                name = "Storm's end",
                description = "House Barethon, gather supplies or allies",
                accessible = true,
                modifyExperientsPoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2001), 10),
                                        new GameItemQuantity(GameItemById(32), 10)

                }
            };

            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Longbow", 1000, 100, 10, "The valyrian steel sword from House Stark. Without this, you do not stand a chance of defeating the night king.", 10),
new Weapon(1002, "Stick", 0, 1, 10, "You can find sticks anywhere and use them to fight off weak enemies, but they will break after one fight.", 1),
new Weapon(1005, "Needle", 250, 1, 9, "Arya's sword. It is light and versatile, but not made out of valyarian steel. You can use this against people and animals.", 1),
new Weapon(1010, "Common sword", 10, 10, 10, "A common sword you can use in battle.", 1),
new Treasure(2001, "Gold Coin", 10, Treasure.TreasureType.Gold, "A gold coin", 5),
new Treasure(2002, "Silver Coin", 5, Treasure.TreasureType.Gold, "A silver coin", 2),
new Treasure(2003, "Bronze Coin", 1, Treasure.TreasureType.Gold, "A bronze coin", 1),
new Potion(3001, "Health potion", 5, 40, 1, "Melissandre made you a potion to help you on your way again. Adds 20 points of health.", 5),
            };

        }
        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.id == id);
        }

    }
}
