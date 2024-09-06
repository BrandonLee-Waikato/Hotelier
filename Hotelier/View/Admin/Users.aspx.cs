using Hotelier.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotelier.View.Admin
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowUsers();
        }
        Models.Functions Con;
        private void ShowUsers()
        {
            string Query = "select * from UserTb1";
            UserGV.DataSource = Con.GetData(Query);
            UserGV.DataBind();
            UserGV.HeaderRow.Cells[1].Text = "Room ID";
            UserGV.HeaderRow.Cells[2].Text = "User Name";
            UserGV.HeaderRow.Cells[3].Text = "Phone";
            UserGV.HeaderRow.Cells[4].Text = "Gender";
            UserGV.HeaderRow.Cells[5].Text = "Address";
            UserGV.HeaderRow.Cells[6].Text = "Password";
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string UName = UNameTb.Value;
                string UPhone = PhoneTb.Value;
                string UGen = GenCb.SelectedValue;
                string UAdd = AddressTb.Value;
                string UPass = PasswordTb.Value;

                string Query = "insert into UserTb1 values('{0}','{1}','{2}','{3}','{4}')";

                Query = string.Format(Query, UName, UPhone, UGen, UAdd, UPass);
                Con.SetData(Query);
                ShowUsers();
                ErrMsg.InnerText = "User added!";
                UNameTb.Value = "";
                GenCb.SelectedIndex = -1;
                AddressTb.Value = "";
                PasswordTb.Value = "";
                PhoneTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.ToString();
            }
        }
        int Key = 0;
        protected void UserGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = Convert.ToInt32(UserGV.SelectedRow.Cells[1].Text);
            UNameTb.Value = UserGV.SelectedRow.Cells[2].Text;
            PhoneTb.Value = UserGV.SelectedRow.Cells[3].Text;
            GenCb.SelectedValue = UserGV.SelectedRow.Cells[4].Text;
            AddressTb.Value = UserGV.SelectedRow.Cells[5].Text;
            PasswordTb.Value = UserGV.SelectedRow.Cells[6].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string UName = UNameTb.Value;
                string UPhone = PhoneTb.Value;
                string UGen = GenCb.SelectedValue;
                string UAdd = AddressTb.Value;
                string UPass = PasswordTb.Value;

                string Query = "update UserTb1 set UName = '{0}', UPhone = '{1}', UGen = '{2}', UAdd = '{3}', UPass = '{4}' where UId = {5}";
                Query = string.Format(Query, UName, UPhone, UGen, UAdd, UPass, UserGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowUsers();
                ErrMsg.InnerText = "User Infromation Updated!";
                UNameTb.Value = "";
                GenCb.SelectedIndex = -1;
                AddressTb.Value = "";
                PasswordTb.Value = "";
                PhoneTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.ToString();
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {

                // 创建SQL命令和参数
                string Query = "delete from UserTb1 where UId = {0}";
                Query = string.Format(Query, UserGV.SelectedRow.Cells[1].Text);

                // 创建Functions对象并调用setData方法
                Functions functions = new Functions();
                functions.SetData(Query);
                ShowUsers();

                ErrMsg.InnerText = "User deleted.";

                //删除后清空表单信息
                UNameTb.Value = "";
                PhoneTb.Value = "";
                GenCb.SelectedIndex = -1;
                AddressTb.Value = "";
                PasswordTb.Value = "";
            }
            catch (Exception ex)
            {
                // 仅向用户显示通用错误消息，避免泄露敏感信息
                ErrMsg.InnerText = "Error delete user. Please try again. Detailed error: " + ex.Message;
                System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
            }
        }
    }
}