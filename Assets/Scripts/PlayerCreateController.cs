using UnityEngine;
using UnityEngine.UI;

public class PlayerCreateController : MonoBehaviour
{
    [SerializeField] private Text username;
    [SerializeField] private Text errorMsg;

    private void Start()
    {
        this.errorMsg.enabled = false;
    }

    public void StartGame()
    {
        string name = this.username.text.ToString();
        if (!SaveGameSystem.DoesSaveDataExist(name))
        {
            FindObjectOfType<GameManager>().CreateNewPlayer(name);
        }
        this.errorMsg.enabled = true;
    }

    public void BackToStart()
    {
        FindObjectOfType<GameManager>().Start();
    }
}
