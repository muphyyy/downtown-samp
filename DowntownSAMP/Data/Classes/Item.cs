using System;
using System.Collections.Generic;
using System.Text;

namespace DowntownSAMP.Data.Classes
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public int objectid { get; set; }
        public int type { get; set; }
        public double peso { get; set; }

        public Item(int iditem, string nameitem, int objiditem, int typeitem, double pesoitem)
        {
            id = iditem;
            name = nameitem;
            objectid = objiditem;
            type = typeitem;
            peso = pesoitem;
        }
    }
}
