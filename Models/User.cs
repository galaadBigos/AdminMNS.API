namespace AdminMNS.API.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public DateTime Birthday { get; set; }
		public string Password { get; set; }
		public string MailAddress { get; set; }
		public string WayNumber { get; set; }
		public string WayType { get; set; }
		public string WayName { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public bool IsValidRegistration { get; set; }
		public int IdUserStatus { get; set; }
		public int IdGraduatingClass { get; set; }
	}
}
