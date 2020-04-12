using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBA2_Quest_Logger
{
    public class LBA2Quest
    {
        public string name;
        public uint memoryOffset;
        public ushort size; //Number of bytes needed to store value
        public Subquest[] subquests;

        public LBA2Quest() { }
        public LBA2Quest(string name, uint memoryOffset, ushort size, Subquest[] sq)
        {
            this.name = name;
            this.memoryOffset = memoryOffset;
            this.size = size;
            this.subquests = sq;
        }
        public override string ToString()
        {
            return name;
        }

        public class Subquest
        {
            public string name;
            public ushort value;

            public override string ToString()
            {
                return name;
            }
            public Subquest()
            {
            }
            public Subquest(string name, ushort value)
            {
                this.name = name;
                this.value = value;
            }
        }
    }
}
