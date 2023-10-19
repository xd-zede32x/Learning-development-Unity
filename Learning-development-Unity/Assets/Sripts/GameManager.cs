using UnityEngine;
using UnityEngine.SceneManagement;
    
public class GameManager : MonoBehaviour
{
    [SerializeField] private string _labelText = "������ ��� 4 �������� � ������ ���� �������!";
    [SerializeField] private int _maxItems = 4;
    [SerializeField] private bool _showWinScreen = false;
    [SerializeField] private bool _showLoseScreen = false;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }

        set
        {
            _itemsCollected = value;
            UpdateGamesHealth();
        }
    }
    
    public int _playerHealth = 10;
    public int HealthPlayer
    {
        get { return _playerHealth; }

        set
        {
            _playerHealth = value;
            UpdateGamesHealth();
        }
    }


    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25),
            "��������: " + _playerHealth);

        GUI.Box(new Rect(20, 50, 150, 25),
            "��������� �������: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50,
            300, 50), _labelText);

        if (_showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "�� ��������"))
            {
                Utilities.RestartLevel();
            }
        }

        if (_showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "�� ���������"))
            {
                Utilities.RestartLevel();
            }
        }
    }

    private void UpdateGamesHealth()
    {
        if (_itemsCollected >= _maxItems)
        {
            _labelText = "�� ����� ��� ������ ��������!";
            _showWinScreen = true;
            Utilities.Cursors();
            Time.timeScale = 0f;

        }   

        if(_playerHealth <= 0)
        {
            _labelText = "������ � ����� �����?";
            _showLoseScreen = true;
            Utilities.Cursors();
            Time.timeScale = 0f;
        }
    }
}