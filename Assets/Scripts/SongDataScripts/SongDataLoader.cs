using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public static class SongDataLoader
{
    public static SongData dataLoaded;
    public static VideoClip clipLoaded;
    public static AudioSource audioLoaded;

    public static bool isLoaded
    {
        get
        {
            return dataLoaded != null && clipLoaded || audioLoaded != null;
        }
    }

    public static void Load(string name)
    {
        //dataLoaded = JsonUtility.FromJson<SongData>(Resources.Load<TextAsset>($"SongDatas/PPAP").ToString());
        dataLoaded = JsonUtility.FromJson<SongData>(Resources.Load<TextAsset>($"SongDatas/{name}").ToString());
        //clipLoaded = Resources.Load<VideoClip>($"VideoClip/PPAP");
        clipLoaded = Resources.Load<VideoClip>($"VideoClip/{name}");
        //audioLoaded = Resources.Load<AudioSource>($"AudioSource/{name}");
    }
}
