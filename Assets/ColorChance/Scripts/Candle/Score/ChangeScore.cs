using UnityEngine;
using System;
using TMPro;

public class ChangeScore : MonoBehaviour
{
    public delegate void ScoreHandlerDelegate();
    public ScoreHandlerDelegate _scoreHandler;

    private int _candyCount { get; set; }
    private float _candyTimelineCount;

    [SerializeField] private RandomSpawn _randomSpawn;
    [SerializeField] private ChangeScrollBar _scrollBar;
    [SerializeField] private TMP_Text _candyText;

    public void SubscribeToAddScoreDelegate() {_scoreHandler = () => AddScore(); }
    public void UnsubscribeToAddScoreDelegate() {_scoreHandler -= () => AddScore(); }
    public void SubscribeToSpendScore() { _scoreHandler = () => SpendScore(); }
    public void UnsubscribeToSpendScore() { _scoreHandler -= () => SpendScore(); }

    private void AddScore() 
    {
        _candyCount++;
        if (_candyCount > 25)
            _candyCount = 25;
        _candyText.text = _candyCount + "/25";
    }

    private void SpendScore()
    {
        int _newCandyValue = _candyCount;

        _candyTimelineCount = _candyCount * 0.010f;
        _scrollBar.Fill += _candyTimelineCount;

        _candyCount = 0;

        _candyText.text = _candyCount + "/50";

        if (_newCandyValue >= 10)
        {
            _randomSpawn._remainingCandies = _newCandyValue;

            _randomSpawn._instantiateCandyDelegate?.Invoke();
            _newCandyValue = 0;
        }
    }


}
