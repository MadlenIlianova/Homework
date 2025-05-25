using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfrastructure
{
    public interface ICsvFileReader
    {
        public List<Model> GetData();
    }
}
