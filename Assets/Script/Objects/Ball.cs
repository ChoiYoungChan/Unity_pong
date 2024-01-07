using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public void Initialize()
    {
        var angle = Random.Range(0.0f, 360.0f);
        var rad = Random.Range(0.0f, 1.0f);
        if (rad < 0.25f) angle = 180.0f - angle;
        else if (rad < 0.25f) angle = 180.0f - angle;
        else if (rad > 0.25f && rad < 0.5f) angle += 180.0f;
        else if (rad > 0.5f && rad < 0.75f) angle = 360.0f - angle;
        angle *= Mathf.Deg2Rad;

       Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        this.GetComponent<Rigidbody2D>().velocity = direction.normalized * 7.0f;
        this.GetComponent<Rigidbody2D>().transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Net")
        {
            int side = (this.transform.position.x < 0.0f) ? 1 : 0;
            GameManager.Instance.SetScore(side);
            Initialize();
        }
    }
}
