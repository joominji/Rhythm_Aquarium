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
        Invoke("Play", NoteManager.instance.noteFallingTime); // ��Ʈ�� ��Ʈ ���Ϳ� ������ ����� �ð��� �����Ŀ� ����
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
