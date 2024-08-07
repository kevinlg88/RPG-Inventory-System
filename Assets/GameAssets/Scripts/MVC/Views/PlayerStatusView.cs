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
        _playerStatusController = playerStatusController;
        _statusEvent = statusEvent;
    }

    public void SetMaxHealth(int maxHealth)
    {
        maxHealthValueField.text = maxHealth.ToString();
    }

    public void SetResistance(int resistance)
    {
        resistanceValueField.text = resistance.ToString();
    }

    public void SetAttack(int attack)
    {
        attackValueField.text = attack.ToString();
    }

    public void SetVelocity(int velocity)
    {
        velocityValueField.text = velocity.ToString();
    }
}
