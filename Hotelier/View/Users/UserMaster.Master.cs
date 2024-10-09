using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotelier.View.Users
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            
                LoadCategories();
            
        }

        private void LoadCategories()
        {
            string Query = "SELECT CatId, CatName FROM CategoryTb1";
            DataTable data = Con.GetData(Query);
            CategoryRepeater.DataSource = data;
            CategoryRepeater.DataBind();
        }
    }
}