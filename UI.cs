using Godot;
using System;

public class UI : Node
{
    Label scoreLabel;
    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("scoreLabel");
    }

    public override void _Process(float delta)
    {
        scoreLabel.Text = Main.score.ToString();
    }
}
