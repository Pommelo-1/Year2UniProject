using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class SignInScript : MonoBehaviour
{
    public Image img;
    public Text DisplayName;
    
    
    

    void Start()
    {
        //PlayGamesPlatform.DebugLogEnabled = true;

        //PlayGamesPlatform.Activate();
    }

    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Login Success");
                StartCoroutine(localImage());
                DisplayName.text = Social.localUser.userName;
            }

            else
            {
                Debug.Log("Login Failed");
                
            }
        });
    }

    public void LogOut()
    {
        
        //((PlayGamesPlatform)Social.Active).SignOut();
        

    }



    IEnumerator localImage()
    {
        Texture2D tex;
        while (Social.localUser.image == null)
        {
            Debug.Log("Image Not Found");
            yield return null;
        }
        Debug.Log("Image Found");
        tex = Social.localUser.image;
        img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0f, 0f));
    }
    public void OpenAchievements()
    {
        Social.ShowAchievementsUI();
    }


}

