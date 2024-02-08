using System.ComponentModel.DataAnnotations;

namespace ITB2203Application.Model;

public class Test
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class Speaker
{
    [Key]
    public int Id_Name { get; set; }
    public string? Email { get; set; }
}

public class Event
{
    public int Id { get; set; }
    public int SpeakerId { get; set; }
    public string Name { get;}
    DateTime Date { get; set; }
    public string Location { get; set; }
}
public class Attendee
{
    public int Id { get; set; }
    public int EverntId { get; set; }
    public string Name { get; }
    public string Email { get; set; }
    DateTime Registration_Time { get; set; }
}
