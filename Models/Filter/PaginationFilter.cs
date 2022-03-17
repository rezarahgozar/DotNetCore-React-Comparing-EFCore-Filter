namespace DotNet5.Models.Filter
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = (pageNumber < 1 || pageNumber == 0) ? 1 : pageNumber;
            this.PageSize = (pageSize > 20 || pageSize == 0) ? 20 : pageSize;
        }
    }
}