using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfrastructure.Convert
{
    public class GrossConvert : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text) || text == "NA")  //$134.3M
            {
                return 0.0;
            }
            text = text.Trim().Replace("$", "");
            double multiplier = 1.0;
            if (text.EndsWith("M")) 
            {
                text=text.Replace("M", "");  //134.6
            }
            if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                multiplier = 1_000_000;
                return multiplier * value; //134 600 000
            }
            else return 0.0;
        }
    }
}
