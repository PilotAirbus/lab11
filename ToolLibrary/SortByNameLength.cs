namespace ToolLibrary
{
    public class SortByNameLength : IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            if (x == null || y == null) return -1;

            return x.NameLength.CompareTo(y.NameLength);
        }
    }
}