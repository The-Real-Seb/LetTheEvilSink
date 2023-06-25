using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnimationFonction : MonoBehaviour
{
    public GameObject _Player;
    public GameObject _Camera;
    public GameObject _PlayerUI;
    public GameObject _PlayerPostProcess;
    public GameObject _CinematiquePostProcess;
    public AudioSource _AudioSource;
    public Animator _Animator;
    public Animator _AnimatorPlanePNG;
    public VideoPlayer videoPlayer;
    
    public void SetAnimatorPlayerSpeed(float speed)
    {
        _AnimatorPlanePNG.SetFloat("Speed", speed);
    }

    public void StartDialogue(So_Discution dis)
    {
        _Animator.speed = 0;
        DialogueManager.Instance.StartDialogue(dis);
    }

    public void PlayVideo()
    {
        _Animator.speed = 0;
        _CinematiquePostProcess.SetActive(false);
        CameraText.SetActive(false);
        videoPlayer.Play();
        StartCoroutine(WaitEndVideo((float)videoPlayer.length));
    }

    IEnumerator WaitEndVideo(float time)
    {
        yield return new WaitForSeconds(time);
        EndVideo();
    }

    public void EndVideo()
    {
        _CinematiquePostProcess.SetActive(true);
        CameraText.SetActive(true);
        videoPlayer.gameObject.SetActive(false);
        _Animator.speed = 1;
    }
    
    
    public void EndDialogue()
    {
        DialogueManager.Instance.EndDialogue();
        _Animator.speed = 1;
    }
    
    private bool skip = false;
    public GameObject CameraText;
    
    private void Update()
    {
        if (DialogueManager.Instance.sentences.Count == 0 && DialogueManager.Instance._PanelParler.activeSelf)
        {
            DialogueManager.Instance.EndDialogue();
            _Animator.speed = 1;
        }


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("LampeTorche")) && !skip)
        {
            skip = true;
            //skipText.SetActive(true);
            return;
        }
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("LampeTorche")) && skip && videoPlayer.isPlaying && videoPlayer != null) EndVideo();
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("LampeTorche")) && skip && DialogueManager.Instance.sentences.Count != 0)
        {
            
            if (DialogueManager.Instance.passSentence)
            {
                DialogueManager.Instance.DisplayNextSentence();
                DialogueManager.Instance.passSentence = false;
            }
            else
            {
                DialogueManager.Instance.ClickNext();
            }
            return;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("LampeTorche"))
        {
            //_Animator.SetFloat("Speed", 1);
            return;
        }
    }

    public void StopPlaying()
    {
        _Player.SetActive(true);
        _Camera.SetActive(true);
        _PlayerUI.SetActive(true);
        _PlayerPostProcess.SetActive(true);
        gameObject.SetActive(false);
    }

    public void StartPlaying()
    {
        _Player.SetActive(false);
        _Camera.SetActive(false);
        _PlayerUI.SetActive(false);
        _PlayerPostProcess.SetActive(false);
    }
    
    public void PlaySound(AudioClip clip)
    {
        _AudioSource.PlayOneShot(clip);
    }
}
