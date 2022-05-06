using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Achievement
{
    public int id { get; private set; }
    public string description { get; private set; }

    public Achievement(int id, string description)
    {
        this.id = id;
        this.description = description;
    }
}
