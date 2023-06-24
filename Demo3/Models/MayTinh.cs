
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo3.Models
{
    public class MayTinh
    {
        public string Mamay { get; set; }
        public string Tendongmay { get; set; }
        public double Price { get; set; }
        public DateTime NSX { get; set; }
        public string HangSX { get; set; }


        public List<MayTinh> Hienthi()
        {
            List<MayTinh> dsMayTinh = new List<MayTinh>();
            var May1 = new MayTinh();
            May1.Mamay = "12015546210";
            May1.Tendongmay = "Asus231564";
            May1.Price = 18000000;
            May1.NSX = new DateTime(2021, 09, 30);
            May1.HangSX = "Asus";
            dsMayTinh.Add(May1);


            var May2 = new MayTinh();
            May2.Mamay = "5478965521";
            May2.Tendongmay = "Dell 20x34";
            May2.Price = 25000000;
            May2.NSX = new DateTime(2022, 05, 10);
            May2.HangSX = "Dell";
            dsMayTinh.Add(May2);

            var May3 = new MayTinh();
            May3.Mamay = "0124796821";
            May3.Tendongmay = "Lenovo Legion 5";
            May3.Price = 38000000;
            May3.NSX = new DateTime(2022, 06, 05);
            May3.HangSX = "Lenovo";
            dsMayTinh.Add(May3);

            var May4 = new MayTinh();
            May4.Mamay = "9856214752";
            May4.Tendongmay = "Lenovo Legion 5 Pro";
            May4.Price = 42000000;
            May4.NSX = new DateTime(2022, 05, 30);
            May4.HangSX = "Lenovo";
            dsMayTinh.Add(May4);

            var May5 = new MayTinh();
            May5.Mamay = "0214532001";
            May5.Tendongmay = "MacBook pro14 inch";
            May5.Price = 52000000;
            May5.NSX = new DateTime(2022, 12, 30);
            May5.HangSX = "Apple";
            dsMayTinh.Add(May5);

            return dsMayTinh;
        }
    }
}
