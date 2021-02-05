using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class SignInScript : MonoBehaviour
{



    public void LogIn()

    {
        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Login Success");
            }

            else
            {
                Debug.Log("Login Failed");
            }
        });
    }

    public void LogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }
}
