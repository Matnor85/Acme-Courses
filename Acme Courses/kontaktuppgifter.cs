using System;
using System.Collections.Generic;
using System.Text;

namespace Acme_Courses;

public class KontaktUppgift
{
    public int ID { get; set; }
    public string KontaktTyp { get; set; } = null!;
    public string KontaktInfo { get; set; } = null!;
    public int ElevID { get; set; }
}
