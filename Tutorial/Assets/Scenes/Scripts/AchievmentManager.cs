using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;


public class AchievmentManager : MonoBehaviour
{
    public GameObject achivementPrefab;  //This is used to reference the achievment prefab

    // Start is called before the first frame update
    void Start()
    {
        CreateAchievment("General", "TestTitle", "This is the description", 10); //This will create a new achievment on the general category along with a title and description with a number value that represents points        
    }

    // Update is called once per frame
    void Update() { }

    public void CreateAchievment(string category, string title, string description, int points) //This will be a function to make a string category to put the achievment under and to find the parent along with adding the title description and points for the achievment 
    {
        GameObject achievment = (GameObject)Instantiate(achivementPrefab); //This will be making a new achievment  
        SetAchievmentInfo(category, achievment,title,description,points); //For this im adding the category with the title description and points from the achievment info function 


    }                     


    public void SetAchievmentInfo(string category, GameObject achievment, string title, string description, int points) //This is addeding the category as well as achievment game object with title description and points to this function
    {
       achievment.transform.SetParent(GameObject.Find(category).transform);//This will be setting the achievment to a set parent then it will be find a game object then put it in the category which will then set the transform of the category of the achievment  
       achievment.transform.localScale = new Vector3(1, 1, 1);//This is setting a new scale for my game object achievment
       achievment.transform.GetChild(0).GetComponent<Text>().text = title;//This is getting the child from the achievment along with the text component from unity for the child which is called title 
       achievment.transform.GetChild(1).GetComponent<Text>().text = description;//This is getting the next child from the achievment gameobjectt along with the text component from unity for the child which is called description 
        achievment.transform.GetChild(2).GetComponent<Text>().text = points.ToString();//This is getting the next child from the achievment gameobjectt along with the text component from unity and changing it to string as it will have a number value for the child which is called points 




    }




}
