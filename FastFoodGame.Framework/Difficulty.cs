using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFoodGame.Framework
{
    public class Difficulty
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfSandwiches { get; set; }
        public int MinNumberOfSandwiches { get; set; }
        public int MaxTimeBetweenOrders { get; set; }
        public int MinTimeBetweenOrders { get; set; }

        #endregion
    }
}
