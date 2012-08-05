using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFoodGame.Framework
{
    public class User
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Name;
        }
        
        #endregion
    }
}
