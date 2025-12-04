using System;
using System.Collections.Generic;
using System.Text;

namespace Acme_Courses;

public class Elev
{
    public int ID { get; set; }
    public int UtbildningsID { get; set; }
    public string? Förnamn { get; set; }
    public string? Efternamn { get; set; }
    public int KontaktUppgiftID { get; set; }
    public Utbildning? Utbildning { get; set; }
    public List<Utbildning> Utbildningar { get; set; } = new();
}
