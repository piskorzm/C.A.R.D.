using System.Collections;
using System.Collections.Generic;

public abstract class Card {

    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Cost { get; private set; }
    public string ImagePath { get; private set; }

    public Card(string name, string desc, int cost, string imagePath)
    {    
        Name = name;
        Description = desc;
        Cost = cost;
        ImagePath = imagePath;
    }
}
