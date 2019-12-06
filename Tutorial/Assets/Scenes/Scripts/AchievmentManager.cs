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
    void Update() {
        
    }

    public void CreateAchievment(string category) //This will be a function to make a string category to put the achievment under and to find the parent
    {
        GameObject achievment = (GameObject)Instantiate(achivementPrefab); //This will be making a new achievment  
        SetAchievmentInfo(category, achievment); 


    }                     


    public void SetAchievmentInfo(string category, GameObject achievment) 
    {
        achievment.transform.SetParent(GameObject.Find(category).transform); 

        
    }




}
