using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;

    private CanvasGroup _canvasGroup;
    private WaitForSeconds _waitForSeconds;
    private float _restartDelay = 0.3f;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_restartDelay);

        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restart.onClick.AddListener(OnRestartButtonClick);
        _exit.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restart.onClick.RemoveListener(OnRestartButtonClick);
        _exit.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnDied()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        Time.timeScale = 1;
        yield return _waitForSeconds;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
