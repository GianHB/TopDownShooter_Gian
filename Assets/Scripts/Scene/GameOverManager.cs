using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_Text finalTimeText;
    [SerializeField] private TMP_Text finalKillsText;
    [SerializeField] private TMP_Text finalWaveText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager no encontrado. Asegúrate de que persista entre escenas.");
            return;
        }

        float totalSeconds = GameManager.Instance.GetElapsedTime();
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.FloorToInt(totalSeconds % 60f);

        if (finalTimeText != null)
            finalTimeText.text = $"Tiempo Trascurrido: {minutes:00}:{seconds:00}";

        int kills = GameManager.Instance.GetEnemiesKilled();
        if (finalKillsText != null)
            finalKillsText.text = $"Enemigos eliminados: {kills}";

        int wave = GameManager.Instance.GetCurrentWave();
        if (finalWaveText != null)
            finalWaveText.text = $"Oleada que Alcansaste: {wave}";

        if (retryButton != null)
            retryButton.onClick.AddListener(OnRetryButton);

        if (quitButton != null)
            quitButton.onClick.AddListener(OnQuitButton);
    }

    public void OnRetryButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlayScene");
    }

    public void OnQuitButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
