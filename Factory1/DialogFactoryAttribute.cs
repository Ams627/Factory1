using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory1
{
    class DialogFactoryAttribute : Attribute
    {
        private string designator;
        public DialogFactoryAttribute(string designator)
        {
            this.designator = designator;
        }

        public string Designator
        {
            get
            {
                return designator;
            }
        }

    }
}
