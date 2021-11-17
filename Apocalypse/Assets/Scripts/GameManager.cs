using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> getLevels;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene("Game");
        int load = PlayerPrefs.GetInt("LevelNoT");
        getLevels[load].gameObject.SetActive(true);
    }

    public void PlayLevel(int index)
    {
        PlayerPrefs.SetInt("LevelNoT", index);
        SceneManager.LoadScene("Game");
        getLevels[index].gameObject.SetActive(true);
    }
}
