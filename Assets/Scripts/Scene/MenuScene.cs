using UnityEngine;
using GameJolt.API;
using UnityEngine.UI;
using GameJolt.UI;

public class MenuScene : MonoBehaviour
{
    [SerializeField] private Button trophiesButton;

    private void Awake()
    {
        trophiesButton.onClick.AddListener(() =>
        {
            GameJoltUI.Instance.ShowTrophies();
        });
        
    }

    private void Start()
    {
        Trophies.Unlock(268997);
    }
}
