using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class AddCharacter : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject heraklios;
    [SerializeField] GameObject parasite;
    [SerializeField] GameObject survivor;
    [SerializeField] GameObject pointLight;
    GameObject character;
    void Awake()
    {
        character = Instantiate(survivor);
        ImportantSettings();
        AdditionalSettings();
        AddPointLight();
    }
    void ImportantSettings()
    {
        character.tag = "Player";
        character.transform.position = new Vector3(0, 0.019f, 0);
        BoxCollider boxCollider = character.AddComponent<BoxCollider>();
        boxCollider.center = new Vector3(0, 0.89f, 0);
        boxCollider.size = new Vector3(1, 1.84f, 1);
        Rigidbody rigidbody = character.AddComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

    }
    void AdditionalSettings()
    {
        Animator animator = character.GetComponent<Animator>();
        string controllerName = "Runner";
        AnimatorController controller = AssetDatabase.LoadAssetAtPath<AnimatorController>("Assets/Animations/" + controllerName+".controller");
        animator.runtimeAnimatorController = controller;
        animator.applyRootMotion = false;
        PlayerMove playerMove = character.AddComponent<PlayerMove>();
        playerMove.groundMask = LayerMask.GetMask("Ground");
    }
    void AddPointLight()
    {
        GameObject pointLightGameObject = GameObject.Instantiate(pointLight);
        pointLightGameObject.transform.parent= character.transform;
    }
}
