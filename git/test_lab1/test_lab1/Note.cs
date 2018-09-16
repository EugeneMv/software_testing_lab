using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_lab1
{
    class Note 
    { 
        private int value;
        public int Value {
            get { return value; }
            private set { }
        }

        public Note(int value)
        {
            if (value < 0)
                value = 0;
            else if (value > 10) 
                value = 10;

            this.value = value;
        }
    }  
}
