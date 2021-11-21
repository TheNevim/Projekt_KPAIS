using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IUManager : MonoBehaviour
{
    [SerializeField] private Toggle WhiteMove;
    [SerializeField] private Toggle BlackMove;

    [SerializeField] private GameObject promotionPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI winnerText;

    #region Singleton

    public static IUManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
            return;
        }
    }

    #endregion

    public void ChangePlayerUI(FigureColor color)
    {
        if (color == FigureColor.White)
        {
            BlackMove.gameObject.SetActive(false);
            WhiteMove.gameObject.SetActive(true);
        }
        else
        {
            BlackMove.gameObject.SetActive(true);
            WhiteMove.gameObject.SetActive(false);
        }
    }

    public bool ShowPlayerMoves(FigureColor color)
    {
        if (color == FigureColor.White)
        {
            return WhiteMove.isOn;
        }
        else
        {
            return BlackMove.isOn;
        }
    }

    public void ActivatePromotionPanel()
    {
        promotionPanel.SetActive(true);
    }

    public void DeactivatePromotionPanel()
    {
        promotionPanel.SetActive(false);
    }

    public void ShowWinnerPanel()
    {
        gameOverPanel.SetActive(true);
        winnerText.text = PlayerManager.Instance.PlayerTurn + " WON";
    }

    public void HideWinnerPanel()
    {
        gameOverPanel.SetActive(false);
        winnerText.text = "";
    }

    public void RestartGame()
    {
        HideWinnerPanel();
        SceneManager.LoadScene(0);
    }

}
