using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
       public static GameManager Instance;
       public static string input;
       public static int maxScore;
       public static string namePlayer;
       
       

      private void Awake()
    {
         // start of new code
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    // end of new code

    Instance = this;
    DontDestroyOnLoad(gameObject);

    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayerName(string s)
    {
        input=s;
        Debug.Log(input);
    }

    [System.Serializable]
    class SaveData
{
    public string NamePlayer;
    public int MaxScore;
}

    public static void SaveName()
{
    SaveData data = new SaveData();
    data.NamePlayer = MainManager.maxPlayer ;
    data.MaxScore = MainManager.maxScore;
    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public static void LoadName()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        namePlayer = data.NamePlayer;
        maxScore = data.MaxScore;
    }
}

}
