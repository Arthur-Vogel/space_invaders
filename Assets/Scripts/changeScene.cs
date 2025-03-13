using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changeScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadScene(string sceneName)
    {
        print("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
