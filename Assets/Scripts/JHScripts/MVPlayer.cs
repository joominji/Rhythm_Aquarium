using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class MVPlayer : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public static MVPlayer instance;

    public void Play(VideoClip clip)
    {
        videoPlayer.clip = clip;
        Invoke("Play", NoteManager.instance.noteFallingTime + 1f); // 노트가 노트 히터에 닿기까지 계산한 시간이 지난후에 실행
    }

    public void Stop()
    {
        videoPlayer.Stop();
        videoPlayer.clip = null;
    }

    private void Awake()
    {
        instance = this;
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Play()
    {
        videoPlayer.Play();
    }
}
