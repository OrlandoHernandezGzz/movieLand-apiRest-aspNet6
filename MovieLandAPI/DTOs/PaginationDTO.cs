namespace MovieLandAPI.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;

        private int numberOfRecordsPerPage = 10;

        private readonly int maxRecordsPerPage = 50; 

        public int NumberOfRecordsPerPage
        {
            get => numberOfRecordsPerPage;

            set
            {
                numberOfRecordsPerPage = (value > maxRecordsPerPage) ? maxRecordsPerPage : value;
            }
        }

    }
}
