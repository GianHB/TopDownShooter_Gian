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

        float totalSeconds = GameManager.TiempoFinal;
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.FloorToInt(totalSeconds % 60f);

        if (finalTimeText != null)
            finalTimeText.text = $"Tiempo Trascurrido: {minutes:00}:{seconds:00}";

        int kills = GameManager.EnemigosMatadosFinal;
        if (finalKillsText != null)
            finalKillsText.text = $"Enemigos eliminados: {kills}";

        int wave = GameManager.OleadasFinal;
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
