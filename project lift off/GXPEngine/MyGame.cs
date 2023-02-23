using GXPEngine;
using System;

public class MyGame : Game
{
    Level level;
    private Menu _menu;
    Bear bear; 
    Bear2 bear2;
    //EndScreen endscreen;
    HUD hud;
    PressurePlate plate;
    string map = "levlemap.tmx";
    //string _endscreen = "endscreen.tmx";
    string menu = "menu.tmx";
    Sound _music;
    float _previousVolume;
    SoundChannel _musicChannel;

    public MyGame() : base(1920, 1080, false, false, -1, -1, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        level = new Level(menu);
        AddChild(level);
        hud = new HUD(level);
        AddChild(hud);
        bear2 = new Bear2();
        AddChild(bear2);
        plate = new PressurePlate(bear2, 100, 600, map);
        AddChild(plate);
        startMusic();
        /*  endscreen = new EndScreen(_endscreen);
          AddChild(endscreen);*/
    }

    void KeyReleased()
    {
        Console.WriteLine("keyRelease");

    }
    void BackgroundMusic()
    {
        if (Input.GetKeyDown(Key.N))
        {
            if (_musicChannel.IsPlaying)
            {
                stopMusic();
            }
            else
            {
                startMusic();
            }
        }
        if (Input.GetKeyDown(Key.FIVE))
        {
            if (_musicChannel.Volume > 0)
            {
                _musicChannel.Volume -= 0.25f;
            }
        }
        if (Input.GetKeyDown(Key.FOUR))
        {
            if (_musicChannel.Volume < 1.5f)
            {
                _musicChannel.Volume += 0.25f;
            }
        }
        if (Input.GetKeyDown(Key.NUMPAD_3))
        {
            if (_musicChannel.Volume > 0)
            {
                _previousVolume = _musicChannel.Volume;
                _musicChannel.Volume = 0;
            }
            else
            {
                _musicChannel.Volume = _previousVolume;
            }
        }

    }
    void startMusic()
    {
        _music = new Sound("BGMusic.wav", true, true);
        _musicChannel = _music.Play();
    }

    void stopMusic()
    {
        _musicChannel.Stop();
    }
    void Update()
    {
        /*if (Input.GetKeyDown(Key.R))
        {
            ResetLevel();
        }*/
        BackgroundMusic();
        
    }
    static void Main()     // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();    // Create a "MyGame" and start it
    }

    /*void ResetLevel()
    {
        if (_level != null)
        {
            RemoveChild(_level);
            _level = null;
        }
        _level = new Level(map);
        // AddChild(_level);
    }*/
}

