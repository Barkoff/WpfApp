using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
   public interface IDetail
    {
         double Weight { get; set; }
         string Name { get; set; }

         string NativeName { get; set; }
        int DetailNumber { get; set; }
    }
}
