namespace Application.Services
{
    public class BookDto
    {
        public BookDto()
        {
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public int BookNumber { get; set; }
    }
}