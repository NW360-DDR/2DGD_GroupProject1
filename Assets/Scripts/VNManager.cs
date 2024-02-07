using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;
using System.Linq;

public class VNManager : MonoBehaviour
{
    public TextSO[] states;
    public GameObject LeftName, RightName, LeftSide, RightSide, Options, Next;
    public TextMeshProUGUI LeftText, RightText, speech, optionA, optionB, optionC;
    public int[] nextStates = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        // TO-DO: Initialize our buttons, text and all that with state zero.
        states = Resources.LoadAll<TextSO>("VNStates");
        NextState(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Updates every necessary UI element via a scriptableObject array.
    // Probably a cleaner way to do this but VNs are not usually resource intensive so I'm okay with losing RAM to this.
    public void NextState(int state)
    {
        // Just gonna grab our relevant state like so.
        // Still working out the kinks so some of this will not be clean, and probably also incorrect.
        int tempID = 0;
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].stateID == state)
            {
              tempID = i;
                break;
            }
        }
        
        TextSO temp = states[tempID];
  
        LeftSide.SetActive(temp.LeftTalk);
        RightSide.SetActive(temp.RightTalk);
        LeftName.SetActive(temp.LeftTalk);
        RightName.SetActive(temp.RightTalk);
        LeftText.text = temp.LeftName;
        RightText.text = temp.RightName;
        // Update all the NextStates, even if we don't use them for that state.
        for (int i = 0; i < 4; i++)
        {
            nextStates[i] = temp.nextStates[i];
        }
        optionA.text = temp.buttonText[0];
        optionB.text = temp.buttonText[1];
        optionC.text = temp.buttonText[2];
        for (int i= 0; i < 3; i++)
        {
            Options.transform.GetChild(i).gameObject.SetActive(temp.hasChoices);
        }
        Options.SetActive(temp.hasChoices);
        Next.SetActive(!temp.hasChoices);
        speech.text = temp.Text;
    }

    public void Buttons(int yee)
    {
        // Next should always call 0, then A = 1, B = 2, and C = 3.
        NextState(nextStates[yee]);
    }

}
