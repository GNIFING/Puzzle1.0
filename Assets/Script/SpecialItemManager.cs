using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialItemManager : MonoBehaviour
{
    public SpecialItem specialItem;
    private SpecialItemManager specialItemManagerInstance;
    private string spawnedLevel;

    private void Awake()
    {
        Scene scene = gameObject.scene;
        spawnedLevel = scene.name;
        if (PlayerPrefs.HasKey(spawnedLevel + "_isVisited") && PlayerPrefs.GetInt(spawnedLevel + "_isVisited") == 1){
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(this);
            if (specialItemManagerInstance == null){
                specialItemManagerInstance = this;
            } else {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string activeLevel = SceneManager.GetActiveScene().name;
        if(spawnedLevel == activeLevel){
            specialItem.gameObject.SetActive(true);
        } else {
            specialItem.gameObject.SetActive(false);
        }
    }
}
