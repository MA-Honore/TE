using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour {
    public string sceneName;
    FadeInOut fade;

    void Start() {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator Teleport() {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("UI")) {
            DontDestroyOnLoad(gameObject);
        }

        fade.StartFadeIn();
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneName);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            StartCoroutine(Teleport());
        }
    }
}
