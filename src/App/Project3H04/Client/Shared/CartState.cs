using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Client.Shared
{
    public class CartState
    {
        public List<Kunstwerk_DTO.Detail> Cart { get; set; } = new List<Kunstwerk_DTO.Detail>();
        public decimal TotalePrijs => Cart.Sum(c => c.Prijs);

    public List<Kunstwerk_DTO.Detail> GetCart()
        {
            return Cart.Distinct().OrderBy(x => x.Naam).ToList();
        }
        public void AddKunstwerk(Kunstwerk_DTO.Detail kunstwerk)
        {
            Cart.Add(kunstwerk);
        }

        public void RemoveKunstwerk(Kunstwerk_DTO.Detail kunstwerk)
        {
            Cart.Remove(kunstwerk);
        }

        //checken op ID, anders ga niet !!!
        //public bool CheckCartItem(Kunstwerk_DTO.Detail kunstwerk)
        //{
        //    bool kek = Cart.Contains(kunstwerk);
        //    return kek;
        //}

        public bool CheckCartItem(int id)
        {
            //=>zoeken op id, want op hans object vind hij niet/GA NIET !!!
            return Cart.SingleOrDefault(x => x.Id == id) != null ? true : false;
        }

/*        public decimal TotalPrice()
        {
            
        }*/

    }
}
