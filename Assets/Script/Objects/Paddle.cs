using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    enum PaddleType
    {
        Left = 0,
        Right = 1
    }
    [SerializeField] PaddleType _paddletype;


    [SerializeField] float _speed;

    private KeyCode _upKey, _downKey;
    // Start is called before the first frame update
    void Start()
    {
       _upKey = (_paddletype == PaddleType.Left) ? KeyCode.W : KeyCode.UpArrow;
       _downKey = (_paddletype == PaddleType.Left) ? KeyCode.S : KeyCode.DownArrow;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_upKey)) MoveUp();
        if (Input.GetKey(_downKey)) MoveDown();
    }

    private void MoveUp()
    {
        if (this.transform.position.y <= 4.2) this.transform.Translate(Vector2.up * _speed);
    }

    private void MoveDown()
    {
        if (this.transform.position.y >= -4.2) this.transform.Translate(Vector2.down * _speed);
    }
}
