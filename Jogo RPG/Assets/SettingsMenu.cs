using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    //Pegando os componentes que preciso e criando outros
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        //checando minha resolução
        resolutions = Screen.resolutions;
        //limpando minhas outras opçoes para coloar as novas
        resolutionDropdown.ClearOptions();
        //criando lista de Strings
        List<string> options = new List<string>();
        //criando meio que uma resolução(nao entendi mt bem essa parte do codigo)
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            //string option esta recebendo minha altura mais a largura da tela
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            //dando um valor completo pra minha resolução e vendo se meu tamanho de tela está certo
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        //adicionado valor e opçoes 
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    //setando resolução de acordo com minha index
    public void SetResolution(int resolutionIndex)
    {
        //definindo a resolução
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    //criando meu volume
    public void SetVolume(float volume)
    {
        //pegando o component AudioMixer para mexer no meu volume
        audioMixer.SetFloat("volume", volume);
    }
    
    //Pegando meu component de qualidade
    public void SetQuality (int qualityIndex)
    {
        //setando qualidade de acordo com as que tem na unity
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    //preciso nem falar nada
    //(comando basico de FullScreen)
    public void SetFullscreen (bool IsFullscreen)
    {
        Screen.fullScreen = IsFullscreen;
    }
}
