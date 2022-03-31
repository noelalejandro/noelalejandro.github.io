using System;
using System.Collections.Generic;
using System.Text;

namespace BananaManor
{
    class Player
    {
        public bool HasCarKeys { get; set; }
        public bool HasCake { get; set; }
        public bool HasBananas { get; set; }
        public bool HasCD { get; set; }

        public Player()
        {
            HasCarKeys = false;
            HasCake = false;
            HasBananas = false;
            HasCD = false;
        }

        public void PickUpCarKeys()
        {
            HasCarKeys = true;
        }

        public void PickUpCake()
        {
            HasCake = true;
        }

        public void PickUpBananas()
        {
            HasBananas = true;
        }

        public void PickUpCD()
        {
            HasCD = true;
        }
    }
}
