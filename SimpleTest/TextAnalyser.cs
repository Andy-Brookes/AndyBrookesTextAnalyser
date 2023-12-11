//simple test

//Test 

namespace Domain
{
    public class TextAnalyser : ITextAnalyser
    {
        private readonly ILogger _logger;

        public TextAnalyser(ILogger logger)
        {
            _logger = logger;
        }

        public string SortWordsAlphabetically(string someInput)
        {
            if (string.IsNullOrWhiteSpace(someInput))
            {
                _logger.Error("Something bad happened");
                throw new ArgumentException("Invalid data");
            }

            _logger.Log("start CalculateTotal");

            var words = someInput
                .Split(new string[] { " ", ".", ",", ";" }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(word => word, StringComparer.OrdinalIgnoreCase)
                .ThenBy(word => word, StringComparer.Ordinal);

            _logger.Log("end CalculateTotal");
            return string.Join(" ", words);
        }
    }
}
