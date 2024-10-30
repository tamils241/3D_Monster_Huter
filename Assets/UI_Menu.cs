using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour

{
    // Method to load a scene based on the scene's index. 
    // Consider using scene names (string) instead of IDs for safety.
    public void PlayButton(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    // Method to exit the application.
    public void ExitButton()
    {
        // Quits the application if running in a build. Will not work in the Editor.
        Application.Quit();
        
        // Logs a message in the console when in the Editor mode for debugging.
        #if UNITY_EDITOR
            Debug.Log("Exit button pressed. Application.Quit() won't work in the editor.");
        #endif
    }
}
