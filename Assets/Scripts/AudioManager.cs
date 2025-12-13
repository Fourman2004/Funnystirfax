using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioClip[] SFX;
    Gamemanager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
        backgroundMusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.m_currentState == Gamemanager.GameState.GameOver)
        {
            backgroundMusicSource.Stop();
        }
    }

    public void PlaySFX(int index)
    {
        AudioSource.PlayClipAtPoint(SFX[index], Vector3.zero/*transform here*/);
    }
}
