using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToRotateMarbles : MonoBehaviour
{
    

    public GameObject[] objectsToMove;   // Array of GameObjects that need to move
    public Button moveButton;             // UI Button to trigger the movement
    public float speed = 2f;              // Speed at which the object moves
    private int currentObjectIndex = 0;   // Track which object is moving
    private bool isMoving = false;        // Flag to check if any object is moving

    void Start()
    {
        // Ensure the button is linked properly and add listener
        if (moveButton != null)
        {
            moveButton.onClick.AddListener(OnButtonClick);
        }
    }

    void Update()
    {
        // If movement is triggered and an object is moving, handle the movement
        if (isMoving)
        {
            MoveObjectToTarget(objectsToMove[currentObjectIndex], GetNextPosition(currentObjectIndex));
        }
    }

    // Method triggered by the button click to start the movement process
    void OnButtonClick()
    {
        // Start the movement if it's not already in progress
        if (!isMoving)
        {
            isMoving = true;
        }
    }

    // Method to move an object towards its target position
    void MoveObjectToTarget(GameObject movingObject, Vector3 targetPosition)
    {
        // Move the object towards the target position
        movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, targetPosition, speed * Time.deltaTime);

        // If the object reaches the target, stop its movement and move to the next object
        if (movingObject.transform.position == targetPosition)
        {
            // Stop this object from moving
            currentObjectIndex++;

            // If we have moved all objects, stop the overall movement
            if (currentObjectIndex >= objectsToMove.Length)
            {
                isMoving = false;
                currentObjectIndex = 0;  // Reset for the next round if needed
            }
        }
    }

    // Get the next target position for each object
    Vector3 GetNextPosition(int currentIndex)
    {
        // Get the next object’s position in the array (looping around)
        int nextIndex = (currentIndex + 1) % objectsToMove.Length;
        return objectsToMove[nextIndex].transform.position;
    }
}






