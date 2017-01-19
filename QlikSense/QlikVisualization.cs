
namespace QlikSense
{
    public class QlikVisualization : QlikObject
    {
        public QlikSheet Sheet { get { return (QlikSheet) Parent; } }

        public QlikVisualization(string id, string name) : base(id, name)
        {
            // empty
        }
    }
}
