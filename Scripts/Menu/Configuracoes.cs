using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Configuracoes : MonoBehaviour
{

     [Header("Configurações de Áudio")]
    [SerializeField] private Slider volumeMestreSlider;
    [SerializeField] private Slider volumeMusicaSlider;
    [SerializeField] private Slider volumeEfeitosSlider;

    [Header("Configurações de Gráficos")]
    [SerializeField] private TMP_Dropdown qualidadeDropdown;
    [SerializeField] private Toggle telaCheiaToggle;
    [SerializeField] private TMP_Dropdown resolucaoDropdown;

    private Resolution[] resolucoes;
    private List<string> opcoesResolucoes = new List<string>();

    private void Start()
    {
        // Carregar as configurações iniciais
        volumeMestreSlider.value = AudioListener.volume;
        volumeMusicaSlider.value = PlayerPrefs.GetFloat("VolumeMusica", 1f);
        volumeEfeitosSlider.value = PlayerPrefs.GetFloat("VolumeEfeitos", 1f);

        // Configurar opções de qualidade gráfica
        qualidadeDropdown.ClearOptions();
        List<string> opcoesQualidade = new List<string>(QualitySettings.names);
        qualidadeDropdown.AddOptions(opcoesQualidade);
        qualidadeDropdown.value = QualitySettings.GetQualityLevel();
        qualidadeDropdown.RefreshShownValue();

        telaCheiaToggle.isOn = Screen.fullScreen;

        // Configurar opções de resoluções
        resolucoes = Screen.resolutions;
        resolucaoDropdown.ClearOptions();

        int resolucaoAtualIndex = 0;

        for (int i = 0; i < resolucoes.Length; i++)
        {
            string opcao = resolucoes[i].width + " x " + resolucoes[i].height;
            opcoesResolucoes.Add(opcao);

            if (resolucoes[i].width == Screen.currentResolution.width && resolucoes[i].height == Screen.currentResolution.height)
            {
                resolucaoAtualIndex = i;
            }
        }

        resolucaoDropdown.AddOptions(opcoesResolucoes);
        resolucaoDropdown.value = resolucaoAtualIndex;
        resolucaoDropdown.RefreshShownValue();

        // Adicionar listeners
        volumeMestreSlider.onValueChanged.AddListener(AlterarVolumeMestre);
        volumeMusicaSlider.onValueChanged.AddListener(AlterarVolumeMusica);
        volumeEfeitosSlider.onValueChanged.AddListener(AlterarVolumeEfeitos);

        qualidadeDropdown.onValueChanged.AddListener(AlterarQualidadeGrafica);
        telaCheiaToggle.onValueChanged.AddListener(AlterarModoTelaCheia);
        resolucaoDropdown.onValueChanged.AddListener(AlterarResolucao);
    }

    private void AlterarVolumeMestre(float volume)
    {
        AudioListener.volume = volume;
    }

    private void AlterarVolumeMusica(float volume)
    {
        PlayerPrefs.SetFloat("VolumeMusica", volume);
    }

    private void AlterarVolumeEfeitos(float volume)
    {
        PlayerPrefs.SetFloat("VolumeEfeitos", volume);
    }

    private void AlterarQualidadeGrafica(int indice)
    {
        QualitySettings.SetQualityLevel(indice);
    }

    private void AlterarModoTelaCheia(bool telaCheia)
    {
        Screen.fullScreen = telaCheia;
    }

    private void AlterarResolucao(int indiceResolucao)
    {
        Resolution resolucao = resolucoes[indiceResolucao];
        Screen.SetResolution(resolucao.width, resolucao.height, Screen.fullScreen);
    }
}