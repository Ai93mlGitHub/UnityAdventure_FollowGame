using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private GameObject _winMessage;
    [SerializeField] private GameObject _loseMessage;

    void Update()
    {
        _timer.text = _gameController.TimeElapsed.ToString("F0") + "/" + _gameController.TimerGoal.ToString("F0");
    }

    public void WinMessage()
    {
        _winMessage.SetActive(true);
    }

    public void LoseMessage()
    {
        _loseMessage.SetActive(true);
    }

    public void CloseAllMessage()
    {
        _winMessage.SetActive(false);
        _loseMessage.SetActive(false);
    }
}
