using UnityEngine;

public class PoliceCheckpoint : MonoBehaviour
{
    private bool passed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (passed)
            return;

        if (other.CompareTag("Player"))
        {
            passed = true;

            ProgressManager.Instance.AddProgress();

            Debug.Log("Police checkpoint passed!");

            // Optional: disable checkpoint after passing
            gameObject.SetActive(false);
        }
    }
}