using UnityEngine;

public class MenuManager : ManagerBase {
    [SerializeField]
    GameObject mainMenuContainer;
    [SerializeField]
    GameObject combatUIContainer;
    [SerializeField]
    GameObject characterManagementUIContainer;

    protected override void OnGameStateChanged(GameState state)
    {
        switch(state)
        {
            case GameState.MainMenu:
                mainMenuContainer.SetActive(true);
                combatUIContainer.SetActive(false);
                characterManagementUIContainer.SetActive(false);
                break;
            case GameState.PlayGame:
                mainMenuContainer.SetActive(false);
                combatUIContainer.SetActive(true);
                break;
            case GameState.CharacterManagement:
                mainMenuContainer.SetActive(false);
                characterManagementUIContainer.SetActive(true);
                break;
            default: break;
        }
    }

    public void OnClickStart()
    {
        GameManager.Instance().UpdateGameState(GameState.PlayGame);
    }

    public void OnClickCharacterManagement()
    {
        GameManager.Instance().UpdateGameState(GameState.CharacterManagement);
    }

    public void OnBackToMainMenu()
    {
        GameManager.Instance().UpdateGameState(GameState.MainMenu);
    }
}
