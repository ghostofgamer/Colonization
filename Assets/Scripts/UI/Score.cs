using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _firstAidCountTxt;

    private int _score;

    public int ScoreAmount => _score;

    public void AddScore()
    {
        _score++;
        Show();
    }

    public void DecreaseScore(int price)
    {
        _score -= price;
        Show();
    }

    private void Show()
    {
        _firstAidCountTxt.text = _score.ToString();
    }
}