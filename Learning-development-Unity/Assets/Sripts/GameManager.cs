using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] private string _labelText = "������ ��� 4 �������� � ������ ���� �������!";
    [SerializeField] private int _maxItems = 4;
    private int _itemsCollected = 0;
    public int Items
    {
        get
        {
            return _itemsCollected;
        }

        set
        {
            _itemsCollected = value;

            if (_itemsCollected >= _maxItems)
            {
                _labelText = "�� ����� ��� ������ ��������!";
            }

            else
            {
                _labelText = "������� ������ " + (_maxItems - _itemsCollected) + "���������";
            }
        }
    }

    private int _playerHealth = 10;
    private int HealthPlayer
    {
        get
        {
            return _playerHealth;
        }

        set
        {
            _playerHealth = value;
            Debug.LogFormat($"Lives: {_playerHealth}");
        }
    }
}