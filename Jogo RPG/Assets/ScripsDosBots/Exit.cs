using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Button BotaoFecharJogo;

    void Start()
    {
        
    }

    void FecharJogo()
    {
        // Fechar o jogo
        Application.Quit();
    }
}