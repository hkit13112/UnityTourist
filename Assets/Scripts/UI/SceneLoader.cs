using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void sceneLoader(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Quit()
    {        
        Application.Quit();
    }
 }
