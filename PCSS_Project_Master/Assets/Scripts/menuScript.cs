using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Canvas menuName;
    public Canvas menuTop;
    public Canvas menuExit;

    public InputField userNameInput;
    
    public Button buttonCreate;
    public Button buttonJoin;
    public Button buttonExit;

    public Text charText;
    public string charName;
    public Text welcomeName;


    void Start () {

        menuName = menuName.GetComponent<Canvas>();
        menuTop = menuTop.GetComponent<Canvas>();
        menuExit = menuExit.GetComponent<Canvas>();

        buttonCreate = buttonCreate.GetComponent<Button>();
        buttonJoin = buttonJoin.GetComponent<Button>();
        buttonExit = buttonExit.GetComponent<Button>();
        charText = GameObject.Find("CharText").GetComponent<Text>();

        menuName.enabled = true;
        menuTop.enabled = false;
        menuExit.enabled = false;

    }



    //FUNCTIONS ON NAME MENU
    
    public void ConfirmAndSaveName()
    {

        if (charText.text.Length >= 4)
        {
            Debug.Log("Confirmed Player Name");
            charName = userNameInput.GetComponentInChildren<InputField>().text;
            menuName.enabled = false;
            menuTop.enabled = true;
            welcomeName.GetComponentInChildren<Text>().text = "Welcome " + charName + " !";
        }
        else {
            Debug.Log("Please Enter a Name or Increase Name Size");
        }
    }

    public void CharacterField(string inputFieldString)
    {
        charText.text = inputFieldString;
    }



    // FUNCTIONS ON MAIN MENU

    /* public void menuCreateServer()
{
   //Enter Server Name
}
    */

     public void menuJoinServer()
    {
        //Click button Join
        //Click button Back
        //Click button Manual Search
		Application.LoadLevel("PCSS");
    } 

    public void ExitPress()
    {
        menuExit.enabled = true;
        buttonCreate.enabled = false;
        buttonJoin.enabled = false;
        buttonExit.enabled = false;
    }
     


    // FUNCTIONS ON EXIT MENU
    
    public void NoPress()
    {
        menuExit.enabled = false;
        buttonCreate.enabled = true;
        buttonJoin.enabled = true;
        buttonExit.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    

    //Update for tests

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.F1))
            print(charName);
    }
}
