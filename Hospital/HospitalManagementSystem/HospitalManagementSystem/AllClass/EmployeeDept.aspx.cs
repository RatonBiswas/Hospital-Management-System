using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem.AllClass
{
    public partial class EmployeeDept : System.Web.UI.Page
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
            string query = @"SELECT [Dept_id]
      ,[Dept_Name]
      ,[Emp_Name]
      ,[Salary]
  FROM [dbo].[DepartmentSalary]";
            GridView1.DataSource = ds.GetData(query);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO [dbo].[DepartmentSalary]
           ([Dept_id]
           ,[Dept_Name]
           ,[Emp_Name]
           ,[Salary])
     VALUES
           ('" + Txtdeptid.Text + "','" + Txtdname.Text + "','" + Txtename.Text + "','" + Txtsalary.Text + "')";

            if (ds.Executequery(query) == 1)
            {
                loaddrid();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            loaddrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loaddrid();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label search = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
            string query = @"DELETE FROM[dbo].[DepartmentSalary]
        WHERE Dept_id=" + search.Text;
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
            Label search = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
            /* TextBox textsum = Txtsalary + (Txtsalary * 15 / 100);
             string query = @"UPDATE [dbo].[DepartmentSalary]  SET [Salary] ='" + Txtsalary.Text + "' + ('" + Txtsalary.Text + "'*15/100)";*/
            string query = @"UPDATE [dbo].[DepartmentSalary] SET [Salary]= Salary + (Salary *15/100) from DepartmentSalary where Dept_id=" + search.Text;
            if (ds.Executequery(query) == 1)
            {
                GridView1.EditIndex = -1;
                loaddrid();
            }

        }
    }
}