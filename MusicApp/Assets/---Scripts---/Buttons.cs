using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading;

public class Buttons : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private float _durationTime;

    [SerializeField] private Button _thisButton;
    [SerializeField] private Image _thisImageBackground;

    [SerializeField] private GameObject _fadeObj;
    [SerializeField] private CanvasGroup _fadeCanvasGroup;
    [SerializeField] private FadeScript _fadeScript;

    private bool _isQuit;
    private bool CanTimer;
    private bool CanInterract;
    private float _currentTimerFade;

    private void Start()
    {
        CanTimer = false;
        _currentTimerFade = 0;
        _fadeObj.SetActive(false);
        CanInterract = true;
        _isQuit = false;
    }
    private void Update()
    {
        if (CanTimer)
        {
            _currentTimerFade += Time.deltaTime;
            CheckTimer();
        }
    }

    private void CheckTimer()
    {
        if (_currentTimerFade > _durationTime)
        {
            if (_isQuit)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(_sceneName);
            }
        }
    }

    public void OnClickPlaylist()
    {
        if (CanInterract)
        {
            TransformScale();
            Fade();
        }

    }
    public void OnClickPlay()
    {
    }
    public void OnClickOptions()
    {

    }
    public void OnClickExit()
    {
        _isQuit = true;
        Fade();
    }

    private void Fade()
    {
        CanInterract = false;
        _fadeObj.SetActive(true);
        _fadeCanvasGroup.alpha = 0;
        _fadeScript.UI_ToActivate_or_not = _fadeCanvasGroup;
        _fadeScript.FadeIn(_durationTime);
        CanTimer = true;
    }

    private void TransformScale()
    {
        _thisButton.transform.DOComplete();
        _thisButton.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.3f, 2, 0.3f);
    }
}