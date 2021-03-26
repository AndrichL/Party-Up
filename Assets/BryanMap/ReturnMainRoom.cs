using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainRoom : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
      
    }

    private void Start()
    {
        StartCoroutine(ReturntoMain());
    }

    // Update is called once per frame
    IEnumerator ReturntoMain()
    {

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);

    }
}
