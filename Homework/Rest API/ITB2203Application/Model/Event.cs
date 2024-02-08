namespace ITB2203Application.Model
{
    public class Event
    {
        public int Id { get; set; }
        public int SpeakerId { get; set; }
        public string Name { get; }
        DateTime Date { get; set; }
        public string Location { get; set; }
    }
}
