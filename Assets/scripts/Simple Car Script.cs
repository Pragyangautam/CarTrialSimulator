using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider ruleBar;

    private int ruleBreaks = 0;
    public int maxRuleBreaks = 2;

    public void BreakRule()
    {
        ruleBreaks++;

        // Update UI bar
        ruleBar.value = ruleBreaks;

        Debug.Log("Rule Broken: " + ruleBreaks);

        // Check lose condition
        if (ruleBreaks >= maxRuleBreaks)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");

        // Stop time
        Time.timeScale = 0f;
    }
}