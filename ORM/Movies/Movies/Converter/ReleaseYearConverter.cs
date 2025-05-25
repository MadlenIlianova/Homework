using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Converter
{
    public class ReleaseYearConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }
            var year = text.Split('-')[0];

            if (int.TryParse(year, out int currentYear))
            {
                return currentYear;
            }
            return 0;
        }
    }
}
