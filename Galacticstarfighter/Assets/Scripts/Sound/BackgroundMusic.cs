//Borrowed this code from the 3D project

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip m_BackgroundMusic1;
    public AudioClip m_BackgroundMusic2;
    public AudioClip m_BackgroundMusic3;
    public AudioClip m_BackgroundMusic4;

    private List<AudioClip> backGroundMusicArray_ = new List<AudioClip>();

    private int randNum_ = 0;
    private int maxListSize = 4;

	// Use this for initialization
	void Start () 
    {
        ChooseRandomMusicTrack();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(!GetComponent<AudioSource>().isPlaying)
        {
            //if no audio or current track is done
            ChooseRandomMusicTrack();
        }
	}

    public void ChooseRandomMusicTrack()
    {
        randNum_ = Random.Range(1, 5);     //gets a number between 1 and 4
        if(randNum_ == 1)
        {
            //if the list does not have this background sound in it, then add it to it and play the music
            if(!backGroundMusicArray_.Contains(m_BackgroundMusic1))
            {
                backGroundMusicArray_.Add(m_BackgroundMusic1);
                MakeSound(m_BackgroundMusic1);
            }
            else
            {
                //call random number again so you can get a different sound file 
                randNum_ = Random.Range(1, 5);     //gets a number between 1 and 4
            }
        }
        else if(randNum_ == 2)
        {
            //if the list does not have this background sound in it, then add it to it and play the music
            if (!backGroundMusicArray_.Contains(m_BackgroundMusic2))
            {
                backGroundMusicArray_.Add(m_BackgroundMusic2);
                MakeSound(m_BackgroundMusic2);
            }
            else
            {
                //call random number again so you can get a different sound file 
                randNum_ = Random.Range(1, 5);     //gets a number between 1 and 4
            }
        }
        else if(randNum_ == 3)
        {
            //if the list does not have this background sound in it, then add it to it and play the music
            if (!backGroundMusicArray_.Contains(m_BackgroundMusic3))
            {
                backGroundMusicArray_.Add(m_BackgroundMusic3);
                MakeSound(m_BackgroundMusic3);
            }
            else
            {
                //call random number again so you can get a different sound file 
                randNum_ = Random.Range(1, 5);     //gets a number between 1 and 4
            }
        }
        else if (randNum_ == 4)
        {
            //if the list does not have this background sound in it, then add it to it and play the music
            if (!backGroundMusicArray_.Contains(m_BackgroundMusic4))
            {
                backGroundMusicArray_.Add(m_BackgroundMusic4);
                MakeSound(m_BackgroundMusic4);
            }
            else
            {
                //call random number again so you can get a different sound file 
                randNum_ = Random.Range(1, 5);     //gets a number between 1 and 4
            }
        }

        //if the list has reached its max size it means you can play all the songs that have been used
        if (backGroundMusicArray_.Count == maxListSize)
        {       
            randNum_ = Random.Range(1, 5);     //random number between 1 and 4

            //play a music track based on what random number was picked
            if(randNum_ == 1)
            {
                MakeSound(m_BackgroundMusic1);
            }
            else if(randNum_ == 2)
            {
                MakeSound(m_BackgroundMusic2);
            }
            else if(randNum_ == 3)
            {
                MakeSound(m_BackgroundMusic3);
            }
            else if(randNum_ == 4)
            {
                MakeSound(m_BackgroundMusic4);
            }
        }
    }

    private void MakeSound(AudioClip originalClip)
    {
        //audio clips fire and forget themselves, so in order to keep track on whether or not it is playing this function will assign the audio to the clip giving to it
        GetComponent<AudioSource>().clip = originalClip;
        GetComponent<AudioSource>().Play();
    }
}
