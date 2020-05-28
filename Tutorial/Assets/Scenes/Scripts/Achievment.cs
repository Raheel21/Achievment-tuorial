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

    public string Child
    {
        get { return child; }
        set { child = value; }


    }

    private string description;

    private bool unlocked;

    private int points;

    private int spriteIndex;

    private GameObject achievmentRef;

    private List<Achievment> dependencies = new List<Achievment>();

    private string child;

    public Achievment(string name, string description, int points, int spriteIndex, GameObject achievmentRef)
    {
        this.Name = name;
        this.Description = description;
        this.Unlocked = false;
        this.Points = points;
        this.SpriteIndex = spriteIndex;
        this.achievmentRef = achievmentRef;
        LoadAchievment(); 

    }

    public void AddDependency(Achievment dependendency)
    {
        dependencies.Add(dependendency);

    }


      public bool EarnAchievment()
    {


        if (!Unlocked && !dependencies.Exists(x => x.unlocked == false))
        {
            achievmentRef.GetComponent<Image>().sprite = AchievmentManager.Instance.unlockedSprite; 
            SaveAchievment(true);

            if (child != null)
            {
                AchievmentManager.Instance.EarnAchievment(child);

            }
            return true; 
        }

           return false;  
    }


    public void SaveAchievment(bool value)
    {
        unlocked = value;

        int tmpPoints = PlayerPrefs.GetInt("Points");

        PlayerPrefs.SetInt("Points", tmpPoints += points);

        PlayerPrefs.SetInt(name, value ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void LoadAchievment()
    {
        unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;

        if (unlocked)
        {
            AchievmentManager.Instance.textPoints.text = "Points: " + PlayerPrefs.GetInt("Points");
            achievmentRef.GetComponent<Image>().sprite = AchievmentManager.Instance.unlockedSprite;

        }





    }



















}
