using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnotherFileBrowser.Windows;
using System;
using UnityEngine.Networking;

public class FileManager : MonoBehaviour
{
    public AudioClip ActualSong;
    private void OpenFileBrowser()
    {
        var browserProp = new BrowserProperties();
        browserProp.filter = "Audio files (*.mp3, *.wav, *.wma) | *.mp3, *.wav, *.wma";
        browserProp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(browserProp, path =>
        {
            //StartCoroutine(LoadAudioFile(path));
        });
    }

    IEnumerable LoadAudioFile(string path, AudioType clip)
    {
        using (UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip(path, clip))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                var webRequestAudio = DownloadHandlerAudioClip.GetContent(webRequest) /*as AudioClip*/;
                ActualSong = webRequestAudio;
            }
        }
    }
}