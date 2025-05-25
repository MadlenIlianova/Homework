using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfrastructure
{
    public class CsvFileReader : ICsvFileReader
    {
        public List<Model> GetData()
        {
            using (var reader = new StreamReader(GlobalParameters.GlobalParameter.FileDir))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) 
            {
                csv.Context.RegisterClassMap<ModelClassMap>();
                var records = csv.GetRecords<Model>() //съдържа всички записи от файла
                    .Where(movies => !string.IsNullOrWhiteSpace(movies.MovieName))
                    .ToList();
                return records;
            }
               
        }
    }
}
