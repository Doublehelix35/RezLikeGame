using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    public List<GameObject> SnakePieces;

    public int HealthPerPiece = 3;
    int Health;
    public float InvunerableDuration = 0.5f; // How long invunerability lasts for
    float InvunerableStartTime; // Stores the time of the invunerability start
    bool IsInvunerable = false;


    void Start()
    {
        // Calc health
        Health = HealthPerPiece * SnakePieces.Count;

        // Init invunerable start time
        InvunerableStartTime = Time.time;
    }

    void Update()
    {
        if (InvunerableStartTime + InvunerableDuration < Time.time)
        {
            // Turn off invunerability
            IsInvunerable = false;
        }
    }

    public void LoseHealth(int value)
    {
        // Dont take damage if invunerable
        if (!IsInvunerable)
        {
            Health -= value;

            if (Health <= 0)
            {
                Debug.Log("Snake Dead");

                // Snake dead
                DestroyPiece(gameObject);
            }
            else
            {
                // Destroy excess pieces
                for (int i = SnakePieces.Count; i > 0; i--)
                {
                    // If health less than i * health per piece then remove a piece
                    if (Health < (i * HealthPerPiece) - 3)
                    {
                        if (SnakePieces.Count == 2)
                        {
                            Debug.Log("Snake 2 pieces left");

                            // Flash piece red

                            // Destroy last piece
                            DestroyPiece(SnakePieces[SnakePieces.Count - 1]);
                        }
                        else
                        {
                            Debug.Log("Snake lost a piece");

                            // Flash piece red

                            // Set last piece's object to follow to piece before removed piece
                            SnakePieces[SnakePieces.Count - 1].GetComponent<SnakeAi>().ObjectToFollow = SnakePieces[SnakePieces.Count - 3].transform;

                            // Move last piece to where removed piece was
                            Vector3 newPos = SnakePieces[SnakePieces.Count - 2].transform.position;
                            SnakePieces[SnakePieces.Count - 1].transform.position = newPos;

                            // Fix spring (connect piece 3rd from end to end piece)
                            Destroy(SnakePieces[SnakePieces.Count - 3].GetComponent<SpringJoint>()); // Remove spring
                            SnakePieces[SnakePieces.Count - 3].AddComponent<SpringJoint>(); // Add new spring

                            SnakePieces[SnakePieces.Count - 3].GetComponent<SpringJoint>().connectedBody = SnakePieces[SnakePieces.Count - 1].GetComponent<Rigidbody>();

                            // Destroy 2nd to last piece
                            DestroyPiece(SnakePieces[SnakePieces.Count - 2]);
                        }
                    }
                }
            }

            // Make invunerable
            IsInvunerable = true;
            InvunerableStartTime = Time.time;
        }
        else
        {
            Debug.Log("Snake is invunerable!");
        }
    }

    void DestroyPiece(GameObject pieceToDestroy)
    {
        Debug.Log("Destroy this piece: " + pieceToDestroy.name);

        // Spawn particle effects

        // Remove from pieces list
        SnakePieces.Remove(pieceToDestroy);

        // Destroy piece
        Destroy(pieceToDestroy);
    }
}
