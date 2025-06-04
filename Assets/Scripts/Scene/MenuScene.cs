using UnityEngine;
using GameJolt.API;
using UnityEngine.UI;
using GameJolt.UI;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    [SerializeField] private Button trophiesButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button rankingButton;

    private void Awake()
    {
        trophiesButton.onClick.AddListener(() =>
        {
            GameJoltUI.Instance.ShowTrophies();
        });
        rankingButton.onClick.AddListener(() =>
        {
            GameJoltUI.Instance.ShowLeaderboards();
        });

    }

    private void Start()
    {
        Trophies.Unlock(268997);

        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButton);
        }     
    }

    public void OnPlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlayScene");
    }
}
