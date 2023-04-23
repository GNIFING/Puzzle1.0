using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashManager : MonoBehaviour
{
    public Trash trash;
    public TrashManager trashManagerInstance;
    private string spawnedLevel;

    private void Awake()
    {
        Scene scene = gameObject.scene;
        spawnedLevel = scene.name;
        if (PlayerPrefs.HasKey(spawnedLevel + "_isVisited") && PlayerPrefs.GetInt(spawnedLevel + "_isVisited") == 1){
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(this);
            if (trashManagerInstance == null){
                trashManagerInstance = this;
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
        // Trash trash = gameObject.GetComponentInChildren<Trash>(true);
        string activeLevel = SceneManager.GetActiveScene().name;
        if(spawnedLevel == activeLevel){
            trash.gameObject.SetActive(true);
        } else {
            trash.gameObject.SetActive(false);
        }
    }
}
