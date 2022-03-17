using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotNet5.Models.Filter
{
    public class BigDataFilter
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("col1")]
        public string Col1 { get; set; }

        [JsonPropertyName("col2")]
        public string Col2 { get; set; }

        [JsonPropertyName("col3")]
        public string Col3 { get; set; }

        [JsonPropertyName("col4")]
        public string Col4 { get; set; }

        [JsonPropertyName("col5")]
        public string Col5 { get; set; }

        [JsonPropertyName("col6")]
        public string Col6 { get; set; }

        [JsonPropertyName("col7")]
        public string Col7 { get; set; }

        [JsonPropertyName("col8")]
        public string Col8 { get; set; }

        [JsonPropertyName("col9")]
        public string Col9 { get; set; }

        [JsonPropertyName("col10")]
        public string Col10 { get; set; }

        [JsonPropertyName("dataGridParameters")]
        public PaginationFilter PaginationParameters { get; set; }
        [JsonPropertyName("dataGridSort")]
        public SortPaggedRequest SortParameters { get; set; }
    }

    public class PaggedRequest
    {
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public SortPaggedRequest DataGridSort { get; set; }
        public int RowCount { get; set; }
        public Dictionary<string, string> Filter { get; set; }

    }
    public class SortPaggedRequest
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }
        [JsonPropertyName("sort")]
        public string Sort { get; set; }
    }

}