
namespace ezDoomCrossPlatform
{
    class WADDetail
    {
        public string Path { get; set; }
        public string Name
        {
            get
            {
                var tempString = Path.Replace("-", " ");
                var count = tempString.Length - 4;
                var name = tempString.Remove(count, 4);
                return name;
            }
        }
    }
}
