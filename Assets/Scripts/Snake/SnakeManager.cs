using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    public GameObject[] SnakePieces;

    public int HealthPerPiece = 3;
    int Health;


    void Start()
    {
        // Calc health
        Health = HealthPerPiece * SnakePieces.Length;
    }

    public void LoseHealth(int value)
    {
        Health -= value;

        if (Health <= 0)
        {
            Debug.Log("Snake Dead");

            // Snake dead
            DestroyPiece(gameObject);
        }
        else if(Health < (SnakePieces.Length - 1 * HealthPerPiece))
        {
            if(SnakePieces.Length == 2)
            {
                Debug.Log("Snake 2 pieces left");

                // Flash piece red

                // Destroy last piece
                DestroyPiece(SnakePieces[SnakePieces.Length - 1]);
            }
            else if(SnakePieces.Length == 1)
            {
                Debug.Log("Snake 1 pieces left");
                // Flash piece red
            }
            else
            {
                Debug.Log("Snake lost a piece");

                // Flash piece red

                // Connect piece (spring) before to piece after

                // Set piece after object to follow to piece before

                // Destroy 2nd to last piece
                DestroyPiece(SnakePieces[SnakePieces.Length - 2]);
            }            
        }
    }

    void DestroyPiece(GameObject pieceToDestroy)
    {
        Debug.Log("Destroy this piece: " + pieceToDestroy.name);

        // Spawn particle effects

        // Destroy piece
        Destroy(pieceToDestroy);
    }
}
