using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionsDropdown;
    private Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        
        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }
        
        resolutionsDropdown.AddOptions(options);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetResolution(int resolution)
    {
        QualitySettings.SetQualityLevel(resolution);
    }
}
