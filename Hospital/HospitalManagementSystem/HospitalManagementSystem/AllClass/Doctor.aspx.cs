using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem.AllClass
{
    public partial class Doctor : System.Web.UI.Page
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
            string query = @"SELECT [Doctor_id]
      ,[Doctor_name]
      ,[Doctor_specification]
  FROM [dbo].[Doctor]";
            GridView1.DataSource = ds.GetData(query);
            GridView1.DataBind();
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO [dbo].[Doctor]
           ([Doctor_id]
           ,[Doctor_name]
           ,[Doctor_specification])
     VALUES
           ('"+Txtdoctorid.Text+"','"+Txtdoctorname.Text+"','"+TxtDoctorspecification.Text+"')";

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label ID = (Label)GridView1.Rows[e.RowIndex].FindControl("Label4");
            string query = @"DELETE FROM [dbo].[Doctor]
      WHERE Doctor_id=" + ID.Text;
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
            Label id = (Label)GridView1.Rows[e.RowIndex].FindControl("Label4");
            //TextBox txtdid = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
            TextBox txtdname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox txtdspecification = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3");
            string query = @"UPDATE [dbo].[Doctor] 
                     SET [Doctor_name] ='"+txtdname.Text+"' ,[Doctor_specification] = '"+txtdspecification.Text+ "' WHERE Doctor_id=" + id.Text;
            if(ds.Executequery(query)==1)
            {
                GridView1.EditIndex = -1;
                loaddrid();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            loaddrid();
        }
    }
}