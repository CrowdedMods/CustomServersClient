namespace CustomServersClient
{
    public class CustomServerInfo
    {
        public string name;
        public string ip;
        public int port;

        public int hash;

        public CustomServerInfo(string name, string ip, int port)
        {
            this.name = name;
            this.ip = ip;
            this.port = port;

            hash = name.GetHashCode() + ip.GetHashCode() + port.GetHashCode();
        }

        public override string ToString()
        {
            return $"{name} ({ip}:{port})";
        }
    }
}
