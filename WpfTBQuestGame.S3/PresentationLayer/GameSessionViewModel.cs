using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.PresentationLayer
{
    public class GameSessionViewModel :ObservableObject
    {
        #region FIELDS

        private Player _player;
        private Map _gameMap; 
        private Location _currentlocation;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation;
        private string _currentLocationInformation;
        private string _gameMessage;

        //  private List<string> AccessibleLocationsNames;
        private GameItemQuantity _currentGameItem;

        #endregion

        #region PROPERTIES

        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set
            {
                _currentGameItem = value;
                OnPropertyChanged(nameof(CurrentGameItem));
                if (_currentGameItem != null && _currentGameItem.GameItem is Weapon)
                {
                    _player.CurrentWeapon = _currentGameItem.GameItem as Weapon;
                }
            }
        }

        public string GameMessage
        {
            get { return _gameMessage; }
            set { _gameMessage = value; }
        }
        public string MessageDisplay
        {
            get { return _currentlocation.Message; }
        }

        public Map GameMap { get { return _gameMap; } set { _gameMap = value; } }

        public Location CurretLocation
        {
            get { return _currentlocation; }
            set
            {
                _currentlocation = value;
                _currentLocationInformation = _currentlocation.description;
                OnPropertyChanged(nameof(CurretLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }

        public bool HasNorthLocation
        {
            get
            {
                if (NorthLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasEastLocation { get { return EastLocation != null; } }
        public bool HasSouthLocation { get { return SouthLocation != null; } }
        public bool HasWestLocation { get { return WestLocation != null; } }


        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public string CurrentLocationName
        {
            get { return _currentlocation.name; }
            set { _currentlocation.name = value; }
        }

        public ObservableCollection<Location> AccessibleLocations
        { get { return _gameMap.AccessibleLocations; } }

        public List<string> AccessibleLocationsnames
        { get { return _gameMap.AccessibleLocationsNames; } }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
        

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {
            
        }

        public GameSessionViewModel(Player player,
                string initialMessages,
                Map gameMap,
                GameMapCoordinates currentLocationCoordinates
                )
        {
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentlocation = _gameMap.CurrentLocation;
            GameMessage = initialMessages;
            InitializeView();




        }
        #endregion

        #region METHODS


        private void InitializeView()
        {
            UpdateAvailableTravelPoints();
            _currentLocationInformation = CurretLocation.description;
            _player.UpdateInventoryCategories();
            _player.calculatewealth();
        }


        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentlocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentlocation.RemoveGameItemQuantityFromLocation(selectedGameItemQuantity);
                _player.AddGameItemQuantityToInventory(selectedGameItemQuantity);

                OnPlayerPickUp(selectedGameItemQuantity);
            }
        }
        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected and is in inventory
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentlocation.AddGameItemQuantityToLocation(selectedGameItemQuantity);
                _player.RemoveGameItemQuantityFromInventory(selectedGameItemQuantity);

                OnPlayerPutDown(selectedGameItemQuantity);
            }
        }

        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
            _player.ExperiencePoints += gameItemQuantity.GameItem.ExperiencePoints;
            _player.Wealth += gameItemQuantity.GameItem.Value;
        }

        private void OnPlayerPutDown(GameItemQuantity gameItemQuantity)
        {
            _player.Wealth -= gameItemQuantity.GameItem.Value;
        }




        public void OnUseGameItem()
        {
           

            if(_currentGameItem is Potion )
            {
                //ProcessPotionUse(potion);
            }
            else if(_currentGameItem is Allies)
            {
               // ProcessRelicUse(relic);
            }           
        }

        private void processrelicuse(Allies allies)
        {
            //string message;
            //switch (relic.useaction)
            //{
            //    case allies.useactiontype.openlocation:
            //        message = _gamemap.openlocationbyrelic(relic.id);
            //        currentlocationname = relic.usemessage;
            //        break;
            //    case allies.useactiontype.killplayer:
            //        playerdies(relic.usemessage);
            //        break;
            //    default:
            //        break;
            //}
        }

        private void PlayerDies(string message)
        {
            string messagetext = message + "\n\n Would you like to play again ";
            string titleText = "Death";

            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuiteApplication();
                    break;
            }
        }

        public void QuiteApplication()
        {
           Application.Current.Shutdown();
        }

        public void ResetPlayer()
        {
            Environment.Exit(0);

         
        }
    

        private void ProcessPotionUse(Potion potion)
        {
            _player.Health += potion.HealthChange;
            _player.Lives += potion.LivesChange;
            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
        }


        private void UpdateAvailableTravelPoints()
        {
            //
            // reset travel location information
            //
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            //
            // north location exists
            //
            if (_gameMap.NorthLocation() != null)
            {
                Location nextNorthLocation = _gameMap.NorthLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextNorthLocation.accessible == true || PlayerCanAccessLocation(nextNorthLocation))
                {
                    NorthLocation = nextNorthLocation;
                }
            }

            //
            // east location exists
            //
            if (_gameMap.EastLocation() != null)
            {
                Location nextEastLocation = _gameMap.EastLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextEastLocation.accessible == true || PlayerCanAccessLocation(nextEastLocation))
                {
                    EastLocation = nextEastLocation;
                }
            }

            //
            // south location exists
            //
            if (_gameMap.SouthLocation() != null)
            {
                Location nextSouthLocation = _gameMap.SouthLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextSouthLocation.accessible == true || PlayerCanAccessLocation(nextSouthLocation))
                {
                    SouthLocation = nextSouthLocation;
                }
            }

            //
            // west location exists
            //
            if (_gameMap.WestLocation() != null)
            {
                Location nextWestLocation = _gameMap.WestLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextWestLocation.accessible == true || PlayerCanAccessLocation(nextWestLocation))
                {
                    WestLocation = nextWestLocation;
                }
            }
        }

        private bool PlayerCanAccessLocation(Location nextLocation)
        {
            //
            // check access by experience points
            //
            if (nextLocation.IsAccessibleByExperiencePoints(_player.ExperiencePoints))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnPlayerMove()
        {
            //
            // update player stats when in new location
            //
            if (!_player.HasVisited(_currentlocation))
            {
                //
                // add location to list of visited locations
                //
                _player.LocationsVisited.Add(_currentlocation);

                // 
                // update experience points
                //
                _player.ExperiencePoints += _currentlocation.modifyExperientsPoints;

                //
                // update health
                //
                _player.Health += _currentlocation.ModifyHealth;

                //
                // update lives
                //
                _player.Lives += _currentlocation.modifyLives;

                //
                // display a new message if available
                //
                OnPropertyChanged(nameof(MessageDisplay));
            }
        }

        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.MoveNorth();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        /// <summary>
        /// travel east
        /// </summary>
        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        /// <summary>
        /// travel south
        /// </summary>
        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        /// <summary>
        /// travel west
        /// </summary>
        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        #endregion
    }
}
