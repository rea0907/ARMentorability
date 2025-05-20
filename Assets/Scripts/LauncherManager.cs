using UnityEngine;
using UnityEngine.SceneManagement;

public class LauncherManager : MonoBehaviour
{
    // Called when the "I am a Mentor" button is clicked
    public void LoadMentorScene()
    {
        SceneManager.LoadScene("MentorScene");
    }

    // Called when the "I am a User" button is clicked
    public void LoadUserScene()
    {
        SceneManager.LoadScene("UserScene");
    }
}