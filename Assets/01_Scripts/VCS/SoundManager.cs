using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    private GameSetting setting;
    [SerializeField] private AudioClip ClickSFX;

    private AudioSource audioSource;
    [Tooltip("오디오 마스터 믹서")]
    public AudioMixer masterMixer;

    [SerializeField] private bool isExistSettingWindowinScene;
    [Header("오디오 설정 슬라이더")]

    [SerializeField]
    private Slider audioSlider_Master;
    [SerializeField]
    private Slider audioSlider_BGM;
    [SerializeField]
    private Slider audioSlider_SFX;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GetAudioSet();
    }


    void Update()
    {
        UpdateAudioSet();
    }
    
    /**
     * <summary>
     * 클릭 이벤트 SFX 오디오를 재생
     * </summary>
     */
    public void PlayClick()
    {
        audioSource.clip = ClickSFX;
        audioSource.Play();
    }
    
    
    /**
     * <summary>
     * 오디오 슬라이더 값에 따라 오디오 설정을 업데이트 해주는 메서드(오디오 설정창이 존재 할때만 실행)
     * </summary>
     */
    public void UpdateAudioSet()
    {
        if (isExistSettingWindowinScene)
        {
            if (audioSlider_Master.value == -40f)
            {
                masterMixer.SetFloat("Master_Vol", -80);
            }
            else
            {
                masterMixer.SetFloat("Master_Vol", audioSlider_Master.value);
            }

            if (audioSlider_BGM.value == -40f)
            {
                masterMixer.SetFloat("BGM_Vol", -80);
            }
            else
            {
                masterMixer.SetFloat("BGM_Vol", audioSlider_BGM.value);
            }

            if (audioSlider_SFX.value == -40f)
            {
                masterMixer.SetFloat("SFX_Vol", -80);
            }
            else
            {
                masterMixer.SetFloat("SFX_Vol", audioSlider_SFX.value);
            }

        }
        

    }

    
    /**
     * <summary>
     * 오디오 설정을 불러와 적용시키는 메서드 (오디오 설정창이 존재 할때만 실행)
     * </summary>
     * 
     */
    public void GetAudioSet()
    {
        if (isExistSettingWindowinScene)
        {
            setting = DBManager.GetGameSetting();
            if (setting == null)
                setting = new GameSetting();
            audioSlider_Master.value = setting.soundLevel_Master;
            audioSlider_BGM.value = setting.soundLevel_BGM;
            audioSlider_SFX.value = setting.soundLevel_SFX;
        }
        
    }
    /**
     * <summary>
     * 오디오 설정을 저장하는 메서드 (오디오 설정창이 존재 할때만 실행)
     * </summary>
     */
    public void SaveAudioSet()
    {
        if (isExistSettingWindowinScene)
        {
            setting = new GameSetting(audioSlider_Master.value, audioSlider_BGM.value, audioSlider_SFX.value);
            DBManager.SaveGameSetting(setting);
        }
        
    }
    
}