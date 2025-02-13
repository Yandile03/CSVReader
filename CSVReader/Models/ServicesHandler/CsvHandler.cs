using static System.Formats.Asn1.AsnWriter;

namespace CSVReader.Models.ServicesHandler
{
    public class CsvHandler
    {


        public static List<DataScores> ParseCsv(string filePath)
        {
            var scores = new List<DataScores>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out int marks))
                {
                    scores.Add(new DataScores { Name = parts[0].Trim(), Mark = marks });
                }
            }
            return scores;
        }
    }
}
