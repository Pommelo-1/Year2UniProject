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
    public Sprite black_sprite;
    public MasterController masterController;
    
    
    

    void Start()
    {
        //PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();
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
        DisplayName.text = "nickname";
        img.sprite = black_sprite;
        ((PlayGamesPlatform)Social.Active).SignOut();
        
        

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

    public void CheckScore()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(masterController.score, "CgkI-ubXyaUJEAIQAw", success => { });
            if (masterController.score == 5)
            {
                UnlockAchievement01();
            }
        }
    }

    public void UnlockAchievement01()
    {
        if (Social.localUser.authenticated) {
            Social.ReportProgress("CgkI-ubXyaUJEAIQAw", 100f, success => { });
        }
    
    }


}

