using GXPEngine;
using System;
using System.Collections.Generic;

public class MyGame : Game
{
    string nextLevel;
    string currentLevel;
    string levelToLoad;
    Level level;
    Menu _menu;
    string map = "levlemap.tmx";
    string endscreen = "endscreen.tmx";
    string menu = "menu.tmx";
    Sound _music;
    float _previousVolume;
    SoundChannel _musicChannel;

    public MyGame() : base(1920, 1080, false, false, 1920, 1080, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        _menu = new Menu(menu);
        AddChild(_menu);
        startMusic();
        nextLevel = null;
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

    public void LoadLevel(string filename)
    {
        nextLevel = filename;
    }
    void DestroyAll()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {
            child.Destroy();
        }
    }
    public void CheckLoadLevel()
    {
        if (nextLevel != null)
        {
            DestroyAll();
            AddChild( level = new Level("levlemap.tmx") );
            nextLevel = null;
        }
    }

    public void LoadLevel(string filename, bool shouldResetPlayerData = false, string soundFile = "BackgroundMusic.ogg")
    {
        if (_musicChannel != null)
            _musicChannel.Stop();
        Sound backgroundMusic = new Sound(soundFile);
        _musicChannel = backgroundMusic.Play();
        levelToLoad = filename;
        currentLevel = filename;
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
        CheckLoadLevel();

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

