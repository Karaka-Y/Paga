using UnityEngine;

public class Jsonreader : MonoBehaviour
{
    public TextAsset jsonFile;
    // Start is called before the first frame update
    void Start()
    {
        Jsondata gameData = JsonUtility.FromJson<Jsondata>(jsonFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
