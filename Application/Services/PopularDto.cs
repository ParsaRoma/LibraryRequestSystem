namespace Application.Services
{
    public class PopularDto
    {
        public PopularDto()
        {
        }

        public int UserId { get; set; }
        public int BookReadingCount { get; set; }
        public int BookReadCount { get; set; }
    }
}