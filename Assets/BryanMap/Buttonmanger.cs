using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Buttonmanger : MonoBehaviour
{
    [SerializeField] GameObject Mainmenu;
    [SerializeField] GameObject Settings;
   

  


    public void Gosettings()
    {
        Mainmenu.SetActive(false);
        Settings.SetActive(true);
    }

    public void GoToMain()
    {
        Mainmenu.SetActive(true);
        Settings.SetActive(false);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void GoToNameInput()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
