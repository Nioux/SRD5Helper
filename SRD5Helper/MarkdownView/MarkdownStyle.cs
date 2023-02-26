namespace Xam.Forms.Markdown
{

    public class MarkdownStyle
    {
        public FontAttributes Attributes { get; set; } = FontAttributes.None;

        public float FontSize { get; set; } = 12;

        public Color ForegroundColor { get; set; } = Colors.Black;

        public Color BackgroundColor { get; set; } = Colors.Transparent;

        public Color BorderColor { get; set; }

        public float BorderSize { get; set; }

        public string FontFamily { get; set; }
    }
}
