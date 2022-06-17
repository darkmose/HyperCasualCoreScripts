using Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Events;
using System;

public class SaveManager
{
    private Player _player;

    public SaveManager(Player player)
    {
        _player = player;
        EventAggregator.Subscribe<StorageEvent>(OnStorageEvent);
    }

    private void OnStorageEvent(object sender, StorageEvent data)
    {
        _player.Save();
    }
}
