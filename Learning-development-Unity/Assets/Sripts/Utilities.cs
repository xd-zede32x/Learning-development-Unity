using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    public static void RestartLevel()
    {
        Cursors();
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public static void Cursors()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}