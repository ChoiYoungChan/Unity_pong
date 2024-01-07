using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonClass<GameManager>
{
    #region private
    [SerializeField] Ball _ball;
    [SerializeField] Text[] _scoreText;
    [SerializeField] Text _countdown;

    int _leftScore = 0, _rightScore = 0;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _ball.Initialize();

        StartCoroutine(CountDown());
        SetScoreText();
    }

    private void SetScoreText()
    {
        _scoreText[0].text = _leftScore.ToString("00");
        _scoreText[1].text = _rightScore.ToString("00");
    }

    private IEnumerator CountDown()
    {
        Time.timeScale = 0;
        for(int count = 5; count > 0; count--)
        {
            _countdown.text = count.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        _countdown.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    public void SetScore(int side)
    {
        if(side == 0) _leftScore++;
        else _rightScore ++;
        SetScoreText();
    }



}
