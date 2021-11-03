namespace Classes
{
    public class MenuConfig
    {
        public string Address { get; }
        public bool ResetOnAwake { get; }

        public MenuConfig(string address, bool resetOnAwake)
        {
            Address = address;
            ResetOnAwake = resetOnAwake;
        }
    }
}