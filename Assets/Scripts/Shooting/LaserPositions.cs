using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPositions : MonoBehaviour
{

    LineRenderer line;
    internal GameObject player;
    internal GameObject enemy;

    float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.SetPosition(0, player.transform.position);
        line.SetPosition(1, enemy.transform.TransformPoint(enemy.GetComponent<BoxCollider>().center));
        line.startColor = Color.red;
        line.endColor = Color.red;

        lifetime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, player.transform.position);
        //line.SetPosition(1, enemy.transform.position);

        lifetime -= Time.deltaTime;

        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}
