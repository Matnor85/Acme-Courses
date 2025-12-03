using System;
using System.Collections.Generic;
using System.Text;

namespace Acme_Courses;

public class kontaktuppgift
{
    public int ID { get; set; }
    public string KontaktTyp { get; set; } = null!;
    public string KontaktUppgift { get; set; } = null!;
    public int ElevID{ get; set; }
}
