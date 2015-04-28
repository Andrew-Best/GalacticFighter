using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour 
{
    public Texture mSplashImage;

    public float mSplashTime;
    private float timer_;
	// Use this for initialization
	void Start () 
    {
        timer_ = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer_ += Time.deltaTime;
        if (timer_ > mSplashTime)
        {
            Application.LoadLevel("MainMenu");
        }
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), 
            mSplashImage, ScaleMode.ScaleToFit);
    }
}
