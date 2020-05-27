using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class AchievmentManager : MonoBehaviour
{
    public GameObject achivementPrefab;  //This is used to reference the achievment prefab

    public Sprite[] sprites; //This is used to make a sprite array 

    private AchievmentButton activeButton;

    public ScrollRect scrollRect;

    public GameObject achievmentMenu;

    public GameObject visualAchievment;

    public Dictionary<string, Achievment> achievments = new Dictionary<string, Achievment>();

    public Sprite unlockedSprite;

    private static AchievmentManager instance;

    public static AchievmentManager Instance
    {
        get
        {
            if (instance == null)
            {

                instance = GameObject.FindObjectOfType<AchievmentManager>();
            }
            return AchievmentManager.instance; 

        }

    }






    // Start is called before the first frame update
    void Start()
    {
        activeButton = GameObject.Find("GeneralBtn").GetComponent<AchievmentButton>();
        CreateAchievment("General", "Press W", "Press W to unlock this achievment", 5, 0); //This will create a new achievment on the general category along with a title and description with a number value that represents points then another value that represents the sprite position      

        foreach (GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievmentList"))
        {
            achievmentList.SetActive(false);

        }
  
        activeButton.Click();

        achievmentMenu.SetActive(false); 
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            achievmentMenu.SetActive(!achievmentMenu.activeSelf); 

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            EarnAchievment("Press W"); 
        }













    }


    public void EarnAchievment(string title)
    {

        if (achievments[title].EarnAchievment())
        {
            GameObject achievment = (GameObject)Instantiate(visualAchievment);
            SetAchievmentInfo("EarnCanvas", achievment, title); 
            StartCoroutine(HideAchievment(achievment)); 
        }
    }

    public IEnumerator HideAchievment(GameObject achievment)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievment); 
    }







    public void CreateAchievment(string parent, string title, string description, int points, int spriteIndex) //This will be a function to make a string category to put the achievment under and to find the parent along with adding the title description and points for the achievment 
    {
        GameObject achievment = (GameObject)Instantiate(achivementPrefab); //This will be making a new achievment  

        Achievment newAchievment = new Achievment(name, description, points, spriteIndex,achievment);

        achievments.Add(title, newAchievment);   

        SetAchievmentInfo(parent, achievment, title); //For this im adding the category with the title description and points from the achievment info function 


    }                     


    public void SetAchievmentInfo(string parent, GameObject achievment, string title) //This is addeding the category as well as achievment game object with title description and points to this function
    {
       achievment.transform.SetParent(GameObject.Find(parent).transform);//This will be setting the achievment to a set parent then it will be find a game object then put it in the category which will then set the transform of the category of the achievment  
       achievment.transform.localScale = new Vector3(1, 1, 1);//This is setting a new scale for my game object achievment
       achievment.transform.GetChild(0).GetComponent<Text>().text = title;//This is getting the child from the achievment along with the text component from unity for the child which is called title 
       achievment.transform.GetChild(1).GetComponent<Text>().text = achievments[title].Description;//This is getting the next child from the achievment gameobject along with the text component from unity for the child which is called description 
       achievment.transform.GetChild(2).GetComponent<Text>().text = achievments[title].Points.ToString();//This is getting the next child from the achievment gameobject along with the text component from unity and changing it to string as it will have a number value for the child which is called points
       achievment.transform.GetChild(3).GetComponent<Image>().sprite = sprites[achievments[title].SpriteIndex];//This is getting the next child from the achievment gameobject along with the image component from unity and changing it to the sprite index which
    }

    public void ChangeCategory(GameObject button)
    {
        AchievmentButton achievmentButton = button.GetComponent<AchievmentButton>();

        scrollRect.content = achievmentButton.achievmentList.GetComponent<RectTransform>();

        achievmentButton.Click();
        activeButton.Click();
        activeButton = achievmentButton; 


    }








}
