using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public abstract class Character :ObservableObject
    {

        public string _name;
        public int _id,/* _health, _lives, _experiencePoints,*/ _locationid;
        public enum House
        {
            Stark,
            Targaryan,
            Lannister,
            Tyrell,
            Baratheon
        }
        public Character()
        {

        }
        public Character(int id, string name, int locationid)
        {
            _id = id;
            _name = name;
            _locationid = locationid;

        }
        public abstract void functionAbstract();
        public virtual void functionVirtual()
        {

        }


    }
}
