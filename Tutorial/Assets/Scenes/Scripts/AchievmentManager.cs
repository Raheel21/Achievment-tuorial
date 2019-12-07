using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievmentManager : MonoBehaviour
{
    public GameObject achivementPrefab;  //This is used to reference the achievment prefab

    // Start is called before the first frame update
    void Start()
    {
        CreateAchievment("General"); //This will create a new achievment on the general category        
    }

    // Update is called once per frame
    void Update() { }

    public void CreateAchievment(string category) //This will be a function to make a string category to put the achievment under and to find the parent
    {
        GameObject achievment = (GameObject)Instantiate(achivementPrefab); //This will be making a new achievment  
        SetAchievmentInfo(category, achievment); //For this im adding the category as well as the achievment to the achievment info


    }                     


    public void SetAchievmentInfo(string category, GameObject achievment) //This is addeding the category as well as achievment game object to this function
    {
       achievment.transform.SetParent(GameObject.Find(category).transform);//This will be setting the achievment to a set parent then it will be find a game object then put it in the category which will then set the transform of the category of the achievment  
       achievment.transform.localScale = new Vector3(1, 1, 1); //This is setting a new scale for my game object achievment  


    }




}
