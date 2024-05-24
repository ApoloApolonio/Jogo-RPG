using UnityEngine;
using UnityEngine.UI;

public class FecharJogo : MonoBehaviour
{
    void Start()
    {
        // Adiciona um listener para o evento de clique no botão
        GetComponent<Button>().onClick.AddListener(SairDoJogo);
    }

    void SairDoJogo()
    {
        // Fecha o jogo
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
