using Godot;
using System;

public class Player : Area2D
{

    [Export]
    public int speed = 400;
    [Export]
    public PackedScene poopScene;
    public Vector2 screenSize;
    public AnimatedSprite animation;
    bool poop = false;

    public bool alive = true;

    public override void _Ready()
    {
        screenSize = GetViewportRect().Size;
        animation = GetNode<AnimatedSprite>("AnimatedSprite");
    }


    public override void _Process(float delta)
    {


        if (poop)
        {
            animation.Rotation += delta * 5;
            if (animation.Rotation > 3)
            {
                Poop poopObject = (Poop)poopScene.Instance();
                Position2D spwanLocation = this.GetNode<Position2D>("SpawnLocation");
                GD.Print(spwanLocation.Position);
                poopObject.Position = spwanLocation.GlobalPosition;

                GetTree().Root.AddChild(poopObject);
                poop = false;
                animation.Rotation = 0;
            }
            else
            {
                animation.Rotation += delta;
            }
        }
        var velocity = Vector2.Zero;
        if (Input.IsActionPressed("move_right"))
        {
            velocity.x += 1;
        }
        if (Input.IsActionPressed("move_left"))
        {
            velocity.x -= 1;
        }
        if (Input.IsActionPressed("move_down"))
        {
            velocity.y += 1;
        }
        if (Input.IsActionPressed("move_up"))
        {
            velocity.y -= 1;
        }

        if (Input.IsActionJustPressed("Poop"))
        {
            poop = true;
            GD.Print("Pooping...");
        }


        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * speed;
        }
        Position += velocity * delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.x, 0, screenSize.x),
            y: Mathf.Clamp(Position.y, 0, screenSize.y)
        );


        if (velocity.x == 0)
        {

            animation.FlipV = false;
            animation.FlipH = velocity.x < 0;
        }
        else
        {
            animation.Animation = "Walk";
        }

        if (velocity.x > 0)
        {
            animation.FlipH = true;

        }
        else
        {
            animation.FlipH = false;
        }

    }
}
