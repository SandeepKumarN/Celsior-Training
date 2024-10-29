using OfficeOpenXml;
using System;
using System.IO;

namespace ExcelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\sandeep.kumar\\Documents\\Customers.xlsx";

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("The specified file does not exist.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    Console.WriteLine("Customer Data:");
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("ID\tName\t\tDOB\tPhone\t\tEmail");
                    Console.WriteLine("------------------------------------------------------------------");

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var ID = worksheet.Cells[row, 1].Text;
                        var Name = worksheet.Cells[row, 2].Text;
                        var DOB = worksheet.Cells[row, 3].Text;
                        var Phone = worksheet.Cells[row, 4].Text;
                        var Email = worksheet.Cells[row, 5].Text;

                        Console.WriteLine($"{ID}\t{Name}\t{DOB}\t{Phone}\t{Email}");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
