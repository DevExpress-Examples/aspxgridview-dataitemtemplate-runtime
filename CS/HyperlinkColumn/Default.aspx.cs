using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;

namespace HyperlinkColumn {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }
        
        protected void ASPxGridView1_Load(object sender, EventArgs e) {
            ASPxGridView1.KeyFieldName = "ID";
            ASPxGridView1.DataSource = GetData();
            if(!IsPostBack && !IsCallback) {
                PopulateColumns();
                ASPxGridView1.DataBind();
            }
            else
                CreateTemplate();
        }

        public DataTable GetData() {
            DataTable Table = new DataTable();
            Table.Columns.Add("ID", typeof(int));
            Table.Rows.Add(1);
            Table.Rows.Add(2);
            return Table;
        }

        public void PopulateColumns() {
            GridViewDataTextColumn colID = new GridViewDataTextColumn();
            colID.FieldName = "ID";
            ASPxGridView1.Columns.Add(colID);

            GridViewDataTextColumn colItemTemplate = new GridViewDataTextColumn();
            colItemTemplate.DataItemTemplate = new MyHyperlinkTemplate(); // Create a template
            colItemTemplate.Name = "colItemTemplate";
            colItemTemplate.Caption = "Template Column";
            ASPxGridView1.Columns.Add(colItemTemplate);
        }

        private void CreateTemplate() {
            ((GridViewDataColumn)ASPxGridView1.Columns["colItemTemplate"]).DataItemTemplate = new MyHyperlinkTemplate();
        }
    }

    class MyHyperlinkTemplate : ITemplate {
        public void InstantiateIn(Control container) {
            ASPxHyperLink link = new ASPxHyperLink();
            GridViewDataItemTemplateContainer gridContainer = (GridViewDataItemTemplateContainer)container;
            link.NavigateUrl = string.Format("~/details.aspx?Device={0}", gridContainer.KeyValue);
            link.Text = string.Format("Get details about device {0}", gridContainer.KeyValue);
            container.Controls.Add(link);
        }
    }
}
