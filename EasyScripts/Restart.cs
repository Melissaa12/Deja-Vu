using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    public AudioSource MusicSource9;

    // Start is called before the first frame update
    public void RestartGame()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 1.0f);
        MusicSource9.Play();


        SceneManager.LoadScene("SampleScene");
    }
}
