using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{

    private AudioSource audio1;
    public Slider volumeslider;
    public GameObject cross;

    public static bool click = true;

    //public AudioSource goatAudio;
    //public AudioSource TigerAudio;musicVolume
    //public AudioSource GameoverAudio;

    public static float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //audio1 = GetComponent<AudioSource>();
        //goatAudio = GetComponent<AudioSource>();
        //TigerAudio = GetComponent<AudioSource>();
        //GameoverAudio = GetComponent<AudioSource>();

        if (click == false)
        {

            cross.SetActive(true);

        }
        else {

            cross.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //audio1.volume = musicVolume;
        //goatAudio.volume = musicVolume;
        //TigerAudio.volume = musicVolume;
        //GameoverAudio.volume = musicVolume;

        musicVolume = volumeslider.value;
    }

    public void OnOff()
    {
        if (click == true)
        {

            click = false;


            cross.SetActive(true);
            Debug.Log(click);
            Debug.Log(".... Music is OFF ....");
        }
        else {

            click = true;
            cross.SetActive(false);
             Debug.Log(click);
            Debug.Log(".... Music is On ...");
        }
    
    }
    public void setvolume(float vol) {

        musicVolume = vol;
    
    }
}
