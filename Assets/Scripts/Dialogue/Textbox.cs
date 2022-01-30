using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Textbox : MonoBehaviour
{
    // Configuration parameters
    [Header("Components")]
    [SerializeField] TextMeshProUGUI contentTMP;
    [SerializeField] TextMeshProUGUI speaker;
    [SerializeField] Image speakerbox;
    [SerializeField] Animator CTCAnimator;
    [SerializeField] Image p1;
    [SerializeField] Image p2;

    // State variables
    string speakerText;
    string contentText;
    int CPS;
    Sprite avatarSprite;
    bool reversed;

    int totalCharacters;
    int i;

    // Updates the avatar image to show
    public void setAvatar(Sprite avatar)
    {
        this.avatarSprite = avatar;
    }
    public void setSpeaker(string speaker)
    {
        this.speakerText = speaker;
    }

    // Updates the content text to show
    public void setText(string newText)
    {
        this.contentText = newText;
    }

    // Updates the characters-per-second
    public void setCPS(int newCPS)
    {
        this.CPS = newCPS;
    }

    public void setReverse(bool reverse)
    {
        this.reversed = reverse;
    }

    // Clears the avatar image and content text
    public void Clear()
    {
        this.speakerText = "";
        this.contentText = "";
        this.CPS = 0;
        StartCoroutine(Say());
    }

    // Stops the typewriting effect for the current dialogue entry, and shows all the text
    public void FastForward()
    {
        i = totalCharacters - 1;
    }

    // Updates the textbox to show the current avatar and content
    public IEnumerator Say()
    {
        // Hide the CTC indicator
        CTCAnimator.SetBool("Hidden", true);

        // Update speaker
        speakerbox.gameObject.SetActive(speakerText != "");
        speaker.text = speakerText;
        speaker.transform.localScale = reversed ? new Vector3(-1,1,1) : new Vector3(1, 1, 1);

        if (speakerText == "")
        {
            p1.color = new Color(1, 1, 1, 0.5f) ;
            p2.color = new Color(1, 1, 1, 0.5f) ;
        }
        else
        {
            if(avatarSprite != null)
            {
                if (reversed)
                {
                    p2.sprite = avatarSprite;
                }
                else
                {
                    p1.sprite = avatarSprite;
                }
            }
            p1.color = reversed ? new Color(1, 1, 1, 0.5f) : Color.white;
            p2.color = reversed ? Color.white: new Color(1, 1, 1, 0.5f) ;
        }
        
        // Update dialogue content text.
        // If typewriting effect is enabled...
        if (CPS > 0)
        {
            // Calculate the duration between characters
            float SPC = 1.0f / CPS;

            // Get the number of characters
            totalCharacters = contentText.Length;

            // At every interval, update the textbox text to achieve a typewriter effect
            for (i = 0; i <= totalCharacters; i++)
            {
                contentTMP.text = contentText.Substring(0, i);
                yield return new WaitForSeconds(SPC);
            }
        }
        // Else, don't typewrite the text.
        else
            contentTMP.text = contentText;

        // Show the CTC indicator
        CTCAnimator.SetBool("Hidden", false);

    }

}
