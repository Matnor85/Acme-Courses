using System;
using System.Collections.Generic;
using System.Text;

namespace Acme_Courses;

public class Utbildning
{
    public int ID { get; set; }
    public string? Namn { get; set; }
    public string? Beskrivning { get; set; }

    public List<Kurs> Kurser { get; set; } = new List<Kurs>();
    public List<Elev> Elever { get; set; } = new List<Elev>();
}
