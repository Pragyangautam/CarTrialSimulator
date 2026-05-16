using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject rulesPanel;

    // PLAY BUTTON
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    // SHOW RULES
    public void ShowRules()
    {
        rulesPanel.SetActive(true);
    }

    // CLOSE RULES
    public void CloseRules()
    {
        rulesPanel.SetActive(false);
    }
}