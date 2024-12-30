using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Panel;
    public Button[] menuButtons;
    private int selectedIndex = 0;
    private bool isPaused = false;

    // Update is called once per frame

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            toggleMenu();
        }
        if(isPaused)
        {
            menuNav();
        }
    }

    void menuNav()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex = (selectedIndex - 1 + menuButtons.Length) % menuButtons.Length;
            updateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex = (selectedIndex + 1 + menuButtons.Length) % menuButtons.Length;
            updateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            menuButtons[selectedIndex].onClick.Invoke();
        }
    }

    private void updateButtonSelection()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            var colors = menuButtons[i].colors;
            if(i == selectedIndex)
            {
                colors.normalColor = Color.green;
            }
            else
            {
                colors.normalColor = Color.white;
            }
            menuButtons[i].colors = colors;
        }
    }
    public void toggleMenu()
    {
        isPaused = !isPaused;
        Panel.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
        if(isPaused)
        {
            updateButtonSelection();
        }
    }
    
    public void resumeGame()
    {
        isPaused = false;
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }
}