using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
// using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class DataManagerX : MonoBehaviour
{    
    public static DataManagerX Instance;
    [SerializeField] public static string userName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);        
    }


}
