using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    public Text text;
    public List<Sprite> Images = new List<Sprite>(); // Creating list of images that are used in the game

    private enum States { cell_0, cell_1, cell_bed, cell_sheets, cell_window, cell_door, rusty_nail, cell_lock }; // Defining states on which to call certain methods and load corresponding pictures
    private States myState;

	// Use this for initialization
	void Start ()
    {
        // Initiating start of the game with beginning state
        myState = States.cell_0;        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Here we are going through states and calling appropriate methods
        print(myState);
        if          (myState == States.cell_0)      { cell_0(); }
        else if     (myState == States.cell_1)      { cell_1(); }
        else if     (myState == States.cell_bed)    { cellBed(); }
        else if     (myState == States.cell_sheets) { cellSheets(); }
        else if     (myState == States.cell_window) { cellWindow(); }
        else if     (myState == States.cell_door)   { cellDoor(); }
        else if     (myState == States.rusty_nail)  { rustyNail(); }
        else if     (myState == States.cell_lock)   { cellLock(); }
	}


    // In this section are defined methods that are called when corresponding state is set. Also, every method loads a corresponding picture.
    void cell_0()
    {
        text.text = "You look around the cell. There is barred window with murky sky above. A rusty nail sticks from the window frame. A bed which have seen much better days with half torn sheets is in the corner below window. " +
                    "And, of course, the only thing that stands between you and freedom, a metal barred door with a very strange lock... Is looks like it is almost alive... It must be the mold and dust gathered on it.\n\n" + 
                    "Press B to view Bed, press W to view Window";
        if          (Input.GetKeyDown(KeyCode.B))   { myState = States.cell_bed; ChangePicture(4); }
        else if     (Input.GetKeyDown(KeyCode.W))   { myState = States.cell_window; ChangePicture(3); }
    }

    void cellBed()
    {
        text.text = "You look at the bed. It is dirty, it smells, has a torn sheets and you could swear there is a dead rat beneath it. Other than that there is not much to see. Tho, those sheets could be useful...\n\n" +
                    "Press S to take Sheets, press R to return to the Cell";
        if          (Input.GetKeyDown(KeyCode.S))   { myState = States.cell_sheets; ChangePicture(5); }
        else if     (Input.GetKeyDown(KeyCode.R))   { myState = States.cell_0;ChangePicture(0); }
    }

    void cellSheets()
    {
        text.text = "You took the sheets!\n\n" + 
                    "Press R to return to Cell";
        if          (Input.GetKeyDown(KeyCode.R))   { myState = States.cell_0; ChangePicture(0); }
    }

    void cellWindow()
    {
        text.text = "You look at the window, and notice again that some rusty nail is embedded between the wall and the window frame. The nail is too high so you have to climb on the bed to reach it." +
                    "You try to pull it out but it is sharp. You remember that you have a sheet from the bed so you use it to pull the nail out of the wall.\n\n" +
                    "Press N to take the Rusty nail, press R to return to the Cell";
        if          (Input.GetKeyDown(KeyCode.N))   { myState = States.rusty_nail; ChangePicture(6); }
        else if     (Input.GetKeyDown(KeyCode.R))   { myState = States.cell_0;ChangePicture(0); }
    }

    void rustyNail()
    {
        text.text = "You took the Rusty Nail!\n\n" +
                    "Press R to return to the cell";
        if          (Input.GetKeyDown(KeyCode.R))   { myState = States.cell_1; ChangePicture(0); }
    }

    void cell_1()
    {
        text.text = "You look around the cell again. There is not much left to do. You decide to check the door and that weird looking dirty lock...\n\n" +
                    "Press D to go to the Barred Door";
        if          (Input.GetKeyDown(KeyCode.D))   { myState = States.cell_door; ChangePicture(1); }
    }

    void cellDoor()
    {
        text.text = "You get to the door. As everything else it is old, rusty and barred. Typical ancient prison door. But there is something so strange about the door lock. You decide to examine it more closely...\n\n" +
                    "Press L to look at the Lock";
        if          (Input.GetKeyDown(KeyCode.L))   { myState = States.cell_lock; ChangePicture(7); }
    }

    void cellLock()
    {
        text.text = "You look at the lock. It is filled with mold and dust. You use the nail to clean it and only that you notice that LOCK IS ALIVE!!! You poke ti with a rusty nail and the voice comes through...\n\n" +
                    "Press N to go to the Next Level...";
        if          (Input.GetKeyDown(KeyCode.N))   { SceneManager.LoadScene(2); }
    }

    // Method that sets the pictures and is called in "STATE" methods
    void ChangePicture(int num)
    {
        gameObject.GetComponentInParent<Image>().sprite = Images[num];
    }
}
