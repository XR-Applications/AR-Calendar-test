using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UtilityPanelControl : MonoBehaviour
{
    [SerializeField] GameObject homeButton;
    [SerializeField] Text debugText;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            homeButton.SetActive(false);
        }
    }
    private static UtilityPanelControl instance;
    public static UtilityPanelControl Instance
    {
        get => instance;
    }    
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

   public void PrintInfo(string infoToPrint)
    {
        debugText.text = infoToPrint;
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void GoToHome()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
