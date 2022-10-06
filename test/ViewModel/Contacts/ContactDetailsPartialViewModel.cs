namespace test.ViewModel.Contacts
{
    public class ContactDetailsPartialViewModel
    {
        public int ContactId { get; set; }
        public string ContactFirstName { get; set; } = default!;
        public string? ContactLastName { get; set; }
        public string? ContactAdress { get; set; }
    }
}
