namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class BorderedPanel : BasePanel
{
    public Color Foreground => fg;
    public Color Background => bg;

    public BorderedPanel(int width, int height) : base(width, height)
    {
        DrawBorder();
    }

    public BorderedPanel(
        int width,
        int height,
        Color foregroung,
        Color background
    ) : base(width, height)
    {
        fg = foregroung;
        bg = background;
        DrawBorder();
    }

    public void SetBackgroundColor(Color color)
    {
        bg = color;
        DrawBorder();
    }
    public void SetForegroundColor(Color color)
    {
        fg = color;
        DrawBorder();
    }
    public void SetColors(Color foreground, Color background)
    {
        fg = foreground;
        bg = background;
        DrawBorder();
    }


    protected void DrawBorder()
    {
        Surface.DrawBox(
            Surface.Area,
            ShapeParameters.CreateStyledBox(
                ICellSurface.ConnectedLineThin,
                new ColoredGlyph(fg, bg)
            )
        );
    }

    private Color fg = SadUiGameSettings.DefaultForeground;
    private Color bg = SadUiGameSettings.DefaultBackground;
}
