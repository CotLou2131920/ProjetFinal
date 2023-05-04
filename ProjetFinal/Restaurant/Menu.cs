using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    partial class Menu
    {
        int maxPlats { get; set; }
        public List<Plats> platsDispo { get; set; }
         public List<Plats> platsMenu { get ; set; }

        public Menu(List<Plats> platsDepart,int max = 4)
        {
            maxPlats = max;
            platsDispo = new List<Plats>();
            platsMenu = new List<Plats>();
            InitailizeList(platsDepart);
        }
        public void InitailizeList(List<Plats> plats)
        {
            for(int i = 0; i < plats.Count; i++)
            {
                platsDispo.Add(plats[i]);
            }
            for (int i = 0; i < plats.Count; i++)
            {
                platsMenu.Add(plats[i]);
            }
        }


    }
}
