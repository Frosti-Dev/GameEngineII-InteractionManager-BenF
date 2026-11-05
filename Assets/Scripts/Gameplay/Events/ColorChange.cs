using Unity.VisualScripting;
using UnityEngine;

public class ColorChange : MonoBehaviour, IInteractable
{

    //Color Changing Ref
    private int currentMatID;
    public string curMatString;

    public Material red;
    public Material green;
    public Material blue;
    public Material purple;
    public Material yellow;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        currentMatID = 1;
    }

    public void Interact()
    {
        ChangeMaterial();
    }

    public void ChangeMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (currentMatID == 1)
        {
            renderer.material = green;
            curMatString = "Green";
            currentMatID = 2;
        }
        else if (currentMatID == 2)
        {
            renderer.material = blue;
            curMatString = "Blue";
            currentMatID = 3;
        }
        else if (currentMatID == 3)
        {
            renderer.material = purple;
            curMatString = "Purple";
            currentMatID = 4;
        }

        else if (currentMatID == 4)
        {
            renderer.material = yellow;
            curMatString = "Yellow";
            currentMatID = 5;
        }
        else
        {
            renderer.material = red;
            curMatString = "Red";
            currentMatID = 1;
        }

       

    }
}
