using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    {
        Idle,
        LoadSongData,
        WaitUntilSongDataLoaded,
        StartGame,
        WaitUntilGameFinished,
        DisplayScore,
        WaitForUser
    }
    public GameStates state;
    public static GameManager instance;
    public string songSelected;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        switch (state)
        {
            case GameStates.Idle:
                break;
            case GameStates.LoadSongData:
                {
                    SceneManager.LoadScene("JH");
                    SongDataLoader.Load(songSelected);
                    state = GameStates.WaitUntilSongDataLoaded;
                }
                break;
            case GameStates.WaitUntilSongDataLoaded:
                {
                    if (SongDataLoader.isLoaded)
                    {
                        state = GameStates.StartGame;
                    }
                }
                break;
            case GameStates.StartGame:
                {
                    NoteManager.instance.StartCreateNote(SongDataLoader.dataLoaded.notes);
                    state = GameStates.WaitUntilGameFinished;
                }
                break;
            case GameStates.WaitUntilGameFinished:
                break;
            case GameStates.DisplayScore:
                break;
            case GameStates.WaitForUser:
                break;
            default:
                break;
        }
    }

}