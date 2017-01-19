
namespace QlikSense
{
    public class QlikSheet : QlikObject<QlikVisualization>
    {
        public QlikApp App { get { return (QlikApp) Parent; } }

        public QlikSheet(string id, string name) : base(id, name)
        {
            // empty
        }
    }
}
