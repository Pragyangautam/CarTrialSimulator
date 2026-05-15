using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    [Header("UI")]
    public Text progressText;

    private int checkpointsPassed = 0;
    private float progress = 0f;

    void Awake()
    {
        Instance = this;
    }

    public void AddProgress()
    {
        checkpointsPassed++;

        progress = checkpointsPassed * 20f;

        if (progress > 100f)
            progress = 100f;

        progressText.text = "Progress : " + progress + "%";

        Debug.Log("Progress = " + progress + "%");
    }
}