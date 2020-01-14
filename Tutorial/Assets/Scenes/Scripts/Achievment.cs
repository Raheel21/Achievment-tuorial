using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievment
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }

    }

    private string description;

    private bool unlocked;

    private int points;

    private int spriteIndex;

    private GameObject achievmentRef; 

    public Achievment(string name, string description, int points, int spriteIndex, GameObject achievmentRef)
    {
        this.Name = name;
        this.description = description;
        this.unlocked = false;
        this.points = points;
        this.spriteIndex = spriteIndex;
        this.achievmentRef = achievmentRef; 

    }

   

    public bool EarnAchievment()
    {


        if (!unlocked)
        {

            unlocked = true;
            return true; 

        }
           return false; 
    }
}
