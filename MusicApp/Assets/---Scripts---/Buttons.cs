using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading;
using Unity.VisualScripting;
using System;

public class Buttons : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private float _durationTime;

    [SerializeField] private Button _thisButton;
    [SerializeField] private Image _thisImageBackground;

    [SerializeField] private GameObject _fadeObj;
    [SerializeField] private CanvasGroup _fadeCanvasGroup;
    [SerializeField] private FadeScript _fadeScript;

    [SerializeField] private FileManager _fileManager;

    [SerializeField] private GameObject _uiToActivate;

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


    public void OnClickLoadSceneButton()
    {
        if (CanInterract)
        {
            TransformScale();
            Fade();
        }
    }
    public void OnClickAddMusic()
    {
        _fileManager.OpenFileBrowser();
    }
    public void OnClickPlay()
    {
        if (CanInterract)
        {
            _fileManager.AudioSource.Play();
        }
    }
    public void OnClickActiveUi()
    {
        _uiToActivate.SetActive(true);
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
                if (_sceneName.Length > 0)
                {
                    SceneManager.LoadScene(_sceneName);
                }
            }
        }
    }
}