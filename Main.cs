using Godot;
using System;


public class Main : Node2D
{
    public enum spawnable
    {
        Farmer
    }
    public static int score = 0;
    public static int farmer = 0;
    [Export]
    public PackedScene farmerScene;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public void Spawn(spawnable entity)
    {
        Area2D spawnObject;
        switch (entity)
        {
            case spawnable.Farmer:
                spawnObject = (Area2D)farmerScene.Instance();
                Position2D spwanLocation = this.GetNode<Position2D>("spawnLocation");
                spawnObject.Position = spwanLocation.Position;
                AddChild(spawnObject);
                break;
        }
    }

    public override void _Process(float delta)
    {
        if (farmer <= 0)
        {
            GD.Print("FARMER");
            farmer++;
            Spawn(spawnable.Farmer);
        }
    }
}
