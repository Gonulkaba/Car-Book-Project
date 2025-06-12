using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeatureDtos
{
    public class AssignFeatureToCarDto
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
    }
}
