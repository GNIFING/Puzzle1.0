using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrashSystem
{
    public class TrashManager : MonoBehaviour
    {
        public Trash trash;
        private TrashManager trashManagerInstance;
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
}