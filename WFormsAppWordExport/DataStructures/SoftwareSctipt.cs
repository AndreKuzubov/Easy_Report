using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormsAppWordExport.DataStructures
{
    public class SoftwareSctipt
    {
        public String script { get; private set; }

        public SoftwareSctipt (String script)
        {
            this.script = script;
        }

        public void run()
        {

        }

        public bool runBool()
        {
            return true;
        }
      
    }
}
