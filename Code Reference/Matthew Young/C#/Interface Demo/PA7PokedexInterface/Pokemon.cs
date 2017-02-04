using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA7_Young_John
{
    class Pokemon : ICloneable, IDisplayable
    {
        private string _name;
        private int _hp;
        private string _type;

        public Pokemon() { }

        public Pokemon(string name, int hp, string type)
        {
            this._name = name;
            this._hp = hp;
            this._type = type;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int HP
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public Pokemon Clone()
        {
            Pokemon p = new Pokemon();
            p.HP = this.HP;
            p.Name = this.Name;
            p.Type = this.Type;
            return p;
        }

        public string GetDisplay(String sep)
        {
            return this.Name + sep + this.HP + sep + this.Type;
        }
    }
}
