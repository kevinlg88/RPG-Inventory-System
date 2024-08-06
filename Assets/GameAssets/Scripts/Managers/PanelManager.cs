using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject statusPanel;
    [SerializeField] GameObject characterPanel;

    PlayerActions inputActions;

    void Awake()
    {
        inputActions = new PlayerActions();
        AssignInputs();
    }

    private void AssignInputs()
    {
        inputActions.Controller.Inventory.performed +=_=> OpenCloseInventoryPanel();
        inputActions.Controller.Status.performed +=_=> OpenCloseStatusPanel();
        inputActions.Controller.Character.performed +=_=> OpenCloseCharacterPanel();
    }

    private void OpenCloseInventoryPanel()
    {
        Debug.Log("Inventory");
        bool isActive = inventoryPanel.activeSelf;
        if (isActive) inventoryPanel.SetActive(false);
        else inventoryPanel.SetActive(true);
    }

    private void OpenCloseStatusPanel()
    {
        Debug.Log("Status");
        bool isActive = statusPanel.activeSelf;
        if (isActive) statusPanel.SetActive(false);
        else statusPanel.SetActive(true);
    }

    private void OpenCloseCharacterPanel()
    {
        Debug.Log("Character");
        bool isActive = characterPanel.activeSelf;
        if (isActive) characterPanel.SetActive(false);
        else characterPanel.SetActive(true);
    }

    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }
}
