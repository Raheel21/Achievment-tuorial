using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class AchievmentButton : MonoBehaviour { 

    public GameObject achievmentList;

    public Sprite neutral, highlight;

    private Image sprite;

    void Awake()
    {
        sprite = GetComponent<Image>(); 
        
    }


    public void Click()
    {
        if (sprite.sprite == neutral)
        {
            sprite.sprite = highlight;
            achievmentList.SetActive(true); 

        }
        else
        {
            sprite.sprite = neutral;
            achievmentList.SetActive(false); 



        }


    }





}