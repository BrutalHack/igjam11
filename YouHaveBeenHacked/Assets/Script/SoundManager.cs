using UnityEngine;

public class SoundManager : MonoBehaviour
{

	public static SoundManager SOUND_MANAGER;
	public AudioSource[] Music;
	public AudioSource SfxSource;
	public AudioClip LoginSound;
	public AudioClip FacebookNotification;
	public AudioClip EmailNotification;
	public AudioClip WhatsupNotification;
	private float _volume = 0.3f;
	private float _volumeStep = 0.05f;
	private int _dramaLevel;

	// Use this for initialization
	void Awake()
	{
		if (SOUND_MANAGER == null)
		{
			SOUND_MANAGER = this;
		}
		else if (SOUND_MANAGER != this)
		{
			Destroy(SOUND_MANAGER);
		}
		
		DontDestroyOnLoad(SOUND_MANAGER);
		ResetVolume();
		SfxSource.volume = _volume;
	}

	void Update()
	{
		foreach (AudioSource audioSource in Music)
		{
			UpdateAudioSource(audioSource);
		}
	}

	private void UpdateAudioSource(AudioSource audioSource)
	{
		if (audioSource.volume > 0f && audioSource.volume < _volume)
		{
			audioSource.volume = audioSource.volume + _volumeStep;
		}
	}

	public void ResetVolume()
	{
		_dramaLevel = 0;
		foreach (AudioSource audioSource in Music)
		{
			audioSource.volume = 0f;
		}
	}

	public void MoreDrama()
	{
		if (_dramaLevel < Music.Length)
		{
			Music[_dramaLevel].volume = _volume;
		}
		_dramaLevel++;
	}

	public void PlayLoginSound()
	{
		PlaySound(LoginSound);
	}

	public void PlayFacebookNotification()
	{
		PlaySound(FacebookNotification);
	}

	public void PlayEmailNitification()
	{
		PlaySound(EmailNotification);
	}

	public void PlayWhatsupNotification()
	{
		PlaySound(WhatsupNotification);
	}
	
	public void PlaySound(AudioClip clip)
	{
		if (clip == null)
		{
			Debug.LogWarning("SfxClip is missing!");
			return;
		}
		SfxSource.clip = clip;
		SfxSource.Play();
	}
}
