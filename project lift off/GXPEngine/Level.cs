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
    bool _gameOver = false;
    const int coolDown = 10000;
    int timeFollower = 0;
    int lastScore;
    public string _filename;
    public int _cols;
    public int _rows;
    public string map = "levlemap.tmx";
    public Level(string filename)
    {
        Console.WriteLine( " Loading level {0}", filename );
        loader = new TiledLoader(filename);
        createlevel();
        pickup = new PickupCoin();
        AddChild(pickup);
        claw = new Claw();
        timer = new Timer(TimerCallback, null, 0, 1000);
        _score = 240;
       
    }
    public int GetScore()
    {
        return _score;
    }
    private void TimerCallback(Object o)
    {
        _score = _score - 1;

        if (_score <= 0)
        {
            _score = 0;
            _gameOver = true;
        }
        if (bear2.health < 1 &&  bear.health<1)
        {
            _score = lastScore;
            _gameOver = true;
        }
        else
        {
            lastScore = _score;
        }

    }

    void Update()
    {
        SpawnCoin();
     //   SpawnBear2();
      //  EndLevel();
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
                bear2 = new Bear2();
                bear = new Bear();
            }

       // }

    }
    void SpawnCoin()
    {
        if (Time.time > timeFollower + coolDown)
        {
            Console.WriteLine("spawn");

            timeFollower = Time.time;
            if (pickup.HasPickedUp)
            {
                AddChild(pickup);
                pickup.HasPickedUp = false;
                pickup.x = Utils.Random(64, (game.width - (128 + pickup.width)));
                pickup.y = Utils.Random(400, (game.height - (128 + pickup.height)));
                GameObject[] colied = GetCollisions();
                for (int i = 0; i < colied.Length; i++)
                {
                    if (colied[i] is Solid || colied[i] is Bear2)
                    {
                        pickup.x = Utils.Random(64, (game.width - (128 + pickup.width)));
                        pickup.y = Utils.Random(400, (game.height - (128 + pickup.height)));
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
        else if (!bear2.Player2Switch) { this.RemoveChild(bear2); }
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