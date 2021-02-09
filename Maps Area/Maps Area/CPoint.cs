using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps_Area
{
    public class CPoint
    {
        public double x { get; set; }
        public double y { get; set; }
        public string place { get; set; }
        public string building { get; set; }
        public string street { get; set; }
        public string town { get; set; }

        public string Image;

        public CPoint() { }
        public CPoint(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public CPoint(double _x, double _y, string _place)
        {
            x = _x;
            y = _y;
            place = _place;
        }

        public CPoint(double _x, double _y, string _building, string _street, string _town)
        {
            x = _x;
            y = _y;
            building = _building;
            street = _street;
            town = _town;
        }

        public CPoint(double _x, double _y, string _building, string _street, string _town, string _image)
        {
            x = _x;
            y = _y;
            building = _building;
            street = _street;
            town = _town;
            Image = _image;
        }
    }
}
