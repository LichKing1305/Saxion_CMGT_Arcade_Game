
using GXPEngine;
using System;
using System.Threading;
using TiledMapParser;

public class Claw : AnimationSprite
{
    bool dropSwitch = false;
    float movementSpeed = 1.5f;
    float dropSpeed = 10f;
    float goUpSpeed = 3f;
    public int _score;
    Timer timer;
    //private bool _gameOver = false;
    Bear bear1 = new Bear();
    Bear2 bear2 = new Bear2();
    public Claw() : base("triangle.png", 1, 1)
    {
        timer = new Timer(TimerCallback, null, 0, 1000);
        _score = 240;
    }

    public Claw(string filename, int cols, int rows, TiledObject obj = null) : base(filename, cols, rows)
    {

        if (obj != null)
        {
            dropSpeed = obj.GetFloatProperty("dropSpeed", 100f);
            goUpSpeed = obj.GetFloatProperty("goUpSpeed", 3f);
            movementSpeed = obj.GetFloatProperty("movementSpeed", 1.5f);
        }
    }

    public int GetScore()
    {
        return _score;
    }
    void Update()
    {
        XMovement();
        YMovement();
        /*if (bear1.health <= 0 && bear2.health <= 0)
        {
            _gameOver = true;
        }*/

    }
    void XMovement()
    {
        if (Input.GetKey(Key.RIGHT)) { MoveUntilCollision(movementSpeed, 0); }
        else if (Input.GetKey(Key.LEFT)) { MoveUntilCollision(-movementSpeed, 0); }
    }
    void YMovement()
    {
        if (Input.GetKey(Key.DOWN) && !dropSwitch)
        {
            y += dropSpeed;
        }
        if (y > game.height - height)
        {
            dropSwitch = true;
        }
        if (y >= game.y - height && dropSwitch == true)
        {
            y -= goUpSpeed;
        }
        if (y <= game.y + height / 2 && dropSwitch == true)
        {
            dropSwitch = false;
        }
        GameObject[] colied = GetCollisions();
        for (int i = 0; i < colied.Length; i++)
        {
            if (colied[i] is Solid || colied[i] is Bear2)
            {
                dropSwitch = true;
                y -= goUpSpeed;
            }
        }
    }
    private void TimerCallback(Object o)
    {
        if (/*!_gameOver &&*/ bear1.health > 0 && bear2.health > 0)
        {
            _score = _score - 1;
            Console.WriteLine(_score);
        }
    }
}


