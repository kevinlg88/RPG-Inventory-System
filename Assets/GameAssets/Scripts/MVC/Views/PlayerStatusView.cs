using TMPro;
using UnityEngine;
using Zenject;

public class PlayerStatusView: MonoBehaviour
{
    private PlayerStatusController _playerStatusController;
    private StatusEvent _statusEvent;
    [Header("Fields")]
    [SerializeField] TextMeshProUGUI maxHealthValueField;
    [SerializeField] TextMeshProUGUI resistanceValueField;
    [SerializeField] TextMeshProUGUI attackValueField;
    [SerializeField] TextMeshProUGUI velocityValueField;

    [Inject]
    public void Construct(PlayerStatusController playerStatusController, StatusEvent statusEvent)
    {
        Debug.Log("InventoryView construct called!");
        _playerStatusController = playerStatusController;
        _statusEvent = statusEvent;
    }

    public void SetMaxHealth(int maxHealth)
    {
        Debug.Log("MAX HEALTH: " + maxHealth);
        maxHealthValueField.text = maxHealth.ToString();
    }

    public void SetResistance(int resistance)
    {
        Debug.Log($"Resistance {resistance}");
        resistanceValueField.text = resistance.ToString();
    }

    public void SetAttack(int attack)
    {
        Debug.Log("ATTACK: " + attack.ToString());
        attackValueField.text = attack.ToString();
    }

    public void SetVelocity(int velocity)
    {
        Debug.Log("Velocity: " + velocity.ToString());
        velocityValueField.text = velocity.ToString();
    }
}
