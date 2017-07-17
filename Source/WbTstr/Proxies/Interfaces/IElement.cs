namespace WbTstr.Proxies.Interfaces
{
    public interface IElement
    {
        string Selector { get; }

        string TagName { get; }

        string Text { get; }

        bool Enabled { get; }

        bool Selected { get; }

        bool Displayed { get; }

        string GetAttribute(string name);

        string GetCssValue(string property);

        int Height { get; }

        int Width { get; }

        int UpperLeftCornerX { get; }

        int UpperLeftCornerY { get; }
    }
}
