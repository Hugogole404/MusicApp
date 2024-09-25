using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnotherFileBrowser.Windows;
using System;
using UnityEngine.Networking;
using static Unity.VisualScripting.Member;

public class FileManager : MonoBehaviour
{
    public List<AudioClip> AllSongs;
    public AudioClip ActualPlayedSong;
    public AudioSource AudioSource;

    private void Start()
    {
        AllSongs = new List<AudioClip>();
    }

    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "Music files (*.mp3)|*.mp3|All Files (*.*)|*.*";
        bp.filterIndex = 0;
        string p;
        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            p = path;
            Debug.Log(path);
            WWW www = new WWW(p);
            AllSongs.Add(www.GetAudioClip());
            ActualPlayedSong = www.GetAudioClip();
            //_audioSource.clip = www.GetAudioClip();
            ////_audioSource.Play();
            //AllSongs.Add(_audioSource.clip);
        });
        
        //var browserProp = new BrowserProperties();
        //browserProp.filter = "Audio files (*.mp3, *.wav, *.wma) | *.mp3, *.wav, *.wma";
        //browserProp.filterIndex = 0;

        //new FileBrowser().OpenFileBrowser(browserProp, path =>
        //{
        //    StartCoroutine(LoadAudioFile(path));
        //    print(path);
        //});
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