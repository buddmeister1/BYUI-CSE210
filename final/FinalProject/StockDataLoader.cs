using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProject
{
    public static class StockDataLoader
    {
        public static List<Stock> LoadStocksFromCsv(string filePath)
        {
            List<Stock> stocks = new List<Stock>();
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                List<string> fields = ParseCsvLine(line);

                string ticker = fields[0];
                string companyName = fields[1];
                string category = fields[2];
                string sector = fields[3];
                double price = Convert.ToDouble(fields[4]);
                double peRatio = ParsePeRatio(fields[5]);
                double dividendYield = Convert.ToDouble(fields[6]);
                string riskNote = fields[7];
                string momentumNote = fields[8];
                string dataConfidence = fields[9];
                DateTime asOfDate = Convert.ToDateTime(fields[10]);

                Stock stock = new Stock(companyName, ticker, sector, price, 0, DateTime.Now,
                                         peRatio, dividendYield, riskNote, momentumNote,
                                         category, dataConfidence, asOfDate);
                stocks.Add(stock);
            }

            return stocks;
        }

        private static double ParsePeRatio(string peField)
        {
            if (peField == "n/a")
            {
                return 0.0;
            }
            return Convert.ToDouble(peField);
        }

        private static List<string> ParseCsvLine(string line)
        {
            List<string> fields = new List<string>();
            bool insideQuotes = false;
            string currentField = "";

            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '"')
                {
                    insideQuotes = !insideQuotes;
                }
                else if (currentChar == ',' && !insideQuotes)
                {
                    fields.Add(currentField);
                    currentField = "";
                }
                else
                {
                    currentField += currentChar;
                }
            }
            fields.Add(currentField);

            return fields;
        }
    }
}