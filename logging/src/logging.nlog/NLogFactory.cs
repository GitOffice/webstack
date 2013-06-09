namespace logging.nlog
{
    public class NLogFactory : ILogFactory
    {
        public ILog GetLogger(string name)
        {
            return new NLogLogger(NLog.LogManager.GetLogger(name));
        }
    }
}