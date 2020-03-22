using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.PersonLib
{
    class Person : IPerson
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
