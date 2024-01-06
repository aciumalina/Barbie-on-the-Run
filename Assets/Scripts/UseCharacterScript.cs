using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseCharacterScript : MonoBehaviour
{
    GameObject zombie;
    GameObject archer;
    GameObject heraklios;
    GameObject parasite;
    GameObject survivor;

    // Start is called before the first frame update
    void Start()
    {
        zombie = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Characters/Zombiegirl W Kurniawan.fbx");
        archer = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Characters/Erika Archer.fbx");
        heraklios = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Characters/Heraklios By A. Dizon.fbx");
        parasite = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Characters/Parasite L Starkie.fbx");
        survivor = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Characters/Ch24_nonPBR.fbx");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void useZombi()
    {
        StaticClass.selectedCaracter = zombie;
        SceneManager.LoadScene("Main Menu");
    }

    public void useArcher()
    {
        StaticClass.selectedCaracter = archer;
        SceneManager.LoadScene("Main Menu");
    }

    public void useHereklios()
    {
        StaticClass.selectedCaracter = heraklios;
        SceneManager.LoadScene("Main Menu");
    }

    public void useParasite()
    {
        StaticClass.selectedCaracter = parasite;
        SceneManager.LoadScene("Main Menu");
    }

    public void useSurvivor() { 
        StaticClass.selectedCaracter = survivor;
        SceneManager.LoadScene("Main Menu");
    }
}

