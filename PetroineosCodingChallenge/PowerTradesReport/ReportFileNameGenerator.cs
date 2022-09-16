namespace PowerTradesReport
{
    public class ReportFileNameGenerator
    {
        public static string GenerateFileName(string basePath, DateTime extractDateTime)
        {
            string csvFileName = $"PowerPosition_{extractDateTime:yyyyMMdd}_{extractDateTime:HHmm}.csv";
            return Path.Combine(basePath, csvFileName);
        }
    }
}
