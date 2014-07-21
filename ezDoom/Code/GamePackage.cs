using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ezDoom.Code
{
    public class GamePackage
    {
        public string FullName
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                int num = this.FullName.LastIndexOf('.');
                int count = this.FullName.Length - num;
                return this.FullName.Remove(this.FullName.LastIndexOf('.'), count);
            }
        }
    }
}
