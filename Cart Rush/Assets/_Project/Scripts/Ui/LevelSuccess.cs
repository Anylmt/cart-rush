using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSuccess : MonoBehaviour
{
    private Button _nextButton;
    private void OnEnable()
    {
        _nextButton = GetComponentInChildren<Button>();
        _nextButton.onClick.AddListener(Next);
    }
    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(Next);
    }

    private void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
