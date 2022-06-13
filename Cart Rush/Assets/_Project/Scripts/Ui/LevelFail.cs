using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFail : MonoBehaviour
{
    private Button _retry;
    private void OnEnable()
    {
        _retry = GetComponentInChildren<Button>();
        _retry.onClick.AddListener(Next);
    }
    private void OnDisable()
    {
        _retry.onClick.RemoveListener(Next);
    }

    private void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
