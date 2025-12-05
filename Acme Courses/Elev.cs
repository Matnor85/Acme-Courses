using System;
using System.Collections.Generic;
using System.Text;

namespace Acme_Courses;

public class Elev
{
    public int ID { get; set; }
    
    public string? Förnamn { get; set; }
    public string? Efternamn { get; set; }
    public List<KontaktUppgift> KontaktUppgifter { get; set; } = new List<KontaktUppgift>();
    public List<Utbildning> Utbildningar { get; set; } = new List<Utbildning>();
}