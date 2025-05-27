using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MovieInfrastructure.Convert
{
    public class ReleaseYearConvert : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var match = Regex.Match(text, @"\d{4}");
            if (match.Success && int.TryParse(match.Value, out int year))
            {
                return year;
            }
            return 0;
        }
    }
}