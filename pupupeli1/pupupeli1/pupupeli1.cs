using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

/// @author Aino
/// @version 19.10.2026
/// <summary>
/// 
/// </summary>

using Jypeli;

public class pupupeli1 : PhysicsGame
{
    private PhysicsObject pupu;
    private IntMeter pisteLaskuri;
    private Label pisteNaytto;
    private const double Painovoima = -500;
    private const double PupunKoko = 40;
    private const double PorkkananKoko = 20;

    public override void Begin()
    {
        Level.Background.Color = Color.HotPink;
        LuoPorkkanat();

        Gravity = new Vector(0, -500);

        // Luodaan pupu
        pupu = new PhysicsObject(40, 40, Shape.Circle);
        pupu.Position = new Vector(0, 300);
        pupu.Color = Color.Brown;
        Add(pupu);

        // Luodaan kentän reunat
        Level.CreateBorders();

        // Luodaan esteet
        LuoEste(0, 0, 200, 15);
        LuoEste(-100, 100, 180, 15);
        LuoEste(120, 180, 160, 15);
        LuoEste(-150, 250, 150, 15);

        // Pupun ohjaus
        Keyboard.Listen(Key.Left, ButtonState.Down,
            Liikuta, null, -200.0);

        // Luodaan porkkanat
        LuoPorkkana(300, 200);
        LuoPorkkana(300, 100);
        LuoPorkkana(300, 0);

        // Luodaan pistelaskuri
        pisteLaskuri = new IntMeter(0);

        pisteNaytto = new Label();
        pisteNaytto.Text = "Porkkanat: 0";
        pisteNaytto.Position = new Vector(
            Screen.Right - 100,
            Screen.Top - 30);

        Add(pisteNaytto);

        Keyboard.Listen(Key.Right, ButtonState.Down,
            Liikuta, null, 200.0);

        // Lopetetaan peli
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed,
            ConfirmExit, "Lopeta peli");
    }

    private void LuoPorkkana(double x, double y)
    {
        PhysicsObject porkkana = new PhysicsObject(
            20, 20, Shape.Circle);

        porkkana.Position = new Vector(x, y);
        porkkana.Color = Color.Orange;
        porkkana.IgnoresGravity = true;
        porkkana.Tag = "porkkana";

        Add(porkkana);
    }

    private void LuoPorkkanat()
    {
        Vector[] sijainnit =
        {
            new Vector(300, 200),
            new Vector(300, 100),
            new Vector(300, 0),
            new Vector(200, -100)
        };

        for (int i = 0; i < sijainnit.Length; i++)
        {
            PhysicsObject porkkana = new PhysicsObject(
                PorkkananKoko, PorkkananKoko, Shape.Circle);

            porkkana.Position = sijainnit[i];
            porkkana.Color = Color.Orange;
            porkkana.IgnoresGravity = true;
            porkkana.Tag = "porkkana";

            Add(porkkana);
        }
    }

    private void LuoEste(double x, double y,
        double leveys, double korkeus)
    {
        PhysicsObject este = new PhysicsObject(
            leveys, korkeus, Shape.Rectangle);

        este.Position = new Vector(x, y);
        este.Color = Color.Green;
        este.MakeStatic();

        Add(este);
    }

    private void Liikuta(double nopeus)
    {
        pupu.Velocity = new Vector(
            nopeus, pupu.Velocity.Y);
    }
}

   