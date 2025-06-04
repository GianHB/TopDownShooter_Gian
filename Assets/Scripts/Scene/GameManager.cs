using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using GameJolt.API;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text killCounterText;
    [SerializeField] private TMP_Text waveText;

    private int enemiesKilled = 0;
    private float elapsedTime = 0f;
    private int currentWave = 1;
    private bool isGameOver = false;

    public static float TiempoFinal = 0;
    public static int OleadasFinal = 0;
    public static int EnemigosMatadosFinal = 0;

    private bool logroManiaco;
    private bool logroSupervivencia;
    private bool logroOleada5;
    private bool logroDesastre;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= GameOver;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        TiempoFinal = 0;
        OleadasFinal = 0;
        EnemigosMatadosFinal = 0;
    }


    private void Update()
    {
        if (isGameOver) return;

            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        if (timerText != null)
        {
            timerText.text = $"Tiempo: {minutes:00}:{seconds:00}";
        }

        if (killCounterText != null)
        {
            killCounterText.text = $"Enemigos Eliminados: {enemiesKilled}";
        }

    }
    public void SetWave(int waveNumber)
    {
        currentWave = waveNumber;
        if (waveText != null)
            waveText.text = $"Oleada: {waveNumber}";
    }

    public void AddKill()
    {
        enemiesKilled++;
    }

    public void GameOver()
    {
        TiempoFinal = elapsedTime;
        OleadasFinal = currentWave;
        EnemigosMatadosFinal = enemiesKilled;

        isGameOver = true;

        if (EnemigosMatadosFinal <= 0)
        {
            Trophies.Unlock(269008);
        }

        if (EnemigosMatadosFinal >= 10)
        {
            GameJolt.API.Trophies.Unlock(268998);
        }

        if (TiempoFinal >= 60)
        {
            GameJolt.API.Trophies.Unlock(269007);
        }
          
        if (OleadasFinal >= 5)
        {
            GameJolt.API.Trophies.Unlock(269010);
        }
           
        Scores.Add(Mathf.CeilToInt(TiempoFinal), $"{Mathf.CeilToInt(TiempoFinal)} segundos", 1008697, "", (success) =>
        {
        });
        Scores.Add(EnemigosMatadosFinal, $"{EnemigosMatadosFinal} enemigos eliminados", 1010357, "", (success) =>
        {
        });
        Scores.Add(OleadasFinal, $"Oleada {OleadasFinal} alcanzada", 1010358, "", (success) =>
        {
        });
        Scores.Add(Mathf.CeilToInt(TiempoFinal),
        $"Tiempo: {Mathf.CeilToInt(TiempoFinal)}s | Enemigos: {EnemigosMatadosFinal} | Oleada: {OleadasFinal}",
        1010362, "", (success) =>
        {
        });
        SceneManager.LoadScene("GameOver");
    }

}
