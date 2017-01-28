using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeamRules
{
    class GameObject
    {
        private Image image;
        private Point location;

        public Image DisplayImage
        {
            get { return image; }
            set { image = value; }
        }
      
        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
