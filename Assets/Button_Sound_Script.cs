using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Sound_Script : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip EnterSound;
    public AudioClip clickSound;
    // Start is called before the first frame update
    
    
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    public void EnterSound_Button()
    {
        Audio.PlayOneShot(EnterSound);
    }
    public void clickSound_Button()
    {
        Audio.PlayOneShot(clickSound);
    }
}
