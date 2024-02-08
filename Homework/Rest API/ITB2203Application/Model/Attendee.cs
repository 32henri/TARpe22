namespace ITB2203Application.Model
{
    public class Attendee
    {
        public int Id { get; set; }
        public int EverntId { get; set; }
        public string Name { get; }
        public string Email { get; set; }
        DateTime Registration_Time { get; set; }
    }

}
