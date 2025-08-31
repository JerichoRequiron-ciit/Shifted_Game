using Unity.VisualScripting;
using UnityEngine;

public class playerAbilities : MonoBehaviour
{

    public Vector3 normalHeight;
    Transform currentHeight;
    Vector3 shiftS;
    Vector3 shiftL;

    void Awake()
    {
        GetNormalScale();
        ShiftCompute();
    }

    void Update()
    {

        Shifting();

        //WASD movements (First Person)(different script?)

        Debugging();
        
    }

    Vector3 GetNormalScale()
    {
        normalHeight = this.transform.localScale;
        return normalHeight;
    }

    Transform CurrentScale()
    {
        currentHeight = this.transform;
        return currentHeight;
    }

    //player's shifting abilities
    void Shifting()
    {

        //loop while shifted, disable shift abilities keybinds and have 5 seconds to be in a different size before returning back to normal
        //need the shifting (process/animation) to happen fast, but not instantaneously (time.deltatime stuff)


        if (Input.GetKeyDown(KeyCode.Q) && this.transform.localScale == normalHeight)
        {
            //shift smaller
            CurrentScale().localScale = shiftS;
            Debug.Log(this.gameObject.name + " is small");
        }
        else if (Input.GetKeyDown(KeyCode.E) && this.transform.localScale == normalHeight)
        {
            //shift larger
            CurrentScale().localScale = shiftL;
            Debug.Log(this.gameObject.name + " is large");
        }
        //if Q or E is already pressed once
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) && this.transform.localScale != normalHeight)
        {
            Debug.Log(this.gameObject.name + " has already shifted");
        }

    }

    void ShiftCompute()
    {
        //size of player when ability keybinds are pressed
        shiftS = normalHeight / 4;
        shiftL = normalHeight * 1.5f;

    }

    //debugger press n to return to normal size
    //to be removed
    void Debugging()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            this.transform.localScale = normalHeight;
        }
    }
    
}
