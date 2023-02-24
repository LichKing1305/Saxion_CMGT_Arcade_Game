using GXPEngine;
using System;
using System.Threading;
using TiledMapParser;
public class Level : GameObject
{
    TiledLoader loader;
    private Level _level;

    Bear bear;
    Claw claw;
    PickupCoin pickup;
    Bear2 bear2;
    public int _score;
    Timer timer;
    HUD hud;
    bool _gameOver = false;
    const int coolDown = 10000;
    int timeFollower = 0;
    int lastScore;
    public string _filename;
    public int _cols;
    public int _rows;
    //  int bear1Health;
    // int bear2Health;
    public string map = "levlemap.tmx";
    public Level(string filename)
    {

        Console.WriteLine(" Loading level {0}", filename);
        loader = new TiledLoader(filename);
        createlevel();
        pickup = new PickupCoin();
        AddChild(pickup);
        claw = new Claw();
       
        _score = 240;
        bear2 = new Bear2();
        AddChild(bear2);
        bear = new Bear();
        AddChild(bear);
        timer = new Timer(TimerCallback, null, 0, 1000);
        //  bear1Health = bear.health;
        // bear2Health = bear2.health;
        hud = new HUD(this);
        AddChild(hud);
    }
    public int GetScore()
    {
        return _score;
    }
    void TimerCallback(Object o)
    {
        _score = _score - 1;

        if (_score <= 0)
        {
            _score = 0;
            _gameOver = true;
        }
        if (bear.health < 1 &&bear2.health < 1)
        {
            _score = lastScore;
            _gameOver = true;
            Console.WriteLine("game over");

        }
        else
        {
            lastScore = _score;
        }

    }

    void Update()
    {
        SpawnCoin();
        //    SpawnBear2();
        //  EndLevel();
        /* if (_score <= 0)
         {
             _score = 0;
             _gameOver = true;
         }*/
        /*  Console.WriteLine(bear1Health + ":" + bear2Health);
          if  (bear2Health < 1 && bear2Health < 1)
              {
              _score = lastScore;
              _gameOver = true;
           //   Console.WriteLine("game over");

          }
          else
          {
              lastScore = _score;
          }*/
    }

    void createlevel()
    {
        //  if (!_gameOver)
        //{
        loader.addColliders = false;
        loader.LoadImageLayers();
        loader.addColliders = false;
        loader.LoadTileLayers();
        loader.autoInstance = true;
        loader.LoadObjectGroups();
        loader.rootObject = this;
        {

        }

        // }

    }
    void SpawnCoin()
    {
        if (Time.time > timeFollower + coolDown)
        {
            timeFollower = Time.time;
            if (pickup.HasPickedUp)
            {
                AddChild(pickup);
                pickup.HasPickedUp = false;
                pickup.x = Utils.Random(64, game.width - 64);
                pickup.y = Utils.Random(-50, -20);
                GameObject[] colied = GetCollisions();
                for (int i = 0; i < colied.Length; i++)
                {
                    if (colied[i] is Solid || colied[i] is Bear2)
                    {
                        pickup.x = Utils.Random(64, game.width - 64);
                        pickup.y = Utils.Random(-50, -20);

                    }
                }
            }
        }
        else if (pickup.HasPickedUp)
        {
            //Remove();
            // timeFollower = Time.time;
            // pickup.HasPickedUp = false;
            this.RemoveChild(pickup);

            //   pickup= null;

        }
    }
    void SpawnBear2()
    {
        if (Input.GetKeyDown(Key.ENTER)) { bear2.Player2Switch = !bear2.Player2Switch; }
        if (bear2.Player2Switch == true) { AddChild(bear2); }
        // else if (!bear2.Player2Switch) { this.RemoveChild(bear2); }
    }
    void ResetLevel()
    {
        if (_level != null)
        {
            _level = null;
            _level.Destroy();
            _level = new Level(map);
            AddChild(_level);
        }
    }
    void EndLevel()
    {
        if (_gameOver == true)
        {
            this.Remove();
            Console.WriteLine("endlevl");
        }
    }
}