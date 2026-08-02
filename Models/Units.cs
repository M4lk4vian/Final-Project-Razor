using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Units
    {
       public int UnitId {  get; set; }
       public string UnitName { get; set; }
        
       public Units() { }
       public Units(int unitId, string UnitName)
       {
            this.UnitId = unitId;
            this.UnitName = UnitName;
       }
    }
}
