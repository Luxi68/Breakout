using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Achievements
{
    public string ID { get; private set; }

    public Achievements(string ID)
    {
        this.ID = ID;
    }
}
