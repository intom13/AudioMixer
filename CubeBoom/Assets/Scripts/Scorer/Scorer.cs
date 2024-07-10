using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private TMP_Text _scoreText;

    private int _score = 0;
    private float _timeBetweenScoring = 0.5f;

    private WaitForSeconds _scoringTimeOut;
    private Coroutine _scoring;

    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        _scoringTimeOut = new WaitForSeconds(_timeBetweenScoring);
        
    }

    public void OnClick()
    {
        if (_scoring == null)
            Activate();
        else if(_scoring != null)
            Pause();
    }

    private void Activate()
    {
        _scoring = StartCoroutine(Scoring());
        Debug.Log("StartScoring");
    }

    private void Pause()
    {
        StopCoroutine(_scoring);
        _scoring = null;
        Debug.Log("Pause");
    }

    private IEnumerator Scoring()
    {
        while (true)
        {
            _scoreText.text = _score.ToString();

            _score++;

            yield return _scoringTimeOut;
        }
    }
}
