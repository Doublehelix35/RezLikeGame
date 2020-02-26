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
            // Snake dead
            DestroyPiece(gameObject);
        }
        else if(Health < (SnakePieces.Length - 1 * HealthPerPiece))
        {
            if(SnakePieces.Length == 2)
            {
                // Flash piece red

                // Destroy last piece
                DestroyPiece(SnakePieces[SnakePieces.Length - 1]);
            }
            else if(SnakePieces.Length == 1)
            {
                // Flash piece red
            }
            else
            {
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
        // Spawn particle effects

        // Destroy piece
        Destroy(pieceToDestroy);
    }
}
