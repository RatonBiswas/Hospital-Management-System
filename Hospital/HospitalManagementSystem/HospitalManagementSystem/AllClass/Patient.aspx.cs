using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem.AllClass
{
    public partial class Patient : System.Web.UI.Page
    {
        DataStore ds = new DataStore();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loaddrid();
            }
        }

        public void loaddrid()
        {
            string query = @"SELECT 
       [User_id]
      ,[User_name]
      ,[User_mobile]
      ,[User_address]
      ,[Doctor_id]
  FROM [dbo].[Patient]";
            GridView1.DataSource = ds.GetData(query);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = @"
INSERT INTO [dbo].[Patient]
           ([User_id]
           ,[User_name]
           ,[User_mobile]
           ,[User_address]
           ,[Doctor_id])
     VALUES
           ('" +Txtuserid.Text + "','" + Txtusername.Text + "','" + Txtmobile.Text + "','" + Txtaddress.Text + "','" + Txtdoctorid.Text + "')";

            if (ds.Executequery(query) == 1)
            {
                loaddrid();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loaddrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            loaddrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label ibId = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
            string query = @"DELETE FROM[dbo].[Patient]
            WHERE User_id ="+ibId.Text;
            if (ds.Executequery(query) == 1)
            {
                loaddrid();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            loaddrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label ibId2 = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
            TextBox txturid = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
            TextBox txtuname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox txtumobile = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3");
            TextBox txtuaddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4");
            TextBox txtudoctorid= (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox5");
            string query = @"UPDATE [dbo].[Patient] SET [User_name] = '"+txtuname.Text+"',[User_mobile] ='"+txtumobile.Text+"' ,[User_address] ='"+txtuaddress.Text+"' ,[Doctor_id] = '"+txtudoctorid.Text+ "'WHERE User_Id="+ibId2.Text;
            if (ds.Executequery(query) == 1)
            {
                GridView1.EditIndex = -1;
                loaddrid();
            }

        }
    }
}