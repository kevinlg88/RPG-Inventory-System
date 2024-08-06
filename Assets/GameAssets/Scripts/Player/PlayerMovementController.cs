using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System;
using UnityEngine.EventSystems;

public class PlayerMovementController : MonoBehaviour
{
    PlayerActions inputActions;

    NavMeshAgent agent;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        inputActions = new PlayerActions();

        AssignInputs();
    }

    void AssignInputs()
    {
        inputActions.Controller.Move.performed +=_=> ClickToMove();
    }

    void ClickToMove()
    {
        if(IsMouseOverUI())return;
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
            if(clickEffect != null)
            {
                GameObject effectgo = Instantiate(clickEffect.gameObject, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
                Destroy(effectgo,0.3f);
            }
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
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
