using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace MovieInfrastructure.Convert
{
    public class ReleaseYearConvert : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var yearPart = text.Trim();
            if (text.Contains("-"))
            {
                yearPart = text.Split('-')[0];
            }
            if (int.TryParse(yearPart, out int year))
            {
                return year;
            }
            else
            {
                return 0;
            }

        }
    }
}