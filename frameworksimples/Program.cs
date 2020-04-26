using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frameworksimples
{
    static class Program
    {
       
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
     
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
          
        }
        
    }
}
