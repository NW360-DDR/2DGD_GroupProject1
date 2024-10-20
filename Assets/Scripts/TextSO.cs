using UnityEngine;


[CreateAssetMenu (fileName = "State", menuName = "ScriptableObjects/VNSO", order = 1)]
public class TextSO : ScriptableObject
{
    // Trying to use a scriptable Object to manage states of the VN. Wish me luck.
    public int stateID;
    public bool LeftTalk, RightTalk;
    public string LeftName, RightName;
    // How to make big text boxes in the Editor
    [TextArea (15,20)]public string Text;
    public string[] buttonText = new string[3];
    public bool hasChoices = false;
    public int[] nextStates = new int[4];

}
