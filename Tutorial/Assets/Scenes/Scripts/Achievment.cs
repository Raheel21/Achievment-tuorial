using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Achievment
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }

    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public bool Unlocked
    {
            get { return unlocked; }
            set { unlocked = value; }
    }

    public int Points
    {
            get { return points; }
            set { points = value; }
    }

    public int SpriteIndex
    {
        get { return spriteIndex; }
        set { spriteIndex = value; }
    }

    private string description;

    private bool unlocked;

    private int points;

    private int spriteIndex;

    private GameObject achievmentRef; 

    public Achievment(string name, string description, int points, int spriteIndex, GameObject achievmentRef)
    {
        this.Name = name;
        this.Description = description;
        this.Unlocked = false;
        this.Points = points;
        this.SpriteIndex = spriteIndex;
        this.achievmentRef = achievmentRef; 

    }

   

    public bool EarnAchievment()
    {


        if (!Unlocked)
        {

            achievmentRef.GetComponent<Image>().sprite = AchievmentManager.Instance.unlockedSprite; 



            Unlocked = true;
            return true; 

        }
           return false; 
    }
}
