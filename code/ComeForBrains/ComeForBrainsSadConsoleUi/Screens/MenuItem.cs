using SadConsole.Input;

namespace ComeForBrainsSadConsoleUi.Screens;

public class MenuItem : ScreenSurface
{
    public string Text { get; private set; }

    public MenuItem(string text, int width)
        : base(width, 1)
    {
        Text = text;
        UseMouse = true;
        MouseEnter += MenuItem_OnMouseEnter;
        MouseExit += MenuItem_OnMouseExit;
        Surface.Fill(IdleBackground);
        Surface.Print((Width - Text.Length) / 2, 0, Text, IdleForeground);
    }

    private void MenuItem_OnMouseExit(
        object? sender, MouseScreenObjectState e
    )
    {
        Surface.Fill(IdleForeground, IdleBackground);
        Surface.Print(
            (Width - Text.Length) / 2, 0, Text, IdleForeground, IdleBackground
        );
    }

    private void MenuItem_OnMouseEnter(
        object? sender, MouseScreenObjectState e
    )
    {
        Surface.Fill(FocusForeground, FocusBackground);
        Surface.Print(
            (Width - Text.Length) / 2, 0, Text, FocusForeground, FocusBackground
        );
    }

    public Color FocusBackground { get; set; } = Color.White;
    public Color FocusForeground { get; set; } = Color.Black;
    public Color IdleBackground { get; set; } = Color.Black;
    public Color IdleForeground { get; set; } = Color.White;
}
