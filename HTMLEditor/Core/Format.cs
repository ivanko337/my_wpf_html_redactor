using mshtml;

namespace HTMLEditor.Core
{
    public static class Format
    {
        public static HTMLDocument doc;

        public static void LayoutChange(string command)
        {
            if (doc != null)
            {
                doc.execCommand(command, false, null);
            }
        }
    }
}
