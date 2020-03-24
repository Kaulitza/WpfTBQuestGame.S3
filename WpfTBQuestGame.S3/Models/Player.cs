using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.Models
{
    public class Player : Character
    {

        private int _lives, _health, _experiencePoints, _wealth;
        private string _house;
        private string _armyname;

        private List<Location> _locationVisited;

        //private ObservableCollection<GameItem> _inventory;
        //private ObservableCollection<GameItem> _potions;
        //private ObservableCollection<GameItem> _Treasures;
        //private ObservableCollection<GameItem> _weapons;

        private Weapon _currentWeapon;


        private ObservableCollection<GameItemQuantity> _inventory; public ObservableCollection<GameItemQuantity> Inventory { get { return _inventory; } set { _inventory = value; } }
        private ObservableCollection<GameItemQuantity> _potions; public ObservableCollection<GameItemQuantity> Potions { get { return _potions; } set { _potions = value; } }
        private ObservableCollection<GameItemQuantity> _treasures; public ObservableCollection<GameItemQuantity> Treasures { get { return _treasures; } set { _treasures = value; } }
        private ObservableCollection<GameItemQuantity> _weapons; public ObservableCollection<GameItemQuantity> Weapons { get { return _weapons; } set { _weapons = value; } }
        private ObservableCollection<GameItemQuantity> _allies; public ObservableCollection<GameItemQuantity> Allies { get { return _allies; } set { _allies = value; } }


        public enum ArmyName
        {
            Dothraki,
            Unsullied,
            Stark,
            Lannister,
            Targaryen
        }

        public Player() :base()
        {

            _locationVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItemQuantity>();
            _treasures = new ObservableCollection<GameItemQuantity>();
            _potions = new ObservableCollection<GameItemQuantity>();
            _inventory = new ObservableCollection<GameItemQuantity>();
            _allies = new ObservableCollection<GameItemQuantity>();
        }
        public Player(int id, string name, int locationid) : base(id, name, locationid)
        {
            _id = id;
            _name = name;
            _locationid = locationid;
        }
        public override void functionAbstract()
        {

        }
        public override void functionVirtual()
        {

        }
        public Weapon CurrentWeapon
        {
            get { return _currentWeapon; }
            set { _currentWeapon = value; }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationVisited; }
            set { _locationVisited = value; }
        }
        public int Lives
        {
            get { return _lives; }
            set { _lives = value;OnPropertyChanged(nameof(_lives)); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(_name)); }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;

                if (_health > 100)
                {
                    _health = 100;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                    _lives--;
                }
                OnPropertyChanged(nameof(_health)); }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; OnPropertyChanged(nameof(_experiencePoints)); }
        }
        public int Locationid
        {
            get { return _locationid; }
            set { _locationid = value; OnPropertyChanged(nameof(_locationid)); }
        }

        public string Army
        {
            get { return _armyname; }
            set { _armyname = value; OnPropertyChanged(nameof(_armyname)); }
        }
        public string HouseType
        {
            get { return _house; }
            set { _house = value; OnPropertyChanged(nameof(_house)); }
        }
        public int Wealth
        {
            get { return _wealth; }
            set { _wealth = value; OnPropertyChanged(nameof(_wealth)); }
        }

        public void UpdateInventoryCategories()
        {
            Potions.Clear();
            Treasures.Clear();
            Weapons.Clear();
            Allies.Clear();
            foreach(var GameItem in _inventory)
            {
                if (GameItem.GameItem is Potion) Potions.Add(GameItem);
                if (GameItem.GameItem is Treasure) Treasures.Add(GameItem);
                if (GameItem.GameItem is Weapon) Weapons.Add(GameItem);
                if (GameItem.GameItem is Allies) Allies.Add(GameItem);

            }
        }


        public void calculatewealth()
        {
            Wealth = _inventory.Sum(i => i.GameItem.Value * i.Quantity);
        }

        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.id == selectedGameItemQuantity.GameItem.id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventoryCategories();
        }

        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.id == selectedGameItemQuantity.GameItem.id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventoryCategories();
        }
        public bool HasVisited(Location location)
        {
            return _locationVisited.Contains(location);
        }

    }
}
