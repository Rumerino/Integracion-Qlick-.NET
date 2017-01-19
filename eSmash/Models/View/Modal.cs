using System.Web;

namespace eSmash.Models.View
{
    public class Modal
    {
        private string id;
        private IHtmlString title;
        private IHtmlString body;

        public string Id { get { return id; } }
        public string HtmlClass { get; set; }
        public IHtmlString Title { get { return title; } }
        public IHtmlString Body { get { return body; } }

        public Modal(string id, string title) :this(id, title, string.Empty)
        {
            // empty
        }

        public Modal(string id, string title, string body)
        {
            this.id = id;
            this.title = new HtmlString(title);
            this.body = new HtmlString(body);
            HtmlClass = "";
        }

        public Modal(string id, string title, HtmlString body)
        {
            this.id = id;
            this.title = new HtmlString(title);
            this.body = body;
            HtmlClass = "";
        }
    }
}