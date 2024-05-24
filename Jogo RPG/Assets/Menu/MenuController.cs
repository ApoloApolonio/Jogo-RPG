using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    //Pegando e Criando os componentes nescessarios
    public VideoPlayer videoPlayer;
    public GameObject menuOpcoes, rawImage;
    private Animator animatorRawImage;
    void Start()
    {
        //Setando meu video pra não iniciar
        rawImage.SetActive(false);
        //Ao iniciar pegando o component Animator
        animatorRawImage = rawImage.GetComponent<Animator>();
    }

    void Update()
    {
        //Se o video não estiver tocando e se eu não apertar nenhuma tecla
        if(!videoPlayer.isPlaying && Input.anyKeyDown)
        {
            //Dar play no video 
            videoPlayer.Play();
            //Ativar a textura do video
            rawImage.SetActive(true);
            //Animação de Fade in
            animatorRawImage.SetTrigger("FadeIn");
            //Ativar o menu opcões
            menuOpcoes.SetActive(true);
        }
    }
}
