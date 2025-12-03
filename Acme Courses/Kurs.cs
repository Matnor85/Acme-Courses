using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;
using System.Text;

namespace Acme_Courses;

public class Kurs
{
    public int ID { get; set; }
    public int UtbildningID { get; set; }
    public string? Namn { get; set; }
    public string? Beskrivning { get; set; }
    public DateTime StartDatum { get; set; }
    public DateTime SlutDatum { get; set; }
}
