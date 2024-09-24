using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnotherFileBrowser.Windows;
using System;
using UnityEngine.Networking;
using static Unity.VisualScripting.Member;

public class FileManager : MonoBehaviour
{
    public AudioClip ActualSong;
    public AudioType FileExtension;


    public void OpenFileBrowser()
    {
        //var browserProp = new BrowserProperties();
        //browserProp.filter = "Audio files (*.mp3, *.wav, *.wma) | *.mp3, *.wav, *.wma";
        //browserProp.filterIndex = 0;

        //new FileBrowser().OpenFileBrowser(browserProp, path =>
        //{
        //    StartCoroutine(LoadAudioFile(path));
        //    print(path);
        //});

        var bp = new BrowserProperties();
        bp.filter = "music files (*.mp3)|*.mp3|All Files (*.*)|*.*";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            //Do something with path(string)
            Debug.Log(path);
        });
    }

    //IEnumerable LoadAudioFile(string path, AudioType clip)
    //{
    //    using (UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip(path, clip))
    //    {
    //        yield return webRequest.SendWebRequest();
    //        if (webRequest.isNetworkError || webRequest.isHttpError)
    //        {
    //            Debug.Log(webRequest.error);
    //        }
    //        else
    //        {
    //            var webRequestAudio = DownloadHandlerAudioClip.GetContent(webRequest); /*as AudioClip;*/
    //            ActualSong = webRequestAudio;
    //        }
    //    }
    //}
}