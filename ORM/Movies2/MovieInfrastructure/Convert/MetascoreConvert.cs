using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace MovieInfrastructure.Convert
{
    public class MetascoreConvert : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text) || text == "NA")
            {
                return 0.0;
            }
            else
            {
                return double.Parse(text,CultureInfo.InvariantCulture);
            }
        }
    }
}
