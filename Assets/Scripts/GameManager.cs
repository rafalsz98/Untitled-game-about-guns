using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        inputMaster = new InputMaster();
    }
    #endregion

    public AudioSource audioSourcePlayer;
    public GameObject player;
    public GameObject map;
    public Camera mainCamera;
    public InputMaster inputMaster;

    private void OnEnable()
    {
        inputMaster.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }
}
