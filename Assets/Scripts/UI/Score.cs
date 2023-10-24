using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _firstAidCountTxt;

    private int _score;

    public void AddScore()
    {
        _score++;
        Show();
    }

    private void Show()
    {
        _firstAidCountTxt.text = _score.ToString();
    }
}
